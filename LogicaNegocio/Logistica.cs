using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public static class Logistica
    {
        #region Producto
        public static Task ActualizarProducto(Producto producto)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (producto == null)
                        throw new ArgumentNullException("producto");

                    new ProductoAD().ActualizarProducto(producto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task EliminarProducto(int idProducto)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (idProducto.Equals(""))
                        throw new ArgumentNullException("idProducto");

                    new ProductoAD().EliminarProducto(idProducto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task InsertarProducto(Producto producto)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (producto == null)
                        throw new ArgumentNullException("producto");

                    new ProductoAD().InsertarProducto(producto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task<List<Producto>> ListarProductos()
        {
            return Task.Run(() =>
            {
                List<Producto> productos;

                try
                {
                    productos = new ProductoAD().ListarProductos();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return productos;
            });
        }
        public static Task<Producto> ObtenerProducto(int idProducto)
        {
            return Task.Run(() =>
            {
                Producto producto;

                try
                {
                    producto = new ProductoAD().ObtenerProducto(idProducto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return producto;
            });
        }
        #endregion
    }
}
