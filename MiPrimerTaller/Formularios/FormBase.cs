using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiPrimerTaller.Formularios
{
    public partial class FormBase : Form
    {
        protected Panel panelMain;

        public FormBase()
        {
            InitializeEstilo();
        }

        private void InitializeEstilo()
        {
            this.Text = "MotoGarage MD";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 450);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Panel principal igual que en FormInicio
            panelMain = new Panel();
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackgroundImage = global::MiPrimerTaller.Properties.Resources.logoMD;
            panelMain.BackgroundImageLayout = ImageLayout.Zoom;

            this.Controls.Add(panelMain);
        }
    }
}