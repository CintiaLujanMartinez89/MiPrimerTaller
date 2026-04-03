using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerTaller.Entidades
{
    public class Moto
    {
        public string Patente { get; set; }
        public Cliente Cliente { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int KmInicial { get; set; }


    }
}
