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
    public partial class UcService : UserControl
    {
        public UcService()
        {
            InitializeComponent();
            DGVService.Visible = true;
        }

        private void btnListarService_Click(object sender, EventArgs e)
        {
            DGVService.Visible = true ;
            var dao = new ServiceDao();
            var lista = dao.ListarServicios();
            // Asignar la lista al DataGridView
            DGVService.DataSource = lista;
        }

        private void btnAgregarService_Click(object sender, EventArgs e)
        {
            FormAgregarService form = new FormAgregarService();
            form.ShowDialog();

            // Refrescar la grilla después de agregar
            DGVService.DataSource = new ServiceDao().ListarServicios();
        }

        private void btnModificarService_Click(object sender, EventArgs e)
        {
            if (DGVService.CurrentRow != null)
            {
                // Obtener el IdServicio del servicio seleccionado
                int idServicio = Convert.ToInt32(DGVService.CurrentRow.Cells["IdServicio"].Value);

                // Buscar el servicio en la BD
                Service servicio = new ServiceDao().ObtenerPorId(idServicio);

                if (servicio != null)
                {
                    // Abrir formulario de modificación pasando el servicio
                    FormModificarService form = new FormModificarService(servicio);
                    form.ShowDialog();

                    // Refrescar la grilla después de modificar
                    DGVService.DataSource = new ServiceDao().ListarServicios();
                }
                else
                {
                    MessageBox.Show("No se encontró el servicio seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un servicio de la lista para modificar.");
            }
        }

        private void btnEliminarService_Click(object sender, EventArgs e)
        {
            if (DGVService.CurrentRow != null)
            {
                // Obtener el IdServicio del servicio seleccionado
                int idServicio = Convert.ToInt32(DGVService.CurrentRow.Cells["IdServicio"].Value);

                // Confirmar con el usuario antes de eliminar
                var confirm = MessageBox.Show("¿Está seguro que desea eliminar este servicio?",
                                              "Confirmar eliminación",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    new ServiceDao().EliminarServicio(idServicio);
                    MessageBox.Show("Servicio eliminado correctamente.");

                    // Refrescar la grilla
                    DGVService.DataSource = new ServiceDao().ListarServicios();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un servicio de la lista para eliminar.");
            }
        }

    }
}
