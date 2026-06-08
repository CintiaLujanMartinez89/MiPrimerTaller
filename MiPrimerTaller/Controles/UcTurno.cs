using MiPrimerTaller.DAOs;
using MiPrimerTaller.Formularios;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Controles
{
    public partial class UcTurno : UserControl
    {
        private Panel tarjetaSeleccionada;

        public UcTurno()
        {
            InitializeComponent();
            LimpiarPantalla();

            // Configurar selector de hora
            selectFechHora.Format = DateTimePickerFormat.Custom;
            selectFechHora.CustomFormat = "HH:00";
            selectFechHora.ShowUpDown = true;
            selectFechHora.Value = DateTime.Today.AddHours(9);

            selectFechHora.ValueChanged += selectFechHora_ValueChanged;

            // Mostrar calendario y botones al iniciar
            calendario.Visible = true;
            btnReservar.Visible = true;
            btnEliminarTurno.Visible = true;
            btnModificarTurno.Visible = true;

            // 👉 Pintar días con turnos al iniciar
            PintarDiasConTurnos();
        }

        private void LimpiarPantalla()
        {
            flpTurnos.Controls.Clear();
            tarjetaSeleccionada = null;
        }

        private void selectFechHora_ValueChanged(object sender, EventArgs e)
        {
            DateTime valor = selectFechHora.Value;

            if (valor.Hour < 9)
                selectFechHora.Value = new DateTime(valor.Year, valor.Month, valor.Day, 9, 0, 0);

            if (valor.Hour > 17)
                selectFechHora.Value = new DateTime(valor.Year, valor.Month, valor.Day, 17, 0, 0);

            if (valor.Minute != 0)
                selectFechHora.Value = new DateTime(valor.Year, valor.Month, valor.Day, valor.Hour, 0, 0);
        }

        public DateTime ObtenerFechaHoraSeleccionada()
        {
            DateTime fecha = calendario.SelectionStart;
            DateTime hora = selectFechHora.Value;

            return new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, 0);
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            DateTime fechaHoraSeleccionada = ObtenerFechaHoraSeleccionada();
            TurnoDao dao = new TurnoDao();

            var turnoExistente = dao.ListarTurnos()
                                    .FirstOrDefault(t => t.FechaHora == fechaHoraSeleccionada);

            if (turnoExistente != null)
            {
                MessageBox.Show("Ya existe un turno asignado en esa fecha y hora.",
                                "Turno ocupado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            FormReservarTurno frm = new FormReservarTurno(fechaHoraSeleccionada);
            frm.ShowDialog();

            // 👉 refrescar calendario y negrita
            PintarDiasConTurnos();
            calendario_DateChanged(calendario, new DateRangeEventArgs(calendario.SelectionStart, calendario.SelectionEnd));
        }

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
            if (tarjetaSeleccionada?.Tag is Turno turno)
            {
                FormModificarTurno frm = new FormModificarTurno(turno);
                frm.ShowDialog();

                // 👉 refrescar calendario y negrita
                PintarDiasConTurnos();
                calendario_DateChanged(calendario, new DateRangeEventArgs(calendario.SelectionStart, calendario.SelectionEnd));
            }
            else
            {
                MessageBox.Show("Seleccione un turno haciendo clic en la tarjeta.");
            }
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            if (tarjetaSeleccionada?.Tag is Turno turno)
            {
                TurnoDao dao = new TurnoDao();
                dao.EliminarTurno(turno.Id);
                MessageBox.Show("Turno eliminado correctamente.");

                // 👉 refrescar calendario y negrita
                PintarDiasConTurnos();
                calendario_DateChanged(calendario, new DateRangeEventArgs(calendario.SelectionStart, calendario.SelectionEnd));
            }
            else
            {
                MessageBox.Show("Seleccione un turno haciendo clic en la tarjeta.");
            }
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start.Date;
            TurnoDao dao = new TurnoDao();

            var turnosDelDia = dao.ListarTurnos()
                                  .Where(t => t.FechaHora.Date == fechaSeleccionada)
                                  .ToList();

            MostrarTurnosComoTarjetas(turnosDelDia);
        }

        private void MostrarTurnosComoTarjetas(List<Turno> turnos)
        {
            flpTurnos.Controls.Clear();
            tarjetaSeleccionada = null;

            foreach (var turno in turnos)
            {
                Panel card = new Panel();
                card.Width = 250;
                card.Height = 150;
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(10);
                card.Tag = turno;

                card.Click += Card_Click;

                Label lblCliente = new Label();
                lblCliente.Text = turno.Cliente.Nombre + " " + turno.Cliente.Apellido;
                lblCliente.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblCliente.Location = new Point(10, 10);
                lblCliente.AutoSize = true;

                Label lblMoto = new Label();
                lblMoto.Text = turno.Moto.Patente + " (" + turno.Moto.Modelo + ")";
                lblMoto.Location = new Point(10, 40);
                lblMoto.AutoSize = true;

                Label lblServicio = new Label();
                lblServicio.Text = "Servicio: " + turno.Servicio.Nombre;
                lblServicio.Location = new Point(10, 65);
                lblServicio.AutoSize = true;

                Label lblFechaHora = new Label();
                lblFechaHora.Text = turno.FechaHora.ToString("dd/MM/yyyy HH:mm");
                lblFechaHora.Location = new Point(10, 90);
                lblFechaHora.AutoSize = true;

                Label lblObs = new Label();
                lblObs.Text = "Obs: " + turno.Observaciones;
                lblObs.Location = new Point(10, 115);
                lblObs.AutoSize = true;

                card.Controls.Add(lblCliente);
                card.Controls.Add(lblMoto);
                card.Controls.Add(lblServicio);
                card.Controls.Add(lblFechaHora);
                card.Controls.Add(lblObs);

                flpTurnos.Controls.Add(card);
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (tarjetaSeleccionada != null)
                tarjetaSeleccionada.BackColor = Color.White;

            tarjetaSeleccionada = sender as Panel;
            tarjetaSeleccionada.BackColor = Color.LightBlue;
        }

        // 👉 Nuevo método para pintar días con turnos
        private void PintarDiasConTurnos()
        {
            TurnoDao dao = new TurnoDao();
            var turnos = dao.ListarTurnos();

            var fechas = turnos.Select(t => t.FechaHora.Date).Distinct().ToArray();
            calendario.BoldedDates = fechas;
        }
    }
}
