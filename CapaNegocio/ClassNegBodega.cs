using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegBodega
    {
        #region Guarda Bodega
        public bool GuardaBodega(ClassEntBodega nuevo)
        {
            var datos = new ClassDatBodega();
            return datos.GuardaBodega(nuevo);
        }
        #endregion

        #region Actualiza Bodega
        public bool ActualizaBodega(ClassEntBodega nuevo)
        {
            var datos = new ClassDatBodega();
            return datos.ActualizaBodega(nuevo);
        }
        #endregion

        #region Elimina Bodega
        public bool EliminaBodega(int id)
        {
            var datos = new ClassDatBodega();
            return datos.EliminaBodega(id);
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatBodega();
            return dat.DardeBaja(id);
        }

        public bool Restaurar(int id)
        {
            var dat = new ClassDatBodega();
            return dat.Restaurar(id);
        }

        #region Muestra Bodega
        public List<ClassEntBodega> MuestraBodega()
        {
            var datos = new ClassDatBodega();
            return datos.MuestraBodega();
        }
        #endregion

        public List<ClassEntBodega> MuestraBodegaInactivos()
        {
            var datos = new ClassDatBodega();
            return datos.MuestraBodegaInactivos();
        }

        #region Muestra Bodega x ID
        public ClassEntBodega MuestraBodegaxID(int id)
        {
            var datos = new ClassDatBodega();
            return datos.MuestraBodegaxID(id);
        }
        #endregion

        #region Muestra x ID Bod-Art
        public List<ClassEntBodega> MostrarProductosorID(int ID)
        {
            var dat = new ClassDatBodega();
            return dat.MostrarProductosorID(ID);
        }
        #endregion

        #region Muestra Bodega x Nombre
        public List<ClassEntBodega> MuestraBodegaxNombre(string name)
        {
            var datos = new ClassDatBodega();
            return datos.MuestraBodegaxNombre(name);
        }
        #endregion

        public List<ClassEntBodega> MuestraBodegaxNombreInactivos(string name)
        {
            var dat = new ClassDatBodega();
            return dat.MuestraBodegaxNombreInactivos(name);
        }

        #region Busca Duplicados
        public List<ClassEntBodega> BuscaBodegaDuplicadas(ClassEntBodega ent)
        {
            var datos = new ClassDatBodega();
            return datos.BuscaBodegaDuplicadas(ent);
        }
        #endregion
    }
}
