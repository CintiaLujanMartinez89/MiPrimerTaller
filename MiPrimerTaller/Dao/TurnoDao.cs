using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.DAOs
{
    public class TurnoDao
    {
        private string connectionString =
            @"Data Source=C:\Users\Usuario\Desktop\Practica Taller\MotoGaragaMD.db";
        private static readonly object dbLock = new object();

        private void ActivarWAL(SQLiteConnection conn)
        {
            using (var cmd = new SQLiteCommand("PRAGMA journal_mode=WAL;", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Insertar un Turno
        public void InsertarTurno(Turno turno)
        {
            lock (dbLock)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    ActivarWAL(conn);

                    string sql = @"INSERT INTO Turnos 
                                   (FechaHora, ClienteId, MotoId, ServicioId, Estado, Observaciones) 
                                   VALUES (@fechaHora, @clienteId, @motoId, @servicioId, @estado, @observaciones)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fechaHora", turno.FechaHora.ToString("yyyy-MM-dd HH:mm"));
                        cmd.Parameters.AddWithValue("@clienteId", turno.Cliente.Dni);
                        cmd.Parameters.AddWithValue("@motoId", turno.Moto.Patente);
                        cmd.Parameters.AddWithValue("@servicioId", turno.Servicio.IdServicio);
                        cmd.Parameters.AddWithValue("@estado", turno.Estado);
                        cmd.Parameters.AddWithValue("@observaciones", turno.Observaciones ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Eliminar un Turno
        public void EliminarTurno(int idTurno)
        {
            lock (dbLock)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    ActivarWAL(conn);

                    string sql = "DELETE FROM Turnos WHERE Id=@id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idTurno);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Obtener un Turno por Id
        public Turno ObtenerTurnoPorId(int id)
        {
            lock (dbLock)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    ActivarWAL(conn);

                    string sql = @"SELECT 
                          t.Id, t.FechaHora, 
                          c.Dni, c.Nombre, c.Apellido, 
                          m.Patente, m.Marca, m.Modelo, 
                          s.IdServicio, s.Nombre, s.PrecioInicial, 
                          t.Estado, t.Observaciones
                       FROM Turnos t
                       JOIN Cliente c ON t.ClienteId = c.Dni
                       JOIN Moto m ON t.MotoId = m.Patente
                       JOIN Service s ON t.ServicioId = s.IdServicio
                       WHERE t.Id = @id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var cliente = new Cliente
                                {
                                    Dni = reader.GetInt32(2),
                                    Nombre = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    Apellido = reader.IsDBNull(4) ? "" : reader.GetString(4)
                                };

                                var moto = new Moto
                                {
                                    Patente = reader.GetString(5),
                                    Marca = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    Modelo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                    Cliente = cliente
                                };

                                var servicio = new Service
                                {
                                    IdServicio = reader.GetInt32(8),
                                    Nombre = reader.IsDBNull(9) ? "" : reader.GetString(9),
                                    PrecioInicial = reader.IsDBNull(10) ? 0 : reader.GetInt32(10)
                                };

                                return new Turno(
                                    DateTime.Parse(reader.GetString(1)),
                                    cliente,
                                    moto,
                                    servicio,
                                    reader.IsDBNull(11) ? "" : reader.GetString(11))
                                {
                                    Id = reader.GetInt32(0),
                                    Observaciones = reader.IsDBNull(12) ? "" : reader.GetString(12)
                                };
                            }
                        }
                    }
                }
                return null;
            }
        }

        // Listar todos los Turnos
        public List<Turno> ListarTurnos()
        {
            lock (dbLock)
            {
                var turnos = new List<Turno>();

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    ActivarWAL(conn);

                    string sql = @"SELECT 
                          t.Id, t.FechaHora, 
                          c.Dni, c.Nombre, c.Apellido, 
                          m.Patente, m.Marca, m.Modelo, 
                          s.IdServicio, s.Nombre, s.PrecioInicial, 
                          t.Estado, t.Observaciones
                       FROM Turnos t
                       JOIN Cliente c ON t.ClienteId = c.Dni
                       JOIN Moto m ON t.MotoId = m.Patente
                       JOIN Service s ON t.ServicioId = s.IdServicio";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Dni = reader.GetInt32(2),
                                Nombre = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Apellido = reader.IsDBNull(4) ? "" : reader.GetString(4)
                            };

                            var moto = new Moto
                            {
                                Patente = reader.GetString(5),
                                Marca = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                Modelo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                                Cliente = cliente
                            };

                            var servicio = new Service
                            {
                                IdServicio = reader.GetInt32(8),
                                Nombre = reader.IsDBNull(9) ? "" : reader.GetString(9),
                                PrecioInicial = reader.IsDBNull(10) ? 0 : reader.GetInt32(10)
                            };

                            var turno = new Turno(
                                DateTime.Parse(reader.GetString(1)),
                                cliente,
                                moto,
                                servicio,
                                reader.IsDBNull(11) ? "" : reader.GetString(11))
                            {
                                Id = reader.GetInt32(0),
                                Observaciones = reader.IsDBNull(12) ? "" : reader.GetString(12)
                            };

                            turnos.Add(turno);
                        }
                    }
                }

                return turnos;
            }
        }

        // Modificar un Turno existente
        public void ModificarTurno(Turno turno)
        {
            lock (dbLock)
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    ActivarWAL(conn);

                    string sql = @"UPDATE Turnos 
                                   SET FechaHora=@fechaHora, ClienteId=@clienteId, MotoId=@motoId,
                                       ServicioId=@servicioId, Estado=@estado, Observaciones=@observaciones
                                   WHERE Id=@id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fechaHora", turno.FechaHora.ToString("yyyy-MM-dd HH:mm"));
                        cmd.Parameters.AddWithValue("@clienteId", turno.Cliente.Dni);
                        cmd.Parameters.AddWithValue("@motoId", turno.Moto.Patente);
                        cmd.Parameters.AddWithValue("@servicioId", turno.Servicio.IdServicio);
                        cmd.Parameters.AddWithValue("@estado", turno.Estado);
                        cmd.Parameters.AddWithValue("@observaciones", turno.Observaciones ?? "");
                        cmd.Parameters.AddWithValue("@id", turno.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
