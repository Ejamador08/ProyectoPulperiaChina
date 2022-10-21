using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

//para enrutar pagina en ASP.NET
using System.Web.Routing;

namespace PulperiaChina
{
    public class Global : System.Web.HttpApplication
    {

        public void EnrutarPaginas()
        {
            RouteTable.Routes.MapPageRoute("Inicio", "Inicio","~/Visitantes/Inicio.aspx");
            RouteTable.Routes.MapPageRoute("Articulos", "Articulos", "~/Visitantes/Articulos.aspx");
            RouteTable.Routes.MapPageRoute("Categorias", "Categoria", "~/Visitantes/Categoria.aspx");
            RouteTable.Routes.MapPageRoute("Cliente", "Cliente", "~/Visitantes/Cliente.aspx");
            RouteTable.Routes.MapPageRoute("Proveedor", "Proveedor", "~/Visitantes/Proveedor.aspx");
            RouteTable.Routes.MapPageRoute("Municipios", "Municipio", "~/Visitantes/Municipio.aspx");
            RouteTable.Routes.MapPageRoute("Departamentos", "Departamento", "~/Visitantes/Departamento.aspx");
            RouteTable.Routes.MapPageRoute("Usuario", "Usuario", "~/Visitantes/Usuario.aspx");
            RouteTable.Routes.MapPageRoute("DetalleArticulo" , "DetalleArticulo" , "~/Visitantes/DetalleArticulo.aspx");
            RouteTable.Routes.MapPageRoute("Bodega", "Bodega", "~/Visitantes/Bodega.aspx");
            RouteTable.Routes.MapPageRoute("Empleado", "Empleado", "~/Visitantes/Empleado.aspx");
            RouteTable.Routes.MapPageRoute("Marca", "Marca", "~/Visitantes/Marca.aspx");
            RouteTable.Routes.MapPageRoute("Bodegas_Articulos", "Bodegas_Articulos", "~/Visitantes/Bodegas_Articulos.aspx");
            RouteTable.Routes.MapPageRoute("Login", "Login", "~/Cuenta/Login.aspx");
            RouteTable.Routes.MapPageRoute("Registro", "Registro", "~/Cuenta/Registro.aspx");
            RouteTable.Routes.MapPageRoute("Venta", "Venta", "~/Ventas/FormVentas.aspx");
            RouteTable.Routes.MapPageRoute("Reporte", "Reporte", "~/Reportes/Reporte.aspx");
            RouteTable.Routes.MapPageRoute("Reporte_MasVendidos", "Reporte_MasVendidos", "~/Reportes/MasVendido.aspx");
            RouteTable.Routes.MapPageRoute("Reporte_VentasxFecha", "Reporte_VentasxFecha", "~/Reportes/VentasxFecha.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            EnrutarPaginas();
        }
    }
}