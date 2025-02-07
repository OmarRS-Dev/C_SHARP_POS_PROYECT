using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//paso #1 agregra MySQL data a referencias
using MySql.Data.MySqlClient;
//paso #2 agregar las librerias necesarias
using System.Data;
using System.IO;
using System.Collections;

namespace Lib01
{
    public class L1 //paso #3 cambiar el nombre de la clase
    {
        //paso #4 Implementar los metodos de la clase
        public static string Guardar(string[] cnn, string tabla, string[] datos)
        {
            try
            {
                String ser = cnn[0], user = cnn[1], pw = cnn[2], bd = cnn[3]; //servidor, usurario, password, base de datos
                MySqlConnection con = new MySqlConnection("Server=" + ser + ";ud =" + user + ";password=" + pw + "database=" + bd);

                con.Open(); //abrir conexión
                MySqlCommand com = new MySqlCommand(); //crear orden
                com.Connection = con; //ejecutar la orden o comando 

                int i = 1;
                string parametros = "";

                foreach (string element in datos) //para cada elemento almacenado en datos se agrega a parametros 
                {
                    com.Parameters.AddWithValue("@p" + i.ToString(), element);
                    parametros += "@p" + i.ToString() + ",";
                    i += 1;
                }
                parametros = parametros.TrimEnd(','); //quitando la ultima coma
                com.CommandText = "Insert into " + tabla + " values(" + parametros + ")"; //comando de la setencia SQL 
                if (com.ExecuteNonQuery() > 0) return "Guardado!"; else return "Error al guardar!";
            }
            catch
            {
                return "Error al guardar!";
            }
        }
        public static string Eliminar(string[] arrayConexion, string tabla, string reg_elim)
        {
            string campollave = "";
            string retu = "";
            try
            {
                string s = arrayConexion[0], user = arrayConexion[1], pw = arrayConexion[2], bd = arrayConexion[3];
                MySqlConnection con = new MySqlConnection("server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd);
                con.Open();
                MySqlCommand comando = new MySqlCommand();
                MySqlCommand comando2 = new MySqlCommand();
                comando.Connection = con;
                comando2.Connection = con;
                comando.CommandText = "SELECT COLUMN_NAME, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA =  '" + bd + "' AND TABLE_NAME =  '" + tabla + "' AND COLUMN_KEY IN ( 'PRI',  'UNI')";
                MySqlDataReader myreader = comando.ExecuteReader();
                if (myreader.Read())
                {
                    campollave = myreader["COLUMN_NAME"].ToString();
                }
                myreader.Close();
                myreader.Dispose();
                if (campollave != "")
                {
                    comando2.CommandText = "delete from " + tabla + " where " + campollave + "='" + reg_elim + "'";
                    if (comando2.ExecuteNonQuery() > 0) retu = "Eliminado!"; else retu = "Error al Eliminar";
                }
            }
            catch
            {
                retu = "Error al Eliminar";
            }
            return retu;
        }

        private static ArrayList obtenerColumnas(string con, string tabla)
        {
            MySqlConnection cone = new MySqlConnection(con);
            cone.Open();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM " + tabla + " LIMIT 0,0", cone); // LIMIT 0,0 (DEVUELVE SOLO LOS NOMBRES DE COLUMNAS DE LA TABLA)
            MySqlDataAdapter adaptador = new MySqlDataAdapter(cm);
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            ArrayList columnas = new ArrayList();
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                columnas.Add(ds.Tables[0].Columns[i].ColumnName);
            }
            return columnas;
        }

        public static string Modificar(string[] cnx, string tabla, string[] datos)
        {
            string sentencia = "";
            try
            {
                string s = cnx[0], user = cnx[1], pw = cnx[2], bd = cnx[3];
                string conexion = "server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd;
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = conexion;
                con.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = con;
                ArrayList columnas;
                columnas = obtenerColumnas(conexion, tabla);
                string cad = "";
                string were = "";
                string rm = "";
                for (int j = 0; j < columnas.Count; j++)
                {
                    if (j == 0)
                    {
                        rm = datos[j].ToString();
                        were = " where " + columnas[j] + "='" + datos[j] + "'";
                    }
                    else
                        cad += columnas[j].ToString() + "='" + datos[j] + "',";
                }
                cad = cad.TrimEnd(',') + were;
                //int i = 1;
                //string parametros = "";
                //foreach (string element in datos)
                //{
                //    comando.Parameters.AddWithValue("@p" + i.ToString(), element);
                //    parametros += "@p" + i.ToString() + ",";
                //    i++;
                //}
                //parametros = parametros.TrimEnd(',');
                sentencia = comando.CommandText = "Update " + tabla + " set " + cad;
                if (comando.ExecuteNonQuery() > 0)
                {
                    return "Modificado";
                }
                else return "No existe el registro[" + rm + "]";
            }
            catch (MySqlException ex)
            {
                return ex.Message + "\r(Sentencia:" + sentencia + ")";
            }
        }

