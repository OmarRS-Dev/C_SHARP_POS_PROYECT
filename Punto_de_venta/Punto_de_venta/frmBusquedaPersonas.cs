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
    public partial class frmBusquedaPersonas : Form
    {
        String tabla, nombre;
        frm_Clientes fc;
        frm_Provedores fp;
        frm_Articulos fa;
        byte cnt;

        public frmBusquedaPersonas(String tabla, String nombre,frm_Clientes fc)
        {
            InitializeComponent();
            this.tabla = tabla;
            this.nombre = nombre;
            lbtitulo.Text += tabla.ToUpper();
            this.Text += tabla.ToUpper();
            this.fc = fc;
            cnt = 1;
        }

        public frmBusquedaPersonas(String tabla, String nombre, frm_Provedores fp)
        {
            InitializeComponent();
            this.tabla = tabla;
            this.nombre = nombre;
            lbtitulo.Text += tabla.ToUpper();
            this.Text += tabla.ToUpper();
            this.fp = fp;
            cnt = 2;
        }

        public frmBusquedaPersonas(String tabla, String nombre, frm_Articulos fa)
        {
            InitializeComponent();
            this.tabla = tabla;
            this.nombre = nombre;
            lbtitulo.Text += tabla.ToUpper();
            this.Text += tabla.ToUpper();
            label3.Text = "Descripción";
            this.fa = fa;
            dgBuscar.Columns["clmNombre"].HeaderText = "DESCRIPCIÓN";
            cnt = 3;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            switch (cnt)
            {
                case 1:
                    fc.Show();
                    break;

                case 2:
                    fp.Show();
                    break;
                case 3:
                    fa.Show();
                    break;
            }            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) 
            {
                this.Close();
                switch (cnt) 
                { 
                    case 1:
                        fc.Show();
                     break;
                }
            }

            if (e.KeyChar == 13 && (!string.IsNullOrEmpty(txtNombre.Text)))
            {                
                MySqlConnection cnn = new MySqlConnection(miclase.conexion);
                cnn.Open();
                string sen = "Select "+tabla+".codigo, "+tabla+"."+nombre+" from "+ tabla +" where "+nombre+" like '%" + txtNombre.Text + "%'";
                //MessageBox.Show(sen);
                MySqlCommand com = new MySqlCommand(sen, cnn);
                MySqlDataReader reader = com.ExecuteReader();
                com.Dispose();
                if (reader.HasRows)
                {
                    dgBuscar.Rows.Clear();
                    while (reader.Read())
                    {
                        dgBuscar.Rows.Add(
                              reader["codigo"].ToString(),
                              reader[nombre].ToString()
                              );
                    }                    
                }
                else dgBuscar.Rows.Clear();
                txtNombre.Clear();
            }

        }

        private void dgBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBuscar.Rows.Count > 0 && e.RowIndex >= 0)
            {
                switch (cnt)
                {
                    case 1:
                        fc.resBus(int.Parse(dgBuscar.Rows[e.RowIndex].Cells["clmCódigo"].Value.ToString()));
                        this.Close();
                        fc.Show();
                        break;

                    case 2:
                        fp.resBus(int.Parse(dgBuscar.Rows[e.RowIndex].Cells["clmCódigo"].Value.ToString()));
                        this.Close();
                        fp.Show();
                        break;

                    case 3:
                        fa.resBus(dgBuscar.Rows[e.RowIndex].Cells["clmCódigo"].Value.ToString());
                        this.Close();
                        fa.Show();
                        break;
                }
            }
            this.Close();
        }

        private void frmBusquedaPersonas_Load(object sender, EventArgs e)
        {
            switch (cnt)
            {
                case 1:
                    ClsCliente c = new ClsCliente();
                    DataTable dt = c.Reporte();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgBuscar.Rows.Add(
                            row["codigo"].ToString(),
                            row["nombre"].ToString()
                            );
                    }                
                break;

                case 2:
                ClsProveedor p = new ClsProveedor();
                DataTable dt1 = p.Reporte();
                foreach (DataRow dr in dt1.Rows)
                {
                    dgBuscar.Rows.Add(
                          dr["codigo"].ToString(),
                          dr["nombre"].ToString()
                        );
                }
                break;

                case 3:
                    ClsArticulo a = new ClsArticulo();
                    DataTable dt3 = a.Reporte();
                    foreach (DataRow row in dt3.Rows)
                    {
                     dgBuscar.Rows.Add(
                    row["codigo"].ToString(),
                    row["descripcion"].ToString()
                    );
                   }
                break;
            } 
        }        
    }
}
