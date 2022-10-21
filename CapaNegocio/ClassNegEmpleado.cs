using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class ClassNegEmpleado
    {
        #region Guarda Empleado
        public bool GuardaEmpleado(ClassEntEmpleado nuevo)
        {
            if (nuevo.Nombre=="")
            {
                return false;
            }
            var datos = new ClassDatEmpleado();
            return datos.GuardaEmpleado(nuevo);
        }
        #endregion

        #region Actualiza Empleado
        public bool ActualizaEmpleado(ClassEntEmpleado nuevo)
        {
            var datos = new ClassDatEmpleado();
            return datos.ActualizaEmpleado(nuevo);
        }
        #endregion

        #region Elimina Empleado
        public bool EiminaEmpleado(int id)
        {
            var datos = new ClassDatEmpleado();
            return datos.EiminaEmpleado(id);
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatEmpleado();
            return dat.DardeBaja(id);
        }

        public bool Restaurar(int id)
        {
            var dat = new ClassDatEmpleado();
            return dat.Restaurar(id);
        }

        #region Muestra Empleado
        public List<ClassEntEmpleado> MuestraEmpleado()
        {
            var datos=new ClassDatEmpleado();
            return datos.MuestraEmpleado();
        }
        #endregion

        public List<ClassEntEmpleado> MuestraEmpleadoInactivos()
        {
            var dat = new ClassDatEmpleado();
            return dat.MuestraEmpleadoInactivos();
        }

        #region Muestra Empleado x ID
        public ClassEntEmpleado MuestraEmpleadoxID(int id)
        {
            var datos = new ClassDatEmpleado();
            return datos.MuestraEmpleadoxID(id);
        }
        #endregion

        #region Muestra Empleado x Nombre
        public List<ClassEntEmpleado> MuestaEmpleadoxNombre(string name)
        {
            var datos = new ClassDatEmpleado();
            return datos.MuestaEmpleadoxNombre(name);
        }
        #endregion

        public List<ClassEntEmpleado> MuestaEmpleadoxNombreInactivos(string name)
        {
            var dat = new ClassDatEmpleado();
            return dat.MuestaEmpleadoxNombreInactivos(name);
        }

        #region Busca Duplicados
        public List<ClassEntEmpleado> BuscaEmpleadoDuplicado(ClassEntEmpleado ent)
        {
            var datos = new ClassDatEmpleado();
            return datos.BuscaEmpleadoDuplicado(ent);
        }
        #endregion
    }
}
