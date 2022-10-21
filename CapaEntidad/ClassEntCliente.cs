using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntCliente
    {
        public int ID_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Apellido1_Cliente { get; set; }
        public string Direccion { get; set; }
        public string N__de_Cedula { get; set; }
        public string Telefono_Celular { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> ID_Municipio { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        //prop agregada
        public string NombreMunicipio { get; set; }
    }
}
