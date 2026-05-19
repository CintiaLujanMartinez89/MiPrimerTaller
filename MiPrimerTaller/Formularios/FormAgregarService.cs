using System;
using System.Windows.Forms;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Formularios
{
    public partial class FormAgregarService : FormBase
    {
        private TextBox txtNombre;
        private TextBox txtPrecioInicial;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormAgregarService()
        {
            InitializeComponent();
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            // Nombre
            var lblNombre = new Label { Left = 50, Top = 50, Text = "Nombre:" };
            txtNombre = new TextBox { Left = 150, Top = 50, Width = 200 };

            // Precio Inicial
            var lblPrecio = new Label { Left = 50, Top = 90, Text = "Precio Inicial:" };
            txtPrecioInicial = new TextBox { Left = 150, Top = 90, Width = 200 };

            // Botón Guardar
            btnGuardar = new Button { Left = 50, Top = 140, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Botón Cancelar
            btnCancelar = new Button { Left = 150, Top = 140, Text = "Cancelar" };
            btnCancelar.Click += (s, e) => this.Close();

            panelMain.Controls.Add(lblNombre);
            panelMain.Controls.Add(txtNombre);
            panelMain.Controls.Add(lblPrecio);
            panelMain.Controls.Add(txtPrecioInicial);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnCancelar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Service servicio = new Service
                {
                    Nombre = txtNombre.Text,
                    PrecioInicial = int.Parse(txtPrecioInicial.Text)
                };

                new ServiceDao().InsertarServicio(servicio);
                MessageBox.Show("Servicio agregado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar servicio: " + ex.Message);
            }
        }
    }
}
