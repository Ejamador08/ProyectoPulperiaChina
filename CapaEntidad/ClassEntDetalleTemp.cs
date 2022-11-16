using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntDetalleTemp
    {
        public int ID_DetalleTemp { get; set; }
        public Nullable<int> ID_Articulo { get; set; }
        public Nullable<float> SubTotal { get; set; }
        public string Estado { get; set; }
        public Nullable<float> Descuento { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public string Garantia { get; set; }
        public string UserName { get; set; }

        //prop agregada
        public string Nombre_Articulo { get; set; }
        public int  ID_User { get; set; }
        public Nullable<int> ID_Venta { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<float> precioventa { get; set; }
    }
}
