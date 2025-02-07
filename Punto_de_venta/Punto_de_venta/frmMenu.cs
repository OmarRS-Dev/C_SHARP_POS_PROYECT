using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Punto_de_venta
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        string[] cnn = {"127.0.0.1","root","root1234","bdpimes"};

        //public void RespaldarBD()
        //{
        //    try
        //    {
        //        DateTime Time = DateTime.Now;
        //        int year = Time.Year;
        //        int month = Time.Month;
        //        int day = Time.Day;
        //        int hour = Time.Hour;
        //        int minute = Time.Minute;
        //        int second = Time.Second;
        //        int millisecond = Time.Millisecond;
        //        // obtener los datos de la conexion                 
        //        string server = ClsServidor.servidor;
        //        string uid = ClsServidor.usuariobd;
        //        string password = ClsServidor.clavebd;
        //        string database = ClsServidor.nombreBD;


        //        if (!Directory.Exists("Barcodes"))
        //        {
        //            System.IO.Directory.CreateDirectory("Barcodes");
        //        }

        //        //guardar el respaldo con la fecha y hora como nombre de archivo
        //        string path;
        //        // crear directorio respaldos si no existe
        //        if (!Directory.Exists("Respaldos"))
        //        {
        //            System.IO.Directory.CreateDirectory("Respaldos");
        //            //MessageBox.Show("Se creó el directorio Respaldos que contendrá los respaldos realizados");
        //        }
        //        path = "Respaldos\\Respaldo_" + year + "-" + month + "-" + day +
        //        "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
        //        StreamWriter file = new StreamWriter(path);
        //        ProcessStartInfo psi = new ProcessStartInfo();
        //        psi.FileName = "mysqldump";
        //        psi.RedirectStandardInput = false;
        //        psi.RedirectStandardOutput = true;
        //        // corrección opcion1: anteponer (--no-defaults)
        //        // corrección opcion2:agregar en la seccion  [client] del my.ini la linea: (# no-beep)
        //        psi.Arguments = string.Format(@" --no-defaults -u{0} -p{1} -h{2} {3}", uid, password, server, database);
        //        psi.UseShellExecute = false;
        //        Process process = Process.Start(psi);
        //        string output;
        //        output = process.StandardOutput.ReadToEnd();
        //        file.WriteLine(output);
        //        process.WaitForExit();
        //        file.Close();
        //        process.Close();
        //        MessageBox.Show("Respaldo generado en:\n" + path, "Respaldo Realizado con exito", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //    }
        //    catch (IOException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error al hacer el Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}






        //private void RegenerarBD()
        //{
        //    try
        //    {

        //        // obtener los datos de la cadena de conexion
        //        ObtenerDatos();

        //        // string[] cn = { ClsServidor.servidor, ClsServidor.usuariobd, ClsServidor.clavebd, ClsServidor.nombreBD }; 

        //        //si se puede crear una nueva bd se hará la restauracion
        //        if (CrearBD() == true) // si se pudo crear la bd 
        //        {
        //            //llenar bd desde un script o respaldo (.sql) (import)
        //            // string ruta = Directory.GetCurrentDirectory() + "\\Respaldos";
        //            OpenFileDialog openFileDialog1 = new OpenFileDialog
        //            {
        //                InitialDirectory = Directory.GetCurrentDirectory() + "\\Respaldos",
        //                Title = "Examinar archivos de respaldo",
        //                CheckFileExists = true,
        //                CheckPathExists = true,
        //                DefaultExt = "sql",
        //                Filter = "Archivos SQL (*.sql)|*.sql",
        //                FilterIndex = 2,
        //                RestoreDirectory = true,
        //                ReadOnlyChecked = true,
        //                ShowReadOnly = true
        //            };
        //            if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //            {
        //                StreamReader file = new StreamReader(openFileDialog1.FileName);
        //                // string input = file.ReadToEnd();
        //                // file.Close();
        //                string[] cn = { ClsServidor.servidor, ClsServidor.usuariobd, ClsServidor.clavebd, ClsServidor.nombreBD };
        //                MessageBox.Show(ml.Restaurar(cn, openFileDialog1.FileName));

        //            }
        //        }
        //        else // si no se pudo crear la bd por que ya existe
        //        {
        //            if (ml.Pregunta("La base de datos " + database + " si existe!", "Desea eliminarla del servidor " + server + " y crear otra desde un archivo de respaldo?") == DialogResult.OK)
        //            {
        //                if (EliminarBD() == true) MessageBox.Show("La Base de Datos " + database + " ha sido eliminada Correctamente\ndel servidor " + server);
        //                RegenerarBD();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ocurrió un Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Clientes FC = new frm_Clientes();
            FC.Show();
            this.Hide();
        }

        private void pROVEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Provedores FP = new frm_Provedores();
            FP.Show();
            this.Hide();
        }

        private void aRTÍCULOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Articulos FA = new frm_Articulos();
            FA.Show();
            this.Hide();
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Usuarios FU = new frm_Usuarios();
            FU.Show();
            this.Hide();
        }

        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas fv = new frmVentas();
            fv.Show();
            this.Hide();
        }        

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("CALC.EXE");
            }
            catch(Exception ex)
            {
              MessageBox.Show(ex.Message,"Error");
            }
        }

        private void impresoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelimpresoraTickets ft = new frmSelimpresoraTickets();
            ft.Show();
            this.Hide();
        }

        private void deArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!miclase.CreaDataSet(cnn, "Select * from articulos", "dsarticulos.xml"))
            {
                MessageBox.Show("Error a crear los datos del reporte", "ERROR");
            }
            else
            {
                frmRGA ga = new frmRGA();
                ga.Show();
            }
        }

        private void deClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!miclase.CreaDataSet(cnn, "Select * from clientes", "dsclientes.xml"))
            {
                MessageBox.Show("Error a crear los datos del reporte", "ERROR");
            }
            else
            {
                frmRGC fc = new frmRGC();
                fc.Show();
            }
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void respaldarBaseDeDatosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;
                // obtener los datos de la conexion                 
                string server = ClsServidor.servidor;
                string uid = ClsServidor.usuariobd;
                string password = ClsServidor.clavebd;
                string database = ClsServidor.nombreBD;


                if (!Directory.Exists("Barcodes"))
                {
                    System.IO.Directory.CreateDirectory("Barcodes");
                }

                //guardar el respaldo con la fecha y hora como nombre de archivo
                string path;
                // crear directorio respaldos si no existe
                if (!Directory.Exists("Respaldos"))
                {
                    System.IO.Directory.CreateDirectory("Respaldos");
                    //MessageBox.Show("Se creó el directorio Respaldos que contendrá los respaldos realizados");
                }
                path = "Respaldos\\Respaldo_" + year + "-" + month + "-" + day +
                "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                // corrección opcion1: anteponer (--no-defaults)
                // corrección opcion2:agregar en la seccion  [client] del my.ini la linea: (# no-beep)
                psi.Arguments = string.Format(@" --no-defaults -u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;
                Process process = Process.Start(psi);
                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
                MessageBox.Show("Respaldo generado en:\n" + path, "Respaldo Realizado con exito", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error al hacer el Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
