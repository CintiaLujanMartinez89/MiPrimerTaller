using System.Collections.Generic;
using System.Data.SQLite;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.DAOs
{
    public class ServiceDao
    {
        private string connectionString = @"Data Source=C:\Users\Usuario\Desktop\Practica Taller\MotoGaragaMD.db;Version=3;";

        public List<Service> ListarServicios()
        {
            var servicios = new List<Service>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT IdServicio, Nombre, PrecioInicial FROM Service";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        servicios.Add(new Service
                        {
                            IdServicio = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            PrecioInicial = reader.GetInt32(2)
                        });
                    }
                }
            }
            return servicios;
        }

        public void InsertarServicio(Service servicio)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Service (Nombre, PrecioInicial) VALUES (@Nombre, @PrecioInicial)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@PrecioInicial", servicio.PrecioInicial);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarServicio(Service servicio)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Service 
                       SET Nombre = @Nombre, 
                           PrecioInicial = @PrecioInicial
                       WHERE IdServicio = @IdServicio";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@PrecioInicial", servicio.PrecioInicial);
                    cmd.Parameters.AddWithValue("@IdServicio", servicio.IdServicio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarServicio(int idServicio)
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


        public Service ObtenerPorId(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Precio FROM Service WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Service
                            {
                                IdServicio = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                PrecioInicial = reader.GetInt32(2)
                            };

                        }
                    }
                }
            }
            return null;
        }
    }
}