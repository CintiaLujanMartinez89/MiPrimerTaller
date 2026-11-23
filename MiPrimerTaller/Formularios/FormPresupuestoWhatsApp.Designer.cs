namespace MiPrimerTaller
{
    partial class FormPresupuestoWhatsApp
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbMoto;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblMoto;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Label lblPrecio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbMoto = new System.Windows.Forms.ComboBox();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMoto = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblCliente);
            this.panelMain.Controls.Add(this.cmbCliente);
            this.panelMain.Controls.Add(this.lblMoto);
            this.panelMain.Controls.Add(this.cmbMoto);
            this.panelMain.Controls.Add(this.lblServicio);
            this.panelMain.Controls.Add(this.cmbServicio);
            this.panelMain.Controls.Add(this.lblObservacion);
            this.panelMain.Controls.Add(this.txtObservacion);
            this.panelMain.Controls.Add(this.lblPrecio);
            this.panelMain.Controls.Add(this.txtPrecio);
            this.panelMain.Controls.Add(this.btnGuardar);
            this.panelMain.Size = new System.Drawing.Size(320, 330);
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Location = new System.Drawing.Point(30, 30);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(250, 25);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // cmbMoto
            // 
            this.cmbMoto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoto.Location = new System.Drawing.Point(30, 80);
            this.cmbMoto.Name = "cmbMoto";
            this.cmbMoto.Size = new System.Drawing.Size(250, 25);
            this.cmbMoto.TabIndex = 3;
            // 
            // cmbServicio
            // 
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicio.Location = new System.Drawing.Point(30, 130);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(250, 25);
            this.cmbServicio.TabIndex = 5;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(30, 180);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(250, 25);
            this.txtObservacion.TabIndex = 7;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(30, 230);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(250, 25);
            this.txtPrecio.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(30, 270);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Enviar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(30, 10);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(100, 23);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblMoto
            // 
            this.lblMoto.Location = new System.Drawing.Point(30, 60);
            this.lblMoto.Name = "lblMoto";
            this.lblMoto.Size = new System.Drawing.Size(100, 23);
            this.lblMoto.TabIndex = 2;
            this.lblMoto.Text = "Moto:";
            // 
            // lblServicio
            // 
            this.lblServicio.Location = new System.Drawing.Point(30, 110);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(100, 23);
            this.lblServicio.TabIndex = 4;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblObservacion
            // 
            this.lblObservacion.Location = new System.Drawing.Point(30, 160);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(100, 23);
            this.lblObservacion.TabIndex = 6;
            this.lblObservacion.Text = "Observación:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Location = new System.Drawing.Point(30, 210);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(100, 23);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio:";
            // 
            // FormPresupuestoWhatsApp
            // 
            this.ClientSize = new System.Drawing.Size(320, 330);
            this.Name = "FormPresupuestoWhatsApp";
            this.Text = "Presupuesto WhatsApp";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
