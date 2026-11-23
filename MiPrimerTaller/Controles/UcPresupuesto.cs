using System;

using System.Linq;
using System.Windows.Forms;
using MiPrimerTaller.Entidades;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Dao;
using MiPrimerTaller.Formularios;

namespace MiPrimerTaller.Controles
{
    public partial class UcPresupuesto : UserControl
    {
        private PresupuestoDao presupuestoDao = new PresupuestoDao();

        public UcPresupuesto()
        {
            InitializeComponent();
            CargarPresupuestos();
        }

        private void CargarPresupuestos()
        {
            var lista = presupuestoDao.Listar();
            dgvPresupuestos.DataSource = lista.Select(p => new
            {
                Id = p.Id,
                Cliente = $"{p.Cliente.Dni} - {p.Cliente.Nombre} {p.Cliente.Apellido}",
                Moto = $"{p.Moto.Patente} - {p.Moto.Marca} {p.Moto.Modelo}",
                Servicio = p.Servicio,
                Observacion = p.Observacion,
                Precio = p.Precio,
                Fecha = p.Fecha.ToString("dd/MM/yyyy HH:mm")
            }).ToList();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var form = new FormPresupuestoWhatsApp();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarPresupuestos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPresupuestos.CurrentRow != null)
            {
                int id = (int)dgvPresupuestos.CurrentRow.Cells["Id"].Value;
                var presupuesto = presupuestoDao.BuscarPorId(id);

                var form = new FormPresupuestoWhatsApp(presupuesto);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarPresupuestos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPresupuestos.CurrentRow != null)
            {
                int id = (int)dgvPresupuestos.CurrentRow.Cells["Id"].Value;
                var confirm = MessageBox.Show("¿Seguro que desea eliminar este presupuesto?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    presupuestoDao.Eliminar(id);
                    CargarPresupuestos();
                }
            }
        }
    }
}
