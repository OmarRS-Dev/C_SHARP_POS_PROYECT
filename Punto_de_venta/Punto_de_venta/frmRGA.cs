using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Punto_de_venta
{
    public partial class frmRGA : Form
    {
        public frmRGA()
        {
            InitializeComponent();
        }

        private void frmRGA_Load(object sender, EventArgs e)
        {
            //creando la variable para parametros
            ReportParameter[] parametros = new ReportParameter[2];

            //agregar los 3 parametros
            parametros[0] = new ReportParameter("empresa","Tienda x");
            parametros[1] = new ReportParameter("direccion", "Blvd. Rosales. No.01");

            //agregamos los parametros al reporte
            this.reportViewer1.LocalReport.SetParameters(parametros);

            //cargamos los archivos con los datos (xml)
            ds_dsarticulos.ReadXml("dsarticulos.xml");

            //pasamos los datos al reporte
            TableBindingSource.DataSource = ds_dsarticulos;

            //mostramos el reporte 
            this.reportViewer1.RefreshReport();
        }

    }
}
