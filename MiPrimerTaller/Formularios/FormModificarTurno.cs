using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MiPrimerTaller.Entidades;
using MiPrimerTaller.DAOs;

namespace MiPrimerTaller.Formularios
{
    public partial class FormModificarTurno : FormBase
    {
        private Turno turno; // turno que se está modificando
        private ServiceDao serviceDao = new ServiceDao(); // DAO para cargar servicios
        private TurnoDao turnoDao = new TurnoDao();       // DAO para guardar cambios

        public FormModificarTurno(Turno turnoSeleccionado)
        {
            InitializeComponent();
            turno = turnoSeleccionado;

            CargarServicios();
            MostrarDatosTurno();

            // 👉 Importante: agregar los controles al panelMain de FormBase
            panelMain.Controls.Add(lblCliente);
            panelMain.Controls.Add(txtCliente);
            panelMain.Controls.Add(lblMoto);
            panelMain.Controls.Add(txtMoto);
            panelMain.Controls.Add(lblServicio);
            panelMain.Controls.Add(cmbServicio);
            panelMain.Controls.Add(lblFechaHora);
            panelMain.Controls.Add(dtpFechaHora);
            panelMain.Controls.Add(lblObservaciones);
            panelMain.Controls.Add(txtObservaciones);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnCancelar);
        }

        private void CargarServicios()
        {
            List<Service> servicios = serviceDao.ListarServicios();

            cmbServicio.DataSource = servicios;
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "IdServicio";
        }

        private void MostrarDatosTurno()
        {
            txtCliente.Text = $"{turno.Cliente.Nombre} {turno.Cliente.Apellido}";
            txtMoto.Text = $"{turno.Moto.Patente} ({turno.Moto.Marca} {turno.Moto.Modelo})";

            cmbServicio.SelectedValue = turno.Servicio.IdServicio;

            dtpFechaHora.Value = new DateTime(
                turno.FechaHora.Year,
                turno.FechaHora.Month,
                turno.FechaHora.Day,
                turno.FechaHora.Hour,
                0, 0);

            txtObservaciones.Text = turno.Observaciones;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            turno.FechaHora = dtpFechaHora.Value;
            turno.Servicio = (Service)cmbServicio.SelectedItem;
            turno.Observaciones = txtObservaciones.Text;

            try
            {
                turnoDao.ModificarTurno(turno);
                MessageBox.Show("Turno modificado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el turno: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
