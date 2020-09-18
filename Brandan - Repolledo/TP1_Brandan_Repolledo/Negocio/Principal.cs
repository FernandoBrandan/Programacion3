using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public partial class Principal : Form
    {
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
                NegocioArticulo ListadoArticulos = new NegocioArticulo();
                dgvPrincipal.DataSource = ListadoArticulos.ListarArticulos();
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
            MessageBox.Show("Agregado correctamente");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo modificar;
            modificar =(Articulo)grillaArticulos.CurrentRow.DataBoundItem;
            frmAgregar formularioModificar = new frmAgregar(modificar);
            formularioModificar.ShowDialog();
            MessageBox.Show("Modificado Correctamente");

        }
    }
}
