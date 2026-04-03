using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace MiPrimerTaller.Controles
{
    public class MenuButton : Button
    {
        public MenuButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.DarkSlateGray;
            this.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Width = 180;
            this.Height = 40;
            this.Cursor = Cursors.Hand;
        }
    }
}