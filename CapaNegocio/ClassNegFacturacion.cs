using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegFacturacion
    {
        #region Muestra Ultima Factura(ID)
        public static int ultimoID()
        {
            var dat = new ClassDatFacturacion();
            return dat.ultimoID();
        }
        #endregion

        public ClassEntUsuario MuestrausuarioID(string user)
        {
            var dat = new ClassDatFacturacion();
            return dat.MuestrausuarioID(user);
        }

        public bool Facturar(ClassEntFacturacion factura, string usuario)
        {
            var datos = new ClassDatFacturacion();
            return datos.Facturar(factura, usuario);
        }

        public bool GuardaTemp(ClassEntDetalleTemp temp)
        {
            var datos = new ClassDatFacturacion();
            return datos.GuardaTemp(temp);
        }

        //  eliminar todo de temporal
        public bool LimpiarTemp(string user)
        {
            var datos = new ClassDatFacturacion();
            return datos.LimpiarTemp(user);
        }

        public bool Cant(int cant, int id)
        {
            var datos = new ClassDatFacturacion();
            return datos.Cant(cant, id);
        }

        public List<ClassEntDetalleTemp> MuestraTmp(string user)
        {
            var datos = new ClassDatFacturacion();
            return datos.MuestraTmp(user);
        }

        public bool EliminaTemp(int idart)
        {
            var datos = new ClassDatFacturacion();
            return datos.EliminaTemp(idart);
        }

        public bool EliminaDetalle(int id)
        {
            var dat = new ClassDatFacturacion();
            return dat.EliminaDetalle(id);
        }

        //ver facturas metodos
        public List<ClassEntFacturacion> MuestraFactura()
        {
            var dat = new ClassDatFacturacion();
            return dat.MuestraFactura();
        }

        public List<ClassEntFacturacion> BuscaFacturaxNombreCliente(string name)
        {
            var dat = new ClassDatFacturacion();
            return dat.BuscaFacturaxNombreCliente(name);
        }

        public List<ClassEntDetalleTemp> muestradetalleFacturaGrid(int id)
        {
            var dat = new ClassDatFacturacion();
            return dat.muestradetalleFacturaGrid(id);
        }
    }
}
