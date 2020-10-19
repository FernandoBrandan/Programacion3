

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;



namespace CarritoWeb
{
    public partial class AgregarArt : System.Web.UI.Page
    {
        public Articulo Lista { get; set; }
        public List<Articulo> Busqueda;
        int total = 0;


        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
          
            dt.Columns.Add("ID");
            dt.Columns.Add("NOMBRE");
            dt.Columns.Add("PRECIO");
            dt.Columns.Add("CANTIDAD");

            return dt;
        }

        public void AgregarFila(DataTable tabla, string nombre, int precio, int id)
        {
            
            DataRow dr = tabla.NewRow();
            dr["id"] = id;
            dr["Nombre"] = nombre;
            dr["Precio"] = precio;
            


            tabla.Rows.Add(dr);
        }

        public void EliminarFila(DataTable tabla, int id)
        {
            for (int i = tabla.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dt = tabla.Rows[i];
                if (Convert.ToInt32(dt["id"]) == id)
                {
                    dt.Delete();
                }
            }
        }
        public int sumarTotal(DataTable tabla, int precio)
        {
            var total = 0;
            total = +precio;   
            return total;
        }


        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {/*
            EliminarFila((DataTable)Session["Carrito"], Convert.ToInt32(ideliminar.Text));
            Response.Redirect("AgregarArt.aspx");
            */
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              
                NegocioArticulo BuscarArticulo = new NegocioArticulo();
                Busqueda = BuscarArticulo.ListarArticulos();
                


                int articuloSeleccionado = Convert.ToInt32(Request.QueryString["idAgregarCarrito"]);

                if (articuloSeleccionado != 0)
                {
                    Lista = Busqueda.Find(x => x.ID == articuloSeleccionado);

                    if (Session["Carrito"] == null)
                    {
                        total = 0;
                        CrearTabla();
                        Session["Carrito"] = CrearTabla();
                    }
                    AgregarFila((DataTable)Session["Carrito"], Lista.Nombre, (int)Lista.Precio, Lista.ID);

                    total +=(int)Lista.Precio;
                    Lbltotal.Text = total.ToString();



                    dvListado.DataSource = (DataTable)Session["Carrito"];
                    dvListado.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }






        }
    }
}