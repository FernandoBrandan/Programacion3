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

            
        }

        private void label2_Click(object sender, EventArgs e)
        {
       

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            NegocioArticulo negocio = new NegocioArticulo();
            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                    nuevo.Codigo = txtCodigo.Text;
                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Descripcion = txtDescripcion.Text;
                    nuevo.Marca = (Marca)cbxMarca.SelectedItem;
                    nuevo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                    nuevo.ImagenUrl = txtImagenURL.Text;
                    nuevo.Precio = Convert.ToDecimal(txtPrecio.Text);

                    if (nuevo.Marca == null || nuevo.Categoria == null)
                    {
                        MessageBox.Show("Faltan cargar datos", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Dispose();
                    }
                    else
                    {
                        negocio.Agregar(nuevo);
                        Dispose();
                    }
                }
                else
                {
                        negocio.Modificar(nuevo);
                        MessageBox.Show("Se ha modificado su registro");
                }
            }  
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
          
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
