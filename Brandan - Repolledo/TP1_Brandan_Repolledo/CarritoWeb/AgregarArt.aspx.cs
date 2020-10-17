using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public DataTable CrearTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Precio");
            return dt;
        }

        public void AgregarFila(DataTable tabla, string nombre, int precio)
        {
            DataRow dr = tabla.NewRow();
            dr["Nombre"] = nombre;
            dr["Precio"] = precio;
            tabla.Rows.Add(dr);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
            List<Articulo> Busqueda;
            NegocioArticulo BuscarArticulo = new NegocioArticulo();
            Busqueda = BuscarArticulo.ListarArticulos();

            int articuloSeleccionado = Convert.ToInt32(Request.QueryString["idAr"]);

            if (articuloSeleccionado != 0)
            {
                Lista = Busqueda.Find(x => x.ID == articuloSeleccionado);

                if (Session["Carrito"] == null)
                {
                    CrearTabla();
                    Session["Carrito"] = CrearTabla();
                }

                AgregarFila((DataTable)Session["Carrito"], Lista.Nombre, (int)Lista.Precio);

               
            }
            dvListado.DataSource = (DataTable)Session["Carrito"];
            dvListado.DataBind();



        }
    }
}