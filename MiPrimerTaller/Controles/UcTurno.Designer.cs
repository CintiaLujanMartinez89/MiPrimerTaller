namespace MiPrimerTaller.Controles
{
    partial class UcTurno
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.selectFechHora = new System.Windows.Forms.DateTimePicker();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnEliminarTurno = new System.Windows.Forms.Button();
            this.btnModificarTurno = new System.Windows.Forms.Button();
            this.flpTurnos = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(10, 10);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 0;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // selectFechHora
            // 
            this.selectFechHora.Location = new System.Drawing.Point(10, 180);
            this.selectFechHora.Name = "selectFechHora";
            this.selectFechHora.Size = new System.Drawing.Size(200, 20);
            this.selectFechHora.TabIndex = 1;
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(10, 210);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(100, 30);
            this.btnReservar.TabIndex = 2;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // btnEliminarTurno
            // 
            this.btnEliminarTurno.Location = new System.Drawing.Point(120, 210);
            this.btnEliminarTurno.Name = "btnEliminarTurno";
            this.btnEliminarTurno.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarTurno.TabIndex = 3;
            this.btnEliminarTurno.Text = "Eliminar";
            this.btnEliminarTurno.UseVisualStyleBackColor = true;
            this.btnEliminarTurno.Click += new System.EventHandler(this.btnEliminarTurno_Click);
            // 
            // btnModificarTurno
            // 
            this.btnModificarTurno.Location = new System.Drawing.Point(230, 210);
            this.btnModificarTurno.Name = "btnModificarTurno";
            this.btnModificarTurno.Size = new System.Drawing.Size(100, 30);
            this.btnModificarTurno.TabIndex = 4;
            this.btnModificarTurno.Text = "Modificar";
            this.btnModificarTurno.UseVisualStyleBackColor = true;
            this.btnModificarTurno.Click += new System.EventHandler(this.btnModificarTurno_Click);
            // 
            // flpTurnos
            // 
            this.flpTurnos.Location = new System.Drawing.Point(10, 250);
            this.flpTurnos.Name = "flpTurnos";
            this.flpTurnos.Size = new System.Drawing.Size(580, 280);
            this.flpTurnos.TabIndex = 5;
            this.flpTurnos.AutoScroll = true;
            this.flpTurnos.WrapContents = true;
            this.flpTurnos.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            // 
            // UcTurno
            // 
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.selectFechHora);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnEliminarTurno);
            this.Controls.Add(this.btnModificarTurno);
            this.Controls.Add(this.flpTurnos);
            this.Name = "UcTurno";
            this.Size = new System.Drawing.Size(600, 550);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.DateTimePicker selectFechHora;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnEliminarTurno;
        private System.Windows.Forms.Button btnModificarTurno;
        private System.Windows.Forms.FlowLayoutPanel flpTurnos;
    }
}
