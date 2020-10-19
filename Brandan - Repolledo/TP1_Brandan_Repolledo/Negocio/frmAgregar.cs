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

            try
            {
                cbxCategoria.ValueMember = "ID";
                cbxCategoria.DisplayMember = "Descripcion";
                cbxCategoria.SelectedIndex = -1;
                cbxMarca.ValueMember = "ID";
                cbxMarca.DisplayMember = "Descripcion";
                cbxMarca.SelectedIndex = -1;

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    cbxCategoria.SelectedValue = articulo.Categoria.ID;
                    cbxMarca.SelectedValue = articulo.Marca.ID;
                    txtImagenURL.Text = articulo.ImagenUrl;
                    txtPrecio.Text = articulo.Precio.ToString();                    
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

                   
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            NegocioArticulo negocio = new NegocioArticulo();
            try
            {
                if (articulo != null)
                {
                    nuevo.ID = articulo.ID;
                    nuevo.Codigo = txtCodigo.Text;
                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Descripcion = txtDescripcion.Text;
                    nuevo.Marca = (Marca)cbxMarca.SelectedItem;
                    nuevo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                    nuevo.ImagenUrl = txtImagenURL.Text;
                    nuevo.Precio = Convert.ToDecimal(txtPrecio.Text);
                    negocio.Modificar(nuevo);
                    MessageBox.Show("Se ha modificado su registro");
                    Dispose();
                }

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
                        MessageBox.Show("Faltan elegir datos", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Dispose();
                    }
                    else
                    {
                        if(nuevo.Codigo == "" ||
                            nuevo.Nombre == "" ||
                            nuevo.Descripcion == "" ||
                            nuevo.ImagenUrl == "")
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
