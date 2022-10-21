using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntFacturacion
    {
        public int ID_Venta { get; set; }
        public Nullable<System.DateTime> Fecha_Vta { get; set; }
        public Nullable<int> ID_Cliente { get; set; }
        public int ID_Usuario { get; set; }
        public string NombreCliente { get; set; }
        public decimal Total { get; set; }
        public string Anulada { get; set; }

        public decimal Dolar { get; set; }
        public string NombreEmpleado { get; set; }
        public string garantia { get; set; }

    }
}
