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
    public partial class frmBuscar : Form
    {
        public frmBuscar()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdescripcion.Text))
            {
                lbarticulos.Visible = false;
            } 
            if (e.KeyChar == 27)
            {
                btnsalir_Click(sender, e);
            }
            else
            {
                trconsulta.Stop();
                trconsulta.Start();
            }
        }

        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                lbarticulos.Focus();
                lbarticulos.SetSelected(0,true);
            }
        }

        private void lbarticulos_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                lbarticulos_Click(sender, e);
            }
        }

        private void lbarticulos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && lbarticulos.SelectedIndex == 0)
            {
                txtdescripcion.Focus();
                lbarticulos.Visible = false;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtdescripcion.Clear();
            txtdescripcion.Enabled = true;
            txtdescripcion.Focus();
            dgbuscar.Rows.Clear();
            btnexistencia.Enabled = false;
            btnlimpiar.Enabled = false;
        }

        private void btnexistencia_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection(miclase.conexion);
            cnn.Open();
            string sen = "Select * from articulos where descripcion like '%" + txtdescripcion.Text + "%'";
            MySqlCommand com = new MySqlCommand(sen, cnn);
            MySqlDataReader reader = com.ExecuteReader();
            com.Dispose();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show("Hay " + reader["existencia"].ToString() + " unidades en existencia de " + reader["descripcion"].ToString(), "EXISTENCIA");
                }
            }
        }

        private void lbarticulos_Click(object sender, EventArgs e)
        {
            string des = lbarticulos.SelectedItem.ToString();
            MySqlConnection cnn = new MySqlConnection(miclase.conexion);
            cnn.Open();
            string sen = "Select codigo, descripcion, p_venta from articulos where descripcion like '%" + des + "%'";
            MySqlCommand com = new MySqlCommand(sen, cnn);
            MySqlDataReader reader = com.ExecuteReader();
            com.Dispose();
            if (reader.HasRows)
            {                
                txtdescripcion.Clear();
                txtdescripcion.Enabled = false;
                while (reader.Read())
                {
                    dgbuscar.Rows.Add(reader["codigo"].ToString(), reader["descripcion"].ToString(), reader["p_venta"].ToString());
                    //dgbuscar.Rows[0].Cells[1].Value = reader["descripcion"].ToString();
                    //dgbuscar.Rows[0].Cells[2].Value = reader["p_venta"].ToString();
                }
            }
            txtdescripcion.Text = des;
            txtdescripcion.Enabled = false;
            lbarticulos.Visible = false;
            btnlimpiar.Enabled = true;
            btnlimpiar.Focus();
            btnexistencia.Enabled = true;
        }

        private void trconsulta_Tick(object sender, EventArgs e)
        {
            trconsulta.Stop();
            string entrada = txtdescripcion.Text.Trim();
            MySqlConnection cnn = new MySqlConnection(miclase.conexion);
            cnn.Open();
            string sen = "SELECT descripcion FROM articulos WHERE descripcion LIKE @descripcion";
            MySqlCommand com = new MySqlCommand(sen, cnn);
            com.Parameters.AddWithValue("@descripcion", "%" + entrada + "%");
            try
            {
                MySqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    lbarticulos.Visible = true;
                    lbarticulos.Items.Clear();
                    while (reader.Read())
                    {
                        lbarticulos.Items.Add(reader.GetValue(0).ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlimpiar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==27)btnsalir_Click(sender,e);
        }
    }
}
