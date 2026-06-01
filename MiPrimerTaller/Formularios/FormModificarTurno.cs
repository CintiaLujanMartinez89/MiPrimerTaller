using System;
using System.Windows.Forms;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades; // Asegurate que acá esté tu clase Turno

namespace MiPrimerTaller.Formularios
{
    public partial class FormModificarTurno : Form
    {
        private Turno turnoActual;

        // Constructor vacío
        public FormModificarTurno()
        {
            InitializeComponent();
        }

        // Constructor que recibe un turno
        public FormModificarTurno(Turno turno) : this()
        {
            turnoActual = turno;

            // Cargar datos en los controles
            txtCliente.Text = turno.Cliente.Nombre + " " + turno.Cliente.Apellido;
            txtMoto.Text = turno.Moto.Patente + " (" + turno.Moto.Modelo + ")";
            txtServicio.Text = turno.Servicio.Nombre;
            dtpFechaHora.Value = turno.FechaHora;
            txtObservaciones.Text = turno.Observaciones;

            if (turno != null && turno.Cliente != null && turno.Moto != null && turno.Servicio != null)
            {
                FormModificarTurno frm = new FormModificarTurno(turno);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("El turno seleccionado no tiene datos completos.");
            }

        }

        // Botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Actualizar los datos del turno con lo que editó el usuario
                turnoActual.FechaHora = dtpFechaHora.Value;
                turnoActual.Observaciones = txtObservaciones.Text;

                // Guardar en la base de datos
                TurnoDao dao = new TurnoDao();
                dao.ModificarTurno(turnoActual);

                MessageBox.Show("Turno actualizado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el turno: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }
}
