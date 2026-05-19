using System;
using System.Windows.Forms;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Formularios
{
    public partial class FormReservarTurno : FormBase
    {
        private ComboBox cmbPatente;
        private ComboBox cmbServicio;
        private ComboBox cmbEstado;
        private TextBox txtCliente;
        private TextBox txtMoto;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnCancelar;

        private DateTime fechaHoraSeleccionada;

        public FormReservarTurno(DateTime fechaHora)
        {
            fechaHoraSeleccionada = fechaHora;
            InitializeComponent();
            CrearFormulario();
           
        }

        private void CrearFormulario()
        {
            // Etiqueta Fecha
            var lblFecha = new Label { Left = 50, Top = 20, Text = "Fecha y Hora:" };
            var lblFechaHora = new Label { Left = 150, Top = 20, Width = 200, Text = fechaHoraSeleccionada.ToString("dd/MM/yyyy HH:mm") };

            // Combo Patente
            var lblPatente = new Label { Left = 50, Top = 50, Text = "Patente:" };
            cmbPatente = new ComboBox { Left = 150, Top = 50, Width = 200 };
            cmbPatente.SelectedIndexChanged += CmbPatente_SelectedIndexChanged;

            // Cliente
            var lblCliente = new Label { Left = 50, Top = 90, Text = "Cliente:" };
            txtCliente = new TextBox { Left = 150, Top = 90, Width = 200, ReadOnly = true };

            // Moto
            var lblMoto = new Label { Left = 50, Top = 130, Text = "Moto:" };
            txtMoto = new TextBox { Left = 150, Top = 130, Width = 200, ReadOnly = true };

            // Servicio
            var lblServicio = new Label { Left = 50, Top = 170, Text = "Servicio:" };
            cmbServicio = new ComboBox { Left = 150, Top = 170, Width = 200 };

            // Estado
            var lblEstado = new Label { Left = 50, Top = 210, Text = "Estado:" };
            cmbEstado = new ComboBox { Left = 150, Top = 210, Width = 200 };
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Confirmado");

            // Observaciones
            var lblObs = new Label { Left = 50, Top = 250, Text = "Observaciones:" };
            txtObservaciones = new TextBox { Left = 150, Top = 250, Width = 300 };

            // Botones
            btnGuardar = new Button { Left = 50, Top = 300, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button { Left = 150, Top = 300, Text = "Cancelar" };
            btnCancelar.Click += (s, e) => this.Close();

            // Agregar controles al panel principal
            panelMain.Controls.Add(lblFecha);
            panelMain.Controls.Add(lblFechaHora);
            panelMain.Controls.Add(lblPatente);
            panelMain.Controls.Add(cmbPatente);
            panelMain.Controls.Add(lblCliente);
            panelMain.Controls.Add(txtCliente);
            panelMain.Controls.Add(lblMoto);
            panelMain.Controls.Add(txtMoto);
            panelMain.Controls.Add(lblServicio);
            panelMain.Controls.Add(cmbServicio);
            panelMain.Controls.Add(lblEstado);
            panelMain.Controls.Add(cmbEstado);
            panelMain.Controls.Add(lblObs);
            panelMain.Controls.Add(txtObservaciones);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnCancelar);

            // Cargar datos desde la BD
            CargarDatos();
        }


        private void CargarDatos()
        {
            // Cargar patentes desde la BD
            var motos = new MotoDao().Listar();
            cmbPatente.DataSource = motos;
            cmbPatente.DisplayMember = "Patente";
            cmbPatente.ValueMember = "Patente"; // usamos la patente como clave

            // Cargar servicios desde la BD
            var servicios = new ServiceDao().ListarServicios();
            cmbServicio.DataSource = servicios;
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "IdServicio"; // usar IdServicio real
        }

        private void CmbPatente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPatente.SelectedValue != null)
            {
                string patente = cmbPatente.SelectedValue.ToString();
                Moto moto = new MotoDao().BuscarPorPatente(patente);
                if (moto != null)
                {
                    txtMoto.Text = moto.Modelo;
                    txtCliente.Text = moto.Cliente.Nombre + " " + moto.Cliente.Apellido;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string patente = cmbPatente.SelectedValue.ToString();
            Moto moto = new MotoDao().BuscarPorPatente(patente);
            Cliente cliente = moto.Cliente;

            int servicioId = (int)cmbServicio.SelectedValue;
            Service servicio = new ServiceDao().ObtenerPorId(servicioId);

            string estado = cmbEstado.Text;
            string observaciones = txtObservaciones.Text;

            Turno turno = new Turno(fechaHoraSeleccionada, cliente, moto, servicio, estado)
            {
                Observaciones = observaciones
            };

            new TurnoDao().InsertarTurno(turno);
            MessageBox.Show("Turno reservado correctamente.");
            this.Close();
        }
    }
}
