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
    public partial class frmPrincipal : Form
    {
        private List<DomArticulo> Listalocal = null;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos() 
        {
            try
            {
                NegArticulo ListarArticulo = new NegArticulo();
                dataGridView1.DataSource = ListarArticulo.ListarArticulos();
                dataGridView1.AutoResizeColumns();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            DomArticulo Modificar;
            Modificar = (DomArticulo)dataGridView1.CurrentRow.DataBoundItem;
            frmAgregar Agregar = new frmAgregar(Modificar);
            Agregar.Text = "Modificar";
            Agregar.ShowDialog();
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            NegArticulo Negocio = new NegArticulo();
            try
            {
                int id = ((DomArticulo)dataGridView1.CurrentRow.DataBoundItem).ID;
                if (MessageBox.Show("Seguro que quiere eliminar?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Negocio.Eliminar(id);
                }
                CargarDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
                List<DomArticulo> ListaFiltrada;
            NegArticulo ListarArticulo = new NegArticulo();
            Listalocal = ListarArticulo.ListarArticulos();
            try
            {
                if (tbxFiltro.Text == "")
                {
                    dataGridView1.DataSource = Listalocal;
                    ListaFiltrada = Listalocal;
                }
                else
                {
                   ListaFiltrada = Listalocal.FindAll(Y => Y.Descripcion.ToLower().Contains(tbxFiltro.Text.ToLower()) || Y.Nombre.ToLower().Contains(tbxFiltro.Text.ToLower()) || Y.Codigo.ToLower().Contains(tbxFiltro.Text.ToLower()));
                   dataGridView1.DataSource = ListaFiltrada;
                }
                dataGridView1.DataSource = ListaFiltrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (lblFiltro.Checked == true)
            {
                tbxFiltro.Enabled = true;
            }
            else
            {
                tbxFiltro.Text = "";
                tbxFiltro.Enabled = false;
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            DomArticulo Detalles;
            Detalles = (DomArticulo)dataGridView1.CurrentRow.DataBoundItem;
            Detalles Agregar = new Detalles(Detalles);
            Agregar.Text = "Detalles";
            Agregar.ShowDialog();
            CargarDatos();
        }
    }
}
