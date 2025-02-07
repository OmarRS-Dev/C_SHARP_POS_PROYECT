namespace Punto_de_venta
{
    partial class frm_Articulos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPCompra = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtProvedor = new System.Windows.Forms.TextBox();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgarticulos = new System.Windows.Forms.DataGridView();
            this.clmCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStockMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCodProvedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPVenta = new System.Windows.Forms.TextBox();
            this.lbProv = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgarticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPCompra
            // 
            this.txtPCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCompra.Location = new System.Drawing.Point(699, 118);
            this.txtPCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPCompra.Name = "txtPCompra";
            this.txtPCompra.Size = new System.Drawing.Size(156, 34);
            this.txtPCompra.TabIndex = 11;
            this.txtPCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPCompra_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(173, 118);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(521, 34);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtProvedor
            // 
            this.txtProvedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvedor.Location = new System.Drawing.Point(541, 188);
            this.txtProvedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProvedor.Name = "txtProvedor";
            this.txtProvedor.Size = new System.Drawing.Size(480, 34);
            this.txtProvedor.TabIndex = 14;
            this.txtProvedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvedor_KeyDown);
            this.txtProvedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProvedor_KeyPress);
            // 
            // txtExistencia
            // 
            this.txtExistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExistencia.Location = new System.Drawing.Point(18, 188);
            this.txtExistencia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(165, 34);
            this.txtExistencia.TabIndex = 12;
            this.txtExistencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExistencia_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(18, 118);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(144, 34);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(694, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "P. compra:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(541, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 29);
            this.label6.TabIndex = 3;
            this.label6.Text = "Proveedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Existencia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código:";
            // 
            // txtSMin
            // 
            this.txtSMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSMin.Location = new System.Drawing.Point(199, 188);
            this.txtSMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSMin.Name = "txtSMin";
            this.txtSMin.Size = new System.Drawing.Size(160, 34);
            this.txtSMin.TabIndex = 18;
            this.txtSMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMin_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(194, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Stock min:";
            // 
            // txtSMax
            // 
            this.txtSMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSMax.Location = new System.Drawing.Point(373, 188);
            this.txtSMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSMax.Name = "txtSMax";
            this.txtSMax.Size = new System.Drawing.Size(160, 34);
            this.txtSMax.TabIndex = 20;
            this.txtSMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMax_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(368, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 29);
            this.label8.TabIndex = 19;
            this.label8.Text = "Stock max:";
            // 
            // dgarticulos
            // 
            this.dgarticulos.AllowDrop = true;
            this.dgarticulos.AllowUserToAddRows = false;
            this.dgarticulos.AllowUserToDeleteRows = false;
            this.dgarticulos.AllowUserToOrderColumns = true;
            this.dgarticulos.AllowUserToResizeColumns = false;
            this.dgarticulos.AllowUserToResizeRows = false;
            this.dgarticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgarticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgarticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgarticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCodigo,
            this.clmDescripción,
            this.clmPrecioCompra,
            this.clmPrecioVenta,
            this.clmExistencia,
            this.clmStockMin,
            this.clmStockMax,
            this.clmCodProvedor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgarticulos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgarticulos.Location = new System.Drawing.Point(16, 233);
            this.dgarticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgarticulos.Name = "dgarticulos";
            this.dgarticulos.ReadOnly = true;
            this.dgarticulos.RowHeadersVisible = false;
            this.dgarticulos.RowTemplate.Height = 28;
            this.dgarticulos.Size = new System.Drawing.Size(1005, 344);
            this.dgarticulos.TabIndex = 21;
            this.dgarticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgarticulos_CellClick);
            this.dgarticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgarticulos_CellContentClick);
            this.dgarticulos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgarticulos_KeyPress);
            // 
            // clmCodigo
            // 
            this.clmCodigo.FillWeight = 95.75073F;
            this.clmCodigo.HeaderText = "CÓDIGO";
            this.clmCodigo.Name = "clmCodigo";
            this.clmCodigo.ReadOnly = true;
            // 
            // clmDescripción
            // 
            this.clmDescripción.FillWeight = 143.9235F;
            this.clmDescripción.HeaderText = "DESCRIPCIÓN";
            this.clmDescripción.Name = "clmDescripción";
            this.clmDescripción.ReadOnly = true;
            // 
            // clmPrecioCompra
            // 
            this.clmPrecioCompra.FillWeight = 96.98952F;
            this.clmPrecioCompra.HeaderText = "PRECIO COMPRA";
            this.clmPrecioCompra.Name = "clmPrecioCompra";
            this.clmPrecioCompra.ReadOnly = true;
            // 
            // clmPrecioVenta
            // 
            this.clmPrecioVenta.FillWeight = 86.72142F;
            this.clmPrecioVenta.HeaderText = "PRECIO VENTA";
            this.clmPrecioVenta.Name = "clmPrecioVenta";
            this.clmPrecioVenta.ReadOnly = true;
            // 
            // clmExistencia
            // 
            this.clmExistencia.FillWeight = 116.4305F;
            this.clmExistencia.HeaderText = "EXISTENCIA";
            this.clmExistencia.Name = "clmExistencia";
            this.clmExistencia.ReadOnly = true;
            // 
            // clmStockMin
            // 
            this.clmStockMin.FillWeight = 78.36812F;
            this.clmStockMin.HeaderText = "MÍNIMA";
            this.clmStockMin.Name = "clmStockMin";
            this.clmStockMin.ReadOnly = true;
            // 
            // clmStockMax
            // 
            this.clmStockMax.FillWeight = 76.23244F;
            this.clmStockMax.HeaderText = "MÁXIMA";
            this.clmStockMax.Name = "clmStockMax";
            this.clmStockMax.ReadOnly = true;
            // 
            // clmCodProvedor
            // 
            this.clmCodProvedor.FillWeight = 105.5837F;
            this.clmCodProvedor.HeaderText = "CÓDIGO DE PROVEDOR";
            this.clmCodProvedor.Name = "clmCodProvedor";
            this.clmCodProvedor.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(858, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 29);
            this.label7.TabIndex = 15;
            this.label7.Text = "P. venta:";
            // 
            // txtPVenta
            // 
            this.txtPVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPVenta.Location = new System.Drawing.Point(863, 118);
            this.txtPVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPVenta.Name = "txtPVenta";
            this.txtPVenta.Size = new System.Drawing.Size(158, 34);
            this.txtPVenta.TabIndex = 16;
            this.txtPVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPVenta_KeyPress);
            // 
            // lbProv
            // 
            this.lbProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProv.FormattingEnabled = true;
            this.lbProv.ItemHeight = 29;
            this.lbProv.Location = new System.Drawing.Point(541, 222);
            this.lbProv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbProv.Name = "lbProv";
            this.lbProv.Size = new System.Drawing.Size(480, 120);
            this.lbProv.TabIndex = 26;
            this.lbProv.Visible = false;
            this.lbProv.Click += new System.EventHandler(this.lbProv_Click);
            this.lbProv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbProv_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label9.Location = new System.Drawing.Point(744, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 29);
            this.label9.TabIndex = 29;
            this.label9.Text = "Blvd. Rosales No.1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label10.Location = new System.Drawing.Point(744, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 29);
            this.label10.TabIndex = 28;
            this.label10.Text = "Tienda \"x\"";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(10, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(626, 53);
            this.label11.TabIndex = 27;
            this.label11.Text = "CATALOGO DE ARTICULOS";
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnbuscar.Image = global::Punto_de_venta.Properties.Resources.Consultar;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.Location = new System.Drawing.Point(12, 581);
            this.btnbuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(277, 103);
            this.btnbuscar.TabIndex = 30;
            this.btnbuscar.Text = "Buscar por \r\nnombre ";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::Punto_de_venta.Properties.Resources.Salir;
            this.btnSalir.Location = new System.Drawing.Point(921, 583);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 103);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::Punto_de_venta.Properties.Resources.Eliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(712, 583);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(204, 103);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnModificar.Enabled = false;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Image = global::Punto_de_venta.Properties.Resources.Modificar;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(503, 583);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(204, 103);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::Punto_de_venta.Properties.Resources.Guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(294, 583);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(204, 103);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frm_Articulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1034, 676);
            this.ControlBox = false;
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbProv);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgarticulos);
            this.Controls.Add(this.txtSMax);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPVenta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPCompra);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtProvedor);
            this.Controls.Add(this.txtExistencia);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_Articulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Articulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgarticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPCompra;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtProvedor;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgarticulos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPVenta;
        private System.Windows.Forms.ListBox lbProv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmExistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStockMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCodProvedor;
    }
}