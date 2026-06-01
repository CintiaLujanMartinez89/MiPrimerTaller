using MiPrimerTaller.DAOs;
using MiPrimerTaller.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimerTaller.Controles
{
    public partial class UcMoto : UserControl
    {
        public UcMoto()
        {
            InitializeComponent();
        }


        private void btnListarMotos_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciamos el DAO
                MotoDao dao = new MotoDao();

                // Obtenemos la lista de motos
                var lista = dao.Listar();

                // Asignamos la lista al DataGridView
                DGVmotos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar motos: " + ex.Message);
            }
        }

        private void btnAgregarMoto_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de alta de moto
            FormAgregarMoto form = new FormAgregarMoto();
            form.ShowDialog();

            // Refrescamos la grilla después de agregar
            DGVmotos.DataSource = new MotoDao().Listar();
        }

    }
}
