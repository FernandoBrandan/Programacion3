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
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }
      
        private void Presentacion_Load(object sender, EventArgs e)
        {
            timer1.Start();
            TituloPresentacion.BackColor = Color.Transparent;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            progressBar1.Increment(5);

           if(progressBar1.Value == 100)
            {
                timer1.Stop();
                //this.Close();
                Dispose();
            }
        }

    }
}
