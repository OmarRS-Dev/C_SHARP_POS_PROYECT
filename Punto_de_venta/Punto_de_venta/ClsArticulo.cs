using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//paso 1 agregar las librerias necesarias
using MySql.Data.MySqlClient;
using System.Data;

namespace Punto_de_venta
{
    class ClsArticulo
    {
        //definir las variables privadas que interactuarán con las propiedas y metodos de la clase

        private string co; //interactuará con código
        private string de; // descripcion
        private float pc; // precio de compra
        private float pv; // precio de venta
        private float ex; // existencia
        private float mi; // stock minimo
        private float ma; // stock maximo
        private int pr; // codigo de provedor 

        public string codigo { get {return co;} set {co=value;} }
        public string descripcion { get { return de; } set { de = value; } }
        public float pcompra { get { return pc; } set { pc = value; } }
        public float pventa { get { return pv; } set { pv = value; } } 
        public float existencia { get { return ex; } set { ex = value; } }
        public float minimo { get { return mi; } set { mi = value; } }
        public float maximo { get { return ma; } set { ma = value; } }
        public int codprovedor { get { return pr; } set { pr = value; } }

        //implimentar los metodos de la clase
        public bool Guardar()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Insert into ARTICULOS values (@co,@de,@pc,@pv,@ex,@mi,@ma,@pr)";
            cmd.Parameters.AddWithValue("@co", co);
            cmd.Parameters.AddWithValue("@de", de);
            cmd.Parameters.AddWithValue("@pc", pc);
            cmd.Parameters.AddWithValue("@pv", pv);
            cmd.Parameters.AddWithValue("@ex", ex);
            cmd.Parameters.AddWithValue("@mi", mi);
            cmd.Parameters.AddWithValue("@ma", ma);
            cmd.Parameters.AddWithValue("@pr", pr);
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }


        public bool eliminar(string cod)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Delete from ARTICULOS where codigo=@co";
            cmd.Parameters.AddWithValue("@co", co);
            int res;
            res = cmd.ExecuteNonQuery();
            if (res > 0) return true; else return false;
        }

        public  bool modificar()
        {
            MySqlConnection cnn = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            cnn.ConnectionString = miclase.conexion;
            comando.Connection = cnn;
            cnn.Open();
            comando.Parameters.AddWithValue("@co", this.co);
            comando.Parameters.AddWithValue("@de", this.de);
            comando.Parameters.AddWithValue("@pc", this.pc);
            comando.Parameters.AddWithValue("@pv", this.pv);
            comando.Parameters.AddWithValue("@ex", this.ex);
            comando.Parameters.AddWithValue("@mi", this.mi);
            comando.Parameters.AddWithValue("@ma", this.ma);
            comando.Parameters.AddWithValue("@pr", this.pr);
            comando.CommandText = "Update ARTICULOS set descripcion=@de, p_compra=@pc, p_venta=@pv, existencia=@ex, stockmin=@mi, stockmax=@ma, codprovedor=@pr where codigo=@co";
            int res;
            res = comando.ExecuteNonQuery();
            if (res > 0) return true; else return false;            
        }

        public  DataTable Reporte()
        {
            //setencia para intentar hacer lo que está dentro
            //catch es la excepción para evitarque el programa crashee
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection cn = new MySqlConnection(miclase.conexion);
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand("Select * from ARTICULOS", cn);
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

        public  DataTable consultar(String cod)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection(miclase.conexion);
                DataSet ds = new DataSet();
                using (cn)
                {
                    MySqlCommand cmd = new MySqlCommand("Select * from ARTICULOS where codigo =" + cod, cn);
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
