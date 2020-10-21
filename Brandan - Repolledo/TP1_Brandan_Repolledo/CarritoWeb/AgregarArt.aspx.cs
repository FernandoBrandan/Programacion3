using System;
using System.Threading;
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
        int articuloSeleccionado;

        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NOMBRE");
            dt.Columns.Add("DESCRIPCION");
            dt.Columns.Add("PRECIO");
            return dt;
        }

        public void AgregarFila(DataTable tabla, string nombre, string descripcion, int precio, int id)
        {
            DataRow dr = tabla.NewRow();
            dr["id"] = id;
            dr["Nombre"] = nombre;
            dr["Descripcion"] = descripcion;
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
                    Response.Redirect("AgregarArt.aspx");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Seleccionar ID correcto')</script>");
                    break;
                }
            }  
        }

        public int sumarTotal(DataTable tabla)
         {
            var total = 0;

            if (tabla != null && tabla.Rows.Count > 0)
            {
                for (int i = tabla.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dt = tabla.Rows[i];
                    total += Convert.ToInt32(dt["Precio"]);
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Carrito vacio. Por favor, seleccionar elementos')</script>");
            }
            return total;
        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarFila((DataTable)Session["Carrito"], Convert.ToInt32(ideliminar.Text));
            }
            catch (Exception)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Carrito vacio. Por favor, seleccionar elementos')</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioArticulo BuscarArticulo = new NegocioArticulo();
            Busqueda = BuscarArticulo.ListarArticulos();

            try
            {
                articuloSeleccionado = Convert.ToInt32(Request.QueryString["idAgregarCarrito"]);
                if (articuloSeleccionado != 0)
                {
                    Lista = Busqueda.Find(x => x.ID == articuloSeleccionado);

                    if (Session["Carrito"] == null)
                    {
                        total = 0;
                        CrearTabla();
                        Session["Carrito"] = CrearTabla();
                    }
                    AgregarFila((DataTable)Session["Carrito"], Lista.Nombre, Lista.Descripcion, (int)Lista.Precio, Lista.ID);

                }
                
                total += sumarTotal((DataTable)Session["Carrito"]);
                Lbltotal.Text = total.ToString();
                dvListado.DataSource = (DataTable)Session["Carrito"];
                dvListado.DataBind();

                // eliminamos
                //Request.QueryString.Remove("idAgregarCarrito");
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Se genero un error'" + ex +")</script>");
            }
        }

        protected void btnEliminarTodo_Click(object sender, EventArgs e)
        {

            int TotalVacio = 0;
            Session["Carrito"] = null;
            Lbltotal.Text = TotalVacio.ToString();
            dvListado.DataSource = (DataTable)Session["Tabla"];
            dvListado.DataBind();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Se vacio el Carrito')</script>");
            
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            int TotalVacio = 0;
            Session["Carrito"] = null;
            Lbltotal.Text = TotalVacio.ToString();
            dvListado.DataSource = (DataTable)Session["Tabla"];
            dvListado.DataBind();
            Response.Redirect("About.aspx");
        }
    }
}