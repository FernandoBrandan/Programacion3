using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_BrandanFernando
{
    public class DomArticulo
    {
        public int  ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DomMarca Marca { get; set; }
        public DomCategoria Categoria { get; set; }
        public string ImagenURL { get; set; }
        public decimal  Precio { get; set; }
    }
}
