using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class NegocioCategoria
    {
        public List<Categoria> ListarCategoria()
        {

            List<Categoria> ListarCategoria = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("SELECT * FROM CATEGORIAS;");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Descripcion = datos.Lector.GetString(1);
                    ListarCategoria.Add(aux);
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

            return ListarCategoria;

        }
    }
}
