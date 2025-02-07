using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Punto_de_venta
{
    public partial class frm_Articulos : Form
    {
        public frm_Articulos()
        {
            InitializeComponent();
        }

        ClsArticulo a = new ClsArticulo();

        public void eliminar(frmValidar v)
        {
            a.codigo = txtCodigo.Text;
            if (a.eliminar(a.codigo) == true)
            {
                llenarDgArticulos();
                frmMensaje m = new frmMensaje("Eliminado con exito");
                m.ShowDialog();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al eliminar");
                m.ShowDialog();
            }

            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "articulos").ToString();
            deshabilita();
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = true;
            v.Close();
            llenarDgArticulos();
            this.BeginInvoke((Action)(() => txtCodigo.Focus()));
        }

        public void resBus(String Cod)
        {
            DataTable datos;
            datos = a.consultar(Cod);
            if (datos.Rows.Count > 0)
            {
                txtCodigo.Text = Cod;
                txtDescripcion.Text = datos.Rows[0]["descripcion"].ToString();
                txtPCompra.Text = datos.Rows[0]["p_compra"].ToString();
                txtPVenta.Text = datos.Rows[0]["p_venta"].ToString();
                txtExistencia.Text = datos.Rows[0]["existencia"].ToString();
                txtSMin.Text = datos.Rows[0]["stockmin"].ToString();
                txtSMax.Text = datos.Rows[0]["stockmax"].ToString();
                txtProvedor.Text = Traer_nombre_Proveedor(int.Parse(datos.Rows[0]["codprovedor"].ToString()));
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                habilita();
            }
        }

        public void deshabilita()
        {
            txtDescripcion.Enabled = false;
            txtPCompra.Enabled = false;
            txtPVenta.Enabled = false;
            txtExistencia.Enabled = false;
            txtSMin.Enabled = false;
            txtSMax.Enabled = false;
            txtProvedor.Enabled = false;
        }

        public void limpia()
        {
            txtDescripcion.Clear();
            txtPCompra.Clear();
            txtPVenta.Clear();
            txtExistencia.Clear();
            txtSMin.Clear();
            txtSMax.Clear();
            txtProvedor.Clear();
        }

        public void habilita()
        {
            txtDescripcion.Enabled = true;
            txtPCompra.Enabled = true;
            txtPVenta.Enabled = true;
            txtExistencia.Enabled = true;
            txtSMin.Enabled = true;
            txtSMax.Enabled = true;
            txtProvedor.Enabled = true;
        }

        public void llenarDgArticulos()
        {
            dgarticulos.Rows.Clear();
            DataTable dt = a.Reporte();
            foreach (DataRow row in dt.Rows)
            {
                dgarticulos.Rows.Add(
                    row["codigo"].ToString(),
                    row["descripcion"].ToString(),
                    row["p_compra"].ToString(),
                    row["p_venta"].ToString(),
                    row["existencia"].ToString(),
                    row["stockmin"].ToString(),
                    row["stockmax"].ToString(),
                    row["codprovedor"].ToString()
                );
            }
        }

        private void frm_Articulos_Load(object sender, EventArgs e)
        {
            deshabilita();
            llenarDgArticulos();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "articulos").ToString();
        }

        private string Traer_nombre_Proveedor(int cod)
        {

            string nombre="";
            MySqlConnection cnn = new MySqlConnection(miclase.conexion);
            cnn.Open();
            MySqlCommand comando = new MySqlCommand("Select nombre from proveedores where codigo='" + cod + "'", cnn);
            MySqlDataReader myreader = comando.ExecuteReader();
            comando.Dispose();
            if (myreader.HasRows)
                while (myreader.Read())
                    nombre = (myreader["nombre"].ToString());
            myreader.Close(); cnn.Close(); cnn.Dispose();
            return nombre;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            miclase.SoloNumeros(e);
            if (e.KeyChar == 27) btnSalir_Click(sender, e);
            if (e.KeyChar == 13 && txtCodigo.Text != " ")
            {
                DataTable datos;
                datos = a.consultar((txtCodigo.Text));
                if (datos.Rows.Count > 0)
                {
                    txtDescripcion.Text = datos.Rows[0]["descripcion"].ToString();
                    txtPCompra.Text = datos.Rows[0]["p_compra"].ToString();
                    txtPVenta.Text = datos.Rows[0]["p_venta"].ToString();
                    txtExistencia.Text = datos.Rows[0]["existencia"].ToString();
                    txtSMin.Text = datos.Rows[0]["stockmin"].ToString();
                    txtSMax.Text = datos.Rows[0]["stockmax"].ToString();
                    txtProvedor.Text = Traer_nombre_Proveedor( int.Parse(datos.Rows[0]["codprovedor"].ToString()));
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                    btnGuardar.Enabled = true;

                txtCodigo.Enabled = false;
                habilita();
                txtDescripcion.Focus();               
            }
         }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            a.codigo = txtCodigo.Text;
            a.descripcion = txtDescripcion.Text;
            a.pcompra = float.Parse(txtPCompra.Text);
            a.pventa = float.Parse(txtPVenta.Text);
            a.existencia = float.Parse(txtExistencia.Text);
            a.maximo = float.Parse(txtSMax.Text);
            a.minimo = float.Parse(txtSMin.Text);
            a.codprovedor = Traercodigoprovedor(txtProvedor.Text);
            if (a.modificar() == true)
            {
                llenarDgArticulos();
                frmMensaje m = new frmMensaje("Modificado con exito");
                m.ShowDialog();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al modificar");
                m.ShowDialog();
            }

            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "articulos").ToString();
            deshabilita();
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = true;
            txtCodigo.Focus();       
        }        

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtPCompra.Focus();
            if (e.KeyChar == 27)
            {
                limpia();
                txtCodigo.Enabled = true;
                txtCodigo.Clear();
                txtCodigo.Focus();
                deshabilita();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtPVenta.Focus();
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27) txtDescripcion.Focus();
        }

        private void txtPVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtExistencia.Focus();
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27) txtPCompra.Focus();
        }

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtSMin.Focus();
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27) txtPVenta.Focus();
        }

        private void txtSMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtSMax.Focus();
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27) txtExistencia.Focus();
        }

        private void txtSMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtProvedor.Focus();
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27) txtSMin.Focus();
        }

        string dato;
        int pos;

        private void txtProvedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                lbProv.Visible = false;
                txtProvedor.Clear();
                txtSMax.Focus();
            }
            else
            {
                MySqlConnection cnn = new MySqlConnection(miclase.conexion);
                cnn.Open();
                string sen = "Select * from proveedores where nombre like '%" + txtProvedor.Text + "%'";
                MySqlCommand com = new MySqlCommand(sen, cnn);
                try
                {
                    MySqlDataReader reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        lbProv.Visible = true;
                        lbProv.Items.Clear();
                        while (reader.Read())
                        { 
                            lbProv.Items.Add("[" + reader.GetValue(0) + "] " + reader.GetValue(2).ToString());
                        }
                        reader.Close();
                    }   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);  
                }
            }

        }

        public int Traercodigoprovedor(String nopro)
        {
            int cp=0;
            MySqlConnection cnn = new MySqlConnection(miclase.conexion);
            cnn.Open();
            MySqlCommand comando = new MySqlCommand("Select codigo from proveedores where nombre='" + nopro + "'", cnn);
            MySqlDataReader myreader = comando.ExecuteReader();
            comando.Dispose();
            if (myreader.HasRows)
                while (myreader.Read())
                   cp = Int32.Parse(myreader["codigo"].ToString());
            myreader.Close(); cnn.Close(); cnn.Dispose();
            return cp;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            a.codigo = txtCodigo.Text;
            a.descripcion = txtDescripcion.Text;
            a.pcompra = float.Parse(txtPCompra.Text);
            a.pventa = float.Parse(txtPVenta.Text);
            a.existencia = float.Parse(txtExistencia.Text);
            a.maximo = float.Parse(txtSMax.Text);
            a.minimo = float.Parse(txtSMin.Text);
            a.codprovedor = Traercodigoprovedor(txtProvedor.Text);
            if (a.Guardar() == true)
            {
                llenarDgArticulos();
                frmMensaje m = new frmMensaje("Guardado con éxito");
                m.ShowDialog();
            }
            else
            {
                frmMensaje m = new frmMensaje("Error al guardar");
                m.ShowDialog();
            }

            limpia();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "articulos").ToString();
            deshabilita();
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = true;
            txtCodigo.Focus();        
        }

        private void dgarticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            habilita();
            txtCodigo.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            txtCodigo.Text = dgarticulos.CurrentRow.Cells[0].Value.ToString();
            txtDescripcion.Text = dgarticulos.CurrentRow.Cells[1].Value.ToString();
            txtPCompra.Text = dgarticulos.CurrentRow.Cells[2].Value.ToString();
            txtPVenta.Text = dgarticulos.CurrentRow.Cells[3].Value.ToString();
            txtExistencia.Text = dgarticulos.CurrentRow.Cells[4].Value.ToString();
            txtSMin.Text = dgarticulos.CurrentRow.Cells[5].Value.ToString();
            txtSMax.Text = dgarticulos.CurrentRow.Cells[6].Value.ToString();
            txtProvedor.Text = Traer_nombre_Proveedor(int.Parse(dgarticulos.CurrentRow.Cells[7].Value.ToString()));
        }

        private void dgarticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgarticulos_CellContentClick(sender, e);
        }

        private void txtProvedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40) //si se presionó la flecha hacia abajo
            {
                lbProv.Focus();
                lbProv.SetSelected(0, true);
            }
        }

        public void obtener_nombre_proveedor()
        {
            try
            {
                dato = lbProv.SelectedItem.ToString();
                pos = lbProv.SelectedItem.ToString().IndexOf("]")+2;                
                txtProvedor.Text = dato.Substring(pos);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void lbProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                obtener_nombre_proveedor();
                lbProv.Visible = false;
                if (btnGuardar.Enabled == true) btnGuardar.Focus(); else btnModificar.Focus();
            }
        }

        private void lbProv_Click(object sender, EventArgs e)
        {
            obtener_nombre_proveedor();
            lbProv.Visible = false;
            if (btnGuardar.Enabled == true) btnGuardar.Focus(); else btnModificar.Focus();            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmValidar v = new frmValidar("¿Eliminar este articulo?", this);
            v.ShowDialog();
        }

        private void dgarticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            limpia();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
            txtCodigo.Text = miclase.FolioSiguiente("codigo", "ARTICULOS").ToString();
            deshabilita();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaPersonas fb = new frmBusquedaPersonas("articulos", "descripcion", this);
            this.Hide();
            fb.ShowDialog();
            
        }
    }
}
