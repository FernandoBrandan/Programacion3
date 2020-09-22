using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public partial class frmDetalle : Form
    {
        private Articulo articulo = null;

        public frmDetalle()
        {
            InitializeComponent();
        }

        public frmDetalle(Articulo arti)
        {
            InitializeComponent();
            articulo = arti;
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            // lblCodigo.Text = articulo.Codigo;
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtCategoria.Text = articulo.Categoria.Descripcion;
            txtMarca.Text = articulo.Marca.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();

            pbxImagen.Load(articulo.ImagenUrl);
        }

        private void lbNombre_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
