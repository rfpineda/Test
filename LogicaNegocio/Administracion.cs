using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static Task EliminarCliente(string idCliente)
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

                    new EmpleadoAD().EliminarEmpleado(idUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task InsertarUsuario(Empleado empleado)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (empleado == null)
                        throw new ArgumentNullException("empleado");

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
    }
}
