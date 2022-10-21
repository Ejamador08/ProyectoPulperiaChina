using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegArticulo
    {
        /// <summary>
        /// Guarda Unu nuevoa articulo en la DB
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        #region Guarda Articulos

        public bool GuardaArticulo(ClassEntArticulo nuevo)
        {
            ClassDatArticulo dat = new ClassDatArticulo();
            return dat.GuardaArticulo(nuevo);
        }

        //public List<ClassEntArticulo> MuestraArticulos()
        //{
        //    ClassDatArticulo dat = new ClassDatArticulo();
        //    return dat.MostrarArticulos();
        //}

        //public List<ClassEntArticulo> MostrarArticulos(int cant)
        //{
        //    ClassDatArticulo datos = new ClassDatArticulo();
        //    return datos.MostrarArticulos(cant);
        //}

    #endregion

        /// <summary>
        /// actualiza los articulos en la tablas en la DB
        /// </summary>
        /// <param name="nuevo"></param>
        /// hecho por Eliecer Amador
        /// <returns></returns>
        #region Actualiza Articulos
        public bool ActualizaArticulo(ClassEntArticulo nuevo)
        {
            if (nuevo.Nombre_Articulo == "")
            {
                return false;
            }
            ClassDatArticulo art = new ClassDatArticulo();
            return art.ActualizarArticulo(nuevo);
        }
        #endregion

        #region Elimina Articulo
        public bool EliminaArticulo(int id)
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.EliminaArticulo(id);
        }
        #endregion

        public bool Restaurar(int id)
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.Restaurar(id);
        }

        public bool DardeBaja(int id)
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.DardeBaja(id);
        }

        public List<ClassEntArticulo> MuestraBA()
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MuestraBA();
        }

        #region Muestra Articulo
        public List<ClassEntArticulo> MuestraArticulo()
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MostrarArticulo();
        }
       #endregion

        public List<ClassEntArticulo> MostrarArticuloInactivos()
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MostrarArticuloInactivos();
        }

        public List<ClassEntArticulo> Mostrarcompra()
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.Mostrarcompra();
        }
        
        #region Muestra Articulos x Categoria
        public List<ClassEntArticulo> MostrarArticulosxCategoria(int id)
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MostrarArticulosxCategoria(id);
        }
        #endregion

        #region Muestra Articulo x ID
        public ClassEntArticulo MuestraArticuloPorID(int id)
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MostrarArticulosPorID(id);
        }
        #endregion

        #region Muestra x ID Bod-Art
        public List<ClassEntArticulo> MostrarProductosorID(int ID)
        {
            ClassDatArticulo dat = new ClassDatArticulo();
            return dat.MostrarProductosorID(ID);
        }
        #endregion

        public List<ClassEntArticulo> MuestraBaedicion(int ID)
        {
            ClassDatArticulo dat = new ClassDatArticulo();
            return dat.MuestraBaedicion(ID);
        }

        #region Muestra Detalle Articulo
        public ClassEntArticulo MuestraDetalleArticulo(int codigo)
        {
            var dat = new ClassDatArticulo();
            return dat.MuestraDetallexID(codigo);
        }
        #endregion

        #region Muestra Articulos x Nombre
        public List<ClassEntArticulo> MostrarArticulosxNombre(string nombre)
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MostrarArticulosxNombre(nombre);
        }

        #endregion

        public List<ClassEntArticulo> MostrarArticulosxNombreInactivos(string nombre)
        {
            ClassDatArticulo dat = new ClassDatArticulo();
            return dat.MostrarArticulosxNombreInactivos(nombre);
        }

        #region Muestra Articulos con Estado TRUE
        public List<ClassEntArticulo> MostrarArticuloTRUE()
        {
            ClassDatArticulo art = new ClassDatArticulo();
            return art.MostrarArticulosTRUE();
        }
        #endregion

        #region Muestra Articulos x Cantidad
        public List<ClassEntArticulo> MuestraxCantidad(int canti)
        {
            var art = new ClassDatArticulo();
            return art.MostrarxCantidad(canti);
        }
        #endregion

        #region Muestra Un Solo Articulo --- servira para los otros catalogos
        //, ClassEntProveedor detp, ClassEntCategoria detc, ClassEntMarca detm
        public ClassEntArticulo EncuentraUnArticulo(int id)
        {
            var dat = new ClassDatArticulo();
            return dat.MuestraUnArticulo(id);
            //, detp, detc, detm
        }
        #endregion

        #region Articulo Detalle x ID
        public ClassEntArticulo MuestraDetalleArtxID(int cod)
        {
            var dat = new ClassDatArticulo();
            return dat.MuestraDetalleArticulosxID(cod);
        }
        #endregion

        #region Registros Duplicados
        public List<ClassEntArticulo> BuscaArticulosDuplicados(ClassEntArticulo ent)
        {
            ClassDatArticulo datos = new ClassDatArticulo();
            return datos.BuscaArticulosDuplicados(ent);
        }
        #endregion  

        #region Muestra Articulos Relacionados -- revisaro
        //public List<ClassEntArticulo> MostrarArticRel(int id, int? idcat)
        //{
        //    var datos = new ClassDatArticulo();
        //    return datos.MostrarArticRel(id, idcat);
        //}
        #endregion

        /*=============FACTURACION============*/
        #region Muestra Detalle Articulo
        public List<ClassEntBodegaArticulo> MuestraDetalleBodegaArticulo(int idart, int idbod)
        {
            var dat = new ClassDatArticulo();
            return dat.MuestraDetalleBodegaArticulo(idart, idbod);
        }
        #endregion

        /*=============Bodega-Articulo============*/
        #region Muestra Articulos x Nombre
        public List<ClassEntArticulo> MostrarArticulosxNombreBA(string nombre)
        {
            var dat = new ClassDatArticulo();
            return dat.MostrarArticulosxNombreBA(nombre);
        }
        #endregion

        /*=============Compra============*/
        public List<ClassEntArticulo> ArticuloLN(int id)
        {
            var dat=new ClassDatArticulo();
            return dat.ArticuloLN(id);
        }
        public List<ClassEntArticulo> ArticuloMueble(int id)
        {
            var dat=new ClassDatArticulo();
            return dat.ArticuloMueble(id);
        }
        public List<ClassEntArticulo> ArticuloConstruxion(int id)
        {
            var dat=new ClassDatArticulo();
            return dat.ArticuloConstruxion(id);
        }



        //compra
        public List<ClassEntArticulo> MostrarLineaBlanca(int id)
        {
            var dat = new ClassDatArticulo();
            return dat.MostrarLineaBlanca(id);
        }

        //public List<ClassEntArticulo> MostrarMueble(int id) 
        //{
        //    var dat = new ClassDatArticulo();
        //    return dat.MostrarMueble(id);
        //}

        //public List<ClassEntArticulo> Mostrarcontruccion(int id)
        //{
        //    var dat = new ClassDatArticulo();
        //    return dat.Mostrarcontruccion(id);
        //}
    }
}
