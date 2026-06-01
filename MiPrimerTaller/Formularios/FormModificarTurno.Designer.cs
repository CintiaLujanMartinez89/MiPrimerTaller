
namespace MiPrimerTaller.Formularios
{
    partial class FormModificarTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormModificarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FormModificarTurno";
            this.Text = "FormModificarTurno";
          
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtMoto;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

    }
}