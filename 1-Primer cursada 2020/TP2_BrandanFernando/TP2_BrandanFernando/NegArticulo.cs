using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP2_BrandanFernando
{
    public class NegArticulo
    {
        public List<DomArticulo> ListarArticulos()
        {
            DomArticulo aux;
            List<DomArticulo> ListarArticulos = new List<DomArticulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("select A.Id, A.Codigo, A.Nombre, A.Descripcion, m.Id, m.Descripcion, c.Id, c.Descripcion, A.ImagenURL, A.Precio from ARTICULOS A inner join MARCAS AS M ON A.IdMarca = M.Id inner join CATEGORIAS AS C ON A.IdCategoria = C.Id");
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    aux = new DomArticulo();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                  
                    aux.Marca = new DomMarca();
                    aux.Marca.IdMarca = datos.Lector.GetInt32(4);
                    aux.Marca.Descripcion = datos.Lector.GetString(5);

                    aux.Categoria = new DomCategoria();
                    aux.Categoria.IdCategoria = datos.Lector.GetInt32(6);
                    aux.Categoria.Descripcion = datos.Lector.GetString(7);

                    aux.ImagenURL = datos.Lector.GetString(8);
                    aux.Precio = datos.Lector.GetDecimal(9);

                    ListarArticulos.Add(aux);
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
            return ListarArticulos;
        }

        public void Agregar(DomArticulo NuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.agregarParametro("@Codigo", NuevoArticulo.Codigo);
                datos.agregarParametro("@Nombre", NuevoArticulo.Nombre);
                datos.agregarParametro("@Descripcion", NuevoArticulo.Descripcion);
                datos.agregarParametro("@IdMarca", NuevoArticulo.Marca.IdMarca);
                datos.agregarParametro("@IdCategoria", NuevoArticulo.Categoria.IdCategoria);
                datos.agregarParametro("@ImagenUrl", NuevoArticulo.ImagenURL);
                datos.agregarParametro("@Precio", NuevoArticulo.Precio);
                datos.EjecutarConsulta();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(DomArticulo NuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id;");
                datos.agregarParametro("@Id", NuevoArticulo.ID);
                datos.agregarParametro("@Codigo", NuevoArticulo.Codigo);
                datos.agregarParametro("@Nombre", NuevoArticulo.Nombre);
                datos.agregarParametro("@Descripcion", NuevoArticulo.Descripcion);
                datos.agregarParametro("@IdMarca", NuevoArticulo.Marca.IdMarca);
                datos.agregarParametro("@IdCategoria", NuevoArticulo.Categoria.IdCategoria);
                datos.agregarParametro("@ImagenUrl", NuevoArticulo.ImagenURL);
                datos.agregarParametro("@Precio", NuevoArticulo.Precio);
                datos.EjecutarUpdate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("delete ARTICULOS where Id = @Id;");
                datos.agregarParametro("@Id", id);
                datos.EjecutarUpdate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}