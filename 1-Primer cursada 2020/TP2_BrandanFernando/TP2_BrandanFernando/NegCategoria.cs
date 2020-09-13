using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2_BrandanFernando
{
    public class NegCategoria
    {
        public List<DomCategoria> ListarCategoria()
        {

        List<DomCategoria> ListarCategoria = new List<DomCategoria>();
        AccesoDatos datos = new AccesoDatos();
        try
        {
            datos.SetearQuery("SELECT * FROM CATEGORIAS;");
            datos.EjecutarConsulta();
            while (datos.Lector.Read())
            {
                DomCategoria aux = new DomCategoria();
                    aux.IdCategoria = datos.Lector.GetInt32(0);
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
           datos.CerrarConexion();
        }

        return ListarCategoria;

        }
    }
}
