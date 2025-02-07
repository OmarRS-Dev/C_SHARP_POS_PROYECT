namespace Punto_de_venta
{
    partial class frmBuscar
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnexistencia = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.dgbuscar = new System.Windows.Forms.DataGridView();
            this.clcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cldescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clprecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbarticulos = new System.Windows.Forms.ListBox();
            this.trconsulta = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgbuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artículo a buscar:";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(11, 38);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(735, 30);
            this.txtdescripcion.TabIndex = 1;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            this.txtdescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdescripcion_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Punto_de_venta.Properties.Resources.Salir;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(572, 167);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 80);
            this.button2.TabIndex = 2;
            this.button2.Text = "SALIR";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnexistencia
            // 
            this.btnexistencia.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnexistencia.Enabled = false;
            this.btnexistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexistencia.Image = global::Punto_de_venta.Properties.Resources.Existencia;
            this.btnexistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexistencia.Location = new System.Drawing.Point(259, 167);
            this.btnexistencia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnexistencia.Name = "btnexistencia";
            this.btnexistencia.Size = new System.Drawing.Size(275, 80);
            this.btnexistencia.TabIndex = 2;
            this.btnexistencia.Text = "EXISTENCIA";
            this.btnexistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexistencia.UseVisualStyleBackColor = false;
            this.btnexistencia.Click += new System.EventHandler(this.btnexistencia_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnlimpiar.Enabled = false;
            this.btnlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlimpiar.Image = global::Punto_de_venta.Properties.Resources.Salir;
            this.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlimpiar.Location = new System.Drawing.Point(12, 167);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(204, 80);
            this.btnlimpiar.TabIndex = 2;
            this.btnlimpiar.Text = "LIMPIAR";
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            this.btnlimpiar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnlimpiar_KeyPress);
            // 
            // dgbuscar
            // 
            this.dgbuscar.AllowUserToAddRows = false;
            this.dgbuscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgbuscar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgbuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbuscar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clcodigo,
            this.cldescripcion,
            this.clprecio});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgbuscar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgbuscar.Location = new System.Drawing.Point(11, 82);
            this.dgbuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgbuscar.Name = "dgbuscar";
            this.dgbuscar.ReadOnly = true;
            this.dgbuscar.RowHeadersVisible = false;
            this.dgbuscar.RowTemplate.Height = 28;
            this.dgbuscar.Size = new System.Drawing.Size(734, 71);
            this.dgbuscar.TabIndex = 3;
            // 
            // clcodigo
            // 
            this.clcodigo.FillWeight = 45.68528F;
            this.clcodigo.HeaderText = "Codigo";
            this.clcodigo.Name = "clcodigo";
            this.clcodigo.ReadOnly = true;
            this.clcodigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cldescripcion
            // 
            this.cldescripcion.FillWeight = 202.2764F;
            this.cldescripcion.HeaderText = "Descripcion";
            this.cldescripcion.Name = "cldescripcion";
            this.cldescripcion.ReadOnly = true;
            this.cldescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clprecio
            // 
            this.clprecio.FillWeight = 52.03829F;
            this.clprecio.HeaderText = "Precio";
            this.clprecio.Name = "clprecio";
            this.clprecio.ReadOnly = true;
            this.clprecio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lbarticulos
            // 
            this.lbarticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbarticulos.FormattingEnabled = true;
            this.lbarticulos.ItemHeight = 25;
            this.lbarticulos.Location = new System.Drawing.Point(10, 70);
            this.lbarticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbarticulos.Name = "lbarticulos";
            this.lbarticulos.Size = new System.Drawing.Size(735, 129);
            this.lbarticulos.TabIndex = 4;
            this.lbarticulos.Visible = false;
            this.lbarticulos.Click += new System.EventHandler(this.lbarticulos_Click);
            this.lbarticulos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbarticulos_KeyPress);
            this.lbarticulos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbarticulos_KeyUp);
            // 
            // trconsulta
            // 
            this.trconsulta.Interval = 350;
            this.trconsulta.Tick += new System.EventHandler(this.trconsulta_Tick);
            // 
            // frmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(756, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lbarticulos);
            this.Controls.Add(this.dgbuscar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnexistencia);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR ARTICULOS";
            ((System.ComponentModel.ISupportInitialize)(this.dgbuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnexistencia;
        private System.Windows.Forms.DataGridView dgbuscar;
        private System.Windows.Forms.ListBox lbarticulos;
        private System.Windows.Forms.Timer trconsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clprecio;
    }
}