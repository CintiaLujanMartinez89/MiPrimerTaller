using MiPrimerTaller.DAOs;
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


namespace MiPrimerTaller.Formularios
{
    public partial class FormAgregarCliente : FormBase
    {
        private TextBox txtDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormAgregarCliente()
        {
            InitializeComponent();
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            // Etiqueta y TextBox DNI
            var lblDni = new Label { Left = 50, Top = 50, Text = "DNI:" };
            txtDni = new TextBox { Left = 150, Top = 50, Width = 200 };

            // Nombre
            var lblNombre = new Label { Left = 50, Top = 90, Text = "Nombre:" };
            txtNombre = new TextBox { Left = 150, Top = 90, Width = 200 };

            // Apellido
            var lblApellido = new Label { Left = 50, Top = 130, Text = "Apellido:" };
            txtApellido = new TextBox { Left = 150, Top = 130, Width = 200 };

            // Teléfono
            var lblTelefono = new Label { Left = 50, Top = 170, Text = "Teléfono:" };
            txtTelefono = new TextBox { Left = 150, Top = 170, Width = 200 };

            // Email
            var lblEmail = new Label { Left = 50, Top = 210, Text = "Email:" };
            txtEmail = new TextBox { Left = 150, Top = 210, Width = 200 };

            // Botón Guardar
            btnGuardar = new Button { Left = 50, Top = 260, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Botón Cancelar
            btnCancelar = new Button { Left = 150, Top = 260, Text = "Cancelar" };
            btnCancelar.Click += (s, e) => this.Close();

            // Agregar controles al panel principal
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
                Cliente cliente = new Cliente
                {
                    Dni = int.Parse(txtDni.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text
                };

                new ClienteDao().Insertar(cliente);
                MessageBox.Show("Cliente agregado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }
    }
}