﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Respaldo_PulperiaChinaEntities : DbContext
    {
        public Respaldo_PulperiaChinaEntities()
            : base("name=Respaldo_PulperiaChinaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CatArticulo> CatArticulo { get; set; }
        public DbSet<CatBodega> CatBodega { get; set; }
        public DbSet<CatCategoria> CatCategoria { get; set; }
        public DbSet<CatCliente> CatCliente { get; set; }
        public DbSet<CatDepartamento> CatDepartamento { get; set; }
        public DbSet<CatEmpleado> CatEmpleado { get; set; }
        public DbSet<CatMarca> CatMarca { get; set; }
        public DbSet<CatMunicipio> CatMunicipio { get; set; }
        public DbSet<CatProveedor> CatProveedor { get; set; }
        public DbSet<CatUsuario> CatUsuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tblAbono_Cliente> tblAbono_Cliente { get; set; }
        public DbSet<tblArticulo_Bodega> tblArticulo_Bodega { get; set; }
        public DbSet<tblCompra> tblCompra { get; set; }
        public DbSet<tblDetalleCompra> tblDetalleCompra { get; set; }
        public DbSet<tblDetalleCpaTemp> tblDetalleCpaTemp { get; set; }
        public DbSet<tblDetalleVenta> tblDetalleVenta { get; set; }
        public DbSet<tblDetalleVtaTemp> tblDetalleVtaTemp { get; set; }
        public DbSet<tblPedidos> tblPedidos { get; set; }
        public DbSet<tblVenta> tblVenta { get; set; }
        public DbSet<tblVentaCredito> tblVentaCredito { get; set; }
    }
}