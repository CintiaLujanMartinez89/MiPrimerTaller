using System;
using System.Windows.Forms;
using MiPrimerTaller.Entidades;
using MiPrimerTaller.DAOs;

namespace MiPrimerTaller.Formularios
{
    public partial class FormModificarMoto : FormBase
    {
        private Moto moto;
        private MotoDao motoDao = new MotoDao();

        public FormModificarMoto(Moto motoSeleccionada)
        {
            InitializeComponent(); // inicializa los controles propios
            moto = motoSeleccionada;
            MostrarDatosMoto();

            // 👉 muy importante: agregar los controles al panelMain del FormBase
            panelMain.Controls.Add(lblPatente);
            panelMain.Controls.Add(txtPatente);
            panelMain.Controls.Add(lblMarca);
            panelMain.Controls.Add(txtMarca);
            panelMain.Controls.Add(lblModelo);
            panelMain.Controls.Add(txtModelo);
            panelMain.Controls.Add(lblCliente);
            panelMain.Controls.Add(txtCliente);
            panelMain.Controls.Add(lblKmInicial);
            panelMain.Controls.Add(txtKmInicial);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnCancelar);
        }

        private void MostrarDatosMoto()
        {
            txtPatente.Text = moto.Patente;
            txtMarca.Text = moto.Marca;
            txtModelo.Text = moto.Modelo;
            txtCliente.Text = $"{moto.Cliente.Nombre} {moto.Cliente.Apellido}";
            txtKmInicial.Text = moto.KmInicial.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                moto.Marca = txtMarca.Text;
                moto.Modelo = txtModelo.Text;
                moto.KmInicial = int.TryParse(txtKmInicial.Text, out int km) ? km : moto.KmInicial;

                motoDao.Actualizar(moto);

                MessageBox.Show("Moto modificada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la moto: " + ex.Message,
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
