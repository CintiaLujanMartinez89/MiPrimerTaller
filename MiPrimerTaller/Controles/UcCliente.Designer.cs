namespace MiPrimerTaller.Controles
{
    partial class UcCliente
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnListarCliente = new MiPrimerTaller.Controles.MenuButton();
            this.btnAgregarCliente = new MiPrimerTaller.Controles.MenuButton();
            this.btnModificarCliente = new MiPrimerTaller.Controles.MenuButton();
            this.btnEliminarCliente = new MiPrimerTaller.Controles.MenuButton();
            this.DGVClientes = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnListarCliente);
            this.flowLayoutPanel1.Controls.Add(this.btnAgregarCliente);
            this.flowLayoutPanel1.Controls.Add(this.btnModificarCliente);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminarCliente);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(638, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnListarCliente
            // 
            this.btnListarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListarCliente.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnListarCliente.Location = new System.Drawing.Point(3, 3);
            this.btnListarCliente.Name = "btnListarCliente";
            this.btnListarCliente.Size = new System.Drawing.Size(147, 40);
            this.btnListarCliente.TabIndex = 0;
            this.btnListarCliente.Text = "Mostrar Clientes";
            this.btnListarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListarCliente.UseVisualStyleBackColor = true;
            this.btnListarCliente.Click += new System.EventHandler(this.btnListarCliente_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCliente.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAgregarCliente.Location = new System.Drawing.Point(156, 3);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(154, 40);
            this.btnAgregarCliente.TabIndex = 1;
            this.btnAgregarCliente.Text = "Agregar Cliente";
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarCliente.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificarCliente.Location = new System.Drawing.Point(316, 3);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(155, 40);
            this.btnModificarCliente.TabIndex = 2;
            this.btnModificarCliente.Text = "Modificar Cliente";
            this.btnModificarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCliente.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminarCliente.Location = new System.Drawing.Point(477, 3);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(158, 40);
            this.btnEliminarCliente.TabIndex = 3;
            this.btnEliminarCliente.Text = "Eliminar Cliente";
            this.btnEliminarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // DGVClientes
            // 
            this.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClientes.Location = new System.Drawing.Point(11, 55);
            this.DGVClientes.Name = "DGVClientes";
            this.DGVClientes.Size = new System.Drawing.Size(614, 291);
            this.DGVClientes.TabIndex = 1;
            // 
            // UcCliente
            // 
            this.Controls.Add(this.DGVClientes);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UcCliente";
            this.Size = new System.Drawing.Size(638, 352);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MenuButton btnListarCliente;
        private MenuButton btnAgregarCliente;
        private MenuButton btnModificarCliente;
        private MenuButton btnEliminarCliente;
        private System.Windows.Forms.DataGridView DGVClientes;
    }
}
