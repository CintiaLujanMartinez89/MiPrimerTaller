using System;
using System.Drawing;
using System.Windows.Forms;
using MiPrimerTaller.Controles;

namespace MiPrimerTaller.Formularios
{
    public partial class FormInicio : Form
    {
        private MenuButton btnClientes;
        private MenuButton btnMotos;
        private MenuButton btnServicios;
        private MenuButton btnTurnos;

        public FormInicio()
        {
            InitializeComponent();
            CrearMenuLateral();
        }

        private void CrearMenuLateral()
        {
            // Panel lateral con FlowLayout
            FlowLayoutPanel sidebar = new FlowLayoutPanel();
            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 200;
            sidebar.BackColor = Color.LightGray;
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.WrapContents = false; // que no se rompa la columna
            sidebar.AutoScroll = true;    // scroll si hay muchos botones

            // Inicializar botones usando los campos de clase
            btnClientes = new MenuButton { Text = "Clientes" };
            btnMotos = new MenuButton { Text = "Motos" };
            btnServicios = new MenuButton { Text = "Servicios" };
            btnTurnos = new MenuButton { Text = "Turnos" };

            // Agregar botones al sidebar
            sidebar.Controls.Add(btnClientes);
            sidebar.Controls.Add(btnMotos);
            sidebar.Controls.Add(btnServicios);
            sidebar.Controls.Add(btnTurnos);

            // Agregar el sidebar al formulario
            this.Controls.Add(sidebar);

            // Ejemplo de eventos
            btnClientes.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcCliente uc = new UcCliente();
                uc.Dock = DockStyle.Fill;
                panelMain.Controls.Add(uc);


            };
            btnMotos.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcMoto uc = new UcMoto();
                uc.Dock = DockStyle.Fill;
                panelMain.Controls.Add(uc);
            };


            btnServicios.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcService uc = new UcService();
                uc.Dock = DockStyle.Fill;
                panelMain.Controls.Add(uc);
            };


            btnTurnos.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcTurno uc = new UcTurno();
                uc.Dock = DockStyle.Fill;
                panelMain.Controls.Add(uc);
            };


        }


    }
}