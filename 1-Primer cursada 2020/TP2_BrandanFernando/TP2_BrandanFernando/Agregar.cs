using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TP2_BrandanFernando
{
    public partial class frmAgregar : Form
    {
        private DomArticulo articulo = null;
        public frmAgregar()
        {
            InitializeComponent();
        }
        public frmAgregar(DomArticulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            NegMarca CargaMarca = new NegMarca();
            NegCategoria CargaCategoria = new NegCategoria();
            try
            {
                cbxMarca.DataSource = CargaMarca.ListarMarca();
                cbxMarca.DisplayMember = "Descripcion";
                cbxMarca.ValueMember = "IdMarca";
                cbxMarca.SelectedIndex = -1;
                               
                cbxCategoria.DataSource = CargaCategoria.ListarCategoria();
                cbxCategoria.DisplayMember = "Descripcion"; 
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.SelectedIndex = -1;

                if (articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                    if (articulo.Marca != null && articulo.Categoria != null)
                    {
                        cbxMarca.SelectedValue = articulo.Marca.IdMarca;
                        cbxCategoria.SelectedValue = articulo.Categoria.IdCategoria;
                    }
                    tbxImagenURL.Text = articulo.ImagenURL;
                    tbxPrecio.Text = articulo.Precio.ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            NegArticulo AgregarArticulo = new NegArticulo();
            try
            {
                if (articulo == null)
                {
                    DomArticulo Nuevoarticulo = new DomArticulo();
                    Nuevoarticulo.Codigo = tbxCodigo.Text;
                    Nuevoarticulo.Nombre = tbxNombre.Text;
                    Nuevoarticulo.Descripcion = tbxDescripcion.Text;
                    Nuevoarticulo.Marca = (DomMarca)cbxMarca.SelectedItem;
                    Nuevoarticulo.Categoria = (DomCategoria)cbxCategoria.SelectedItem;
                    Nuevoarticulo.ImagenURL = tbxImagenURL.Text;
                    Nuevoarticulo.Precio = Convert.ToDecimal(tbxPrecio.Text);
                    AgregarArticulo.Agregar(Nuevoarticulo);
                    Dispose();
                }
                
                if (articulo != null)
                {
                    articulo.Codigo = tbxCodigo.Text;
                    articulo.Nombre = tbxNombre.Text;
                    articulo.Descripcion = tbxDescripcion.Text;
                    articulo.Marca = (DomMarca)cbxMarca.SelectedItem;
                    articulo.Categoria = (DomCategoria)cbxCategoria.SelectedItem;
                    articulo.ImagenURL = tbxImagenURL.Text;
                    articulo.Precio = Convert.ToDecimal(tbxPrecio.Text);
                    AgregarArticulo.Modificar(articulo);  
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tbxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 47 || e.KeyChar > 58) && e.KeyChar != 46) e.Handled = true;
        }
    }
}
