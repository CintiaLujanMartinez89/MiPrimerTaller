using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades;
using System;
using System.Windows.Forms;

namespace MiPrimerTaller.Formularios
{
    public partial class FormModificarCliente : FormBase
    {
        private Cliente cliente;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtDni;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormModificarCliente(Cliente clienteExistente)
        {
            cliente = clienteExistente; // viene con Dni cargado
            InitializeComponent();
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            // DNI (solo lectura)
            var lblDni = new Label { Left = 50, Top = 20, Text = "DNI:" };
            txtDni = new TextBox { Left = 150, Top = 20, Width = 200, Text = cliente.Dni.ToString(), ReadOnly = true };

            // Nombre
            var lblNombre = new Label { Left = 50, Top = 60, Text = "Nombre:" };
            txtNombre = new TextBox { Left = 150, Top = 60, Width = 200, Text = cliente.Nombre };

            // Apellido
            var lblApellido = new Label { Left = 50, Top = 100, Text = "Apellido:" };
            txtApellido = new TextBox { Left = 150, Top = 100, Width = 200, Text = cliente.Apellido };

            // Teléfono
            var lblTelefono = new Label { Left = 50, Top = 140, Text = "Teléfono:" };
            txtTelefono = new TextBox { Left = 150, Top = 140, Width = 200, Text = cliente.Telefono };

            // Email
            var lblEmail = new Label { Left = 50, Top = 180, Text = "Email:" };
            txtEmail = new TextBox { Left = 150, Top = 180, Width = 200, Text = cliente.Email };

            // Botón Guardar
            btnGuardar = new Button { Left = 50, Top = 230, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Botón Cancelar
            btnCancelar = new Button { Left = 150, Top = 230, Text = "Cancelar" };
            btnCancelar.Click += (s, e) => this.Close();

            panelMain.Controls.Add(lblDni);
            panelMain.Controls.Add(txtDni);
            panelMain.Controls.Add(lblNombre);
            panelMain.Controls.Add(txtNombre);
            panelMain.Controls.Add(lblApellido);
            panelMain.Controls.Add(txtApellido);
            panelMain.Controls.Add(lblTelefono);
            panelMain.Controls.Add(txtTelefono);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnCancelar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Nombre y Apellido son obligatorios.");
                    return;
                }

                // Actualizamos el objeto con los valores del formulario
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Email = txtEmail.Text;
                cliente.Dni = int.Parse(txtDni.Text); // aseguramos que el Dni esté cargado

                // Guardamos en la BD
                var dao = new ClienteDao();
                dao.Actualizar(cliente);

                MessageBox.Show("Cliente modificado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar cliente: " + ex.Message);
            }
        }
    }
}
