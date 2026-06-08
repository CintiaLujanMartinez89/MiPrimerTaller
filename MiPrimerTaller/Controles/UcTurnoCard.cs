using MiPrimerTaller.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerTaller.Controles
{
    public partial class UcTurnoCard : UserControl
    {
        public UcTurnoCard(Turno turno)
        {
            InitializeComponent();

            lblCliente.Text = turno.Cliente.Nombre + " " + turno.Cliente.Apellido;
            lblMoto.Text = turno.Moto.Patente + " (" + turno.Moto.Modelo + ")";
            lblServicio.Text = turno.Servicio.Nombre;
            lblFechaHora.Text = turno.FechaHora.ToString("dd/MM/yyyy HH:mm");
            lblObservaciones.Text = turno.Observaciones;
        }

       
    }


}
