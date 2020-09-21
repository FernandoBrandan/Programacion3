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
            lbNombre.Text = articulo.Nombre;
            pbxImagen.Load(articulo.ImagenUrl);
        }
    }
}
