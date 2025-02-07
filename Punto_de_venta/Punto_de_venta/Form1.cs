using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Punto_de_venta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMenu FM = new frmMenu();
            FM.Show();
            this.Hide(); //ocultar este formulario (form1)
        }

        public void RestaurarBD()
        {
            OpenFileDialog ventana = new OpenFileDialog();
            ventana.Filter = "Archivos SQL (.sql)|*.sql";

            if (ventana.ShowDialog() == DialogResult.OK)
            {
                string archivoRespaldo = ventana.FileName;
                string usuario = ClsServidor.usuariobd;
                string contraseña = ClsServidor.clavebd;
                string baseDatos = ClsServidor.nombreBD;

                // Comando para restaurar la base de datos
                //string comando = "mysql -u " + usuario + " --password=" + contraseña + " " + baseDatos + " < \"" + archivoRespaldo + "\"";
                string comando = "mysql -u " + usuario + " --password=" + contraseña + " " + baseDatos + " -e \"source " + archivoRespaldo + "\" 2> nul";
                //MessageBox.Show(comando);

                try
                {
                    // Crear el proceso para ejecutar el comando
                    ProcessStartInfo startInfo = new ProcessStartInfo()
                    {
                        FileName = "cmd.exe", // Usamos cmd.exe para ejecutar el comando de MySQL
                        Arguments = "/c " + comando, // /c permite ejecutar el comando y cerrar la terminal después
                        RedirectStandardOutput = true, // Redirigir la salida estándar (útil para depuración)
                        RedirectStandardError = true,  // Redirigir los errores
                        UseShellExecute = false,      // Necesario para redirigir la salida
                        CreateNoWindow = true         // No crear ventana de cmd
                    };

                    // Iniciar el proceso
                    using (Process process = Process.Start(startInfo))
                    {
                        if (process != null)
                        {
                            // Leer la salida del proceso
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();

                            if (string.IsNullOrEmpty(error))
                            {
                                MessageBox.Show("La base de datos se ha restaurado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al restaurar la base de datos: " + archivoRespaldo + "  " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo iniciar el proceso para restaurar la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool CrearBD()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection
                    ("server = 127.0.0.1; userid = root; password=root1234;");
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "use mysql;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "create database bdpimes; use bdpimes;";
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EliminarBD()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection
                    ("server = 127.0.0.1; userid = root; password=root1234;");
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "use mysql;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DROP DATABASE bdpimes;";
                cmd.ExecuteNonQuery();
                cn.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }

        private void btnregenerar_Click(object sender, EventArgs e)
        {
            if (CrearBD() == true)
            {
                RestaurarBD();
            }
            else
            {
                DialogResult op;
                op = MessageBox.Show("Desea Eliminarla Primero?", "LA BASE DE DATOS EXISTE!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (op == DialogResult.Yes)
                {
                    EliminarBD();
                    if (CrearBD())
                    {
                        RestaurarBD();
                    }
                    else
                        MessageBox.Show("No se pudo restaurar la BD", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
    }
}
