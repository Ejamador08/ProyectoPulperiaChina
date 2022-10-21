using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntBodega
    {
        public int ID_Bodega { get; set; }
        public string Nombre_Bodega { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
