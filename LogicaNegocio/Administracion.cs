using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace LogicaNegocio
{
    public static class Administracion
    {
        #region Cliente
        public static Task ActualizarCliente(Cliente cliente)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (cliente == null)
                        throw new ArgumentNullException("cliente");

                    new ClienteAD().ActualizarCliente(cliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task EliminarCliente(int idCliente)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (idCliente.Equals(""))
                        throw new ArgumentNullException("idCliente");

                    new ClienteAD().EliminarCliente(idCliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task InsertarCliente(Cliente cliente)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (cliente == null)
                        throw new ArgumentNullException("cliente");

                    new ClienteAD().InsertarCliente(cliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task<List<Cliente>> ListarClientes()
        {
            return Task.Run(() =>
            {
                List<Cliente> clientes;

                try
                {
                    clientes = new ClienteAD().ListarClientes();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return clientes;
            });
        }
        public static Task<Cliente> ObtenerCliente(string idCliente)
        {
            return Task.Run(() =>
            {
                Cliente cliente;

                try
                {
                    cliente = new ClienteAD().ObtenerCliente(idCliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return cliente;
            });
        }
        #endregion
        #region Empleado
        public static Task ActualizarEmpleado(Empleado empleado)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (empleado == null)
                        throw new ArgumentNullException("empleado");

                    empleado.Contrasena = Criptografia.EncryptData(empleado.Contrasena, System.Configuration.ConfigurationManager.AppSettings["encriptionKey"].ToString());

                    new EmpleadoAD().ActualizarEmpleado(empleado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task EliminarEmpleado(string idUsuario)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (idUsuario.Equals(""))
                        throw new ArgumentNullException("empleado");

                    new EmpleadoPerfilAD().EliminarEmpleadoPerfilPorEmpleado(idUsuario);
                    new EmpleadoAD().EliminarEmpleado(idUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task InsertarEmpleado(Empleado empleado)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (empleado == null)
                        throw new ArgumentNullException("empleado");

                    empleado.Contrasena = Criptografia.EncryptData(empleado.Contrasena, System.Configuration.ConfigurationManager.AppSettings["encriptionKey"].ToString()); 

                    new EmpleadoAD().InsertarEmpleado(empleado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task<List<Empleado>> ListarEmpleado()
        {
            return Task.Run(() =>
            {
                List<Empleado> empleados;

                try
                {
                    empleados = new EmpleadoAD().ListarEmpleados();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return empleados;
            });
        }
        public static Task<Empleado> ObtenerEmpleado(string idEmpleado)
        {
            return Task.Run(() =>
            {
                Empleado empleado;

                try
                {
                    empleado = new EmpleadoAD().ObtenerEmpleado(idEmpleado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return empleado;
            });
        }
        #endregion
        #region EmpleadoPerfil
        public static Task EliminarEmpleadoPerfil(string idUsuario)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (idUsuario.Equals(""))
                        throw new ArgumentNullException("empleadoPerfil");

                    new EmpleadoPerfilAD().EliminarEmpleadoPerfilPorEmpleado(idUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task InsertarEmpleadoPerfil(EmpleadoPerfil empleadoPerfil)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (empleadoPerfil == null)
                        throw new ArgumentNullException("empleadoPerfil");
                    
                    new EmpleadoPerfilAD().InsertarEmpleadoPerfil(empleadoPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task<List<EmpleadoPerfil>> ListarEmpleadoPerfil()
        {
            return Task.Run(() =>
            {
                List<EmpleadoPerfil> empleadoPerfiles;

                try
                {
                    empleadoPerfiles = new EmpleadoPerfilAD().ListarEmpleadoPerfiles();
                    foreach (var empleadoPerfil in empleadoPerfiles)
                    {
                        empleadoPerfil.Perfil = new PerfilAD().ObtenerPerfil(empleadoPerfil.Perfil.IdPerfil);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return empleadoPerfiles;
            });
        }
        #endregion
        #region Perfil
        public static Task<List<Perfil>> ListarPerfil()
        {
            return Task.Run(() =>
            {
                List<Perfil> perfiles;

                try
                {
                    perfiles = new PerfilAD().ListarPerfiles();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return perfiles;
            });
        }
        public static Task<Perfil> ObtenerPerfil(int idPerfil)
        {
            return Task.Run(() =>
            {
                Perfil perfil;

                try
                {
                    perfil = new PerfilAD().ObtenerPerfil(idPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return perfil;
            });
        }
        #endregion
    }
}
