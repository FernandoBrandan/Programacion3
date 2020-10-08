using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CarritoWeb
{
    public partial class _Default : Page
    {
        public List<Articulo> ListadeArticulos { get; set; }
       
            

        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            ListadeArticulos = negocio.ListarArticulos();



           
        }
    }
}