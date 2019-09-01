using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public static class Facturacion
    {
        #region Factura
        public static Task ActualizarFactura(Factura factura)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (factura == null)
                        throw new ArgumentNullException("factura");

                    new FacturaAD().ActualizarFactura(factura);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task EliminarFactura(int idFactura)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (idFactura.Equals(""))
                        throw new ArgumentNullException("idFactura");

                    new FacturaAD().EliminarFactura(idFactura);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task InsertarFactura(Factura factura)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (factura == null)
                        throw new ArgumentNullException("factura");

                    new FacturaAD().InsertarFactura(factura);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
        public static Task<List<Factura>> ListarFacturas()
        {
            return Task.Run(() =>
            {
                List<Factura> facturas;

                try
                {
                    facturas = new FacturaAD().ListarFacturas();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return facturas;
            });
        }
        public static Task<Factura> ObtenerFactura(int idFactura)
        {
            return Task.Run(() =>
            {
                Factura factura;

                try
                {
                    factura = new FacturaAD().ObtenerFactura(idFactura);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return factura;
            });
        }
        #endregion
    }
}
