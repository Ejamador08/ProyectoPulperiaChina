using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegProveedor
    {
        #region Guarda Proveedor
        public bool GuardaProveedor(ClassEntProveedor nuevo)
        {
            if (nuevo.Nombre_Proveedor=="")
            {
                return false;
            }
            ClassDatProveedor pro = new ClassDatProveedor();
            return pro.GuardaProveedor(nuevo);
        }
        #endregion

        #region Actualiza Proveedor
        public bool ActualizaProveedor(ClassEntProveedor nuevo)
        {
            if (nuevo.Nombre_Proveedor=="")
            {
                return false;
            }
            ClassDatProveedor pro = new ClassDatProveedor();
            return pro.ActualizaProveedor(nuevo);
        }
        #endregion

        #region Elimina Proveedor
        public bool EliminaProveedor(int id)
        {
            ClassDatProveedor pro = new ClassDatProveedor();
            return pro.EliminaProveedor(id);
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatProveedor();
            return dat.DardeBaja(id);
        }

        public bool Restaurar(int id)
        {
            var dat = new ClassDatProveedor();
            return dat.Restaurar(id);
        }

        #region Muestra Proveedor
        public List<ClassEntProveedor> MuestraProveedor()
        {
            ClassDatProveedor pro = new ClassDatProveedor();
            return pro.MuestraProveedor();
        }
        #endregion

        public List<ClassEntProveedor> MuestraProveedorInactivos()
        {
            var dat = new ClassDatProveedor();
            return dat.MuestraProveedorInactivos();
        }

        #region Muestra Proveedor x ID
        public ClassEntProveedor MuestraProveedorxID(int id)
        {
            ClassDatProveedor pro = new ClassDatProveedor();
            return pro.MuestraProveedorxID(id);
        }
        #endregion

        public List<ClassEntProveedor> MostrarProvsorID(int ID)
        {
            var dat = new ClassDatProveedor();
            return dat.MostrarProvsorID(ID);
        }

        #region Muestra Proveedor x Nombre
        public List<ClassEntProveedor> MuestraProveedorxNombre(string nombre)
        {
            ClassDatProveedor pro = new ClassDatProveedor();
            return pro.MuestraProveedorxNombre(nombre);
        }
        #endregion

        public List<ClassEntProveedor> MuestraProveedorxNombreInactivos(string nombre)
        {
            var dat = new ClassDatProveedor();
            return dat.MuestraProveedorxNombreInactivos(nombre);
        }

        #region Busca Duplicados
        public List<ClassEntProveedor> BuscaProveedorDuplicado(ClassEntProveedor ent)
        {
            var datos = new ClassDatProveedor();
            return datos.BuscaProveedorDuplicado(ent);
        }
        #endregion
    }
}
