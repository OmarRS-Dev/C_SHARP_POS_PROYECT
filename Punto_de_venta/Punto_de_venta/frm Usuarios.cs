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
    public partial class frm_Usuarios : Form
    {
        public frm_Usuarios()
        {
            InitializeComponent();            
        }
        
        public void limpia()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            CBrol.SelectedIndex = -1;
        }

        public void habilita()
        {
            txtClave.Enabled = true;           
        }

        public void deshabilita()
        {            
            txtClave.Enabled = false;
            CBrol.Enabled = false;
            CBrol.Enabled = false;
        }

        ClsUsuarios u = new ClsUsuarios();
        
        public void llenarDgUsuarios()
        { 
            //dgUsuarios.DataSource= u.Reporte();
            DataTable dt = u.Reporte();
            foreach(DataRow dr in dt.Rows)
            {
                dgUsuarios.Rows.Add(
                      dr["usuario"].ToString(),
                      dr["clave"].ToString(),
                      dr["rol"].ToString()
                    );
            }

            contraseña(dgUsuarios, "clmClave");
        }

        private void contraseña(DataGridView dataGridView, string nombreColumna)
        {
            // Manejar el evento CellFormatting para ocultar el contenido real y mostrar asteriscos
            dataGridView.CellFormatting += (sender, e) =>
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == nombreColumna && e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            };
        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {            
            deshabilita();
            llenarDgUsuarios();            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Hide();
            menu.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            u.usuario = txtUsuario.Text;
            u.clave = txtClave.Text;
            u.rol = CBrol.SelectedItem.ToString();

            if (u.Guardar() == true)
            {
                llenarDgUsuarios();
                MessageBox.Show("Guardado con éxito", "Aviso");
            }
            else
                MessageBox.Show("Error al guardar", "Aviso");

            limpia();            
            deshabilita();
            btnGuardar.Enabled = false;
            txtUsuario.Enabled = true;
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                frmMenu FM = new frmMenu();
                FM.Show();
                this.Close();
            } 
            if (e.KeyChar == 13 && txtUsuario.Text != " ")
            {
                DataTable datos;
                datos = u.consultar(txtUsuario.Text);
                if (datos.Rows.Count > 0)
                {
                    txtClave.Text = datos.Rows[0]["clave"].ToString();
                    string rol = datos.Rows[0]["rol"].ToString();
                    if (CBrol.Items.Contains(rol))
                        CBrol.SelectedItem = rol;
                    btnEliminar.Enabled = true;
                    btnEliminar.Focus();
                }
                else
                {
                    btnGuardar.Enabled = true;
                    habilita();
                    txtClave.Focus();
                }                
                txtUsuario.Enabled = false;              
                
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtClave.Text != " ")
            {
                CBrol.Enabled = true;
                CBrol.Focus();
                txtClave.Enabled = false;
            }
            if (e.KeyChar == 27)
            {
                txtClave.Clear();
                txtClave.Enabled = false;
                txtUsuario.Clear();
                txtUsuario.Enabled = true;
                txtUsuario.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (u.eliminar(txtUsuario.Text) == true)
            {
                llenarDgUsuarios();
                MessageBox.Show("Eliminado con exito");
                btnEliminar.Enabled = false;
                limpia(); //limpiamos los textos 
                deshabilita(); //desabilitamos los textos                
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }

            txtUsuario.Enabled = true; //habilitamos para capturar otro codigo
            txtUsuario.Focus(); //mandamos el cursor
        }        

        private void CBrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && CBrol.SelectedIndex >= 0)
            {
                btnGuardar.Focus();
                CBrol.Enabled = false;
            }
            if (e.KeyChar == 27)
            {
                CBrol.SelectedIndex = -1;
                CBrol.Enabled = false;
                txtClave.Clear();
                txtClave.Enabled=true;
                txtClave.Focus();
            }
        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Enabled = false;
            btnEliminar.Enabled = true;
            txtUsuario.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtClave.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            CBrol.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgUsuarios_CellContentClick(sender, e);
        }
    }
}
