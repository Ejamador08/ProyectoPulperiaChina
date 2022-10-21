using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public class ClassEntCompra
    {
        public int ID_Compra { get; set; }
        public Nullable<System.DateTime> Fecha_Compra { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}
