using System;
using System.Collections.Generic;
using System.Data;
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
        private List<Articulo> listaOriginal;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NegocioArticulo negocio = new NegocioArticulo();
                ListadeArticulos = negocio.ListarArticulos();
                Session[Session.SessionID + "ListadeArticulos"] = ListadeArticulos; // Se guarda la lista
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }            
        }

        protected void Busar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> ListaFiltrada;
            NegocioArticulo Lista = new NegocioArticulo();
            listaOriginal = Lista.ListarArticulos();

            try
            {
                if (tbxBuscar.Text == "")
                {
                    ListadeArticulos = listaOriginal;
                    ListaFiltrada = listaOriginal;
                }
                else
                {
                    ListaFiltrada = listaOriginal.FindAll(Y => Y.Descripcion.ToLower().Contains(tbxBuscar.Text.ToLower()) || Y.Nombre.ToLower().Contains(tbxBuscar.Text.ToLower()) || Y.Codigo.ToLower().Contains(tbxBuscar.Text.ToLower()));
                    ListadeArticulos = ListaFiltrada;
                }
                ListadeArticulos = ListaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
} 