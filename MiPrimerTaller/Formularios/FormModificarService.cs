using System;
using System.Windows.Forms;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Formularios
{
    public partial class FormModificarService : FormBase
    {
        private Service servicio;
        private TextBox txtNombre;
        private TextBox txtPrecioInicial;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormModificarService(Service servicioExistente)
        {
            servicio = servicioExistente;
            InitializeComponent();
            CrearFormulario();
        }

        private void CrearFormulario()
        {
            // Nombre
            var lblNombre = new Label { Left = 50, Top = 50, Text = "Nombre:" };
            txtNombre = new TextBox { Left = 150, Top = 50, Width = 200, Text = servicio.Nombre };

            // Precio Inicial
            var lblPrecio = new Label { Left = 50, Top = 90, Text = "Precio Inicial:" };
            txtPrecioInicial = new TextBox { Left = 150, Top = 90, Width = 200, Text = servicio.PrecioInicial.ToString() };

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
                servicio.Nombre = txtNombre.Text;
                servicio.PrecioInicial = int.Parse(txtPrecioInicial.Text);

                new ServiceDao().ModificarServicio(servicio);
                MessageBox.Show("Servicio modificado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar servicio: " + ex.Message);
            }
        }
    }
}
