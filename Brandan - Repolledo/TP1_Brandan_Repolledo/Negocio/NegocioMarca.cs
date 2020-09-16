using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    class NegocioMarca
    {
        public List<Marca> ListarMarca()
        {

            List<Marca> ListarMarca = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("SELECT id, Descripcion FROM MARCAS;");
                datos.EjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.ID = datos.Lector.GetInt32(0);
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
                datos.CerraConexion();
            }
            return ListarMarca;
        }
    }
}
