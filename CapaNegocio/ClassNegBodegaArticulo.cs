using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class ClassNegBodegaArticulo
    {
        #region Guarda Bodega-Articulo
        public bool GuardaBodegaArticulo(ClassEntBodegaArticulo ent)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.GuardaBodegaArticulo(ent);
        }
        #endregion

        #region Actualiza Bodega-Articulo
        public bool ActualizaBodegaArticulo(ClassEntBodegaArticulo id)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.ActualizaBodegaArticulo(id);
        }
        #endregion

        #region Eliminar Bodega-Articulo
        public bool EliminaBodegaArticulo(int id)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.EliminaBodegaArticulo(id);
        }
        #endregion

        #region Muestra Bodega-Articulo
        public List<ClassEntBodegaArticulo> MuestraBodegaArticulo()
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.MuestraBodegaArticulo();
        }
        #endregion

        #region Muestra Bodega-Articulo
        public List<ClassEntBodegaArticulo> MuestraBodegaArticuloelectrodomestico(int id)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.MuestraBodegaArticuloelectrodomestico(id);
        }
        #endregion

        #region Muestra Bodega-Articulo
        public List<ClassEntBodegaArticulo> MuestraBodegaArticuloferreteria(int id)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.MuestraBodegaArticuloferreteria(id);
        }
        #endregion

        #region Muestra Bodega-Articulo x ID
        public ClassEntBodegaArticulo MuestraBodegaArticuloxID(int id)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.MuestraBodegaArticuloxID(id);
        }
        #endregion

        #region Muestra Bodega-Articulo x Nombre
        public List<ClassEntBodegaArticulo> MuestraBodegaArticuloxNombre(string name)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.MuestraBodegaArticuloxNombre(name);
        }
        #endregion

        public List<ClassEntBodegaArticulo> Duplicados(ClassEntBodegaArticulo ent)
        {
            var dat = new ClassDatBodegaArticulo();
            return dat.Duplicados(ent);
        }
    }
}
