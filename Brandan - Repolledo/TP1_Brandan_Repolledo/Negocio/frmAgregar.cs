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
    public partial class frmAgregar : Form
    {
        private Articulo articulo = null;
        public frmAgregar()
        {
            InitializeComponent();
        }
        public frmAgregar(Articulo arti)
        {
            InitializeComponent();
            articulo = arti;
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            NegocioCategoria negocioCategoria = new NegocioCategoria();
            cbxCategoria.DataSource = negocioCategoria.ListarCategoria();
            NegocioMarca negocioMarca = new NegocioMarca();
            cbxMarca.DataSource = negocioMarca.ListarMarca();
             
            cbxCategoria.ValueMember = "ID";
            cbxCategoria.DisplayMember = "Descripcion";
            cbxCategoria.SelectedIndex = -1;
            cbxMarca.ValueMember = "ID";
            cbxMarca.DisplayMember = "Descripcion";
            cbxMarca.SelectedIndex = -1;

            if (articulo !=null)
            {
                Text = "Modificar Articulo";
                txtCodigo.Text = articulo.Codigo;
                txtCodigo.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                cbxCategoria.SelectedValue = articulo.Categoria;
                cbxMarca.SelectedValue = articulo.Marca;
                txtImagenURL.Text = articulo.ImagenUrl;
               //txtPrecio. = articulo.Precio; FER NO PUEDO TRAER EL PRECIO AYUDA!!!!!

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
       

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (articulo == null)
            {
                articulo = new Articulo();
            }
            Articulo nuevo = new Articulo();
            NegocioArticulo negocio = new NegocioArticulo();
            nuevo.Nombre = txtCodigo.Text;
            nuevo.Descripcion = txtNombre.Text;
            nuevo.Categoria = (Categoria)cbxCategoria.SelectedItem;
            

            if (articulo.ID == 0)
            {
                //negocio.Agregar();
                MessageBox.Show("Agregado exitosamente", "EXITO");
            }
            else
            {
                negocio.Modificar(nuevo);
                MessageBox.Show("Se ha modificado su registro");
            }
           


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
