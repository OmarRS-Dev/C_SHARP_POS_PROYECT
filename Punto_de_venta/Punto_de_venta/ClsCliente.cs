using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 //paso 1: poner en uso las clases necesarias
using MySql.Data.MySqlClient;
using System.Data;

namespace Punto_de_venta
{
    //indicar si va a tomar herencia de alguna superclase
    //(:nombre_de_la_superclase)
    class ClsCliente:ClsPersona
    {
        //paso 3. declarar las variables privadas que interactuarán con las propiedades y metodos de esta clase
        private int co; //representa código
        private string rf; //represneta rfc
        private string no; // representa nombre
        private string di; // representa nobre
        private string te; // representa telefono
        private string em; // representa email

        //paso 4: implementar las propiedades 
        public override int codigo
        {
            get //lectura
            {
                return this.co;
            }
            set //escritura
            {
                this.co = value;
            }
        }

        public override string rfc { get { return rf; } set { rf = value; } }
        public override string nombre { get { return no; } set { no = value; } }
        public override string dirección { get { return di; } set { di = value; } }
        public override string telefono { get { return te; } set { te = value; } }
        public override string email { get { return em; } set { em = value; } }


        //paso 5.- Implementar los metodos de la clase

        public override bool guardar()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Insert into CLIENTES values (null,@rf,@no,@di,@te,@em)";
            cmd.Parameters.AddWithValue("@rf", rf);
            cmd.Parameters.AddWithValue("@no", no);
            cmd.Parameters.AddWithValue("@di", di);
            cmd.Parameters.AddWithValue("@te", te);
            cmd.Parameters.AddWithValue("@em", em);
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }

        public override bool eliminar(int cod)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion; 
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Delete from CLIENTES where codigo=@co";
            cmd.Parameters.AddWithValue("@co", cod);
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }

        public override bool modificar()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update CLIENTES set rfc=@rf, nombre=@no, direccion=@di, telefono=@te, email=@em where codigo=@co";
            cmd.Parameters.AddWithValue("@co", co);
            cmd.Parameters.AddWithValue("@rf", rf);
            cmd.Parameters.AddWithValue("@no", no);
            cmd.Parameters.AddWithValue("@di", di);
            cmd.Parameters.AddWithValue("@te", te);
            cmd.Parameters.AddWithValue("@em", em);
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }

        public override DataTable Reporte()
        {
            //setencia para intentar hacer lo que está dentro
            //catch es la excepción para evitarque el programa crashee
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection cn = new MySqlConnection(miclase.conexion);
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand("Select * from CLIENTES", cn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(dt); //rellena el datable (dt) a partir del adaptador 
                    return dt; //retorna el DataTable
                }
                
            }
            catch (Exception)
            {
                
                return null;
            }
        }

        public override DataTable consultar(int cod)
        {
            try
            {
                
                MySqlConnection cn = new MySqlConnection(miclase.conexion);
                DataSet ds = new DataSet();
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand("Select * from CLIENTES where codigo ="+cod, cn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(ds); //rellena el datable (ds)  
                    return ds.Tables[0];
                }
                
             }
             catch (Exception)
             {

                return null;
             }
        }
        
        }
    }

