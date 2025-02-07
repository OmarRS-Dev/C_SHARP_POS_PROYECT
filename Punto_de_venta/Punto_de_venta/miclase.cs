using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace Punto_de_venta
{
    class miclase
    {
        public static string conexion = "server=127.0.0.1; userid=root; password=root1234; database=bdpimes";
        public static string usuario = "Admin";
        public static string rol = "Administrador";
        

        public static int FolioSiguiente(string campo, string tabla)
        {
            using (MySqlConnection cnn = new MySqlConnection(conexion))
            using (MySqlCommand cmd = new MySqlCommand("Select max(" + campo + ")+1 as foli from " + tabla, cnn))
            {
                cnn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            try
                            {
                                return Int32.Parse(dr["foli"].ToString());
                            }
                            catch
                            {
                                return 1;
                            }
                        } // fin del while                
                }
            }
            return 1;
        } //fin del metodo foliosiguiente


        // El metodo SoloNumeros sirve para que los textbox acepten solo numeros
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // El metodo SoloNumerosPD acepta numeros con punto decimal
        public static void SoloNumerosPD(KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar.ToString() != cc.NumberFormat.NumberDecimalSeparator)
            {
                e.Handled = true;
            }
        }

        //metodo par crear un databas para los reportes
        public static bool CreaDataSet(string[] arrayConexion, string OrdenSql, string FileName_XML)
        {
            try
            {
                string s = arrayConexion[0], user = arrayConexion[1], pw = arrayConexion[2], bd = arrayConexion[3];
                if (Path.GetExtension(FileName_XML).ToUpper() == ".XML")
                {
                    string conexion = "server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd;
                    DataSet myData = new DataSet();
                    MySql.Data.MySqlClient.MySqlConnection conn;
                    MySql.Data.MySqlClient.MySqlCommand cmd;
                    MySql.Data.MySqlClient.MySqlDataAdapter myAdapter;
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand();
                    myAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
                    conn.ConnectionString = conexion;
                    cmd.CommandText = OrdenSql;
                    cmd.Connection = conn;
                    myAdapter.SelectCommand = cmd;
                    myAdapter.Fill(myData);
                    //  cApp App = new cApp(System.Reflection.Assembly.GetExecutingAssembly());
                    string ruta = FileName_XML;
                    myData.WriteXml(@ruta, XmlWriteMode.WriteSchema);
                    //Generando archivo .xsd
                    //leer xml
                    DataSet ds = new DataSet();
                    ds.ReadXml(ruta);
                    // Generando archivo .xsd   
                    string result = Path.ChangeExtension(ruta, ".xsd");
                    ds.WriteXmlSchema(result);
                    return true;
                }
                else
                    return false; // return false si no tiene extension el nombre del archivo xml a crear
            }
            catch
            {
                return false;
            }
        }

    }
}
