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
    public class EmpleadoAD : Base
    {
        public EmpleadoAD() : base()
        {

        }
        public Empleado ObtenerEmpleado(string idUsuario)
        {
            Empleado empleado = new Empleado();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ObtenerEmpleado";
                    comando.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                    reader = comando.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            empleado.IdUsuario = Convert.ToString(reader["IdUsuario"]);
                            empleado.Identificacion = Convert.ToInt32(reader["Identificacion"]);
                            empleado.Nombre = Convert.ToString(reader["Nombre"]);
                            empleado.PrimerApellido = Convert.ToString(reader["PrimerApellido"]);
                            empleado.SegundoApellido = Convert.ToString(reader["SegundoApellido"]);
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
            return empleado;
        }
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlDataReader reader;
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ListarEmpleado";
                    reader = comando.ExecuteReader();
                    try
                    {
                        Empleado empleado;
                        while (reader.Read())
                        {
                            empleado = new Empleado()
                            {
                                IdUsuario = Convert.ToString(reader["IdUsuario"]),
                                Identificacion = Convert.ToInt32(reader["Identificacion"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                PrimerApellido = Convert.ToString(reader["PrimerApellido"]),
                                SegundoApellido = Convert.ToString(reader["SegundoApellido"])
                            };
                            empleados.Add(empleado);
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
            return empleados;
        }
        public void InsertarEmpleado(Empleado empleado)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "InsertarEmpleado";
                    comando.Parameters.Add(new SqlParameter("@idUsuario", empleado.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@identificacion", empleado.Identificacion));
                    comando.Parameters.Add(new SqlParameter("@PrimerApellido", empleado.Nombre));
                    comando.Parameters.Add(new SqlParameter("@PrimerApellido", empleado.PrimerApellido));
                    comando.Parameters.Add(new SqlParameter("@SegundoApellido", empleado.SegundoApellido));
                    comando.Parameters.Add(new SqlParameter("@Contraseña", empleado.Contrasena));
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
        public void ActualizarEmpleado(Empleado empleado)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "ActualizarEmpleado";
                    comando.Parameters.Add(new SqlParameter("@idUsuario", empleado.IdUsuario));
                    comando.Parameters.Add(new SqlParameter("@identificacion", empleado.Identificacion));
                    comando.Parameters.Add(new SqlParameter("@PrimerApellido", empleado.Nombre));
                    comando.Parameters.Add(new SqlParameter("@PrimerApellido", empleado.PrimerApellido));
                    comando.Parameters.Add(new SqlParameter("@SegundoApellido", empleado.SegundoApellido));
                    comando.Parameters.Add(new SqlParameter("@Contraseña", empleado.Contrasena));
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
        public void EliminarEmpleado(string idUsuario)
        {
            using (var bd = new Base())
            {
                try
                {
                    bd.IniciarTransaccion();

                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "EliminarEmpleado";
                    comando.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
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
