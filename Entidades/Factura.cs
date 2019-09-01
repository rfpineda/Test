using System;

namespace Entidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime MomentoCreacion { get; set; }

        public Cliente Cliente { get; set; }
        public Empleado EmpleadoFacturador { get; set; }
    }
}
