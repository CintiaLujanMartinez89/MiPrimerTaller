using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerTaller.Entidades
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Moto Moto { get; set; }
        public string Servicio { get; set; }
        public string Observacion { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
    }

}
