using System.Drawing;
using System.Windows.Forms;
using MiPrimerTaller.Controles;

namespace MiPrimerTaller.Formularios
{
    public partial class FormInicio : FormBase
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
            FlowLayoutPanel sidebar = new FlowLayoutPanel();
            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 200;
            sidebar.BackColor = Color.LightGray;
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.WrapContents = false;
            sidebar.AutoScroll = true;

            btnClientes = new MenuButton { Text = "Clientes" };
            btnMotos = new MenuButton { Text = "Motos" };
            btnServicios = new MenuButton { Text = "Servicios" };
            btnTurnos = new MenuButton { Text = "Turnos" };

            sidebar.Controls.Add(btnClientes);
            sidebar.Controls.Add(btnMotos);
            sidebar.Controls.Add(btnServicios);
            sidebar.Controls.Add(btnTurnos);

            this.Controls.Add(sidebar);

            btnClientes.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcCliente uc = new UcCliente { Dock = DockStyle.Fill };
                panelMain.Controls.Add(uc);
            };

            btnMotos.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcMoto uc = new UcMoto { Dock = DockStyle.Fill };
                panelMain.Controls.Add(uc);
            };

            btnServicios.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcService uc = new UcService { Dock = DockStyle.Fill };
                panelMain.Controls.Add(uc);
            };

            btnTurnos.Click += (s, e) =>
            {
                panelMain.Controls.Clear();
                UcTurno uc = new UcTurno { Dock = DockStyle.Fill };
                panelMain.Controls.Add(uc);
            };
        }
    }
}