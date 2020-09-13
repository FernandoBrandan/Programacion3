using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_BrandanFernando
{
    public partial class Detalles : Form
    {
        private DomArticulo articulo = null;
        public Detalles()
        {
            InitializeComponent();
        }
        public Detalles(DomArticulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void Detalles_Load(object sender, EventArgs e)
        {
            NegMarca CargaMarca = new NegMarca();
            NegCategoria CargaCategoria = new NegCategoria();
            try
            {
                lblCodigo.Text = articulo.Codigo;
                lblNombre.Text = articulo.Nombre;
                lblDescripcion.Text = articulo.Descripcion;
                lblMarca.Text = articulo.Marca.Descripcion;
                lblCategoria.Text = articulo.Categoria.Descripcion;
                pbImagenUrl.Load(articulo.ImagenURL); 
                lblPrecio.Text = articulo.Precio.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
