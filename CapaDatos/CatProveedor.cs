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
    
    public partial class CatProveedor
    {
        public CatProveedor()
        {
            this.CatArticulo = new HashSet<CatArticulo>();
            this.tblPedidos = new HashSet<tblPedidos>();
        }
    
        public int ID_Proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string RutaLogo { get; set; }
    
        public virtual ICollection<CatArticulo> CatArticulo { get; set; }
        public virtual ICollection<tblPedidos> tblPedidos { get; set; }
    }
}
