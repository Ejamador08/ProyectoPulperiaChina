using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatBodega
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        #region Guarda Bodega
        public bool GuardaBodega(ClassEntBodega nuevo)
        {
            var bod = new CatBodega();

            bod.ID_Bodega = nuevo.ID_Bodega;
            bod.Nombre_Bodega = nuevo.Nombre_Bodega;
            bod.Descripcion = nuevo.Descripcion;
            bod.Estado = nuevo.Estado;


            context.CatBodega.Add(bod);
            context.SaveChanges();
            return true;
        }
        
        #endregion

        #region Actualiza Bodega
        public bool ActualizaBodega(ClassEntBodega nuevo)
        {
            var bod = context.CatBodega.FirstOrDefault(x => x.ID_Bodega == nuevo.ID_Bodega);

            bod.ID_Bodega = nuevo.ID_Bodega;
            bod.Nombre_Bodega = nuevo.Nombre_Bodega;
            bod.Descripcion = nuevo.Descripcion;
            bod.Estado = nuevo.Estado;

            context.SaveChanges();
            return true;
        }
        #endregion

        #region Elimina Bodega
        public bool EliminaBodega(int id)
        {
            var bod = context.CatBodega.FirstOrDefault(x => x.ID_Bodega == id);
            context.CatBodega.Remove(bod);
            context.SaveChanges();
            return true;
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var bod = context.CatBodega.FirstOrDefault(x => x.ID_Bodega == id);
            bod.Estado = false;
            context.SaveChanges();
            return true;
        }

        public bool Restaurar(int id)
        {
            var bod = context.CatBodega.FirstOrDefault(x => x.ID_Bodega == id);
            bod.Estado = true;
            context.SaveChanges();
            return true;
        }

        #region Muestra Bodega
        public List<ClassEntBodega> MuestraBodega()
        {
            var consulta = (from b in context.CatBodega
                            orderby b.ID_Bodega descending
                            where b.Estado==true
                            select new ClassEntBodega
                            {
                                ID_Bodega = b.ID_Bodega,
                                Nombre_Bodega = b.Nombre_Bodega,
                                Descripcion = b.Descripcion,
                                Estado = b.Estado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntBodega> MuestraBodegaInactivos()
        {
            var consulta = (from b in context.CatBodega
                            orderby b.ID_Bodega descending
                            where b.Estado == false
                            select new ClassEntBodega
                            {
                                ID_Bodega = b.ID_Bodega,
                                Nombre_Bodega = b.Nombre_Bodega,
                                Descripcion = b.Descripcion,
                                Estado = b.Estado
                            }).ToList();
            return consulta;
        }

        #region Muestra Bodega x ID
        public ClassEntBodega MuestraBodegaxID(int id)
        {
            var bod = context.CatBodega.FirstOrDefault(x => x.ID_Bodega == id);
            ClassEntBodega bodeg = new ClassEntBodega();
            if (bod!=null)
            {
                bodeg.ID_Bodega = bod.ID_Bodega;
                bodeg.Nombre_Bodega = bod.Nombre_Bodega;
                bodeg.Descripcion = bod.Descripcion;
                bodeg.Estado = bod.Estado;
            }
            return bodeg;

        }
        #endregion

        #region Muestra x ID Bod-Art
        public List<ClassEntBodega> MostrarProductosorID(int ID)
        {
            var consulta = (from pro in context.CatBodega
                            where pro.ID_Bodega == ID
                            select new ClassEntBodega
                            {
                                ID_Bodega = pro.ID_Bodega,
                                Nombre_Bodega = pro.Nombre_Bodega,
                                Descripcion = pro.Descripcion,
                                Estado = pro.Estado
                            }).ToList();

            return consulta;
        }
        #endregion

        #region Muestra Bodega x Nombre
        public List<ClassEntBodega> MuestraBodegaxNombre(string name)
        {
            var consulta = (from b in context.CatBodega
                            where b.Nombre_Bodega.Contains(name) && b.Estado == true
                            select new ClassEntBodega
                            {
                                ID_Bodega=b.ID_Bodega,
                                Nombre_Bodega=b.Nombre_Bodega,
                                Descripcion=b.Descripcion,
                                Estado=b.Estado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntBodega> MuestraBodegaxNombreInactivos(string name)
        {
            var consulta = (from b in context.CatBodega
                            where b.Nombre_Bodega.Contains(name) && b.Estado == false
                            select new ClassEntBodega
                            {
                                ID_Bodega = b.ID_Bodega,
                                Nombre_Bodega = b.Nombre_Bodega,
                                Descripcion = b.Descripcion,
                                Estado = b.Estado
                            }).ToList();
            return consulta;
        }

        #region Busca Duplicados
        public List<ClassEntBodega> BuscaBodegaDuplicadas(ClassEntBodega ent)
        {
            var consulta = (from b in context.CatBodega
                            where (b.Nombre_Bodega.Equals(ent.Nombre_Bodega) &&
                                  (b.Descripcion.Equals(ent.Descripcion)))
                            select new ClassEntBodega
                            {
                                ID_Bodega = b.ID_Bodega,
                                Nombre_Bodega = b.Nombre_Bodega,
                                Descripcion = b.Descripcion,
                                Estado = b.Estado
                            }).ToList();
            return consulta;

        }
        #endregion
    }
}
