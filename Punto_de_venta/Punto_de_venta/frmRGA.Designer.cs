namespace Punto_de_venta
{
    partial class frmRGA
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ds_dsarticulos = new Punto_de_venta.NewDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dsarticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // TableBindingSource
            // 
            this.TableBindingSource.DataMember = "Table";
            this.TableBindingSource.DataSource = this.ds_dsarticulos;
            // 
            // ds_dsarticulos
            // 
            this.ds_dsarticulos.DataSetName = "NewDataSet";
            this.ds_dsarticulos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsrga";
            reportDataSource1.Value = this.TableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Punto_de_venta.RGA.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1207, 617);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmRGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 617);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRGA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRGA";
            this.Load += new System.EventHandler(this.frmRGA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dsarticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TableBindingSource;
        private NewDataSet ds_dsarticulos;

    }
}