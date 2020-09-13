using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2_BrandanFernando
{
    public class AccesoDatos
    {
        public SqlDataReader Lector { get; set; }
        public SqlConnection Conexion { get; set; }
        public SqlCommand Comando { get; set; }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("data source= DESKTOP-PRA4SKB\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=sspi");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void SetearQuery(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }
        public void SP(string sp)
        {

        }

        public void agregarParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarConsulta()
        {
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void CerrarConexion()
        {
            Conexion.Close();
        }

        public void EjecutarUpdate()
        {
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
