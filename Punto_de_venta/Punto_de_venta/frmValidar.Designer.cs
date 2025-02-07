namespace Punto_de_venta
{
    partial class frmValidar
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
            this.lbmensaje = new System.Windows.Forms.Label();
            this.btnsi = new System.Windows.Forms.Button();
            this.btnno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbmensaje
            // 
            this.lbmensaje.AutoSize = true;
            this.lbmensaje.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmensaje.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbmensaje.Location = new System.Drawing.Point(12, 9);
            this.lbmensaje.Name = "lbmensaje";
            this.lbmensaje.Size = new System.Drawing.Size(64, 26);
            this.lbmensaje.TabIndex = 3;
            this.lbmensaje.Text = "Error\r\n";
            // 
            // btnsi
            // 
            this.btnsi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsi.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnsi.Image = global::Punto_de_venta.Properties.Resources.verificar1;
            this.btnsi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsi.Location = new System.Drawing.Point(12, 46);
            this.btnsi.Name = "btnsi";
            this.btnsi.Size = new System.Drawing.Size(153, 49);
            this.btnsi.TabIndex = 0;
            this.btnsi.Text = "SI";
            this.btnsi.UseVisualStyleBackColor = false;
            this.btnsi.Click += new System.EventHandler(this.btnsi_Click);
            this.btnsi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnsi_KeyPress);
            // 
            // btnno
            // 
            this.btnno.BackColor = System.Drawing.Color.SteelBlue;
            this.btnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnno.Image = global::Punto_de_venta.Properties.Resources.Cancel;
            this.btnno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnno.Location = new System.Drawing.Point(234, 46);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(153, 49);
            this.btnno.TabIndex = 1;
            this.btnno.Text = "NO";
            this.btnno.UseVisualStyleBackColor = false;
            this.btnno.Click += new System.EventHandler(this.btnno_Click);
            // 
            // frmValidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(399, 92);
            this.ControlBox = false;
            this.Controls.Add(this.lbmensaje);
            this.Controls.Add(this.btnsi);
            this.Controls.Add(this.btnno);
            this.Name = "frmValidar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbmensaje;
        private System.Windows.Forms.Button btnno;
        private System.Windows.Forms.Button btnsi;
    }
}