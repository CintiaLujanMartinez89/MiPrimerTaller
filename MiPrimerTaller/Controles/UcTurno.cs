using MiPrimerTaller.Data;
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
    public partial class UcTurno : UserControl
    {
 

        public UcTurno()
        {
            InitializeComponent();

            calendario.Visible = false;
            selectFechHora.Visible = false;
            btnCancelar.Visible = false;
            btnReservar.Visible = false;
            dgvTurnos.Visible = false;


           // Mostrar fecha + hora, pero en minutos 00
           selectFechHora.Format = DateTimePickerFormat.Custom;
            selectFechHora.CustomFormat = "HH:00"; // muestra 9:00, 10:00, etc.
            selectFechHora.ShowUpDown = true;

            // Valor inicial: 9:00 del día actual
            selectFechHora.Value = DateTime.Today.AddHours(9);

            // Asociar evento
            selectFechHora.ValueChanged += selectFechHora_ValueChanged;



        }

        private void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            calendario.Visible = true;
            selectFechHora.Visible = true;
            btnCancelar.Visible = true;
            btnReservar.Visible = true;
        }

        private void selectFechHora_ValueChanged(object sender, EventArgs e)
        {
            DateTime valor = selectFechHora.Value;

            if (valor.Hour < 9)
                selectFechHora.Value = new DateTime(valor.Year, valor.Month, valor.Day, 9, 0, 0);

            if (valor.Hour > 17)
                selectFechHora.Value = new DateTime(valor.Year, valor.Month, valor.Day, 17, 0, 0);

            // Normalizar minutos a 00
            if (valor.Minute != 0)
                selectFechHora.Value = new DateTime(valor.Year, valor.Month, valor.Day, valor.Hour, 0, 0);
        }

        public DateTime ObtenerFechaHoraSeleccionada()
        {
            // Fecha elegida en el calendario
            DateTime fecha = calendario.SelectionStart; 

            // Hora elegida en el DateTimePicker
            DateTime hora = selectFechHora.Value; 

            // Combinar fecha y hora en un solo DateTime
            return new DateTime(
                fecha.Year,
                fecha.Month,
                fecha.Day,
                hora.Hour,
                hora.Minute,
                0
            );
        }

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
          
                calendario.Visible = true;
                selectFechHora.Visible = true;
            dgvTurnos.Visible = true;
           // Cargar los días con turnos
           PintarDiasConTurnos();
          
        }
        private void PintarDiasConTurnos()
        {
            TurnoDao dao = new TurnoDao();
            var turnos = dao.ListarTurnos();

            // Obtener solo las fechas (sin hora)
            var fechas = turnos.Select(t => t.FechaHora.Date).Distinct().ToArray();

            // Marcar esas fechas en negrita en el calendario
            calendario.BoldedDates = fechas;
        }
        private void btnReservar_Click(object sender, EventArgs e)
        {
            ObtenerFechaHoraSeleccionada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            calendario.Visible = false;
            selectFechHora.Visible = false;
            btnCancelar.Visible = false;
            btnReservar.Visible = false;


        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start.Date;

            TurnoDao dao = new TurnoDao();
            var turnosDelDia = dao.ListarTurnos()
                                  .Where(t => t.FechaHora.Date == fechaSeleccionada)
                                  .ToList();

           dgvTurnos.DataSource = turnosDelDia;
        }
    }
}
