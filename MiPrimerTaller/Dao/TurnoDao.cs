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
                    cmd.Parameters.AddWithValue("@motoId", turno.Moto.Patente);
                    cmd.Parameters.AddWithValue("@servicioId", turno.Servicio.IdServicio);
                    cmd.Parameters.AddWithValue("@estado", turno.Estado);
                    cmd.Parameters.AddWithValue("@observaciones", turno.Observaciones ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
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

                            int motoId = reader.GetInt32(3);
                            Moto moto = new MotoDao().ObtenerPorId(motoId);

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

        // Listar todos los Turnos
        public List<Turno> ListarTurnos()
        {
            var turnos = new List<Turno>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, FechaHora, ClienteId, MotoId, ServicioId, Estado, Observaciones FROM Turnos";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime fechaHora = DateTime.Parse(reader.GetString(1));

                        int clienteId = reader.GetInt32(2);
                        Cliente cliente = new ClienteDao().ObtenerPorId(clienteId);

                        int motoId = reader.GetInt32(3);
                        Moto moto = new MotoDao().ObtenerPorId(motoId);

                        int servicioId = reader.GetInt32(4);
                        Service servicio = new ServiceDao().ObtenerPorId(servicioId);

                        string estado = reader.GetString(5);
                        string observaciones = reader.IsDBNull(6) ? "" : reader.GetString(6);

                        var turno = new Turno(fechaHora, cliente, moto, servicio, estado)
                        {
                            Id = reader.GetInt32(0),
                            Observaciones = observaciones
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
