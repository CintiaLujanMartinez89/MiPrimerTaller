using MiPrimerTaller.DAOs;
using MiPrimerTaller.Formularios;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace MiPrimerTaller.Controles
{
    public partial class UcTurno : UserControl
    {
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

            // Configurar estilo de la grilla
            ConfigurarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow != null)
            {
                // Obtener el turno seleccionado
                DateTime fechaHora = DateTime.Parse(dgvTurnos.CurrentRow.Cells["Hora"].Value.ToString());
                TurnoDao dao = new TurnoDao();

                // Buscar y eliminar
                var turno = dao.ListarTurnos().FirstOrDefault(t => t.FechaHora.ToString("HH:mm") == fechaHora.ToString("HH:mm"));
                if (turno != null)
                {
                    dao.EliminarTurno(turno.Id);
                    MessageBox.Show("Turno eliminado correctamente.");
                    calendario_DateChanged(calendario, new DateRangeEventArgs(calendario.SelectionStart, calendario.SelectionEnd));
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno de la lista para eliminar.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow != null)
            {
                // Obtener el turno seleccionado
                DateTime fechaHora = DateTime.Parse(dgvTurnos.CurrentRow.Cells["Hora"].Value.ToString());
                TurnoDao dao = new TurnoDao();

                var turno = dao.ListarTurnos().FirstOrDefault(t => t.FechaHora.ToString("HH:mm") == fechaHora.ToString("HH:mm"));
                if (turno != null)
                {
                    FormModificarTurno frm = new FormModificarTurno(turno);
                    frm.ShowDialog();

                    // Refrescar la grilla
                    calendario_DateChanged(calendario, new DateRangeEventArgs(calendario.SelectionStart, calendario.SelectionEnd));
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno de la lista para modificar.");
            }
        }


        private void ConfigurarGrilla()
        {
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.MultiSelect = false;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.AllowUserToResizeRows = false;

            dgvTurnos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvTurnos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvTurnos.CellFormatting += dgvTurnos_CellFormatting;
        }

        private void dgvTurnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTurnos.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                if (estado.Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                {
                    dgvTurnos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    dgvTurnos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki;
                }
                else if (estado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                {
                    dgvTurnos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            dgvTurnos.Visible = false;
            btnModificarTurno.Visible = false;
            calendario.Visible = true;
            selectFechHora.Visible = true;
            btnReservar.Visible = true;
        }

        private void LimpiarPantalla()
        {
            calendario.Visible = false;
            selectFechHora.Visible = false;
            btnEliminarTurno.Visible = false;
            btnReservar.Visible = false;
            dgvTurnos.Visible = false;
            btnModificarTurno.Visible = false;

            dgvTurnos.DataSource = null;
            if (dgvTurnos.Rows.Count > 0)
                dgvTurnos.Rows.Clear();
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

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
            btnModificarTurno.Visible = true;
            btnEliminarTurno.Visible = false;
            btnReservar.Visible = false;
            calendario.Visible = true;
            selectFechHora.Visible = false;
            dgvTurnos.Visible = true;

            PintarDiasConTurnos();
        }

        private void PintarDiasConTurnos()
        {
            TurnoDao dao = new TurnoDao();
            var turnos = dao.ListarTurnos();

            var fechas = turnos.Select(t => t.FechaHora.Date).Distinct().ToArray();

            calendario.BoldedDates = fechas;
            calendario.UpdateBoldedDates();
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
        }

        // ✅ Solo se llena la grilla cuando seleccionás un día
        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start.Date;
            TurnoDao dao = new TurnoDao();

            var turnosDelDia = dao.ListarTurnos()
                                  .Where(t => t.FechaHora.Date == fechaSeleccionada)
                                  .Select(t => new
                                  {
                                      Hora = t.FechaHora.ToString("HH:mm"),
                                      Cliente = t.Cliente.Nombre + " " + t.Cliente.Apellido,
                                      Moto = t.Moto.Patente + " (" + t.Moto.Modelo + ")",
                                      Servicio = t.Servicio.Nombre,
                                      Estado = t.Estado,
                                      Observaciones = t.Observaciones
                                  })
                                  .ToList();

            dgvTurnos.DataSource = turnosDelDia;
            dgvTurnos.Visible = true;
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            btnEliminarTurno.Visible = true;
            btnModificarTurno.Visible = false;
            btnReservar.Visible = false;
            calendario.Visible = true;
            selectFechHora.Visible = false;
            dgvTurnos.Visible = true;

            PintarDiasConTurnos();
        }

        private void btnListarTurnos_Click(object sender, EventArgs e)
        {
            calendario.Visible = true;
            selectFechHora.Visible = false;
            btnEliminarTurno.Visible = false;
            btnReservar.Visible = false;
            dgvTurnos.Visible = true;
            btnModificarTurno.Visible = false;

            // Ya no llenamos todos los turnos aquí, solo pintamos los días
            PintarDiasConTurnos();
        }
    }
}
