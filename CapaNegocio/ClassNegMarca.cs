using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class ClassNegMarca
    {
        #region Guarda Marca
        public bool GuardaMarca(ClassEntMarca nuevo)
        {
            var datos = new ClassDatMarca();
            return datos.GuardaMarca(nuevo);
        }
        #endregion

        #region Actualiza Marca
        public bool ActualizaMarca(ClassEntMarca nuevo)
        {
            var datos = new ClassDatMarca();
            return datos.ActualizaMarca(nuevo);
        }
        #endregion

        #region Elimina Marca
        public bool EliminaMarca(int id)
        {
            var datos = new ClassDatMarca();
            return datos.EliminaMarca(id);
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatMarca();
            return dat.DardeBaja(id);
        }

        public bool Restaurar(int id)
        {
            var dat = new ClassDatMarca();
            return dat.Restaurar(id);
        }

        #region Muestra Marca
        public List<ClassEntMarca> MuestraMarca()
        {
            var datos = new ClassDatMarca();
            return datos.MuestraMarca();
        }
        #endregion

        public List<ClassEntMarca> MuestraMarcaInactivas()
        {
            var dat = new ClassDatMarca();
            return dat.MuestraMarcaInactivas();
        }

        #region Muestra Marca x ID
        public ClassEntMarca MuestraMarcaxID(int id)
        {
            var datos = new ClassDatMarca();
            return datos.MuestraMarcaxID(id);
        }
        #endregion

        #region Muestra Marca x Nombre
        public List<ClassEntMarca> MuestraMarcaxNombre(string name)
        {
            var datos = new ClassDatMarca();
            return datos.MuestraMarcaxNombre(name);
        }
        #endregion

        public List<ClassEntMarca> MuestraMarcaxNombreInactivas(string name)
        {
            var dat = new ClassDatMarca();
            return dat.MuestraMarcaxNombreInactivas(name);
        }

        #region Busca Duplicados
        public List<ClassEntMarca> BuscaMarcaDuplicada(ClassEntMarca ent)
        {
            var datos = new ClassDatMarca();
            return datos.BuscaMarcaDuplicada(ent);
        }
        #endregion
    }
}
