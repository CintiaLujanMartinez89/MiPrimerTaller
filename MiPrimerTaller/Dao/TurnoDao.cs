using System;
using System.Data.SQLite;
using MiPrimerTaller.Entidades;
using System.Collections.Generic;

namespace MiPrimerTaller.DAOs
{
    public class TurnoDao
    {
        private string connectionString = @"Data Source=C:\Users\Usuario\Desktop\Practica Taller\MotoGaragaMD.db";

        // Insertar un Turno
        public void InsertarTurno(Turno turno)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO Turnos 
                               (FechaHora, ClienteId, MotoId, ServicioId, Estado, Observaciones) 
                               VALUES (@fechaHora, @clienteId, @motoId, @servicioId, @estado, @observaciones)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaHora", turno.FechaHora.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@clienteId", turno.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@motoId", turno.Moto.Patente); // usamos Patente como FK
                    cmd.Parameters.AddWithValue("@servicioId", turno.Servicio.IdServicio);
                    cmd.Parameters.AddWithValue("@estado", turno.Estado);
                    cmd.Parameters.AddWithValue("@observaciones", turno.Observaciones ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void EliminarTurno(object idTurno)
        {
            throw new NotImplementedException();
        }

        // Obtener un Turno por Id
        public Turno ObtenerTurnoPorId(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, FechaHora, ClienteId, MotoId, ServicioId, Estado, Observaciones FROM Turnos WHERE Id = @id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime fechaHora = DateTime.Parse(reader.GetString(1));

                            int clienteId = reader.GetInt32(2);
                            Cliente cliente = new ClienteDao().ObtenerPorId(clienteId);

                            string patente = reader.GetString(3);
                            Moto moto = new MotoDao().BuscarPorPatente(patente);

                            int servicioId = reader.GetInt32(4);
                            Service servicio = new ServiceDao().ObtenerPorId(servicioId);

                            string estado = reader.GetString(5);
                            string observaciones = reader.IsDBNull(6) ? "" : reader.GetString(6);

                            return new Turno(fechaHora, cliente, moto, servicio, estado)
                            {
                                Id = reader.GetInt32(0),
                                Observaciones = observaciones
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Turno> ListarTurnos()
        {
            var turnos = new List<Turno>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
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
                            Nombre = reader.GetString(3),
                            Apellido = reader.GetString(4)
                        };

                        var moto = new Moto
                        {
                            Patente = reader.GetString(5),
                            Marca = reader.GetString(6),
                            Modelo = reader.GetString(7),
                            Cliente = cliente
                        };

                        var servicio = new Service
                        {
                            IdServicio = reader.GetInt32(8),
                            Nombre = reader.GetString(9),
                            PrecioInicial = reader.GetInt32(10)
                        };

                        var turno = new Turno(
                            DateTime.Parse(reader.GetString(1)),
                            cliente,
                            moto,
                            servicio,
                            reader.GetString(11))
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


        // Modificar un Turno existente
        public void ModificarTurno(Turno turno)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"UPDATE Turnos 
                               SET FechaHora=@fechaHora, ClienteId=@clienteId, MotoId=@motoId,
                                   ServicioId=@servicioId, Estado=@estado, Observaciones=@observaciones
                               WHERE Id=@id";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaHora", turno.FechaHora.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@clienteId", turno.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@motoId", turno.Moto.Patente); // usamos Patente como FK
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
