//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatCliente
    {
        public CatCliente()
        {
            this.tblVenta = new HashSet<tblVenta>();
            this.tblVentaCredito = new HashSet<tblVentaCredito>();
        }
    
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
    
        public virtual CatMunicipio CatMunicipio { get; set; }
        public virtual ICollection<tblVenta> tblVenta { get; set; }
        public virtual ICollection<tblVentaCredito> tblVentaCredito { get; set; }
    }
}