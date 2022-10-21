using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegDepartamento
    {
        #region Guarda Departamento
        public bool GuardaDepto(ClassEntDepartamento nuevo)
        {
            if (nuevo.Nombre_Depto=="")
            {
                return false;
            }
            var depto = new ClassDatDepartamento();
            return depto.GuardaDepto(nuevo);
        }
        #endregion

        #region Actualiza Departamento
        public bool ActualizaDepto(ClassEntDepartamento nuevo)
        {
            if (nuevo.Nombre_Depto=="")
            {
                return false;
            }
            var depto = new ClassDatDepartamento();
            return depto.ActualizaDepto(nuevo);
        }
        #endregion

        #region Elimina Departamento
        public bool EliminaDepto(int id)
        {
            var depto = new ClassDatDepartamento();
            return depto.EliminaDepto(id);
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatDepartamento();
            return dat.DardeBaja(id);
        }

        public bool Restaurar(int id)
        {
            var dat = new ClassDatDepartamento();
            return dat.Restaurar(id);
        }

        #region Muestra Departamento
        public List<ClassEntDepartamento> MuestraDepto()
        {
            var depto = new ClassDatDepartamento();
            return depto.MuestraDepto();
        }
        #endregion

        public List<ClassEntDepartamento> MuestraDeptoInactivos()
        {
            var dat = new ClassDatDepartamento();
            return dat.MuestraDeptoInactivos();
        }

        #region Muestra Departamento x ID
        public ClassEntDepartamento MuestraDeptoxID(int id)
        {
            var depto = new ClassDatDepartamento();
            return depto.MuestraDeptoxID(id);
        }
        #endregion

        #region Muestra Departamento x Nombre
        public List<ClassEntDepartamento> MuestraDeptoxNombre(string nombre)
        {
            var depto = new ClassDatDepartamento();
            return depto.MuestraDeptoxNombre(nombre);
        }
        #endregion

        public List<ClassEntDepartamento> MuestraDeptoxNombreInactivos(string nombre)
        {
            var dat = new ClassDatDepartamento();
            return dat.MuestraDeptoxNombreInactivos(nombre);
        }

        #region Busca Duplicados
        public List<ClassEntDepartamento> BuscaDepartamentoDuplicado(ClassEntDepartamento ent)
        {
            var datos = new ClassDatDepartamento();
            return datos.BuscaDepartamentoDuplicado(ent);
        }
        #endregion
    }
}
