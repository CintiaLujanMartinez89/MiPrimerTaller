using MiPrimerTaller.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerTaller.Dao
{
    class PresupuestoDao
    {
        private string connectionString =
        $@"Data Source={Path.Combine(Application.StartupPath, "MotoGaragaMD.db")};Version=3;UTF8Encoding=True;";


        public Presupuesto BuscarPorId(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT p.Id, p.Servicio, p.Observacion, p.Precio, p.Fecha,
                              c.Dni, c.Nombre, c.Apellido,
                              m.Patente, m.Marca, m.Modelo
                       FROM Presupuesto p
                       INNER JOIN Cliente c ON p.DniCliente = c.Dni
                       INNER JOIN Moto m ON p.Patente = m.Patente
                       WHERE p.Id = @Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Dni = reader.GetInt32(5),
                                Nombre = reader.GetString(6),
                                Apellido = reader.GetString(7)
                            };
                            var moto = new Moto
                            {
                                Patente = reader.GetString(8),
                                Marca = reader.GetString(9),
                                Modelo = reader.GetString(10),
                                Cliente = cliente
                            };
                            return new Presupuesto
                            {
                                Id = reader.GetInt32(0),
                                Servicio = reader.GetString(1),
                                Observacion = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                Fecha = DateTime.Parse(reader.GetString(4)),
                                Cliente = cliente,
                                Moto = moto
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Eliminar(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Presupuesto WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Insertar(Presupuesto presupuesto)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Presupuesto 
                       (DniCliente, Patente, Servicio, Observacion, Precio, Fecha)
                       VALUES (@DniCliente, @Patente, @Servicio, @Observacion, @Precio, @Fecha)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DniCliente", presupuesto.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@Patente", presupuesto.Moto.Patente);
                    cmd.Parameters.AddWithValue("@Servicio", presupuesto.Servicio);
                    cmd.Parameters.AddWithValue("@Observacion", presupuesto.Observacion);
                    cmd.Parameters.AddWithValue("@Precio", presupuesto.Precio);
                    cmd.Parameters.AddWithValue("@Fecha", presupuesto.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(Presupuesto presupuesto)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Presupuesto 
                       SET DniCliente=@DniCliente, Patente=@Patente, Servicio=@Servicio, 
                           Observacion=@Observacion, Precio=@Precio, Fecha=@Fecha
                       WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DniCliente", presupuesto.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@Patente", presupuesto.Moto.Patente);
                    cmd.Parameters.AddWithValue("@Servicio", presupuesto.Servicio);
                    cmd.Parameters.AddWithValue("@Observacion", presupuesto.Observacion);
                    cmd.Parameters.AddWithValue("@Precio", presupuesto.Precio);
                    cmd.Parameters.AddWithValue("@Fecha", presupuesto.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Id", presupuesto.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Presupuesto> Listar()
        {
            var lista = new List<Presupuesto>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT p.Id, p.Servicio, p.Observacion, p.Precio, p.Fecha,
                              c.Dni, c.Nombre, c.Apellido,
                              m.Patente, m.Marca, m.Modelo
                       FROM Presupuesto p
                       INNER JOIN Cliente c ON p.DniCliente = c.Dni
                       INNER JOIN Moto m ON p.Patente = m.Patente";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Dni = reader.GetInt32(5),
                            Nombre = reader.GetString(6),
                            Apellido = reader.GetString(7)
                        };
                        var moto = new Moto
                        {
                            Patente = reader.GetString(8),
                            Marca = reader.GetString(9),
                            Modelo = reader.GetString(10),
                            Cliente = cliente
                        };
                        var presupuesto = new Presupuesto
                        {
                            Id = reader.GetInt32(0),
                            Servicio = reader.GetString(1),
                            Observacion = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            Fecha = DateTime.Parse(reader.GetString(4)),
                            Cliente = cliente,
                            Moto = moto
                        };
                        lista.Add(presupuesto);
                    }
                }
            }
            return lista;
        }

    }
}
