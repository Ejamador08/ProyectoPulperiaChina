using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegCompra
    {
        public int ultimoID()
        {
            var dat = new ClassDatCompra();
            return dat.ultimoID();
        }

        public ClassEntUsuario MuestrausuarioID(string user)
        {
            var dat = new ClassDatCompra();
            return dat.MuestrausuarioID(user);
        }





        public bool Comprar(ClassEntCompra compras, string usuario)
        {
            var dat = new ClassDatCompra();
            return dat.Comprar(compras, usuario);
        }

        public bool GuardaTemp(ClassEntDetalleComp temp)
        {
            var dat = new ClassDatCompra();
            return dat.GuardaTemp(temp);
        }

        public List<ClassEntDetalleComp> MuestraTmp(string user)
        {
            var dat = new ClassDatCompra();
            return dat.MuestraTmp(user);
        }

        public bool EliminaTemp(int id)
        {
            var dat = new ClassDatCompra();
            return dat.EliminaTemp(id);
        }
    }

 
}
