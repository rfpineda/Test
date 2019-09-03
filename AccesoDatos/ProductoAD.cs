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
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "logistica.ObtenerProducto";
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
        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "logistica.ListarProducto";
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
        public void InsertarProducto(Producto producto)
        {
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "logistica.InsertarProducto";
                    comando.Parameters.Add(new SqlParameter("@nombre", producto.Nombre));
                    comando.Parameters.Add(new SqlParameter("@descripcion", producto.Descripcion));
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
        public void ActualizarProducto(Producto producto)
        {
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "logistica.ActualizarProducto";
                    comando.Parameters.Add(new SqlParameter("@idProducto", producto.IdProducto));
                    comando.Parameters.Add(new SqlParameter("@nombre", producto.Nombre));
                    comando.Parameters.Add(new SqlParameter("@idUsuario", producto.Descripcion));
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
        public void EliminarProducto(int idProducto)
        {
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "logistica.EliminarProducto";
                    comando.Parameters.Add(new SqlParameter("@idFactura", idProducto));
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
