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
    public class FacturaProductoAD : Base
    {
        public FacturaProductoAD() : base()
        {

        }
        public FacturaProducto ObtenerFacturaProducto(int idFactura, int idProducto)
        {
            FacturaProducto facturaProducto = new FacturaProducto();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ObtenerFacturaProducto";
                    comando.Parameters.Add(new SqlParameter("@idFactura", idFactura));
                    comando.Parameters.Add(new SqlParameter("@idProducto", idProducto));
                    reader = comando.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            facturaProducto.Cantidad = Convert.ToInt32(reader["Cantidad"]);

                            facturaProducto.Factura = new Factura() { IdFactura = Convert.ToInt32(reader["IdFactura"]) };
                            facturaProducto.Producto = new Producto() { IdProducto = Convert.ToInt32(reader["IdProducto"]) };
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
            return facturaProducto;
        }
        public List<FacturaProducto> ListarFacturaProductos()
        {
            List<FacturaProducto> facturaProductos = new List<FacturaProducto>();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ListarFacturaProducto";
                    reader = comando.ExecuteReader();
                    try
                    {
                        FacturaProducto facturaProducto;
                        while (reader.Read())
                        {
                            facturaProducto = new FacturaProducto()
                            {
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Factura = new Factura() { IdFactura = Convert.ToInt32(reader["IdFactura"]) },
                                Producto = new Producto() { IdProducto = Convert.ToInt32(reader["IdProducto"]) }
                            };
                            facturaProductos.Add(facturaProducto);
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
            return facturaProductos;
        }
        public void InsertarFacturaProducto(FacturaProducto facturaProducto)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "InsertarFacturaProducto";
                    comando.Parameters.Add(new SqlParameter("@cantidad", facturaProducto.Cantidad));
                    comando.Parameters.Add(new SqlParameter("@idFactura", facturaProducto.Factura.IdFactura));
                    comando.Parameters.Add(new SqlParameter("@idProducto", facturaProducto.Producto.IdProducto));
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
        public void EliminarFacturaProductoPorFactura(int idFacturaProducto)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "EliminarFacturaProductoPorFactura";
                    comando.Parameters.Add(new SqlParameter("@idFacturaProducto", idFacturaProducto));
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
