using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatBodegaArticulo
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        #region Guarda Bodega-Articulo
        public bool GuardaBodegaArticulo(ClassEntBodegaArticulo ent)
        {
            tblArticulo_Bodega bod = new tblArticulo_Bodega();

            bod.ID_BodegaArticulo = ent.ID_BodegaArticulo;
            bod.ID_Articulo = ent.ID_Articulo;
            bod.ID_Bodega = ent.ID_Bodega;
            bod.Precio_Compra = ent.Precio_Compra;
            bod.Precion_Venta = ent.Precion_Venta;
            bod.Existencia = ent.Existencia;
            bod.UserName = ent.UserName;

            context.tblArticulo_Bodega.Add(bod);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Actualiza Bodega-Articulo
        public bool ActualizaBodegaArticulo(ClassEntBodegaArticulo id)
        {
            tblArticulo_Bodega art = context.tblArticulo_Bodega.FirstOrDefault(x => x.ID_BodegaArticulo == id.ID_BodegaArticulo);

            art.ID_BodegaArticulo = id.ID_BodegaArticulo;
            art.ID_Articulo = id.ID_Articulo;
            art.ID_Bodega = id.ID_Bodega;
            art.Precio_Compra = id.Precio_Compra;
            art.Precion_Venta = id.Precion_Venta;
            art.Existencia = id.Existencia;
            art.UserName = id.UserName;

            context.SaveChanges();
            return true;
        }
        #endregion

        #region Eliminar Bodega-Articulo
        public bool EliminaBodegaArticulo(int id)
        {
            tblArticulo_Bodega art = context.tblArticulo_Bodega.FirstOrDefault(x => x.ID_BodegaArticulo == id);
            context.tblArticulo_Bodega.Remove(art);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Muestra Bodega-Articulo
        public List<ClassEntBodegaArticulo> MuestraBodegaArticulo()
        {
            var consulta = (from ba in context.tblArticulo_Bodega
                            join a in context.CatArticulo on ba.ID_Articulo equals a.ID_Articulo
                            join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
                            orderby ba.ID_BodegaArticulo descending
                            select new ClassEntBodegaArticulo
                            {
                                ID_BodegaArticulo = ba.ID_BodegaArticulo,
                                ID_Articulo = ba.ID_Articulo,
                                ID_Bodega = ba.ID_Bodega,
                                Precio_Compra = ba.Precio_Compra,
                                Precion_Venta = ba.Precion_Venta,
                                Existencia = ba.Existencia,
                                UserName=ba.UserName,

                                NombreArticulo = a.Nombre_Articulo,
                                NombreBodega = b.Nombre_Bodega
                            }).ToList();
            return consulta;
        }
        #endregion

        #region Muestra Bodega-Articulo
        public List<ClassEntBodegaArticulo> MuestraBodegaArticuloelectrodomestico(int id)
        {
            var consulta = (from ba in context.tblArticulo_Bodega
                            join a in context.CatArticulo on ba.ID_Articulo equals a.ID_Articulo
                            join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
                            where ba.ID_Bodega == 1
                            orderby ba.ID_Articulo descending
                            select new ClassEntBodegaArticulo
                            {
                                ID_BodegaArticulo = ba.ID_BodegaArticulo,
                                ID_Articulo = ba.ID_Articulo,
                                ID_Bodega = ba.ID_Bodega,
                                Precio_Compra = ba.Precio_Compra,
                                Precion_Venta = ba.Precion_Venta,
                                Existencia = ba.Existencia,
                                UserName=ba.UserName,

                                NombreArticulo = a.Nombre_Articulo,
                                NombreBodega = b.Nombre_Bodega
                            }).ToList();
            return consulta;
        }
        #endregion
        
        #region Muestra Bodega-Articulo
        public List<ClassEntBodegaArticulo> MuestraBodegaArticuloferreteria(int id)
        {
            var consulta = (from ba in context.tblArticulo_Bodega
                            join a in context.CatArticulo on ba.ID_Articulo equals a.ID_Articulo
                            join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
                            where ba.ID_Bodega == 3
                            orderby ba.ID_Articulo descending
                            select new ClassEntBodegaArticulo
                            {
                                ID_BodegaArticulo = ba.ID_BodegaArticulo,
                                ID_Articulo = ba.ID_Articulo,
                                ID_Bodega = ba.ID_Bodega,
                                Precio_Compra = ba.Precio_Compra,
                                Precion_Venta = ba.Precion_Venta,
                                Existencia = ba.Existencia,
                                UserName=ba.UserName,

                                NombreArticulo = a.Nombre_Articulo,
                                NombreBodega = b.Nombre_Bodega
                            }).ToList();
            return consulta;
        }
        #endregion

        #region Muestra Bodega-Articulo x ID
        public ClassEntBodegaArticulo MuestraBodegaArticuloxID(int id)
        {
            tblArticulo_Bodega art = context.tblArticulo_Bodega.FirstOrDefault(x => x.ID_BodegaArticulo == id);
            ClassEntBodegaArticulo ent = new ClassEntBodegaArticulo();
            if (art!=null)
            {
                ent.ID_BodegaArticulo = art.ID_BodegaArticulo;
                ent.ID_Articulo = art.ID_Articulo;
                ent.ID_Bodega = art.ID_Bodega;
                ent.Precio_Compra = art.Precio_Compra;
                ent.Precion_Venta = art.Precion_Venta;
                ent.Existencia = art.Existencia;
                ent.UserName = art.UserName;
            }
            return ent;
        }
        #endregion

        #region Muestra Bodega-Articulo x Nombre
        public List<ClassEntBodegaArticulo> MuestraBodegaArticuloxNombre(string name)
        {
            var consulta = (from ba in context.tblArticulo_Bodega
                            join a in context.CatArticulo on ba.ID_Articulo equals a.ID_Articulo
                            join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
                            where a.Nombre_Articulo.Contains(name)
                            select new ClassEntBodegaArticulo
                            {
                                ID_BodegaArticulo = ba.ID_BodegaArticulo,
                                ID_Articulo = ba.ID_Articulo,
                                ID_Bodega = ba.ID_Bodega,
                                Precio_Compra = ba.Precio_Compra,
                                Precion_Venta = ba.Precion_Venta,
                                Existencia = ba.Existencia,
                                UserName = ba.UserName,

                                NombreArticulo = a.Nombre_Articulo,
                                NombreBodega = b.Nombre_Bodega
                            }).ToList();
            return consulta;

        }
        #endregion

        public List<ClassEntBodegaArticulo> Duplicados(ClassEntBodegaArticulo ent)
        {
            var consulta = (from ba in context.tblArticulo_Bodega
                            where (ba.ID_Articulo.Equals(ent.ID_Articulo))
                            select new ClassEntBodegaArticulo
                            {
                                ID_BodegaArticulo = ba.ID_BodegaArticulo,
                                ID_Articulo = ba.ID_Articulo,
                                ID_Bodega = ba.ID_Bodega,
                                Precio_Compra = ba.Precio_Compra,
                                Precion_Venta = ba.Precion_Venta,
                                Existencia = ba.Existencia,
                                UserName = ba.UserName,
                            }).ToList();
            return consulta;
        }
    }
}
