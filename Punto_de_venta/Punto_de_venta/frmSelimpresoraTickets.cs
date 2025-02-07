using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Punto_de_venta
{
    public partial class frmSelimpresoraTickets : Form
    {
        public frmSelimpresoraTickets()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //almacenar la inpresora seleccionada



            //cerrar el formulario y mostrar el menú
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }

        private void frmSelimpresoraTickets_Load(object sender, EventArgs e)
        {
            llenarcomboimpresoras();
        }

        private void llenarcomboimpresoras()
        {
            String impresorasIns;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i+=1)
            {
                impresorasIns = PrinterSettings.InstalledPrinters[i];
                cbimpresoras.Items.Add(impresorasIns);
            }
        }
    }
}
