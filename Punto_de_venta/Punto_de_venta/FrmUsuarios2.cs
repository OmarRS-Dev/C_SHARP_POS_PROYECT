using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lib01;

namespace Punto_de_venta
{
    public partial class FrmUsuarios2 : Form
    {
        public FrmUsuarios2()
        {
            InitializeComponent();
        }

        string[] cn = { "127.0.0.1", "root", "root1234", "bdpime" };

        private void btnSalir_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        public void actualizardg()
        {
            dgUsuarios.DataSource = (L1.Reporte(cn, "Select * from usuarios"));
            contraseña(dgUsuarios, "clave");
        }

        private void FrmUsuarios2_Load(object sender, EventArgs e)
        {
            actualizardg();
            CBrol.SelectedIndex = 0;
        }

        private void FrmUsuarios2_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenu mu = new frmMenu();
            mu.Show();
        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtClave.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            CBrol.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
            btnEliminar.Enabled = true;
        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgUsuarios_CellContentClick(sender,e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(L1.Eliminar(cn,"usuarios",txtUsuario.Text));
            actualizardg();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
