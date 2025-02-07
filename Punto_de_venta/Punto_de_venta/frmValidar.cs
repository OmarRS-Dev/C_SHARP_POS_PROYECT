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
    public partial class frmValidar : Form
    {
        frm_Clientes fc;
        frm_Provedores fp;
        frm_Articulos fa;
        frmVentas fv;
        byte tf;

        public frmValidar(String mensaje, frmVentas fv)
        {
            InitializeComponent();
            lbmensaje.Text = mensaje;
            this.fv = fv;
            this.tf = 1;
        }

        public frmValidar(String mensaje, frm_Clientes fc)
        {
            InitializeComponent();
            lbmensaje.Text = mensaje;
            this.fc = fc;
            this.tf = 2;
        }

        public frmValidar(String mensaje, frm_Provedores fp)
        {
            InitializeComponent();
            lbmensaje.Text = mensaje;
            this.fp = fp;
            this.tf = 3;
        }

        public frmValidar(String mensaje, frm_Articulos fa)
        {
            InitializeComponent();
            lbmensaje.Text = mensaje;
            this.fa = fa;
            this.tf = 4;
        }

        private void btnsi_Click(object sender, EventArgs e)
        {
            switch (tf)
            {
                case 1:
                        fv.venderFuera();
                        this.Close();                    
                break;

                case 2:
                    fc.eliminar(this);
                break;

                case 3:
                    fp.eliminar(this);
                break;

                case 4:
                    fa.eliminar(this);
                break;
            }
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}
