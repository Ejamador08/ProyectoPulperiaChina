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
    
    public partial class tblVenta
    {
        public tblVenta()
        {
            this.tblDetalleVenta = new HashSet<tblDetalleVenta>();
        }
    
        public int ID_Venta { get; set; }
        public Nullable<System.DateTime> Fecha_Vta { get; set; }
        public Nullable<int> ID_Cliente { get; set; }
        public int ID_Usuario { get; set; }
        public string NombreCliente { get; set; }
        public decimal Total { get; set; }
        public string Anulada { get; set; }
    
        public virtual CatCliente CatCliente { get; set; }
        public virtual ICollection<tblDetalleVenta> tblDetalleVenta { get; set; }
    }
}
