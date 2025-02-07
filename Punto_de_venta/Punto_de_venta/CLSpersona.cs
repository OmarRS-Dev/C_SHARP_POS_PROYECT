using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//paso 1: Poner en uso las librerias necesarias para 
//trabajar con mysql y Data
using MySql.Data.MySqlClient;
using System.Data;

namespace Punto_de_venta
{
    //paso 2: Indicar si esta será una superclase (Abstract)
    abstract class ClsPersona
    {
        //paso 3 definir las propiedades de la clase "ClsPersona"
        public abstract int codigo { get; set; }

        public abstract string rfc { get; set; }
        public abstract string nombre { get; set; }
        public abstract string dirección { get; set; }
        public abstract string telefono { get; set; }
        public abstract string email { get; set; }

        //Paso 4: definir los metodos de la clase
        public abstract bool guardar();
        public abstract bool eliminar(int cod);
        public abstract bool modificar();
        public abstract DataTable Reporte();
        public abstract DataTable consultar(int cod);
    }
}
