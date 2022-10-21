using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatMarca
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        #region Guarda Marca
        public bool GuardaMarca(ClassEntMarca nuevo)
        {
            var mar = new CatMarca();

            mar.IDMarca = nuevo.IDMarca;
            mar.Nombre_Marca = nuevo.Nombre_Marca;
            mar.Estado = nuevo.Estado;

            context.CatMarca.Add(mar);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Actualiza Marca
        public bool ActualizaMarca(ClassEntMarca nuevo)
        {
            var mar = context.CatMarca.FirstOrDefault(x => x.IDMarca == nuevo.IDMarca);

            mar.IDMarca = nuevo.IDMarca;
            mar.Nombre_Marca = nuevo.Nombre_Marca;
            mar.Estado = nuevo.Estado;

            context.SaveChanges();
            return true;

        }
        #endregion

        #region Elimina Marca
        public bool EliminaMarca(int id)
        {
            var mar = context.CatMarca.FirstOrDefault(x => x.IDMarca == id);
            context.CatMarca.Remove(mar);
            context.SaveChanges();
            return true;
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var mar = context.CatMarca.FirstOrDefault(x => x.IDMarca == id);
            mar.Estado = false;
            context.SaveChanges();
            return true;
        }

        public bool Restaurar(int id)
        {
            var mar = context.CatMarca.FirstOrDefault(x => x.IDMarca == id);
            mar.Estado = true;
            context.SaveChanges();
            return true;
        }

        #region Muestra Marca
        public List<ClassEntMarca> MuestraMarca()
        {
            var consulta = (from m in context.CatMarca
                            orderby m.IDMarca descending
                            where m.Estado==true
                            select new ClassEntMarca
                            {
                                IDMarca = m.IDMarca,
                                Nombre_Marca = m.Nombre_Marca,
                                Estado = m.Estado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntMarca> MuestraMarcaInactivas()
        {
            var consulta = (from m in context.CatMarca
                            orderby m.IDMarca descending
                            where m.Estado == false
                            select new ClassEntMarca
                            {
                                IDMarca = m.IDMarca,
                                Nombre_Marca = m.Nombre_Marca,
                                Estado = m.Estado
                            }).ToList();
            return consulta;
        }

        #region Muestra Marca x ID
        public ClassEntMarca MuestraMarcaxID(int id)
        {
            CatMarca mar = context.CatMarca.FirstOrDefault(x => x.IDMarca == id);
            var ent = new ClassEntMarca();
            if (mar!=null)
            {
                ent.IDMarca = mar.IDMarca;
                ent.Nombre_Marca = mar.Nombre_Marca;
                ent.Estado = mar.Estado;
            }
            return ent;
        }
        #endregion

        #region Muestra Marca x Nombre
        public List<ClassEntMarca> MuestraMarcaxNombre(string name)
        {
            var consulta = (from m in context.CatMarca
                            where m.Nombre_Marca.Contains(name) && m.Estado == true
                            select new ClassEntMarca
                            {
                                IDMarca = m.IDMarca,
                                Nombre_Marca = m.Nombre_Marca,
                                Estado = m.Estado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntMarca> MuestraMarcaxNombreInactivas(string name)
        {
            var consulta = (from m in context.CatMarca
                            where m.Nombre_Marca.Contains(name) && m.Estado == false
                            select new ClassEntMarca
                            {
                                IDMarca = m.IDMarca,
                                Nombre_Marca = m.Nombre_Marca,
                                Estado = m.Estado
                            }).ToList();
            return consulta;
        }

        #region Busca Duplicados
        public List<ClassEntMarca> BuscaMarcaDuplicada(ClassEntMarca ent)
        {
            var consulta = (from m in context.CatMarca
                            where (m.Nombre_Marca.Equals(ent.Nombre_Marca))
                            select new ClassEntMarca
                            {
                                IDMarca = m.IDMarca,
                                Nombre_Marca = m.Nombre_Marca,
                                Estado = m.Estado
                            }).ToList();
            return consulta;
        }
        #endregion
    }
}
