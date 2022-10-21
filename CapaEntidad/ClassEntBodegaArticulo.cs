using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntBodegaArticulo
    {
        public int ID_BodegaArticulo { get; set; }
        public int ID_Articulo { get; set; }
        public int ID_Bodega { get; set; }
        public float Precio_Compra { get; set; }
        public float Precion_Venta { get; set; }
        public int Existencia { get; set; }
        public string UserName { get; set; }


        //Propiedades Necesarias
        public string NombreArticulo { get; set; }
        public string NombreBodega { get; set; }
        public string garantia { get; set; }
    }
}
