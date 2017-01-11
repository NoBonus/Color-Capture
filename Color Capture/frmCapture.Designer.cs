namespace Color_Capture
{
    partial class frmCapture
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCapture = new System.Windows.Forms.Button();
            this.txtHtmlColor = new System.Windows.Forms.TextBox();
            this.pnlSelColor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Location = new System.Drawing.Point(12, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(24, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // txtHtmlColor
            // 
            this.txtHtmlColor.Location = new System.Drawing.Point(75, 12);
            this.txtHtmlColor.Name = "txtHtmlColor";
            this.txtHtmlColor.ReadOnly = true;
            this.txtHtmlColor.Size = new System.Drawing.Size(197, 20);
            this.txtHtmlColor.TabIndex = 1;
            this.txtHtmlColor.TabStop = false;
            // 
            // pnlSelColor
            // 
            this.pnlSelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelColor.Location = new System.Drawing.Point(42, 12);
            this.pnlSelColor.Name = "pnlSelColor";
            this.pnlSelColor.Size = new System.Drawing.Size(27, 23);
            this.pnlSelColor.TabIndex = 2;
            // 
            // frmCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pnlSelColor);
            this.Controls.Add(this.txtHtmlColor);
            this.Controls.Add(this.btnCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCapture";
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox txtHtmlColor;
        private System.Windows.Forms.Panel pnlSelColor;
    }
}