        public static DataTable Reporte(string[] cnx, string Orden_Sql)
        {
            try
            {
                string s = cnx[0], user = cnx[1], pw = cnx[2], bd = cnx[3];
                DataTable dt = new DataTable();
                string cone = "server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd;
                MySqlConnection cn = new MySqlConnection(cone);
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand(Orden_Sql, cn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable Consulta(string[] cnx, string tabla, string reg_consultar)
        {
            try
            {
                string conexion = "";
                string s = cnx[0], user = cnx[1], pw = cnx[2], bd = cnx[3];
                if (cnx.Count() > 1) conexion = "server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd;
                else
                    conexion = cnx[0];

                string campollave = "";
                DataTable dt = new DataTable();
                MySqlConnection cnn = new MySqlConnection();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = cnn;
                cnn.ConnectionString = conexion;
                cnn.Open();
                comando.CommandText = "SELECT COLUMN_NAME, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + bd + "' AND TABLE_NAME = '" + tabla + "' and COLUMN_KEY IN('PRI', 'UNI')";
                //comando.CommandText = "SELECT COLUMN_NAME, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tabla + "' AND COLUMN_KEY='PRI'";
                MySqlDataReader myreader = comando.ExecuteReader();
                if (myreader.Read())
                    campollave = myreader["COLUMN_NAME"].ToString();
                myreader.Close(); myreader.Dispose();
                if (campollave != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from " + tabla + " where " + campollave + "='" + reg_consultar + "'", cnn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(dt);
                    return dt;
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static int FolioSiguiente(string[] cnx, string tabla_con_pk)
        {
            try
            {
                string s = cnx[0], user = cnx[1], pw = cnx[2], bd = cnx[3];
                string conexion = "server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd;
                string campollave = "";
                MySqlConnection cnn = new MySqlConnection();
                MySqlCommand comando = new MySqlCommand();
                MySqlCommand comando2 = new MySqlCommand();
                comando.Connection = cnn;
                comando2.Connection = cnn;
                cnn.ConnectionString = conexion;
                cnn.Open();
                comando.CommandText = "SELECT COLUMN_NAME, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + bd + "' AND TABLE_NAME = '" + tabla_con_pk + "' and COLUMN_KEY IN('PRI', 'UNI')";

                //comando.CommandText = "SELECT COLUMN_NAME, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tabla + "' AND COLUMN_KEY='PRI'";

                // Obteniendo el campollave llave  o PK

                MySqlDataReader myreader = comando.ExecuteReader();
                if (myreader.Read())
                {
                    campollave = myreader["COLUMN_NAME"].ToString();
                }
                myreader.Close(); myreader.Dispose();

                if (campollave != "")
                {
                    comando2.CommandText = "Select max(" + campollave + ") from " + tabla_con_pk;
                    comando2.Connection = cnn;
                    try
                    {
                        object res = comando2.ExecuteScalar();
                        if (res == System.DBNull.Value)
                            return 1;
                        else
                        {
                            return (Convert.ToInt32(res) + 1);
                        }
                    }
                    catch
                    {
                        return 1;
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
            }
            catch { return 1; }
            return 1;
        }




        public static bool CreaDataSet(string[] cnx, string OrdenSql, string Nombre_Archivo_XML)
        {
            try
            {
                string s = cnx[0], user = cnx[1], pw = cnx[2], bd = cnx[3];
                if (Path.GetExtension(Nombre_Archivo_XML).ToUpper() == ".XML")
                {
                    string FileName = Path.GetFileNameWithoutExtension(Nombre_Archivo_XML);
                    string conexion = "server=" + s + ";uid=" + user + ";password=" + pw + ";database=" + bd;
                    DataSet myData = new DataSet("ds_" + FileName);
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
                    //myAdapter.Fill(myData);
                    myAdapter.FillSchema(myData, SchemaType.Source, FileName);
                    myAdapter.Fill(myData, FileName);

                    //  cApp App = new cApp(System.Reflection.Assembly.GetExecutingAssembly());
                    string ruta = Nombre_Archivo_XML;
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
