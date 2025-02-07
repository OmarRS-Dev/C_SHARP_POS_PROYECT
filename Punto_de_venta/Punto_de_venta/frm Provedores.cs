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
    public partial class frm_Provedores : Form
    {
        public frm_Provedores()
        {
            InitializeComponent();
        }

        ClsProveedor p = new ClsProveedor();

        public void eliminar(frmValidar v)
        {
            if (p.eliminar(int.Parse(txtCodigo.Text)) == true)
            {
                frmMensaje m = new frmMensaje("Eliminado con exito");
                m.ShowDialog();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                desactiva(); //desabilitamos los textos
                llenarDgProvedores();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al eliminar");
                m.ShowDialog();
            }

            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString();
            txtCodigo.Enabled = true;
            v.Close();
            
            this.BeginInvoke((Action)(() => txtCodigo.Focus()));
        }

        public void resBus(int cod)
        {
            DataTable datos;
            datos = p.consultar(cod);
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

        public void desactiva()
        {
            txtRfc.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show(); 
        }

        public void llenarDgProvedores()
        {            
            dgprovedores1.Rows.Clear();
            DataTable dt = p.Reporte();
            foreach (DataRow row in dt.Rows)
            {
                dgprovedores1.Rows.Add(
                    row["codigo"].ToString(),
                    row["rfc"].ToString(),
                    row["nombre"].ToString(),
                    row["direccion"].ToString(),
                    row["telefono"].ToString(),
                    row["email"].ToString()
                );
            }
        }

        private void frm_Provedores_Load(object sender, EventArgs e)
        {
            desactiva();
            llenarDgProvedores();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                frmMenu FM = new frmMenu();
                FM.Show();
                this.Close();
            } 
            if (e.KeyChar == 13 && txtCodigo.Text != "")
            {
                DataTable datos;
                datos = p.consultar(int.Parse(txtCodigo.Text));
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
            p.codigo = int.Parse(txtCodigo.Text);
            p.rfc = txtRfc.Text;
            p.nombre = txtNombre.Text;
            p.dirección = txtDireccion.Text;
            p.telefono = txtTelefono.Text;
            p.email = txtEmail.Text;
            if (p.modificar() == true)
            {
                frmMensaje m = new frmMensaje("Modificado con exito");
                m.ShowDialog();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                limpia(); //limpiamos los textos 
                desactiva(); //desabilitamos los textos
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al modificar");
                m.ShowDialog();
            }
            txtCodigo.Text = (miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString());
            txtCodigo.Enabled = true; //habilitamos para capturar otro codigo
            txtCodigo.Focus(); //mandamos el cursor 
            llenarDgProvedores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmValidar v = new frmValidar("¿Eliminar este provedor?", this);
            v.ShowDialog();
        }

        private void txtRfc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)txtNombre.Focus();               
            
            if (e.KeyChar == 27)
            {
                limpia();
                txtCodigo.Enabled = true;
                txtCodigo.Text = miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString();
                txtCodigo.Focus();
                deshabilita();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtDireccion.Focus();
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
                if (btnGuardar.Enabled == true)
                    btnGuardar.Focus();
                else btnModificar.Focus();
            }
            if (e.KeyChar == 27) txtTelefono.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            p.codigo = int.Parse(txtCodigo.Text);
            p.rfc = txtRfc.Text;
            p.nombre = txtNombre.Text;
            p.dirección = txtDireccion.Text;
            p.telefono = txtTelefono.Text;
            p.email = txtEmail.Text;
            if (p.guardar() == true)
            {
                llenarDgProvedores();
                frmMensaje m = new frmMensaje("Guardado con éxito");
                m.ShowDialog();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al guardar");
                m.ShowDialog();
            }

            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString();
            desactiva();
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = true;
            txtCodigo.Focus();            
        }

        private void dgprovedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            limpia();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString();
            deshabilita();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmMenu FM = new frmMenu();
            this.Close();
            FM.Show();
        }

        private void dgprovedores1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            habilita();
            txtCodigo.Enabled=false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            txtCodigo.Text = dgprovedores1.CurrentRow.Cells[0].Value.ToString();
            txtRfc.Text = dgprovedores1.CurrentRow.Cells[1].Value.ToString();            
            txtNombre.Text = dgprovedores1.CurrentRow.Cells[2].Value.ToString();
            txtDireccion.Text = dgprovedores1.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dgprovedores1.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dgprovedores1.CurrentRow.Cells[5].Value.ToString();

        }

        private void dgprovedores1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgprovedores1_CellContentClick(sender, e);
        }

        private void dgprovedores1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                limpia();
                txtCodigo.Enabled = true;
                txtCodigo.Focus();
                txtCodigo.Text = miclase.FolioSiguiente("codigo", "PROVEEDORES").ToString();
                deshabilita();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaPersonas fb = new frmBusquedaPersonas("proveedores", "nombre", this);
            this.Hide();
            fb.ShowDialog();
            
        }
                        
    }
}
