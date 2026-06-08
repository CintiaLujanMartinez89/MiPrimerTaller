using MiPrimerTaller.DAOs;
using MiPrimerTaller.Entidades;
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

        private void btnModificarMoto_Click(object sender, EventArgs e)
        {
            if (DGVmotos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una moto de la lista primero.");
                return;
            }

            try
            {
                // Obtenemos la moto seleccionada
                Moto motoSeleccionada = (Moto)DGVmotos.CurrentRow.DataBoundItem;

                // Abrimos el formulario de modificación
                FormModificarMoto form = new FormModificarMoto(motoSeleccionada);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Refrescamos la grilla después de modificar
                    DGVmotos.DataSource = new MotoDao().Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar moto: " + ex.Message);
            }
        }

        private void btnEliminarMoto_Click(object sender, EventArgs e)
        {
            if (DGVmotos.CurrentRow != null)
            {
                // Obtenemos la patente de la moto seleccionada en la grilla
                string patente = DGVmotos.CurrentRow.Cells["Patente"].Value.ToString();

                // Confirmamos con el usuario
                var confirm = MessageBox.Show(
                    $"¿Seguro que deseas eliminar la moto con patente {patente}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        MotoDao dao = new MotoDao();
                        dao.Eliminar(patente);

                        MessageBox.Show("Moto eliminada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescamos la grilla
                        DGVmotos.DataSource = dao.Listar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la moto: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una moto para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
