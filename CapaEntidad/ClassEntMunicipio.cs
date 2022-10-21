using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntMunicipio
    {
        public int ID_Municipio { get; set; }
        public string Nombre_Municipio { get; set; }
        public Nullable<int> ID_Departamento { get; set; }
        public Nullable<bool> Estado { get; set; }

        public string NombreDepartamento { get; set; }
    }
}
