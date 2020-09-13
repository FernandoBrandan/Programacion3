using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2_BrandanFernando
{
    public class NegMarca
    {
        public List<DomMarca> ListarMarca()
        {

            List<DomMarca> ListarMarca = new List<DomMarca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("SELECT id, Descripcion FROM MARCAS;");
           //     datos.agregarParametro("@Id",id );
                datos.EjecutarConsulta();

                while (datos.Lector.Read())
                {
                    DomMarca aux = new DomMarca();
                    aux.IdMarca = datos.Lector.GetInt32(0);
                    aux.Descripcion = datos.Lector.GetString(1);
                    ListarMarca.Add(aux);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return ListarMarca;

        }
    }
}
