using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades;

namespace MiPrimerTaller.Formularios
{
    public partial class FormAgregarMoto : FormBase
    {
        private TextBox txtPatente;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private TextBox txtKmInicial;
        private ComboBox cmbClientes;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormAgregarMoto()
        {
            InitializeComponent();
            CrearFormulario();
            CargarClientes();
        }

        private void CrearFormulario()
        {
            // Patente
            var lblPatente = new Label { Left = 50, Top = 50, Text = "Patente:" };
            txtPatente = new TextBox { Left = 150, Top = 50, Width = 200 };

            // Modelo
            var lblModelo = new Label { Left = 50, Top = 90, Text = "Modelo:" };
            txtModelo = new TextBox { Left = 150, Top = 90, Width = 200 };

            // Marca
            var lblMarca = new Label { Left = 50, Top = 130, Text = "Marca:" };
            txtMarca = new TextBox { Left = 150, Top = 130, Width = 200 };

            // KmInicial
            var lblKmInicial = new Label { Left = 50, Top = 170, Text = "Km Inicial:" };
            txtKmInicial = new TextBox { Left = 150, Top = 170, Width = 200 };

            // Cliente
            var lblCliente = new Label { Left = 50, Top = 210, Text = "Cliente:" };
            cmbClientes = new ComboBox { Left = 150, Top = 210, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            // Botón Guardar
            btnGuardar = new Button { Left = 50, Top = 260, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            // Botón Cancelar
            btnCancelar = new Button { Left = 150, Top = 260, Text = "Cancelar" };
            btnCancelar.Click += (s, e) => this.Close();

            panelMain.Controls.Add(lblPatente);
            panelMain.Controls.Add(txtPatente);
            panelMain.Controls.Add(lblModelo);
            panelMain.Controls.Add(txtModelo);
            panelMain.Controls.Add(lblMarca);
            panelMain.Controls.Add(txtMarca);
            panelMain.Controls.Add(lblKmInicial);
            panelMain.Controls.Add(txtKmInicial);
            panelMain.Controls.Add(lblCliente);
            panelMain.Controls.Add(cmbClientes);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnCancelar);
        }

        private void CargarClientes()
        {
            var clientes = new ClienteDao().ObtenerTodas(); // tu ClienteDao debe tener Listar()
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "NombreCompleto"; // propiedad calculada en Cliente
            cmbClientes.ValueMember = "Dni";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var clienteSeleccionado = (Cliente)cmbClientes.SelectedItem;

                int kmInicial = 0;
                int.TryParse(txtKmInicial.Text, out kmInicial);

                Moto moto = new Moto
                {
                    Patente = txtPatente.Text,
                    Modelo = txtModelo.Text,
                    Marca = txtMarca.Text,
                    KmInicial = kmInicial,
                    Cliente = clienteSeleccionado
                };

                new MotoDao().Insertar(moto);
                MessageBox.Show("Moto agregada correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar moto: " + ex.Message);
            }
        }
    }
}
