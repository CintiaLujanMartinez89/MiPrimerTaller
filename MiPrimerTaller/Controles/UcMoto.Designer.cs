
namespace MiPrimerTaller.Controles
{
    partial class UcMoto
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
            this.btnListarMotos = new MiPrimerTaller.Controles.MenuButton();
            this.btnAgregarMoto = new MiPrimerTaller.Controles.MenuButton();
            this.btnModificarMoto = new MiPrimerTaller.Controles.MenuButton();
            this.btnEliminarMoto = new MiPrimerTaller.Controles.MenuButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnListarMotos);
            this.flowLayoutPanel1.Controls.Add(this.btnAgregarMoto);
            this.flowLayoutPanel1.Controls.Add(this.btnModificarMoto);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminarMoto);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnListarMotos
            // 
            this.btnListarMotos.BackColor = System.Drawing.Color.Transparent;
            this.btnListarMotos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListarMotos.FlatAppearance.BorderSize = 0;
            this.btnListarMotos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarMotos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListarMotos.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnListarMotos.Location = new System.Drawing.Point(3, 3);
            this.btnListarMotos.Name = "btnListarMotos";
            this.btnListarMotos.Size = new System.Drawing.Size(142, 40);
            this.btnListarMotos.TabIndex = 0;
            this.btnListarMotos.Text = "Mostrar Motos";
            this.btnListarMotos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarMotos.UseVisualStyleBackColor = false;
            // 
            // btnAgregarMoto
            // 
            this.btnAgregarMoto.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarMoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMoto.FlatAppearance.BorderSize = 0;
            this.btnAgregarMoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarMoto.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAgregarMoto.Location = new System.Drawing.Point(151, 3);
            this.btnAgregarMoto.Name = "btnAgregarMoto";
            this.btnAgregarMoto.Size = new System.Drawing.Size(143, 40);
            this.btnAgregarMoto.TabIndex = 1;
            this.btnAgregarMoto.Text = "Agregar Moto";
            this.btnAgregarMoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMoto.UseVisualStyleBackColor = false;
            // 
            // btnModificarMoto
            // 
            this.btnModificarMoto.BackColor = System.Drawing.Color.Transparent;
            this.btnModificarMoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarMoto.FlatAppearance.BorderSize = 0;
            this.btnModificarMoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarMoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarMoto.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificarMoto.Location = new System.Drawing.Point(300, 3);
            this.btnModificarMoto.Name = "btnModificarMoto";
            this.btnModificarMoto.Size = new System.Drawing.Size(144, 40);
            this.btnModificarMoto.TabIndex = 3;
            this.btnModificarMoto.Text = "Modificar Moto";
            this.btnModificarMoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarMoto.UseVisualStyleBackColor = false;
            // 
            // btnEliminarMoto
            // 
            this.btnEliminarMoto.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarMoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarMoto.FlatAppearance.BorderSize = 0;
            this.btnEliminarMoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarMoto.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminarMoto.Location = new System.Drawing.Point(450, 3);
            this.btnEliminarMoto.Name = "btnEliminarMoto";
            this.btnEliminarMoto.Size = new System.Drawing.Size(130, 40);
            this.btnEliminarMoto.TabIndex = 2;
            this.btnEliminarMoto.Text = "Eliminar Moto";
            this.btnEliminarMoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarMoto.UseVisualStyleBackColor = false;
            // 
            // UcMoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UcMoto";
            this.Size = new System.Drawing.Size(606, 305);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MenuButton btnListarMotos;
        private MenuButton btnAgregarMoto;
        private MenuButton btnModificarMoto;
        private MenuButton btnEliminarMoto;
    }
}
