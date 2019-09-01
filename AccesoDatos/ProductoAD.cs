using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ProductoAD : Base
    {
        public ProductoAD() : base()
        {

        }
        public Producto ObtenerProducto(int idProducto)
        {
            Producto producto = new Producto();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ObtenerProducto";
                    comando.Parameters.Add(new SqlParameter("@idProducto", idProducto));
                    reader = comando.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                            producto.Nombre = Convert.ToString(reader["Nombre"]);
                            producto.Descripcion = Convert.ToString(reader["Descripcion"]);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
            return producto;
        }
        public List<Producto> ListarProductoas()
        {
            List<Producto> productos = new List<Producto>();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ListarProducto";
                    reader = comando.ExecuteReader();
                    try
                    {
                        Producto producto;
                        while (reader.Read())
                        {
                            producto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                Descripcion = Convert.ToString(reader["Descripcion"])
                            };
                            productos.Add(producto);
                        };
                    }
                    finally
                    {
                        try
                        {
                            reader.Close();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
            return productos;
        }
        public void InsertarFactura(Factura factura)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "InsertarFactura";
                    comando.Parameters.Add(new SqlParameter("@momentoCreacion", factura.MomentoCreacion));
                    comando.Parameters.Add(new SqlParameter("@idUsuario", factura.EmpleadoFacturador.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@idCliente", factura.Cliente.IdCliente));
                    comando.ExecuteNonQuery();

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
        }
        public void ActualizarFactura(Factura factura)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ActualizarFactura";
                    comando.Parameters.Add(new SqlParameter("@idFactura", factura.IdFactura));
                    comando.Parameters.Add(new SqlParameter("@momentoCreacion", factura.MomentoCreacion));
                    comando.Parameters.Add(new SqlParameter("@idUsuario", factura.EmpleadoFacturador.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@idCliente", factura.Cliente.IdCliente));
                    comando.ExecuteNonQuery();

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
        }
        public void EliminarFactura(int idFactura)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "EliminarFactura";
                    comando.Parameters.Add(new SqlParameter("@idFactura", idFactura));
                    comando.ExecuteNonQuery();

                    bd.ConfirmarTransaccion();
                }
                catch (Exception)
                {
                    bd.RevertirTransaccion();
                    throw;
                }
            }
        }
    }
}
