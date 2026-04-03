using System;
using System.Data.SQLite;
using MiPrimerTaller.Entidades;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Dao;
using System.Collections.Generic;

namespace MiPrimerTaller.Data
{
    public class TurnoDao
    {
        private string connectionString = "Data Source=miBD.db";

        // Método para insertar un Turno en la tabla
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
                    // ⚠️ Cambio: convertir DateTime a string ISO para SQLite
                    cmd.Parameters.AddWithValue("@fechaHora", turno.FechaHora.ToString("yyyy-MM-dd HH:mm"));

                    // ⚠️ Cambio: usar los IDs de los objetos relacionados
                    cmd.Parameters.AddWithValue("@clienteId", turno.Cliente.Dni);
                    cmd.Parameters.AddWithValue("@motoId", turno.Moto.Patente);
                    cmd.Parameters.AddWithValue("@servicioId", turno.Servicio);

                    // Estado y Observaciones se guardan tal cual
                    cmd.Parameters.AddWithValue("@estado", turno.Estado);
                    cmd.Parameters.AddWithValue("@observaciones", turno.Observaciones ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para leer un Turno desde la tabla
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
                            // ⚠️ Cambio: convertir string ISO a DateTime
                            DateTime fechaHora = DateTime.Parse(reader.GetString(1));

                            // ⚠️ Cambio: recuperar objetos relacionados a partir de sus IDs
                            int clienteId = reader.GetInt32(2);
                            int motoId = reader.GetInt32(3);
                            int servicioId = reader.GetInt32(4);

                            Cliente cliente = new ClienteDao().ObtenerPorId(clienteId);
                            Moto moto = new MotoDao().ObtenerPorId(motoId);
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
            // ... leer de la BD y llenar la lista
            return turnos;
        }
    }
}