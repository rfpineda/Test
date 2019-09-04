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
    public class ClienteAD : Base
    {
        public ClienteAD() : base()
        {

        }
        public Cliente ObtenerCliente(string idCliente)
        {
            Cliente cliente = new Cliente();
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
                    comando.CommandText = "administracion.ObtenerCliente";
                    comando.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    reader = comando.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            cliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                            cliente.Nit = Convert.ToInt32(reader["Nit"]);
                            cliente.Nombre = Convert.ToString(reader["Nombre"]);
                            cliente.Descripcion = Convert.ToString(reader["Descripcion"]);
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
            return cliente;
        }
        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
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
                    comando.CommandText = "administracion.ListarCliente";
                    reader = comando.ExecuteReader();
                    try
                    {
                        Cliente cliente;
                        while (reader.Read())
                        {
                            cliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Nit = Convert.ToInt32(reader["Nit"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                Descripcion = Convert.ToString(reader["Descripcion"])
                            };
                            clientes.Add(cliente);
                        }
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
            return clientes;
        }
        public void InsertarCliente(Cliente cliente)
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
                    comando.CommandText = "administracion.InsertarCliente";
                    comando.Parameters.Add(new SqlParameter("@nit", cliente.Nit));
                    comando.Parameters.Add(new SqlParameter("@nombre", cliente.Nombre));
                    comando.Parameters.Add(new SqlParameter("@descripcion", cliente.Descripcion));
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
        public void ActualizarCliente(Cliente cliente)
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
                    comando.CommandText = "administracion.ActualizarCliente";
                    comando.Parameters.Add(new SqlParameter("@idCliente", cliente.IdCliente));
                    comando.Parameters.Add(new SqlParameter("@nit", cliente.Nit));
                    comando.Parameters.Add(new SqlParameter("@nombre", cliente.Nombre));
                    comando.Parameters.Add(new SqlParameter("@descripcion", cliente.Descripcion));
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
        public void EliminarCliente(int idCliente)
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
                    comando.CommandText = "administracion.EliminarCliente";
                    comando.Parameters.Add(new SqlParameter("@idCliente", idCliente));
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
