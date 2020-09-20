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
            comboBox1.DataSource = negocioCategoria.ListarCategoria();
            NegocioMarca negocioMarca = new NegocioMarca();
            comboBox2.DataSource = negocioMarca.ListarMarca();
             
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.SelectedIndex = -1;
           comboBox2.ValueMember = "ID";
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.SelectedIndex = -1;

            if (articulo !=null)
            {
                textBox1.Text = articulo.Codigo;
                textBox2.Text = articulo.Nombre;
                textBox3.Text = articulo.Descripcion;
                comboBox1.SelectedValue = articulo.Categoria;
                comboBox2.SelectedValue = articulo.Marca;
                textBox4.Text = articulo.ImagenUrl;
               //textBox5 = articulo.Precio; FER NO PUEDO TRAER EL PRECIO AYUDA!!!!!

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
       

        }
    }
}
