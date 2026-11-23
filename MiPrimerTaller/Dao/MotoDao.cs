using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.DAOs
{
    public class MotoDao
    {
        private string connectionString;

        public MotoDao()
        {
          connectionString =$@"Data Source={Path.Combine(Application.StartupPath, "MotoGaragaMD.db")};Version=3;";
    }

        // Insertar moto
        public void Insertar(Moto moto)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Moto (Patente, DniCliente, Marca, Modelo, KmInicial)
                               VALUES (@Patente, @DniCliente, @Marca, @Modelo, @KmInicial)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Patente", moto.Patente);
                    cmd.Parameters.AddWithValue("@DniCliente", moto.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@Marca", moto.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", moto.Modelo);
                    cmd.Parameters.AddWithValue("@KmInicial", moto.KmInicial);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Moto> ListarPorCliente(int dniCliente)
        {
            var lista = new List<Moto>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT m.Patente, m.Marca, m.Modelo, m.KmInicial,
                              c.Dni, c.Nombre, c.Apellido
                       FROM Moto m
                       INNER JOIN Cliente c ON m.DniCliente = c.Dni
                       WHERE m.DniCliente = @DniCliente";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DniCliente", dniCliente);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Dni = reader.GetInt32(4),
                                Nombre = reader.GetString(5),
                                Apellido = reader.GetString(6)
                            };

                            var moto = new Moto
                            {
                                Patente = reader.GetString(0),
                                Marca = reader.GetString(1),
                                Modelo = reader.GetString(2),
                                KmInicial = reader.GetInt32(3),
                                Cliente = cliente
                            };

                            lista.Add(moto);
                        }
                    }
                }
            }
            return lista;
        }


        // Listar todas las motos con su cliente
        public List<Moto> Listar()
        {
            var lista = new List<Moto>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT m.Patente, m.DniCliente, m.Marca, m.Modelo, m.KmInicial,
                                      c.Dni, c.Nombre, c.Apellido, c.Telefono, c.Email
                               FROM Moto m
                               INNER JOIN Cliente c ON m.DniCliente = c.Dni";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Dni = reader.GetInt32(5),
                            Nombre = reader.GetString(6),
                            Apellido = reader.GetString(7),
                            Telefono = reader.IsDBNull(8) ? "" : reader.GetString(8),
                            Email = reader.IsDBNull(9) ? "" : reader.GetString(9)
                        };

                        var moto = new Moto
                        {
                            Patente = reader.GetString(0),
                            Cliente = cliente,
                            Marca = reader.GetString(2),
                            Modelo = reader.GetString(3),
                            KmInicial = reader.GetInt32(4)
                        };

                        lista.Add(moto);
                    }
                }
            }
            return lista;
        }

        // Buscar moto por patente
        public Moto BuscarPorPatente(string patente)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT m.Patente, m.DniCliente, m.Marca, m.Modelo, m.KmInicial,
                                      c.Dni, c.Nombre, c.Apellido, c.Telefono, c.Email
                               FROM Moto m
                               INNER JOIN Cliente c ON m.DniCliente = c.Dni
                               WHERE m.Patente = @Patente";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Patente", patente);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Dni = reader.GetInt32(5),
                                Nombre = reader.GetString(6),
                                Apellido = reader.GetString(7),
                                Telefono = reader.IsDBNull(8) ? "" : reader.GetString(8),
                                Email = reader.IsDBNull(9) ? "" : reader.GetString(9)
                            };

                            return new Moto
                            {
                                Patente = reader.GetString(0),
                                Cliente = cliente,
                                Marca = reader.GetString(2),
                                Modelo = reader.GetString(3),
                                KmInicial = reader.GetInt32(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Actualizar moto
        public void Actualizar(Moto moto)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Moto SET DniCliente=@DniCliente, Marca=@Marca, Modelo=@Modelo, KmInicial=@KmInicial
                               WHERE Patente=@Patente";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Patente", moto.Patente);
                    cmd.Parameters.AddWithValue("@DniCliente", moto.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@Marca", moto.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", moto.Modelo);
                    cmd.Parameters.AddWithValue("@KmInicial", moto.KmInicial);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar moto
        public void Eliminar(string patente)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"DELETE FROM Moto WHERE Patente=@Patente";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Patente", patente);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
