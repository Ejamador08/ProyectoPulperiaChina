using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntCategoria
    {
        public int ID_Categoria { get; set; }
        public string Nombre_Categoria { get; set; }
        public string Descripcion_Categoria { get; set; }
        public Nullable<bool> Estado { get; set; }

        //---estas son las relaciones con otras tablas---
        //public virtual ICollection<tblArticulo> tblArticulo { get; set; }
    }
}
