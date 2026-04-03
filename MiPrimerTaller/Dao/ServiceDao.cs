using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Dao
{
    class ServiceDao
    {
        private string connectionString = "Data Source=MotogarageMD.db;Version=3;";

        // Obtener todos los servicios
        public List<Service> ObtenerTodos()
        {
            List<Service> lista = new List<Service>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IdServicio, Nombre, PrecioInicial FROM Service";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Service service = new Service
                        {
                            IdServicio = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            PrecioInicial = reader.GetInt32(2)
                        };
                        lista.Add(service);
                    }
                }
            }

            return lista;
        }

        // Insertar un servicio
        public void Insertar(Service service)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Service (IdServicio, Nombre, PrecioInicial) " +
                             "VALUES (@IdServicio, @Nombre, @PrecioInicial)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdServicio", service.IdServicio);
                    cmd.Parameters.AddWithValue("@Nombre", service.Nombre);
                    cmd.Parameters.AddWithValue("@PrecioInicial", service.PrecioInicial);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Actualizar un servicio
        public void Actualizar(Service service)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Service SET Nombre = @Nombre, PrecioInicial = @PrecioInicial " +
                             "WHERE IdServicio = @IdServicio";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", service.Nombre);
                    cmd.Parameters.AddWithValue("@PrecioInicial", service.PrecioInicial);
                    cmd.Parameters.AddWithValue("@IdServicio", service.IdServicio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar un servicio
        public void Eliminar(int idServicio)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Service WHERE IdServicio = @IdServicio";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdServicio", idServicio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal Service ObtenerPorId(int servicioId)
        {
            throw new NotImplementedException();
        }
    }
}