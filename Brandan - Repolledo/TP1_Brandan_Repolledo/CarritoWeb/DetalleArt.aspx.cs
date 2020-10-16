using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CarritoWeb
{
    public partial class DetalleArt : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            List<Articulo> listarArticulo;
            try
            {
                listarArticulo = negocio.ListarArticulos();
                int articuloSeleccionado = Convert.ToInt32(Request.QueryString["idAr"]);
                articulo = listarArticulo.Find(x => x.ID == articuloSeleccionado);

            }
            catch(Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}