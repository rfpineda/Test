using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaProducto
    {
        public int Cantidad { get; set; }

        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
