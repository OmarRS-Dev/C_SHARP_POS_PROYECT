using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //libreria para usar mysql en este formulario
//using 

namespace Punto_de_venta
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            deshabilitaCL();
            txtcodcliente.Focus();
        }

        private int ulse = -1;
        private float resto=0;
        float supago = 0, cambio = 0, subtotal = 0, total = 0;
        const float IVA = 0.16f;
        public bool bloquearbd = false;
        String tt = "CONTADO";

        public void ImprimirTicket(String tipoTi)
        {
            ClsTicket t = new ClsTicket();            

            if(System.IO.File.Exists("Logo Ticket.JPG"))
            {
                t.HeaderImage = Image.FromFile("Logo Ticket.JPG");
            }
            else
            {
                t.AddHeaderLine("Electrónica y Ferretería: Serchi.");
            }

            t.AddHeaderLine("");
            t.AddHeaderLine("");
            t.AddHeaderLine("Guamúchil, Sinaloa.");
            t.AddHeaderLine("673-111-6675.");
            t.AddHeaderLine("");
            t.AddHeaderLine("Fecha: "+System.DateTime.Now.ToShortDateString()+".");
            t.AddHeaderLine("Hora: " + System.DateTime.Now.ToShortTimeString() + "");
            t.AddHeaderLine("No. Ticket: " + lblfolio.Text);
            t.AddHeaderLine("Atendió: "+miclase.usuario);
            //t.AddHeaderLine("");
            //t.AddSubHeaderLine("COD  DESCRIPCIÓN    CANT     PRECIO");
            t.AddSubHeaderLine("");
            for (int i = 0; i < lbcodigo.Items.Count; i += 1)
            {
                t.AddItem(lbcantidad.Items[i].ToString(), lbdescripcion.Items[i].ToString(), lbparcial.Items[i].ToString().Substring(2));
                t.AddItem("", "", "");
                //t.AddItem(lbdescripcion.Items[i].ToString(), lbcantidad.Items[i].ToString(), "");
            }
            t.AddTotal("     SUBTOTAL: ", lblsubtotal.Text.Substring(2));
            t.AddTotal("          IVA: ", lbliva.Text.Substring(2));
            t.AddTotal("        TOTAL: ", lbltotal.Text.Substring(2));
            t.AddTotal("     PAGÓ CON: ", float.Parse(txtsupago.Text).ToString("N2"));
            t.AddTotal("       CAMBIO: ", cambio.ToString("N2"));

            //t.AddTotal("", "");

            t.AddFooterLine("===================================");
            t.AddFooterLine("GRACIAS POR SU COMPRA");
            t.AddFooterLine("--Para cualquier reclamación, conserve su ticket--");
            t.AddFooterLine("VUELVA PRONTO :)");

            t.PrintTicket("Microsoft Print to PDF");
        }

        public void limpiarPago()
        {
            txtsupago.Clear();
            txtsupago.Focus();
        }

        public void codacant(MySqlDataReader myreader) 
        {
            ChMenudeo.Enabled = false;
            txtcantidad.Enabled = true;
            while (myreader.Read())
            {
                txtcodarticulo.Text = myreader["codigo"].ToString();
                txtdescripcion.Text = myreader["descripcion"].ToString();
                txtprecio.Text = myreader["p_venta"].ToString();
            }
            txtcodarticulo.Enabled = false;
            if (ChMenudeo.Checked)
            {
                txtcantidad.Text = "1";
                vender();
            }
            txtcantidad.Focus();
        }

        public void venderFuera()
        {
            supago = float.Parse(txtsupago.Text);
            total = float.Parse(lbltotal.Text.Substring(2).Trim());
            cambio= supago - total;
            if (cambio >= 0)
            {
                //Si le alcanza
                lbltotalfinal.Text = lbltotal.Text;
                lblcambiofinal.Text = "$ " + cambio.ToString("N2");
                lblsupagofinal.Text = "$ " + supago.ToString("N2");
                btncancelar.Enabled = false;
                btnbuscar.Enabled = false;
                gbventafinalizada.Visible = true;
                ImprimirTicket(tt);
                this.BeginInvoke((Action)(() => btnnuevaventa.Focus())); 
            }
            else
            {
                if (int.Parse(txtcodcliente.Text) != 0)
                {
                    //Se le puede dar crédito porque es cliente
                    resto = total - supago;
                    btncredito.Visible = btnnocredito.Visible = true;
                    btncredito.Text = "¿Cargar "+resto.ToString("N2") +" a crédito?";
                    
                }
                else
                {
                    //El cliente es punlico en general y no se le da crédito 
                    lbnocredito.Visible = true;
                    txtsupago.Clear();
                    txtsupago.Focus();
                }                
            }    
        }

        public float traerExistencia(String cod) 
        {
            MySqlConnection cnn1 = new MySqlConnection(miclase.conexion);
            cnn1.Open();
            MySqlCommand comando1 = new MySqlCommand("SELECT existencia FROM articulos WHERE codigo = @codigo", cnn1);
            comando1.Parameters.AddWithValue("@codigo", cod);
            MySqlDataReader myreader1 = comando1.ExecuteReader();
            myreader1.Read();
            float exis = 0;
            exis = myreader1.GetFloat("existencia"); // Obtiene el valor de la columna 'existencia'               
            myreader1.Close();
            comando1.Dispose();
            cnn1.Close();

            return exis;
        }

        public bool esDeudor(string cliente)
        {
            MySqlConnection cn = new MySqlConnection(miclase.conexion);
            DataTable dt = new DataTable();
            using (cn)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM deudores WHERE codcliente=@cli",cn);
                cmd.Parameters.AddWithValue("@cli",cliente);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                adaptador.Fill(dt); //llenamos el dt a partir del adaptador
            }
            if (dt.Rows.Count > 0) return true; else return false;
        }

        public int CargarCredito(String cliente, float cantidad) 
        {
            int res;            
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = miclase.conexion;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;

            if (esDeudor(cliente) == true)
            {
                cmd.CommandText = "UPDATE deudores SET deuda=deuda+@can WHERE codcliente=@co";
                res = 1;
            }
            else
            {
                cmd.CommandText = "INSERT INTO deudores values (@co,@can)";
                res = 2;
            }       
            
            cmd.Parameters.AddWithValue("@co", cliente);
            cmd.Parameters.AddWithValue("@can", resto);
            cmd.ExecuteNonQuery();
            return res;
        }

        public void vender()
        {
           bool aum = true; //bandera para saber si va a agregar de 0  o ya existe
           float exis = traerExistencia(txtcodarticulo.Text);

                    for (int i = 1; i <= lbcodigo.Items.Count; i += 1) //ciclo que recorre los elementos del listview
                    {
                        String lCod = lbcodigo.Items[i - 1].ToString();
                        int inIn = lCod.IndexOf("[");
                        int inFi = lCod.IndexOf("]");
                        String lbCod = lCod.Substring(inIn + 1, inFi - inIn - 1);

                        if (lbCod == txtcodarticulo.Text) //verifica que el código existente sea igual al que queremos agregar
                        {                            
                            float cantCompra = float.Parse(lbcantidad.Items[i - 1].ToString()); //variable que guarda cuantos ya tiene agregados 
                            float quiere = cantCompra + float.Parse(txtcantidad.Text); // sumamos cuanto quiere llevar en total (los que ya tiene en lista, mas los que se van a agregar)

                            if(exis-quiere >= 0) // nos aseguramos que tenemos más existencia de la que se quiere comprar
                            {
                             //agrega el nuevo producto a una fila ya existente 
                            float can1 = float.Parse(txtcantidad.Text) + float.Parse(lbcantidad.Items[i - 1].ToString()); 
                            lbcantidad.Items[i - 1] = can1 ;
                            float pu1 = float.Parse(txtprecio.Text);
                            lbparcial.Items[i - 1] = ("$ " + (can1 * pu1));
                            aum = false; //no se agregó, por eso no se ocupa aumentar la lista
                            subtotal = subtotal + (float.Parse(txtcantidad.Text)*pu1);
                            lblsubtotal.Text = "$ " + subtotal.ToString("N2");
                            nuevoArt();
                            lbcodigo.SelectedIndex = i - 1;
                            break;
                            }  
                            else // en casi de que se quieran comprar más de lo que existe
                            {
                              frmMensaje m = new frmMensaje("Cambie la cantidad. Max: ("+(exis-cantCompra)+")");
                              aum = false; //no se agregó, por eso no se ocupa aumentar la lista
                              m.ShowDialog();
                              txtcantidad.Clear();
                              txtcantidad.Focus();
                              break;
                            }
                        }
                    }
                    if (aum)
                    {
                        //agrega el elemento a los listview en caso de que no exista ya                        
                        if (float.Parse(txtcantidad.Text) > exis)
                        {
                            frmMensaje m = new frmMensaje("Cambie la cantidad. Max: (" + exis + ")");
                            m.ShowDialog();
                            txtcantidad.Clear();
                            txtcantidad.Focus();
                        }
                        else
                        {
                            lbcodigo.Items.Add("[" + txtcodarticulo.Text + "]");
                            lbdescripcion.Items.Add(txtdescripcion.Text);
                            lbcantidad.Items.Add(float.Parse(txtcantidad.Text).ToString());
                            lbprecio.Items.Add("$ " + txtprecio.Text);
                            float cant2 = float.Parse(txtcantidad.Text);
                            float pu2 = float.Parse(txtprecio.Text);
                            lbparcial.Items.Add("$ " + (cant2 * pu2));
                            ulse += 1;
                            subtotal = subtotal + float.Parse(lbparcial.Items[ulse].ToString().Substring(2).Trim());
                            lblsubtotal.Text = "$ " + subtotal.ToString("N2");//le agregamos uno al contador de selección
                            nuevoArt();
                        }                        
                    }  
        }

        public void nuevoArt()
        {
            ChMenudeo.Enabled = true; //habiliatmos las ventas a menudeo
            //mandamos la selección
            sigArt();
            //actualizamos los totales y los mostramos 
            actualizatotales();
            //limpiamos todo y volvemos a código, checamos el estado de los botones
            limpiarCant();
            botonesEstado();
        }

        public void NuevaVenta()
        {
            limpiarSC();
            ChMenudeo.Checked = false;
            txtcodarticulo.Clear();
            txtdescripcion.Clear();
            txtprecio.Clear();
            txtcantidad.Clear();
            gbcliente.Enabled = true;
            txtcodcliente.Clear();
            txtrfc.Clear();
            txtnombre.Clear();
            txtdireccion.Clear();
            txtelefono.Clear();
            txtcodcliente.Focus();
            gbarticulos.Enabled = false;
            gbsucompra.Enabled = false;
            deshabilitaCL();
            ulse = -1;
            bloquearbd = false;
            subtotal = 0;
            lblsubanuncio.Enabled = true;
            lblsubtotal.Enabled = true;
            lblivaanuncio.Enabled = true;
            lbliva.Enabled = true;
            lblsubtotal.Text = "$ 0.00";
            lbliva.Text = "$ 0.00";
            lbltotal.Text = "$ 0.00";
            botonesEstado();
            btncancelar.Enabled = false;
            supago = 0; cambio = 0; subtotal = 0; total = 0;            
            txtsupago.Clear();
            txtsupago.Visible = false;
            lblsupago.Visible = false;
            pbanuncios.Visible = true;
            btnreimprimir.Visible = true;
            btndevolver.Visible = true;
            nucantidad.Value = 1;
            btncredito.Visible = false;
            btnnocredito.Visible = false;
            lbnocredito.Visible = false;
            gbventafinalizada.Visible = false;
            ChMenudeo.Checked = true;
            tt = "CONTADO";
        }

        public void bloquarlb(ListBox xd)
        {
            if (xd.SelectedIndex != -1 && bloquearbd==true)
            {
                lbcodigo.SelectedIndex = -1;
                lbcantidad.SelectedIndex = -1;
                lbdescripcion.SelectedIndex = -1;
                lbprecio.SelectedIndex = -1;
                lbparcial.SelectedIndex = -1;
            }
        }
        public void botonesEstado()
        {
            bool elementos = lbcodigo.Items.Count > 0;
            if (elementos == true)
            {
                btnEliminar.Enabled = true;
                btnRepetir.Enabled = true;
                nucantidad.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnRepetir.Enabled = false;
                nucantidad.Enabled = false;
            }
        }

        public void actualizatotales()
        {            
            lbliva.Text = "$ 0.00";
            //lbliva.Text =(float.Parse(lblSubtotal.Text)*IVA).ToString("N2");
            lbltotal.Text = "$ " + (float.Parse(lblsubtotal.Text.Substring(2).Trim()) + float.Parse(lbliva.Text.Substring(2).Trim())).ToString("N2");
        }

        public void deshabilitaCL()
        {
            txtcodcliente.Enabled = true;
            txtrfc.Enabled=false;
            txtnombre.Enabled=false;
            txtdireccion.Enabled=false;
            txtelefono.Enabled=false;
        }

        public void limpiarSC()
        {
            lbcodigo.Items.Clear();
            lbdescripcion.Items.Clear();
            lbcantidad.Items.Clear();
            lbprecio.Items.Clear();
            lbparcial.Items.Clear();
        }

        private void txtcodarticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            miclase.SoloNumeros(e);
            if (e.KeyChar == 27)
            {
                if (lbcodigo.Items.Count > 0)
                {
                    subtotal = 0;
                    for (int i = 1; i <= lbparcial.Items.Count; i += 1)
                    {
                        subtotal = subtotal + float.Parse(lbparcial.Items[i - 1].ToString().Substring(2).Trim());
                    }
                    lblsubtotal.Text = "$ " + subtotal.ToString("N2");
                    lbliva.Text = "$ 0.00";
                    //lbliva.Text =(float.Parse(lblSubtotal.Text)*IVA).ToString("N2");
                    lbltotal.Text = "$ " + (float.Parse(lblsubtotal.Text.Substring(2).Trim()) + float.Parse(lbliva.Text.Substring(2).Trim())).ToString("N2");
                    lblsupago.Visible = true;
                    txtsupago.Visible = true;
                    txtsupago.Focus();
                    txtcodarticulo.Clear();

                    txtcodarticulo.Enabled = false;
                    ulse = -1;
                    sigArt();
                    pbanuncios.Visible = false;
                    btnreimprimir.Visible = false;
                    btndevolver.Visible = false;

                    lblsubanuncio.Enabled = false;
                    lblsubtotal.Enabled = false;
                    lblivaanuncio.Enabled = false;
                    lbliva.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnRepetir.Enabled = false;
                    nucantidad.Enabled = false;

                    bloquearbd = true;
                    ChMenudeo.Enabled = false;
                }
                else NuevaVenta();
            }

            if (e.KeyChar == 13 && txtcodarticulo.Text.Length > 0)
            {               
                MySqlConnection cnn = new MySqlConnection(miclase.conexion);
                cnn.Open();
                MySqlCommand comando = new MySqlCommand("Select * from articulos where codigo='" + txtcodarticulo.Text + "'", cnn);
                MySqlDataReader myreader = comando.ExecuteReader();
                comando.Dispose();
                if (myreader.HasRows)
                {
                    float exis = traerExistencia(txtcodarticulo.Text);
                    if (exis > 0)
                    {
                        if (lbcodigo.Items.Count > 0)
                        {
                            bool aum = true;

                            for (int i = 1; i <= lbcodigo.Items.Count; i += 1) //ciclo que recorre los elementos del listview
                            {
                                String lCod = lbcodigo.Items[i - 1].ToString();
                                int inIn = lCod.IndexOf("[");
                                int inFi = lCod.IndexOf("]");
                                String lbCod = lCod.Substring(inIn + 1, inFi - inIn - 1);
                                if (lbCod == txtcodarticulo.Text) //verifica que el código existente sea igual al que queremos agregar
                                {
                                    float cantCompra = float.Parse(lbcantidad.Items[i - 1].ToString()); //variable que guarda cuantos ya tiene agregados                                 
                                    if (exis == cantCompra)
                                    {
                                        frmMensaje m = new frmMensaje("Existencia agotada");
                                        m.ShowDialog();
                                        txtcodarticulo.Clear();
                                        txtcodarticulo.Focus();
                                        aum = false;
                                        break;
                                    }
                                }
                            }
                            if (aum) codacant(myreader);
                        }
                        else codacant(myreader);                        
                    }
                    else 
                    {
                        frmMensaje m = new frmMensaje("Existencia agotada");
                        m.ShowDialog();
                        txtcodarticulo.Clear();
                        txtcodarticulo.Focus();
                    }
                }
                else 
                {
                    frmMensaje m = new frmMensaje("El articulo no existe");
                    m.ShowDialog();
                    txtcodarticulo.Clear();
                    txtcodarticulo.Focus();
                }
            }
        }
        public void limpiarCant()
        {   //metodo que limpia cantidad y vuelve al codigo de articulo
            txtcodarticulo.Enabled = true;
            txtcodarticulo.Clear();
            txtdescripcion.Clear();
            txtprecio.Clear();
            txtcantidad.Clear();
            txtcantidad.Enabled = false;
            txtcodarticulo.Focus();
        }

        public void sigArt()
        {
            lbcodigo.SelectedIndex = ulse;
            lbcantidad.SelectedIndex = ulse;
            lbdescripcion.SelectedIndex = ulse;
            lbprecio.SelectedIndex = ulse;
            lbparcial.SelectedIndex = ulse;
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27)
            {
                ChMenudeo.Enabled = true;
                limpiarCant();
            }

            if (e.KeyChar == 13 && txtcantidad.Text.Length > 0 && float.Parse(txtcantidad.Text)>0)
            {
                vender();
            }
        }

        public int FolioVentas()
        {
            MySqlConnection cnn = new MySqlConnection(miclase.conexion);
            cnn.Open();
            MySqlCommand comando = new MySqlCommand("Select max(factura)+1 as folio from encabezado", cnn);
            MySqlDataReader myreader = comando.ExecuteReader();
            comando.Dispose();
            if(myreader.HasRows)
            {
                while (myreader.Read())
                {
                    try
                    {
                        return Int32.Parse(myreader["folio"].ToString());
                    }
                    catch
                    { 
                        
                    }
                }
            }
            return 1;
        }
        private void frmVentas_Load(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss tt");
            trHora.Start();
            lblfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblfolio.Text = FolioVentas().ToString();
            botonesEstado();
        }

        private void trHora_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void seleccion(ListBox sl)
        {
            if (bloquearbd == false)
            {
                int valor = sl.SelectedIndex;

                lbcodigo.SelectedIndex = valor;
                lbcantidad.SelectedIndex = valor;
                lbdescripcion.SelectedIndex = valor;
                lbprecio.SelectedIndex = valor;
                lbparcial.SelectedIndex = valor;
            }
        }
        private void lbcodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccion(lbcodigo);
            bloquarlb(lbcodigo);
        }

        private void lbdescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccion(lbdescripcion);
            bloquarlb(lbdescripcion);
        }

        private void lbcantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccion(lbcantidad);
            bloquarlb(lbcantidad);
        }

        private void lbprecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccion(lbprecio);
            bloquarlb(lbprecio);
        }

        private void lbparcial_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccion(lbparcial);
            bloquarlb(lbparcial);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int pos = lbcodigo.SelectedIndex;
            if (pos != -1)
            {
                float canEli = float.Parse(nucantidad.Value.ToString());
                float canExi = float.Parse(lbcantidad.Items[pos].ToString());

                if (canEli < canExi)
                {
                    float viePar = float.Parse(lbparcial.Items[pos].ToString().Substring(2));
                    float pre = float.Parse(lbprecio.Items[pos].ToString().Substring(2));
                    float nueExi = (canExi - canEli);
                    float nuePar = pre * nueExi;
                    float difSub = viePar - nuePar;

                    lbcantidad.Items[pos] = nueExi;
                    lbparcial.Items[pos] = ("$ " + nuePar);
                    subtotal -= difSub;
                    lblsubtotal.Text = "$ " + subtotal.ToString("N2");
                    lbltotal.Text = "$ " + subtotal.ToString("N2");
                }
                else if (canEli == canExi)
                {
                    float des = float.Parse(lbparcial.Items[pos].ToString().Substring(2));
                    lbcodigo.Items.RemoveAt(pos);
                    lbdescripcion.Items.RemoveAt(pos);
                    lbcantidad.Items.RemoveAt(pos);
                    lbprecio.Items.RemoveAt(pos);
                    lbparcial.Items.RemoveAt(pos);
                    ulse -= 1;
                    sigArt();

                    subtotal -= des;
                    lblsubtotal.Text = "$ " +subtotal.ToString("N2");
                    lbltotal.Text = "$ " + subtotal.ToString("N2");
                }
                else
                {
                    frmMensaje m = new frmMensaje("Cantidad erronea. Max.[" + canExi+"]");
                    m.ShowDialog();
                    nucantidad.Value = 1;
                }
                nucantidad.Value = 1;
                txtcodarticulo.Focus();
                botonesEstado();
            }
        }

        private void btnRepetir_Click(object sender, EventArgs e)
        {
            int pos = lbcodigo.SelectedIndex;
            if (pos != -1)
            {
                String lCod = lbcodigo.Items[pos].ToString();
                int inIn = lCod.IndexOf("[");
                int inFi = lCod.IndexOf("]");
                String lbCod = lCod.Substring(inIn + 1, inFi - inIn - 1);
                float exis = traerExistencia(lbCod);
                float act = float.Parse(lbcantidad.Items[pos].ToString());
                float agre = float.Parse(nucantidad.Value.ToString());

                if(exis>=(act+agre))
                {
                    float cantidad = float.Parse(lbcantidad.Items[pos].ToString()) + float.Parse(nucantidad.Value.ToString());
                    String pre = lbprecio.Items[pos].ToString().Substring(2);
                    float parcial = cantidad * float.Parse(pre);

                    lbcantidad.Items[pos] = cantidad;
                    lbparcial.Items[pos] = ("$ " + parcial);
                    
                    subtotal = subtotal + (float.Parse(nucantidad.Value.ToString()) * float.Parse(pre));
                    lblsubtotal.Text = "$ " + subtotal.ToString("N2");
                    lbltotal.Text = "$ " + subtotal.ToString("N2");
                }
                else
                {
                    if (exis == act)
                    {
                        frmMensaje m = new frmMensaje("Existencia agotada");
                        m.ShowDialog();                        
                    }
                    else
                    {
                        frmMensaje m = new frmMensaje("Cantidad errona. Max.[" + (exis - act) + "]");
                        m.ShowDialog();
                    }
                    
                }
                nucantidad.Value = 1;
                txtcodarticulo.Focus();                
            }
        }

        private void txtSuPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            miclase.SoloNumerosPD(e);
            if (e.KeyChar == 27)
            {
                txtsupago.Clear();
                lblsupago.Visible = false;
                txtsupago.Visible = false;
                pbanuncios.Visible = true;
                btnreimprimir.Visible = true;
                txtcodarticulo.Focus();
                bloquearbd = false;
                ulse = (lbcodigo.Items.Count)-1;
                sigArt();
                lblsubtotal.Enabled = true;
                lblsubanuncio.Enabled = true;
                lblivaanuncio.Enabled = true;
                lbliva.Enabled = true;
                txtcodarticulo.Enabled = true;
                txtcodarticulo.Focus();
                ChMenudeo.Enabled = true;
                btncredito.Visible = false;
                btnnocredito.Visible = false;
                btnreimprimir.Visible = false;
                btnreimprimir.Visible = true;
                btndevolver.Visible = true;
                botonesEstado();
            }
            if(e.KeyChar==13 && txtsupago.Text.Length > 0)
            {
                frmValidar v = new frmValidar("El pago $"+int.Parse(txtsupago.Text).ToString("N2") +" ¿es correcto?",this);
                v.ShowDialog();
            }
        }        

        private void btncancelar_Click(object sender, EventArgs e)
        {
            NuevaVenta();
        }

        private void btnnocredito_Click(object sender, EventArgs e)
        {
            txtsupago.Clear();
            txtsupago.Focus();
            btncredito.Visible = btnnocredito.Visible = false;            
        }

        private void btncredito_Click(object sender, EventArgs e)
        {
            tt = "CREDITO";
            int res = CargarCredito(txtcodcliente.Text, resto);
            ImprimirTicket(tt);
            switch (res)
            { 
                case 1:
                    frmMensaje m = new frmMensaje("Se agregó $"+resto.ToString("N2") + " a la deuda");
                    m.ShowDialog();
                break;

                case 2:
                    frmMensaje m1 = new frmMensaje("Se creó una deuda con $"+resto.ToString("N2"));
                    m1.ShowDialog();
                break;
            }
            NuevaVenta();
        }

        private void btnbusqueda_Click(object sender, EventArgs e)
        {

            frmBuscar b = new frmBuscar();
            b.ShowDialog();
            if (txtcodarticulo.Enabled == true)
            {
                txtcodarticulo.Focus();
            }
            else if (txtcodcliente.Enabled == true)
            {
                txtcodcliente.Focus();
            }
            else if (txtcantidad.Enabled == true)
            {
                txtcantidad.Focus();
            }
            else
            {
                txtsupago.Focus();
            }
        }

        private void txtcodcliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            miclase.SoloNumeros(e);
            if (e.KeyChar == 27)
            {
                frmMenu FM = new frmMenu();
                FM.Show();
                this.Close();
            }
            if (e.KeyChar == 13 && txtcodcliente.Text.Length > 0)
            {
                MySqlConnection cnn = new MySqlConnection(miclase.conexion);
                cnn.Open();
                MySqlCommand comando = new MySqlCommand("Select * from clientes where codigo='" + int.Parse(txtcodcliente.Text).ToString() + "'", cnn);
                MySqlDataReader myreader = comando.ExecuteReader();
                comando.Dispose();
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        txtcodcliente.Text = myreader["codigo"].ToString();
                        txtrfc.Text = myreader["rfc"].ToString();
                        txtnombre.Text = myreader["nombre"].ToString();
                        txtdireccion.Text = myreader["direccion"].ToString();
                        txtelefono.Text = myreader["telefono"].ToString();
                    }
                    gbarticulos.Enabled = true;
                    gbsucompra.Enabled = true;
                    gbcliente.Enabled = false;
                    txtcodarticulo.Enabled = true;
                    txtcodarticulo.Focus();
                    btncancelar.Enabled = true;
                    ChMenudeo.Enabled = true;
                }
                else
                {
                    frmMensaje ms = new frmMensaje("El cliente ingresado no existe");
                    ms.ShowDialog();
                    txtcodcliente.Clear();
                    txtcodcliente.Focus();
                }
            }
        }

        private void ChMenudeo_Click(object sender, EventArgs e)
        {
            txtcodarticulo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevaVenta();
        }
      }
    }

