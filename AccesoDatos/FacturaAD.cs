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
    public class FacturaAD : Base
    {
        public FacturaAD() : base()
        {

        }
        public Factura ObtenerFactura(int idFactura)
        {
            Factura factura = new Factura();
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
                    comando.CommandText = "facturacion.ObtenerFactura";
                    comando.Parameters.Add(new SqlParameter("@idFactura", idFactura));
                    reader = comando.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            factura.IdFactura = Convert.ToInt32(reader["IdFactura"]);
                            factura.MomentoCreacion = Convert.ToDateTime(reader["MomentoCreacion"]);

                            factura.EmpleadoFacturador = new Empleado() { IdUsuario = Convert.ToString(reader["IdUsuario"]) };
                            factura.Cliente = new Cliente() { IdCliente = Convert.ToInt32(reader["IdCliente"]) };
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
            return factura;
        }
        public List<Factura> ListarFacturas()
        {
            List<Factura> facturas = new List<Factura>();
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
                    comando.CommandText = "facturacion.ListarFactura";
                    reader = comando.ExecuteReader();
                    try
                    {
                        Factura factura;
                        while (reader.Read())
                        {
                            factura = new Factura()
                            {
                                IdFactura = Convert.ToInt32(reader["IdFactura"]),
                                MomentoCreacion = Convert.ToDateTime(reader["MomentoCreacion"]),
                                EmpleadoFacturador = new Empleado() { IdUsuario = Convert.ToString(reader["IdUsuario"]) },
                                Cliente = new Cliente() { IdCliente = Convert.ToInt32(reader["IdCliente"]) }
                            };
                            facturas.Add(factura);
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
            return facturas;
        }
        public void InsertarFactura(Factura factura)
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
                    comando.CommandText = "facturacion.InsertarFactura";
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
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "facturacion.ActualizarFactura";
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
            using (var bd = this)
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = bd.Conexion;
                    comando.Transaction = bd.Transaccion;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "facturacion.EliminarFactura";
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
