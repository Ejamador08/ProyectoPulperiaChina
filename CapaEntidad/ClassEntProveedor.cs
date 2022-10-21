using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntProveedor
    {
        public int ID_Proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string RutaLogo { get; set; }
    }
}
