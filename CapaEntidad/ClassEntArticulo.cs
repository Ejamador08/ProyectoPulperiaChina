using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntArticulo
    {
        public int ID_Articulo { get; set; } 
        public string Nombre_Articulo { get; set; }
        public string Descripcion { get; set; }
        public int ID_Categoria { get; set; }
        public int ID_Proveedor { get; set; }
        public Nullable<int> ID_Marca { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string RutaImagen { get; set; }
        public string Garantia { get; set; }

        //este campos ayudara en algunas consultas
        public string NombreCategoria { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreMarca { get; set; }
        public string NombreBodega { get; set; }
        public int ID_Bodega { get; set; }
        public float Precio_Venta { get; set; }
        public int Existencia { get; set; }
        public int IdBodegaArticulo { get; set; }
    }
}
