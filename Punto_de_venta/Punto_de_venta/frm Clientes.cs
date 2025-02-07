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
    public partial class frm_Clientes : Form
    {
        public frm_Clientes()
        {
            InitializeComponent();
        }

        public void deshabilita()
        {
            txtRfc.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
        }

        public void limpia()
        {
            txtCodigo.Clear();
            txtRfc.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }

        public void habilita()
        {
            txtRfc.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
        }

        ClsCliente c = new ClsCliente();

        public void eliminar(frmValidar v)
        {
            if (c.eliminar(int.Parse(txtCodigo.Text)) == true)
            {
                frmMensaje m = new frmMensaje("Eliminado con exito");
                m.ShowDialog();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false; 
                deshabilita(); //desabilitamos los textos                
                llenarDgClientes();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al eliminar");
                m.ShowDialog();
            }

            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "clientes").ToString();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();            
            v.Close();
            this.BeginInvoke((Action)(() => txtCodigo.Focus()));
        }

        public void resBus(int cod) 
        {
            DataTable datos;
            datos = c.consultar(cod);
            if (datos.Rows.Count > 0)
            {
                txtCodigo.Text = cod.ToString();
                txtRfc.Text = datos.Rows[0]["rfc"].ToString();
                txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                txtDireccion.Text = datos.Rows[0]["direccion"].ToString();
                txtEmail.Text = datos.Rows[0]["email"].ToString();
                txtTelefono.Text = datos.Rows[0]["telefono"].ToString();
                txtCodigo.Enabled = false;
                habilita();
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                txtRfc.Focus();
            }
        }

         public void llenarDgClientes()
        {
            dgclientes.Rows.Clear();
            DataTable dt = c.Reporte(); 
            foreach (DataRow row in dt.Rows)
            {
                dgclientes.Rows.Add(
                    row["codigo"].ToString(),
                    row["rfc"].ToString(),
                    row["nombre"].ToString(),
                    row["direccion"].ToString(),
                    row["telefono"].ToString(),
                    row["email"].ToString()
                );
            }
        } 

        private void frm_Clientes_Load(object sender, EventArgs e)
        {            
            deshabilita();          
            llenarDgClientes();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "clientes").ToString();            
        }       

        private void button4_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }
 
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            miclase.SoloNumeros(e);
            if (e.KeyChar == 27) button4_Click(sender, e);
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable datos;
                datos=c.consultar(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count > 0)
                {
                    txtRfc.Text = datos.Rows[0]["rfc"].ToString();
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    txtDireccion.Text = datos.Rows[0]["direccion"].ToString();
                    txtEmail.Text = datos.Rows[0]["email"].ToString();
                    txtTelefono.Text = datos.Rows[0]["telefono"].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                    btnGuardar.Enabled = true;
                
                txtCodigo.Enabled = false;
                    habilita();
                    txtRfc.Focus();                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            c.codigo = int.Parse(txtCodigo.Text);
            c.rfc = txtRfc.Text;
            c.nombre = txtNombre.Text;
            c.dirección = txtDireccion.Text;
            c.telefono = txtTelefono.Text;
            c.email = txtEmail.Text;
            if (c.modificar() == true)
            {
                frmMensaje m = new frmMensaje("Modificado con exito");
                m.ShowDialog();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                limpia(); //limpiamos los textos 
                deshabilita(); //desabilitamos los textos                
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al modificar");
                m.ShowDialog();
                limpia();
            }
            txtCodigo.Text = (miclase.FolioSiguiente("codigo", "clientes").ToString());
            txtCodigo.Enabled = true; //habilitamos para capturar otro codigo
            txtCodigo.Focus(); //mandamos el cursor 
            llenarDgClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmValidar v = new frmValidar("¿Eliminar este cliente?", this);
            v.ShowDialog();
        }

        private void txtRfc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtNombre.Focus();
            if (e.KeyChar == 27)
            {
                limpia();
                txtCodigo.Enabled = true;
                txtCodigo.Text = miclase.FolioSiguiente("codigo", "CLIENTES").ToString();
                txtCodigo.Focus();
                deshabilita();
                btnModificar.Enabled=false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtDireccion.Focus();
            if (e.KeyChar == 27) txtRfc.Focus();
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtTelefono.Focus();
            if (e.KeyChar == 27) txtNombre.Focus();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtEmail.Focus();
            miclase.SoloNumeros(e);
            if (e.KeyChar == 27) txtDireccion.Focus();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                if(btnGuardar.Enabled==true)
                btnGuardar.Focus();
                else btnModificar.Focus();
            }
            if (e.KeyChar == 27) txtTelefono.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            c.codigo = int.Parse(txtCodigo.Text);
            c.rfc = txtRfc.Text;
            c.nombre = txtNombre.Text;
            c.dirección = txtDireccion.Text;
            c.telefono = txtTelefono.Text;
            c.email = txtEmail.Text;
            if (c.guardar() == true)
            {
                llenarDgClientes();
                frmMensaje m = new frmMensaje("Guardado con éxito");
                m.ShowDialog();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al guardar");
                m.ShowDialog();
            }
           
            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "clientes").ToString(); 
            deshabilita();
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = true;
            txtCodigo.Focus();            
        }

        private void dgclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            habilita();
            txtCodigo.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            txtCodigo.Text = dgclientes.CurrentRow.Cells[0].Value.ToString();
            txtRfc.Text = dgclientes.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgclientes.CurrentRow.Cells[2].Value.ToString();
            txtDireccion.Text = dgclientes.CurrentRow.Cells[3].Value.ToString();            
            txtTelefono.Text = dgclientes.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dgclientes.CurrentRow.Cells[5].Value.ToString();
        }

        private void dgclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgclientes_CellContentClick(sender, e);
        }

        private void dgclientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==27)
            {
                limpia();
                txtCodigo.Enabled = true;
                txtCodigo.Focus();
                txtCodigo.Text = miclase.FolioSiguiente("codigo", "CLIENTES").ToString();
                deshabilita();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }
        

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaPersonas fb = new frmBusquedaPersonas("clientes", "nombre",this);
            this.Hide();
            fb.ShowDialog();
            txtCodigo.Focus();
        }
    }
}