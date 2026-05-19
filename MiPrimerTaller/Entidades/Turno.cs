using System;

namespace MiPrimerTaller.Entidades
{
    public class Turno
    {
        public int Id { get; set; } // Identificador único
        public DateTime FechaHora { get; set; } // Fecha y hora del turno

        // Objetos asociados
        public Cliente Cliente { get; set; }
        public Moto Moto { get; set; }
        public Service Servicio { get; set; }

        // Propiedades auxiliares para trabajar con la BD
        public int ClienteDni => Cliente?.Dni ?? 0;
        public string MotoPatente => Moto?.Patente ?? "";
        public int ServicioId => Servicio?.IdServicio ?? 0;

        public int ServiId => Servicio?.IdServicio ?? 0;

        public string Estado { get; set; } // Ej: "Pendiente", "Confirmado", "Cancelado"
        public string Observaciones { get; set; } // Comentarios adicionales

        public Turno() { }

        public Turno(DateTime fechaHora, Cliente cliente, Moto moto, Service servicio, string estado = "Pendiente")
        {
            FechaHora = fechaHora;
            Cliente = cliente;
            Moto = moto;
            Servicio = servicio;
            Estado = estado;
        }

        public override string ToString()
        {
            return $"{FechaHora:dd/MM/yyyy HH:mm} - {Cliente?.Nombre} - {Moto?.Modelo} - {Servicio?.Nombre} ({Estado})";
        }
    }
}
