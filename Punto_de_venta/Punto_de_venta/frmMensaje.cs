using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Punto_de_venta
{
    public partial class frmMensaje : Form
    {
        Timer timer = new Timer();

        public frmMensaje(String texto)
        {
            InitializeComponent();
            this.lbmensaje.Text = texto;
        }

        private void frmMensaje_Load(object sender, EventArgs e)
        {
            btnAceptar.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
