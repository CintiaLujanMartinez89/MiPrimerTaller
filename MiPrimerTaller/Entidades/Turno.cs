using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Entidades
{
    public class Turno
    {
        public int Id { get; set; } // Identificador único
        public DateTime FechaHora { get; set; } // Fecha y hora del turno

        public Cliente Cliente { get; set; } // Cliente asociado
        public Moto Moto { get; set; } // Moto asociada
        public Service Servicio { get; set; } // Servicio solicitado

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
            return $"{FechaHora:dd/MM/yyyy HH:mm} - {Cliente.Nombre} - {Moto.Patente} - {Servicio.Nombre} ({Estado})";
        }
    }
}
