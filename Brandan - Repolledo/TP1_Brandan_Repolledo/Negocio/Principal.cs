using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public partial class Principal : Form
    {
        private List<Articulo> listaOriginal;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                NegocioArticulo listadoArticulos = new NegocioArticulo();
                listaOriginal = listadoArticulos.ListarArticulos();
                dgvPrincipal.DataSource = listadoArticulos.ListarArticulos();
                dgvPrincipal.Columns[0].Visible = false;
                dgvPrincipal.Columns[4].Visible = false;
                dgvPrincipal.Columns[5].Visible = false;
                dgvPrincipal.Columns[6].Visible = false;
                dgvPrincipal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar Agregar = new frmAgregar();
            Agregar.ShowDialog();
            CargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo ModificaArticulo;
            ModificaArticulo = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;// traigo el registro actual
            frmAgregar modificar = new frmAgregar(ModificaArticulo);
            modificar.Text = "Modificar";
            modificar.ShowDialog();
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            if (MessageBox.Show("Eliminar", "¿Seguro desea eliminar el registro?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                CargarDatos();
            }
            else
            { 
                negocio.eliminar(((Articulo)dgvPrincipal.CurrentRow.DataBoundItem).ID);
                CargarDatos();
                MessageBox.Show("Se ha eliminado el registro");
            }
        }

        private void tbxBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> ListaFiltrada;
            NegocioArticulo ListaArticulos = new NegocioArticulo();
            listaOriginal = ListaArticulos.ListarArticulos();
            
            try
            {
                if (tbxBusqueda.Text == "")
                {
                    dgvPrincipal.DataSource = listaOriginal;
                    ListaFiltrada = listaOriginal;
                }
                else
                {
                 //   ListaFiltrada = listaOriginal.FindAll(x => x.Nombre.ToUpper().Contains(tbxBusqueda.Text.ToUpper()));
                    ListaFiltrada = listaOriginal.FindAll(Y => Y.Descripcion.ToLower().Contains(tbxBusqueda.Text.ToLower()) || Y.Nombre.ToLower().Contains(tbxBusqueda.Text.ToLower()) || Y.Codigo.ToLower().Contains(tbxBusqueda.Text.ToLower()));

                    dgvPrincipal.DataSource = listaOriginal;
                }
                dgvPrincipal.DataSource = ListaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbxFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxFiltro.Checked == true)
            {
                tbxBusqueda.Enabled = true;
            }    
            else
            {
                tbxBusqueda.Enabled = false;
            }    
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo DetalleArticulo;
            DetalleArticulo = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;// traigo el registro actual

            frmDetalle Detalle = new frmDetalle(DetalleArticulo);
            Detalle.ShowDialog();
            CargarDatos();
        }



        /*
private void btnBuscar_Click(object sender, EventArgs e)
{
//List<Articulo> lista = (List<Articulo>)dgvPrincipal.DataSource;
List<Articulo> listaFiltrada = listaOriginal.FindAll(x => x.Nombre.ToUpper().Contains(tbxFiltro.Text.ToUpper()));
dgvPrincipal.DataSource = listaFiltrada;
}*/


    }
}
