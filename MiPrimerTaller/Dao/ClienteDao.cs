using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.DAOs
{
    public class ClienteDao
    {
        private string connectionString = @"Data Source=C:\Users\Usuario\Desktop\Practica Taller\MotoGaragaMD.db;Version=3;";

        // Obtener todos los clientes
        public List<Cliente> ObtenerTodas()
        {
            List<Cliente> lista = new List<Cliente>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Dni, Nombre, Apellido, Telefono, Email FROM Cliente";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Dni = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Email = reader.IsDBNull(4) ? "" : reader.GetString(4)
                        };

                        lista.Add(cliente);
                    }
                }
            }

            return lista;
        }

        // Insertar un cliente
        public void Insertar(Cliente cliente)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Cliente (Dni, Nombre, Apellido, Telefono, Email)
                               VALUES (@Dni, @Nombre, @Apellido, @Telefono, @Email)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Dni", cliente.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Actualizar un cliente
        public void Actualizar(Cliente cliente)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Cliente 
                               SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono, Email=@Email 
                               WHERE Dni=@Dni";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Dni", cliente.Dni);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Obtener cliente por DNI
        public Cliente ObtenerPorId(int dni)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Dni, Nombre, Apellido, Telefono, Email FROM Cliente WHERE Dni=@Dni";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Dni = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Eliminar un cliente
        public void Eliminar(int dni)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Cliente WHERE Dni=@Dni";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}