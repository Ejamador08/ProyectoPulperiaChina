using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntDetalleComp
    {
        public int ID_ComraTmp { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> ID_Articulo { get; set; }
        public Nullable<decimal> Precio_Compra { get; set; }
        public Nullable<decimal> Precio_Venta { get; set; }
        public Nullable<int> ID_Proveedor { get; set; }
        public Nullable<int> ID_Bodega { get; set; }
        public Nullable<int> ID_Marca { get; set; }
        public Nullable<System.DateTime> Fecha_Entrega { get; set; }
        public string UserName { get; set; }

        public string NombreArticulo { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreBodega { get; set; }
        public string NombreMarca { get; set; }
    }
}
