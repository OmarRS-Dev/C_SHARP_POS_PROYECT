using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//librerias necesarias
using MySql.Data.MySqlClient;
using System.Data;

namespace Punto_de_venta
{
    class ClsUsuarios
    {
        private string us; //usuario
        private string cv; //clave
        private string ro; //rol

        public string usuario { get { return us; } set { us = value; } }
        public string clave { get { return cv; } set { cv = value; } }
        public string rol { get { return ro; } set { ro = value; } }

        public bool Guardar()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Insert into USUARIOS values (@us,@cv,@ro)";
            cmd.Parameters.AddWithValue("@us", us);
            cmd.Parameters.AddWithValue("@cv", cv);
            cmd.Parameters.AddWithValue("@ro", ro);            
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }


        public bool eliminar(string usuario)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "DELETE FROM USUARIOS WHERE usuario = @usuario"; // Corregir el nombre del parámetro
            cmd.Parameters.AddWithValue("@usuario", usuario);
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }
              

        public DataTable Reporte()
        {
            //setencia para intentar hacer lo que está dentro
            //catch es la excepción para evitarque el programa crashee
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection cn = new MySqlConnection(miclase.conexion);
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand("Select * from USUARIOS", cn);
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

        public DataTable consultar(string us)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection(miclase.conexion);
                DataSet ds = new DataSet();
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM USUARIOS WHERE usuario = @usuario", cn);
                    cmd.Parameters.AddWithValue("@usuario", us);
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
