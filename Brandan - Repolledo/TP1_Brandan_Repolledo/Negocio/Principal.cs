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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
