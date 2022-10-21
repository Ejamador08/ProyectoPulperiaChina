using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntEmpleado
    {
        public int IDEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string E_Mail { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string ImgEmpleado { get; set; }
    }
}
