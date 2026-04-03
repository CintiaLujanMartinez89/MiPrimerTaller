
namespace MiPrimerTaller.Controles
{
    partial class UcTurno
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnListarTurnos = new MiPrimerTaller.Controles.MenuButton();
            this.btnAgregarTurno = new MiPrimerTaller.Controles.MenuButton();
            this.btnModificarTurno = new MiPrimerTaller.Controles.MenuButton();
            this.btnEliminarTurno = new MiPrimerTaller.Controles.MenuButton();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.selectFechHora = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnListarTurnos);
            this.flowLayoutPanel1.Controls.Add(this.btnAgregarTurno);
            this.flowLayoutPanel1.Controls.Add(this.btnModificarTurno);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminarTurno);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(602, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnListarTurnos
            // 
            this.btnListarTurnos.BackColor = System.Drawing.Color.Transparent;
            this.btnListarTurnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListarTurnos.FlatAppearance.BorderSize = 0;
            this.btnListarTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarTurnos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListarTurnos.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnListarTurnos.Location = new System.Drawing.Point(3, 3);
            this.btnListarTurnos.Name = "btnListarTurnos";
            this.btnListarTurnos.Size = new System.Drawing.Size(143, 40);
            this.btnListarTurnos.TabIndex = 0;
            this.btnListarTurnos.Text = "Mostrar Turnos";
            this.btnListarTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarTurnos.UseVisualStyleBackColor = false;
            // 
            // btnAgregarTurno
            // 
            this.btnAgregarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTurno.FlatAppearance.BorderSize = 0;
            this.btnAgregarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTurno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTurno.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAgregarTurno.Location = new System.Drawing.Point(152, 3);
            this.btnAgregarTurno.Name = "btnAgregarTurno";
            this.btnAgregarTurno.Size = new System.Drawing.Size(146, 40);
            this.btnAgregarTurno.TabIndex = 1;
            this.btnAgregarTurno.Text = "Agregar Turno";
            this.btnAgregarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarTurno.UseVisualStyleBackColor = false;
            this.btnAgregarTurno.Click += new System.EventHandler(this.btnAgregarTurno_Click);
            // 
            // btnModificarTurno
            // 
            this.btnModificarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnModificarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarTurno.FlatAppearance.BorderSize = 0;
            this.btnModificarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarTurno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarTurno.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificarTurno.Location = new System.Drawing.Point(304, 3);
            this.btnModificarTurno.Name = "btnModificarTurno";
            this.btnModificarTurno.Size = new System.Drawing.Size(142, 40);
            this.btnModificarTurno.TabIndex = 2;
            this.btnModificarTurno.Text = "Modificar Turno";
            this.btnModificarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarTurno.UseVisualStyleBackColor = false;
            this.btnModificarTurno.Click += new System.EventHandler(this.btnModificarTurno_Click);
            // 
            // btnEliminarTurno
            // 
            this.btnEliminarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTurno.FlatAppearance.BorderSize = 0;
            this.btnEliminarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTurno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTurno.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminarTurno.Location = new System.Drawing.Point(452, 3);
            this.btnEliminarTurno.Name = "btnEliminarTurno";
            this.btnEliminarTurno.Size = new System.Drawing.Size(143, 40);
            this.btnEliminarTurno.TabIndex = 3;
            this.btnEliminarTurno.Text = "Eliminar Turno";
            this.btnEliminarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarTurno.UseVisualStyleBackColor = false;
            this.btnEliminarTurno.Click += new System.EventHandler(this.btnEliminarTurno_Click);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(145, 73);
            this.calendario.MaxSelectionCount = 1;
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 1;
            // 
            // selectFechHora
            // 
            this.selectFechHora.Location = new System.Drawing.Point(175, 247);
            this.selectFechHora.Name = "selectFechHora";
            this.selectFechHora.Size = new System.Drawing.Size(200, 20);
            this.selectFechHora.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(318, 291);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(145, 291);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(75, 23);
            this.btnReservar.TabIndex = 4;
            this.btnReservar.Text = "Reservar Turno";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(396, 73);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.Size = new System.Drawing.Size(155, 162);
            this.dgvTurnos.TabIndex = 5;
            // 
            // UcTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.selectFechHora);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UcTurno";
            this.Size = new System.Drawing.Size(609, 335);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MenuButton btnListarTurnos;
        private MenuButton btnAgregarTurno;
        private MenuButton btnModificarTurno;
        private MenuButton btnEliminarTurno;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.DateTimePicker selectFechHora;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.DataGridView dgvTurnos;
    }
}
