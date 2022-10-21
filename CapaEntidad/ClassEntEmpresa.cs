using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntEmpresa
    {
        public int ID_Informacion { get; set; }
        public string Nombre_Empresa { get; set; }
        public string Propietario { get; set; }
        public string Admonistrador { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public Nullable<float> CambioDolar { get; set; }
    }
}
