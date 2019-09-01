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

                    new ProductoAD().ActualizarEmpleado(producto);
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
