using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatCategoria
    {
        //variable Global
        //Pulperia_ChinaEntities context = new Pulperia_ChinaEntities();
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        //variable Global
        List<ClassEntCategoria> categoria = new List<ClassEntCategoria>();

        #region Guardar Categoria
        public bool GuardaCategoria(ClassEntCategoria nuevo)
        {
                CatCategoria cat = new CatCategoria();

                cat.ID_Categoria = nuevo.ID_Categoria;
                cat.Nombre_Categoria = nuevo.Nombre_Categoria;
                cat.Descripcion_Categoria = nuevo.Descripcion_Categoria;
                cat.Estado = nuevo.Estado;

                context.CatCategoria.Add(cat);
                context.SaveChanges();
                return true;

        }
        #endregion

        #region Actualizar Categoria
        public bool ActualizaCategoria(ClassEntCategoria nuevo)
        {
                CatCategoria cat = context.CatCategoria.FirstOrDefault(x => x.ID_Categoria == nuevo.ID_Categoria);

                cat.ID_Categoria = nuevo.ID_Categoria;
                cat.Nombre_Categoria = nuevo.Nombre_Categoria;
                cat.Descripcion_Categoria = nuevo.Descripcion_Categoria;
                cat.Estado = nuevo.Estado;

                context.SaveChanges();
                return true;
        }
        #endregion

        #region Elimina Categoria
        public bool EliminaCategoria(int id)
        {
            try
            {
                CatCategoria cat = context.CatCategoria.FirstOrDefault(x => x.ID_Categoria == id);

                context.CatCategoria.Remove(cat);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        #endregion

        public bool DardeBaja(int id)
        {
            try
            {
                CatCategoria cat = context.CatCategoria.FirstOrDefault(x => x.ID_Categoria == id);
                cat.Estado = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Restaurar(int id)
        {
            try
            {
                CatCategoria cat = context.CatCategoria.FirstOrDefault(x => x.ID_Categoria == id);
                cat.Estado = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #region Muestra Categoria
        public List<ClassEntCategoria> MostrarCategoria()
        {
                var consulta = (from cat in context.CatCategoria
                                where cat.Estado==true
                                orderby cat.ID_Categoria descending
                                select new ClassEntCategoria
                                {
                                    ID_Categoria = cat.ID_Categoria,
                                    Nombre_Categoria = cat.Nombre_Categoria,
                                    Descripcion_Categoria = cat.Descripcion_Categoria,
                                    Estado=cat.Estado
                                }).ToList();
                return consulta;
        }
        #endregion

        public List<ClassEntCategoria> MostrarCategoriaInactivas()
        {
            var consulta = (from cat in context.CatCategoria
                            orderby cat.ID_Categoria descending
                            where cat.Estado == false
                            select new ClassEntCategoria
                            {
                                ID_Categoria = cat.ID_Categoria,
                                Nombre_Categoria = cat.Nombre_Categoria,
                                Descripcion_Categoria = cat.Descripcion_Categoria,
                                Estado = cat.Estado
                            }).ToList();
            return consulta;
        }

        #region Muestra Categoria x ID
        public ClassEntCategoria MostrarCategoriaxID(int id)
        {
            CatCategoria cat = context.CatCategoria.FirstOrDefault(x => x.ID_Categoria == id);
            ClassEntCategoria categ = new ClassEntCategoria();
            if (cat!=null)
            {
                categ.ID_Categoria = cat.ID_Categoria;
                categ.Nombre_Categoria = cat.Nombre_Categoria;
                categ.Descripcion_Categoria = cat.Descripcion_Categoria;
                categ.Estado = cat.Estado;
            }
            return categ;
                 
        }
        #endregion

        #region Muestra Categoria x Nombre
        public List<ClassEntCategoria> MostrarCategoriaxNombre(string nombre)
        {
            var consulta = (from c in context.CatCategoria
                            where c.Nombre_Categoria.Contains(nombre) && c.Estado==true
                            select new ClassEntCategoria
                            {
                                ID_Categoria = c.ID_Categoria,
                                Nombre_Categoria = c.Nombre_Categoria,
                                Descripcion_Categoria = c.Descripcion_Categoria,
                                Estado=c.Estado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntCategoria> MostrarCategoriaxNombreInactivos(string nombre)
        {
            var consulta = (from c in context.CatCategoria
                            where c.Nombre_Categoria.Contains(nombre) && c.Estado == false
                            select new ClassEntCategoria
                            {
                                ID_Categoria = c.ID_Categoria,
                                Nombre_Categoria = c.Nombre_Categoria,
                                Descripcion_Categoria = c.Descripcion_Categoria,
                                Estado = c.Estado
                            }).ToList();
            return consulta;
        }

        #region Busca Duplicados
        public List<ClassEntCategoria> BuscarCategoriasDuplicadas(ClassEntCategoria ent)
        {
            var consulta=(from c in context.CatCategoria
                          where (c.Nombre_Categoria.Equals(ent.Nombre_Categoria) &&
                                (c.Descripcion_Categoria.Equals(ent.Descripcion_Categoria)))
                          select new ClassEntCategoria
                          {
                               ID_Categoria = c.ID_Categoria,
                               Nombre_Categoria = c.Nombre_Categoria,
                               Descripcion_Categoria = c.Descripcion_Categoria,
                               Estado=c.Estado
                          }).ToList();
            return consulta;
        }
        #endregion

        #region Muestra Categoria "Linea Blanca"
        public List<ClassEntCategoria> MostrarCategoriaLineaBlanca()
        {
            try
            {
                var consulta = (from cat in context.CatCategoria
                                where cat.Nombre_Categoria == "Linea Blanca"
                                select new ClassEntCategoria
                                {
                                    ID_Categoria = cat.ID_Categoria,
                                    Nombre_Categoria = cat.Nombre_Categoria,
                                    Descripcion_Categoria = cat.Descripcion_Categoria,
                                    Estado=cat.Estado
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return categoria;
            }
        }
        #endregion

        #region Muestra Categoria "Muebles"
        public List<ClassEntCategoria> MostrarCategoriaMuebles()
        {
            try
            {
                var consulta=(from cat in context.CatCategoria
                              where cat.Nombre_Categoria=="Mueble"
                              select new ClassEntCategoria
                              {
                                  ID_Categoria=cat.ID_Categoria,
                                  Nombre_Categoria=cat.Nombre_Categoria,
                                  Descripcion_Categoria = cat.Descripcion_Categoria,
                                  Estado = cat.Estado
                              }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return categoria;
            }
        }
        #endregion

        #region Muestra Categoria "Materiales de Construccion"
        public List<ClassEntCategoria> MostrarCategoriaContruccion()
        {
            try
            {
                var consulta = (from cat in context.CatCategoria
                                where cat.Nombre_Categoria == "Materiales de Contruccion"
                                select new ClassEntCategoria
                                {
                                    ID_Categoria = cat.ID_Categoria,
                                    Nombre_Categoria = cat.Nombre_Categoria,
                                    Descripcion_Categoria = cat.Descripcion_Categoria,
                                    Estado = cat.Estado
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return categoria;
            }
        }
        #endregion

    }
}
