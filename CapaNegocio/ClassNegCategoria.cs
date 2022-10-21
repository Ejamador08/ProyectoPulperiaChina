using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegCategoria
    {
            #region Guarda Categoria
        public bool GuardaCategoria(ClassEntCategoria nuevo)
        {
            if (nuevo.Nombre_Categoria=="")
            {
                return false;
            }
            ClassDatCategoria cat = new ClassDatCategoria();
            return cat.GuardaCategoria(nuevo);
        }
        #endregion

            #region Actualiza Categoria
        public bool ActualizaCategoria(ClassEntCategoria nuevo)
        {
            if (nuevo.Nombre_Categoria=="")
            {
                return false;
            }
            ClassDatCategoria cat = new ClassDatCategoria();
            return cat.ActualizaCategoria(nuevo);
        }
        #endregion

            #region Elimina Categoria
            public bool EliminarCategoria(int id)
                {
                    ClassDatCategoria cat=new ClassDatCategoria();
                    return cat.EliminaCategoria(id);

                }
        #endregion

            public bool DardeBaja(int id)
            {
                var dat = new ClassDatCategoria();
                return dat.DardeBaja(id);
            }

            public bool Restaurar(int id)
            {
                var dat = new ClassDatCategoria();
                return dat.Restaurar(id);
            }

            #region Muestra Categoria
            public List<ClassEntCategoria> MuestraCategoria()
            {
                ClassDatCategoria cat = new ClassDatCategoria();
                return cat.MostrarCategoria();
            }
        #endregion

            public List<ClassEntCategoria> MostrarCategoriaInactivas()
            {
                var dat = new ClassDatCategoria();
                return dat.MostrarCategoriaInactivas();
            }

            #region Muestra Categoriax ID
            public ClassEntCategoria MostrarCategoriaxID(int id)
            {
                ClassDatCategoria cat = new ClassDatCategoria();
                return cat.MostrarCategoriaxID(id);
            }
            #endregion

            #region Muestra Categoria x Nombre
            public List<ClassEntCategoria> MostrarCategoriaxNombre(string nombre)
            {
                var cat = new ClassDatCategoria();
                return cat.MostrarCategoriaxNombre(nombre);
            }
            #endregion

            public List<ClassEntCategoria> MostrarCategoriaxNombreInactivos(string nombre)
            {
                var dat = new ClassDatCategoria();
                return dat.MostrarCategoriaxNombreInactivos(nombre);
            }

            #region Busca Duplicados
            public List<ClassEntCategoria> BuscarCategoriasDuplicadas(ClassEntCategoria ent)
            {
                ClassDatCategoria datos = new ClassDatCategoria();
                return datos.BuscarCategoriasDuplicadas(ent);
            }
            #endregion

            #region Muestra Categoria "Linea Blanca"
            public List<ClassEntCategoria> MostrarCategoriaLineaBlanca()
            {
                ClassDatCategoria cat = new ClassDatCategoria();
                return cat.MostrarCategoriaLineaBlanca();
            }
        #endregion

            #region Muestra Categoria "Muebles"
            public List<ClassEntCategoria> MostrarCategoriaMuebles()
            {
                ClassDatCategoria cat = new ClassDatCategoria();
                return cat.MostrarCategoriaMuebles();
            }

        #endregion

            #region Muestra Categoria "Materiales de Contruccion
            public List<ClassEntCategoria> MostrarCategoriaContruccion()
            {
                ClassDatCategoria cat = new ClassDatCategoria();
                return cat.MostrarCategoriaContruccion();
            }
        #endregion

    }
}
