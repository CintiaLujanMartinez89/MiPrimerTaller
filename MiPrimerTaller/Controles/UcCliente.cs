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
    public partial class UcCliente : UserControl
    {
        
        public UcCliente()
        {
         
            InitializeComponent();
            DGVClientes.Visible = true;

        }

        private void btnListarCliente_Click(object sender, EventArgs e)
        {
            DGVClientes.Visible = true;
            var dao = new ClienteDao();
            var lista = dao.ObtenerTodas();
            // Asignar la lista al DataGridView
            DGVClientes.DataSource = lista;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormAgregarCliente form = new FormAgregarCliente();
            form.ShowDialog();
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
           


            if (DGVClientes.CurrentRow != null)
            {
                // Obtener el DNI del cliente seleccionado en el DataGridView
                int dni = Convert.ToInt32(DGVClientes.CurrentRow.Cells["Dni"].Value);

                // Buscar el cliente en la BD
                Cliente cliente = new ClienteDao().ObtenerPorId(dni);

                if (cliente != null)
                {
                    // Abrir formulario de modificación pasando el cliente
                    FormModificarCliente form = new FormModificarCliente(cliente);
                    form.ShowDialog();

                    // Refrescar la grilla después de modificar
                    DGVClientes.DataSource = new ClienteDao().ObtenerTodas();
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente de la lista para modificar.");
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (DGVClientes.CurrentRow != null)
            {
                int dni = Convert.ToInt32(DGVClientes.CurrentRow.Cells["Dni"].Value);

                var dao = new ClienteDao();
                dao.Eliminar(dni);

                MessageBox.Show("Cliente eliminado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la grilla
                DGVClientes.DataSource = dao.ObtenerTodas();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
