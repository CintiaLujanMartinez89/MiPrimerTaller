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
    public partial class FormModificarCliente : FormBase
    {
        private Cliente cliente;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormModificarCliente(Cliente clienteExistente)
        {
            cliente = clienteExistente;
            InitializeComponent();
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            // Nombre
            var lblNombre = new Label { Left = 50, Top = 50, Text = "Nombre:" };
            txtNombre = new TextBox { Left = 150, Top = 50, Width = 200, Text = cliente.Nombre };

            // Apellido
            var lblApellido = new Label { Left = 50, Top = 90, Text = "Apellido:" };
            txtApellido = new TextBox { Left = 150, Top = 90, Width = 200, Text = cliente.Apellido };

            // Teléfono
            var lblTelefono = new Label { Left = 50, Top = 130, Text = "Teléfono:" };
            txtTelefono = new TextBox { Left = 150, Top = 130, Width = 200, Text = cliente.Telefono };

            // Email
            var lblEmail = new Label { Left = 50, Top = 170, Text = "Email:" };
            txtEmail = new TextBox { Left = 150, Top = 170, Width = 200, Text = cliente.Email };

            // Botón Guardar
            btnGuardar = new Button { Left = 50, Top = 220, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Botón Cancelar
            btnCancelar = new Button { Left = 150, Top = 220, Text = "Cancelar" };
            btnCancelar.Click += (s, e) => this.Close();

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
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Email = txtEmail.Text;

                new ClienteDao().Actualizar(cliente);
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
