using System;
using System.Diagnostics;
using System.Windows.Forms;
using MiPrimerTaller.Entidades;
using MiPrimerTaller.DAOs;
using MiPrimerTaller.Dao;
using MiPrimerTaller.Formularios;
using System.Net;

namespace MiPrimerTaller
{
    public partial class FormPresupuestoWhatsApp : FormBase
    {
        private PresupuestoDao presupuestoDao = new PresupuestoDao();
        private Presupuesto presupuestoEditar;

        public FormPresupuestoWhatsApp()
        {
            InitializeComponent();
            CargarClientes();
            CargarServicios();
        }

        public FormPresupuestoWhatsApp(Presupuesto presupuesto) : this()
        {
            presupuestoEditar = presupuesto;
            CargarDatosPresupuesto();
        }

        private void CargarClientes()
        {
            var clienteDao = new ClienteDao();
            var clientes = clienteDao.ObtenerTodas();
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Dni";
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem is Cliente cliente)
            {
                var motoDao = new MotoDao();
                var motos = motoDao.ListarPorCliente(cliente.Dni);
                cmbMoto.DataSource = motos;
                cmbMoto.DisplayMember = "Modelo";
                cmbMoto.ValueMember = "Patente";
            }
        }

        private void CargarDatosPresupuesto()
        {
            cmbCliente.SelectedValue = presupuestoEditar.Cliente.Dni;
            cmbMoto.SelectedValue = presupuestoEditar.Moto.Patente;
            cmbServicio.SelectedItem = presupuestoEditar.Servicio; // ahora ComboBox
            txtObservacion.Text = presupuestoEditar.Observacion;
            txtPrecio.Text = presupuestoEditar.Precio.ToString();
        }

        private void CargarServicios()
        {
            var servicioDao = new ServiceDao();
            var servicios = servicioDao.ListarServicios();
            cmbServicio.DataSource = servicios;
            cmbServicio.DisplayMember = "Nombre";   // propiedad de tu entidad Servicio
            cmbServicio.ValueMember = "IdServicio";         // clave primaria
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var cliente = (Cliente)cmbCliente.SelectedItem;
            var moto = (Moto)cmbMoto.SelectedItem;
            var servicioSeleccionado = (Service)cmbServicio.SelectedItem;

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio ingresado no es válido. Ingrese un número.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // corta la ejecución si el precio no es válido
            }

            var presupuesto = new Presupuesto
            {
                Cliente = cliente,
                Moto = moto,
                Servicio = servicioSeleccionado.Nombre,
                Observacion = txtObservacion.Text,
                Precio = precio,   // ahora seguro es decimal válido
                Fecha = DateTime.Now
            };


      

            if (presupuestoEditar == null)
                presupuestoDao.Insertar(presupuesto);
            else
            {
                presupuesto.Id = presupuestoEditar.Id;
                presupuestoDao.Actualizar(presupuesto);
            }

            // Generar mensaje de WhatsApp
            string mensaje = $"Hola {cliente.Nombre}!\n\n" +
                     $"Presupuesto para su moto:\n" +
                     $"- Marca/Modelo: {moto.Marca} {moto.Modelo}\n" +
                     $"- Patente: {moto.Patente}\n\n" +
                     $"Detalle del servicio:\n" +
                     $"- Servicio: {presupuesto.Servicio}\n" +
                     $"- Observación: {presupuesto.Observacion}\n" +
                     $"- Precio: ${presupuesto.Precio}\n\n" +
                     "Gracias por confiar en MotoGarage MD";




            string numero = cliente.Telefono; // debe estar en formato internacional (+54911xxxxxxx)
            string mensajeCodificado = WebUtility.UrlEncode(mensaje);
            string url = $"https://wa.me/{numero}?text={mensajeCodificado}";

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
