using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatArticulo
    {
        //variable tipo "context" global
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        //variable "articulo" tipo global
        List<ClassEntArticulo> articulo = new List<ClassEntArticulo>();

        #region Guarda Articulos
        public bool GuardaArticulo(ClassEntArticulo nuevo)
        {
                CatArticulo art = new CatArticulo();

                art.ID_Articulo = nuevo.ID_Articulo;
                art.Nombre_Articulo = nuevo.Nombre_Articulo;
                art.Descripcion = nuevo.Descripcion;
                art.ID_Categoria = nuevo.ID_Categoria;
                art.ID_Proveedor = nuevo.ID_Proveedor;
                art.ID_Marca = nuevo.ID_Marca;
                art.Estado = nuevo.Estado;
                art.RutaImagen = nuevo.RutaImagen;
                art.Garantia = nuevo.Garantia;

                context.CatArticulo.Add(art);
                context.SaveChanges();
                return true;
        }

        #endregion

        #region Actualizar Articulo
        public bool ActualizarArticulo(ClassEntArticulo nuevo)
        {
                //tblArticulo art = new tblArticulo();
                CatArticulo art = context.CatArticulo.FirstOrDefault(x => x.ID_Articulo == nuevo.ID_Articulo);

                art.ID_Articulo = nuevo.ID_Articulo;
                art.Nombre_Articulo = nuevo.Nombre_Articulo;
                art.Descripcion = nuevo.Descripcion;
                art.ID_Categoria = nuevo.ID_Categoria;
                art.ID_Proveedor = nuevo.ID_Proveedor;
                art.ID_Marca = nuevo.ID_Marca;
                art.Estado = nuevo.Estado;
                art.RutaImagen = nuevo.RutaImagen;
                art.Garantia = nuevo.Garantia;

                context.SaveChanges();
                return true;
        }

        #endregion

        #region Elimina Articulo
        public bool EliminaArticulo(int id)
        {
                CatArticulo art = context.CatArticulo.FirstOrDefault(x => x.ID_Articulo == id);
                context.CatArticulo.Remove(art);
                context.SaveChanges();
                return true;
        }
        #endregion

        public bool Restaurar(int id)
        {
            CatArticulo art = context.CatArticulo.FirstOrDefault(x => x.ID_Articulo == id);
            art.Estado = true;
            context.SaveChanges();
            return true;
        }

        public bool DardeBaja(int id)
        {
            CatArticulo art = context.CatArticulo.FirstOrDefault(x => x.ID_Articulo == id);
            art.Estado = false;
            context.SaveChanges();
            return true;
        }

        #region Muestra Articulos para Bodega
        public List<ClassEntArticulo> MuestraBA()
        {
            {
                var consulta = (from art in context.CatArticulo
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = art.ID_Articulo,
                                    Nombre_Articulo = art.Nombre_Articulo,
                                    Descripcion = art.Descripcion,
                                    ID_Categoria = art.ID_Categoria,
                                    ID_Proveedor = art.ID_Proveedor,
                                    ID_Marca = art.ID_Marca,
                                    Estado = art.Estado,
                                    RutaImagen = art.RutaImagen,
                                    Garantia=art.Garantia
                                }).ToList();
                return consulta;
            }
        }
        #endregion

        #region Muestra Articulos
        public List<ClassEntArticulo> MostrarArticulo()
        {
            var consulta = (from art in context.CatArticulo
                            join c in context.CatCategoria on art.ID_Categoria equals c.ID_Categoria
                            join p in context.CatProveedor on art.ID_Proveedor equals p.ID_Proveedor
                            join m in context.CatMarca on art.ID_Marca equals m.IDMarca
                            orderby art.ID_Articulo descending //agregada recientemente
                            where art.Estado==true
                            select new ClassEntArticulo
                            {
                                ID_Articulo = art.ID_Articulo,
                                Nombre_Articulo = art.Nombre_Articulo,
                                Descripcion=art.Descripcion,
                                ID_Categoria = art.ID_Categoria,
                                ID_Proveedor = art.ID_Proveedor,
                                ID_Marca=art.ID_Marca,
                                Estado = art.Estado,
                                RutaImagen = art.RutaImagen,
                                Garantia=art.Garantia,

                                NombreCategoria=c.Nombre_Categoria,
                                NombreProveedor=p.Nombre_Proveedor,
                                NombreMarca=m.Nombre_Marca
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntArticulo> MostrarArticuloInactivos()
        {
            var consulta = (from art in context.CatArticulo
                            join c in context.CatCategoria on art.ID_Categoria equals c.ID_Categoria
                            join p in context.CatProveedor on art.ID_Proveedor equals p.ID_Proveedor
                            join m in context.CatMarca on art.ID_Marca equals m.IDMarca
                            orderby art.ID_Articulo descending //agregada recientemente
                            where art.Estado == false
                            select new ClassEntArticulo
                            {
                                ID_Articulo = art.ID_Articulo,
                                Nombre_Articulo = art.Nombre_Articulo,
                                Descripcion = art.Descripcion,
                                ID_Categoria = art.ID_Categoria,
                                ID_Proveedor = art.ID_Proveedor,
                                ID_Marca = art.ID_Marca,
                                Estado = art.Estado,
                                RutaImagen = art.RutaImagen,
                                Garantia=art.Garantia,

                                NombreCategoria = c.Nombre_Categoria,
                                NombreProveedor = p.Nombre_Proveedor,
                                NombreMarca = m.Nombre_Marca
                            }).ToList();
            return consulta;
        }

        #region Muestra Articulos x Categoria
        public List<ClassEntArticulo> MostrarArticulosxCategoria(int id)
        {
            try
            {
                var consulta = (from art in context.CatArticulo
                                join artic in context.CatCategoria
                                on art.ID_Categoria equals artic.ID_Categoria
                                select new ClassEntArticulo
                                    {
                                        ID_Articulo = art.ID_Articulo,
                                        Nombre_Articulo = art.Nombre_Articulo,
                                        Descripcion=art.Descripcion,
                                        ID_Categoria = art.ID_Categoria,
                                        ID_Proveedor = art.ID_Proveedor,
                                        ID_Marca=art.ID_Marca,
                                        Estado = art.Estado,
                                        RutaImagen = art.RutaImagen,
                                        Garantia = art.Garantia

                                        //campo agregado
                                        //NombreCategoria = artic.Nombre_Categoria
                                    }).ToList();

                return consulta;

            }
            catch (Exception)
            {

                return articulo;
            }
        }
        #endregion

        #region Muestra Articulo x ID
        public ClassEntArticulo MostrarArticulosPorID(int id)
        {

            CatArticulo art = context.CatArticulo.FirstOrDefault(x => x.ID_Articulo == id);
            ClassEntArticulo artic = new ClassEntArticulo();
            if (art != null)
            {
                artic.ID_Articulo = art.ID_Articulo;
                artic.Nombre_Articulo = art.Nombre_Articulo;
                artic.Descripcion = art.Descripcion;
                artic.ID_Categoria = art.ID_Categoria;
                artic.ID_Proveedor = art.ID_Proveedor;
                artic.ID_Marca = art.ID_Marca;
                artic.Estado = art.Estado;
                artic.RutaImagen = art.RutaImagen;
                artic.Garantia = art.Garantia;
            }
            return artic;

            //var consulta=(from art in context.tblArticulo
            //              //join artic in context.tblCategoria
            //              //on art.ID_Categoria equals artic.ID_Categoria
            //              where art.ID_Articulo==id
            //              select new ClassEntArticulo
            //              {
            //                  ID_Articulo=art.ID_Articulo,
            //                  Nombre_Articulo=art.Nombre_Articulo,
            //                  Precio=art.Precio,
            //                  ID_Categoria=art.ID_Categoria,
            //                  ID_Proveedor=art.ID_Proveedor,
            //                  Activo=art.Activo,
            //                  RutaImagen=art.RutaImagen,

            //                  //campo agregado
            //                  //NombreCategoria=artic.Nombre_Categoria

            //              }).ToList();

            //return consulta;
        }
        #endregion

        #region Muestra x ID Bod-Art
        public List<ClassEntArticulo> MostrarProductosorID(int ID)
        {
                var consulta = (from pro in context.CatArticulo
                                join ba in context.tblArticulo_Bodega on pro.ID_Articulo equals ba.ID_Articulo
                                where pro.ID_Articulo == ID
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = pro.ID_Articulo,
                                    Nombre_Articulo = pro.Nombre_Articulo,
                                    Descripcion = pro.Descripcion,
                                    ID_Categoria = pro.ID_Categoria,
                                    ID_Proveedor = pro.ID_Proveedor,
                                    ID_Marca = pro.ID_Marca,
                                    Estado = pro.Estado,
                                    RutaImagen = pro.RutaImagen,
                                    Garantia = pro.Garantia,

                                    //prop agregadas
                                    Precio_Venta=ba.Precion_Venta,
                                    Existencia=ba.Existencia
                                }).ToList();

                return consulta;
            }
	#endregion

        #region BAedicion
        public List<ClassEntArticulo> MuestraBaedicion(int ID)
        {
            var consulta = (from pro in context.CatArticulo
                            //join ba in context.tblArticulo_Bodega on pro.ID_Articulo equals ba.ID_Articulo
                            where pro.ID_Articulo == ID
                            select new ClassEntArticulo
                            {
                                ID_Articulo = pro.ID_Articulo,
                                Nombre_Articulo = pro.Nombre_Articulo,
                                Descripcion = pro.Descripcion,
                                ID_Categoria = pro.ID_Categoria,
                                ID_Proveedor = pro.ID_Proveedor,
                                ID_Marca = pro.ID_Marca,
                                Estado = pro.Estado,
                                RutaImagen = pro.RutaImagen,
                                Garantia = pro.Garantia,

                                ////prop agregadas
                                //Precio_Venta = ba.Precion_Venta,
                                //Existencia = ba.Existencia
                            }).ToList();

            return consulta;
        }
        #endregion

        #region Muestra Detalle Articulo
        public ClassEntArticulo MuestraDetallexID(int codigo)
        {
            var art = new ClassEntArticulo();

            var consulta=(from a in context.CatArticulo
                          join c in context.CatCategoria on a.ID_Categoria equals c.ID_Categoria
                          join p in context.CatProveedor on a.ID_Proveedor equals p.ID_Proveedor
                          where a.Estado==true && a.ID_Articulo==codigo
                          select new ClassEntArticulo
                          {
                                ID_Articulo = a.ID_Articulo,
                                Nombre_Articulo = a.Nombre_Articulo,
                                Descripcion=a.Descripcion,
                                ID_Categoria = a.ID_Categoria,
                                ID_Proveedor = a.ID_Proveedor,
                                ID_Marca=a.ID_Marca,
                                Estado = a.Estado,
                                RutaImagen = a.RutaImagen,
                                Garantia = art.Garantia
                          }).ToList();

            foreach (var c in consulta)
            {
                art.ID_Articulo = c.ID_Articulo;
                art.Nombre_Articulo = c.Nombre_Articulo;
                art.Descripcion = c.Descripcion;
                art.ID_Categoria = c.ID_Categoria;
                art.ID_Proveedor = c.ID_Proveedor;
                art.ID_Marca = c.ID_Marca;
                art.Estado = c.Estado;
                art.RutaImagen = c.RutaImagen;
            }

            return art;
        }
        #endregion

        #region Muestra Articulos x Nombre
        public List<ClassEntArticulo> MostrarArticulosxNombre(string nombre)
        {
            try
            {
                var consulta = (from art in context.CatArticulo
                                join c in context.CatCategoria on art.ID_Categoria equals c.ID_Categoria
                                join p in context.CatProveedor on art.ID_Proveedor equals p.ID_Proveedor
                                join m in context.CatMarca on art.ID_Marca equals m.IDMarca
                                where art.Nombre_Articulo.Contains(nombre)
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = art.ID_Articulo,
                                    Nombre_Articulo = art.Nombre_Articulo,
                                    Descripcion=art.Descripcion,
                                    ID_Categoria = art.ID_Categoria,
                                    ID_Proveedor = art.ID_Proveedor,
                                    ID_Marca=art.ID_Marca,
                                    Estado = art.Estado,
                                    RutaImagen = art.RutaImagen,
                                    Garantia = art.Garantia,

                                    //campo agregado
                                    NombreCategoria = c.Nombre_Categoria,
                                    NombreProveedor=p.Nombre_Proveedor,
                                    NombreMarca=m.Nombre_Marca
                                }).ToList();

                return consulta;

            }
            catch (Exception)
            {

                return articulo;
            }
        }
        #endregion

        public List<ClassEntArticulo> MostrarArticulosxNombreInactivos(string nombre)
        {
            try
            {
                var consulta = (from art in context.CatArticulo
                                join c in context.CatCategoria on art.ID_Categoria equals c.ID_Categoria
                                join p in context.CatProveedor on art.ID_Proveedor equals p.ID_Proveedor
                                join m in context.CatMarca on art.ID_Marca equals m.IDMarca
                                where art.Nombre_Articulo.Contains(nombre) && art.Estado==false
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = art.ID_Articulo,
                                    Nombre_Articulo = art.Nombre_Articulo,
                                    Descripcion = art.Descripcion,
                                    ID_Categoria = art.ID_Categoria,
                                    ID_Proveedor = art.ID_Proveedor,
                                    ID_Marca = art.ID_Marca,
                                    Estado = art.Estado,
                                    RutaImagen = art.RutaImagen,
                                    Garantia = art.Garantia,

                                    //campo agregado
                                    NombreCategoria = c.Nombre_Categoria,
                                    NombreProveedor = p.Nombre_Proveedor,
                                    NombreMarca = m.Nombre_Marca
                                }).ToList();

                return consulta;

            }
            catch (Exception)
            {

                return articulo;
            }
        }

        #region Muestra Articulo Con Estado TRUE
        public List<ClassEntArticulo> MostrarArticulosTRUE()
        {
            try
            {
                var consulta = (from art in context.CatArticulo
                                //join artic in context.tblCategoria
                                //on art.ID_Categoria equals artic.ID_Categoria
                                where art.Estado.Equals("True")
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = art.ID_Articulo,
                                    Nombre_Articulo = art.Nombre_Articulo,
                                    Descripcion=art.Descripcion,
                                    ID_Categoria = art.ID_Categoria,
                                    ID_Proveedor = art.ID_Proveedor,
                                    ID_Marca=art.ID_Marca,
                                    Estado = art.Estado,
                                    RutaImagen = art.RutaImagen,
                                    Garantia = art.Garantia

                                    //campo agregado
                                    //NombreCategoria = artic.Nombre_Categoria
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {

                return articulo;
            }
        }
        #endregion

        #region Muestra Articulos x Cantidad
        public List<ClassEntArticulo> MostrarxCantidad(int cant)
        {
            var consulta = (from c in context.CatArticulo
                            join p in context.CatProveedor on c.ID_Proveedor equals p.ID_Proveedor
                            join cat in context.CatCategoria on c.ID_Categoria equals cat.ID_Categoria
                            join m in context.CatMarca on c.ID_Marca equals m.IDMarca
                            where c.Estado == true orderby c.ID_Articulo descending
                            select new ClassEntArticulo
                                  {
                                      ID_Articulo = c.ID_Articulo,
                                      Nombre_Articulo = c.Nombre_Articulo,
                                      Descripcion=c.Descripcion,
                                      ID_Categoria = c.ID_Categoria,
                                      ID_Proveedor = c.ID_Proveedor,
                                      ID_Marca=c.ID_Marca,
                                      Estado = c.Estado,
                                      RutaImagen = c.RutaImagen,
                                      Garantia = c.Garantia,

                                      NombreProveedor=p.Nombre_Proveedor,
                                      NombreCategoria=cat.Nombre_Categoria,
                                      NombreMarca=m.Nombre_Marca
                                  }).Take(cant).ToList();
            return consulta;
        }
        #endregion

        #region Muestra Un solo Articulo ---servira para los otros catalogos
        //, ClassEntProveedor detp, ClassEntCategoria detc, ClassEntMarca detm
        public ClassEntArticulo MuestraUnArticulo(int id)
        {
            CatArticulo art = context.CatArticulo.FirstOrDefault(x => x.ID_Articulo == id); 
        //&& x.ID_Proveedor==detp.ID_Proveedor && x.ID_Categoria==detc.ID_Categoria && x.ID_Marca==detm.IDMarca
            var ent = new ClassEntArticulo();

            if (art != null)
            {
                ent.ID_Articulo = art.ID_Articulo;
                ent.Nombre_Articulo = art.Nombre_Articulo;
                ent.Descripcion = art.Descripcion;
                ent.ID_Categoria = art.ID_Categoria;
                ent.ID_Proveedor = art.ID_Proveedor;
                ent.ID_Marca = art.ID_Marca;
                ent.Estado = art.Estado;
                ent.RutaImagen = art.RutaImagen;
                ent.Garantia = art.Garantia;

                //ent.NombreCategoria = art.CatCategoria.Nombre_Categoria;
                //ent.NombreProveedor = art.CatProveedor.Nombre_Proveedor;
                //ent.NombreMarca = art.CatMarca.Nombre_Marca;
            }
            return ent;


            //var consulta = (from a in context.tblArticulo
            //                join c in context.tblCategoria on a.ID_Categoria equals c.ID_Categoria
            //                join p in context.tblProveedor on a.ID_Proveedor equals p.ID_Proveedor
            //                where a.ID_Articulo == id
            //                select new ClassEntArticulo
            //                {
            //                    ID_Articulo = a.ID_Articulo,
            //                    Nombre_Articulo = a.Nombre_Articulo,
            //                    Precio = a.Precio,
            //                    ID_Categoria = a.ID_Categoria,
            //                    ID_Proveedor = a.ID_Proveedor,
            //                    Activo = a.Activo,
            //                    RutaImagen = a.RutaImagen,

            //                    NombreCategoria = c.Nombre_Categoria,
            //                    NombreProveedor = p.Nombre_Proveedor
            //                }).ToList();
        }
        #endregion

        #region MostrarArticulos x ID--Inicio
        public ClassEntArticulo MuestraDetalleArticulosxID(int cod)
        {
            ClassEntArticulo art = new ClassEntArticulo();

            //Buscamos el articulo
            var consulta = (from a in context.CatArticulo
                            join c in context.CatCategoria on a.ID_Categoria equals c.ID_Categoria
                            join p in context.CatProveedor on a.ID_Proveedor equals p.ID_Proveedor
                            where a.Estado == true && a.ID_Articulo == cod
                            select new ClassEntArticulo
                            {
                                ID_Articulo = a.ID_Articulo,
                                Nombre_Articulo = a.Nombre_Articulo,
                                Descripcion=a.Descripcion,
                                ID_Categoria = a.ID_Categoria,
                                ID_Proveedor = a.ID_Proveedor,
                                ID_Marca=a.ID_Marca,
                                Estado = a.Estado,
                                RutaImagen = a.RutaImagen,
                                Garantia = art.Garantia,
                            }).ToList();

            //recorremos lo encontrado y se lo pasamos a art
            foreach (var a in consulta)
            {
                art.ID_Articulo = a.ID_Articulo;
                art.Nombre_Articulo = a.Nombre_Articulo;
                art.ID_Categoria = a.ID_Categoria;
                art.ID_Proveedor = a.ID_Proveedor;
                art.Estado = a.Estado;
                art.RutaImagen = a.RutaImagen;
            }
            return art;

        }
        #endregion

        #region Registros Duplicados
        public List<ClassEntArticulo> BuscaArticulosDuplicados(ClassEntArticulo ent)
        {
            var consulta=(from a in context.CatArticulo
                          where (a.Nombre_Articulo.Equals(ent.Nombre_Articulo))
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = a.ID_Articulo,
                                    Nombre_Articulo = a.Nombre_Articulo,
                                    Descripcion=a.Descripcion,
                                    ID_Categoria = a.ID_Categoria,
                                    ID_Proveedor = a.ID_Proveedor,
                                    ID_Marca=a.ID_Marca,
                                    Estado = a.Estado,
                                    RutaImagen = a.RutaImagen,
                                    Garantia = a.Garantia
                                }).ToList();
            return consulta;
        }
        #endregion

        #region Muestra Articulos Relacionedos --- revisarlo
        //public List<ClassEntArticulo> MostrarArticRel(int id, int? idcat)
        //{
        //    var consulta = (from a in context.tblArticulo
        //                    join c in context.tblCategoria on a.ID_Categoria equals c.ID_Categoria
        //                    join p in context.tblProveedor on a.ID_Proveedor equals p.ID_Proveedor
        //                    where a.Activo == true && a.ID_Categoria == idcat && a.ID_Articulo != id
        //                    select new ClassEntArticulo
        //                    {
        //                        ID_Articulo = a.ID_Articulo,
        //                        Nombre_Articulo = a.Nombre_Articulo,
        //                        Precio = a.Precio,
        //                        ID_Categoria = a.ID_Categoria,
        //                        ID_Proveedor = a.ID_Proveedor,
        //                        Activo = a.Activo,
        //                        RutaImagen = a.RutaImagen
        //                    }).Take(4).ToList();
        //    return consulta;
        //}
        #endregion

        /*===================FACTURACION=======================*/
        List<ClassEntBodegaArticulo> vacio = new List<ClassEntBodegaArticulo>();

        public List<ClassEntBodegaArticulo> MuestraDetalleBodegaArticulo(int idart, int idbod)
        {
            try
            {
                var consulta = (from det in context.tblArticulo_Bodega
                                join art in context.CatArticulo on det.ID_Articulo equals art.ID_Articulo
                                join bod in context.CatBodega on det.ID_Bodega equals bod.ID_Bodega
                                where det.ID_Articulo == idart
                                select new ClassEntBodegaArticulo
                                {
                                    ID_BodegaArticulo = det.ID_BodegaArticulo,
                                    ID_Articulo = det.ID_Articulo,
                                    ID_Bodega = det.ID_Bodega,
                                    Precio_Compra = det.Precio_Compra,
                                    Precion_Venta = det.Precion_Venta,
                                    Existencia = det.Existencia,

                                    //pro agregada
                                    NombreArticulo=art.Nombre_Articulo,
                                    garantia=art.Garantia
                                }).ToList();
                return consulta;

            }
            catch (Exception)
            {
                
                return vacio;
            }
        }

        /*===================Bodega-Articulo=======================*/
        #region Muestra Articulos x Nombre
        public List<ClassEntArticulo> MostrarArticulosxNombreBA(string nombre)
        {
            try
            {
                var consulta = (from art in context.CatArticulo
                                where art.Nombre_Articulo.Contains(nombre)
                                select new ClassEntArticulo
                                {
                                    ID_Articulo = art.ID_Articulo,
                                    Nombre_Articulo = art.Nombre_Articulo,
                                    Descripcion = art.Descripcion,
                                    ID_Categoria = art.ID_Categoria,
                                    ID_Proveedor = art.ID_Proveedor,
                                    ID_Marca = art.ID_Marca,
                                    Estado = art.Estado,
                                    RutaImagen = art.RutaImagen
                                }).ToList();

                return consulta;

            }
            catch (Exception)
            {

                return articulo;
            }
        }
        #endregion

        /*===================Compra=======================*/
        public List<ClassEntArticulo> ArticuloLN(int id)
        {
            var consulta = (from art in context.CatArticulo
                            where art.ID_Categoria == 1
                            select new ClassEntArticulo
                            {
                                ID_Articulo = art.ID_Articulo,
                                Nombre_Articulo = art.Nombre_Articulo,
                                Descripcion = art.Descripcion,
                                ID_Categoria = art.ID_Categoria,
                                ID_Proveedor = art.ID_Proveedor,
                                ID_Marca = art.ID_Marca,
                                Estado = art.Estado,
                                RutaImagen = art.RutaImagen,
                                Garantia = art.Garantia
                            }).ToList();
            return consulta;
        }

        public List<ClassEntArticulo> ArticuloMueble(int id) 
        {
            var consulta = (from a in context.CatArticulo
                            where a.ID_Categoria == 2
                            select new ClassEntArticulo
                            {
                                ID_Articulo = a.ID_Articulo,
                                Nombre_Articulo = a.Nombre_Articulo,
                                ID_Categoria = a.ID_Categoria
                            }).ToList();
            return consulta;
        }

        public List<ClassEntArticulo> ArticuloConstruxion(int id)
        {
            var consulta = (from a in context.CatArticulo 
                            where a.ID_Categoria == 3
                            select new ClassEntArticulo
                            {
                                ID_Articulo = a.ID_Articulo,
                                Nombre_Articulo = a.Nombre_Articulo,
                                ID_Categoria = a.ID_Categoria
                            }).ToList();
            return consulta;
        }

        #region Muestra compra
        public List<ClassEntArticulo> MostrarLineaBlanca(int id)
        {
            var consulta = (from pro in context.CatArticulo
                            join c in context.CatCategoria on pro.ID_Categoria equals c.ID_Categoria
                            join p in context.CatProveedor on pro.ID_Proveedor equals p.ID_Proveedor
                            join m in context.CatMarca on pro.ID_Marca equals m.IDMarca
                            join ba in context.tblArticulo_Bodega on pro.ID_Articulo equals ba.ID_Articulo
                            join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
                            where pro.ID_Articulo == id 
                            select new ClassEntArticulo
                            {
                                ID_Articulo = pro.ID_Articulo,
                                ID_Categoria = pro.ID_Categoria,
                                Nombre_Articulo = pro.Nombre_Articulo,
                                NombreCategoria = c.Nombre_Categoria,
                                NombreProveedor = p.Nombre_Proveedor,
                                NombreMarca = m.Nombre_Marca,
                                NombreBodega=b.Nombre_Bodega,
                                Precio_Venta=ba.Precio_Compra,
                                Existencia=ba.Existencia,
                                ID_Proveedor=pro.ID_Proveedor,
                                ID_Marca=pro.ID_Marca,
                                ID_Bodega=b.ID_Bodega,
                                Garantia = pro.Garantia
                            }).ToList();

            return consulta;
        }

        public List<ClassEntArticulo> Mostrarcompra()
        {
            var consulta = (from pro in context.CatArticulo
                            join c in context.CatCategoria on pro.ID_Categoria equals c.ID_Categoria
                            join p in context.CatProveedor on pro.ID_Proveedor equals p.ID_Proveedor
                            join m in context.CatMarca on pro.ID_Marca equals m.IDMarca
                            join ba in context.tblArticulo_Bodega on pro.ID_Articulo equals ba.ID_Articulo
                            join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega orderby pro.ID_Articulo descending
                            select new ClassEntArticulo
                            {
                                ID_Articulo = pro.ID_Articulo,
                                ID_Categoria = pro.ID_Categoria,
                                Nombre_Articulo = pro.Nombre_Articulo,
                                NombreCategoria = c.Nombre_Categoria,
                                NombreProveedor = p.Nombre_Proveedor,
                                NombreMarca = m.Nombre_Marca,
                                NombreBodega = b.Nombre_Bodega,
                                Precio_Venta = ba.Precio_Compra,
                                Existencia = ba.Existencia,
                                ID_Proveedor = pro.ID_Proveedor,
                                ID_Marca = pro.ID_Marca,
                                ID_Bodega = b.ID_Bodega
                            }).ToList();

            return consulta;
        }

        //public List<ClassEntArticulo> MostrarMueble(int id)
        //{
        //    var consulta = (from pro in context.CatArticulo
        //                    join c in context.CatCategoria on pro.ID_Categoria equals c.ID_Categoria
        //                    join p in context.CatProveedor on pro.ID_Proveedor equals p.ID_Proveedor
        //                    join m in context.CatMarca on pro.ID_Marca equals m.IDMarca
        //                    join ba in context.tblArticulo_Bodega on pro.ID_Articulo equals ba.ID_Articulo
        //                    join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
        //                    where pro.ID_Articulo == id
        //                    select new ClassEntArticulo
        //                    {
        //                        ID_Articulo = pro.ID_Articulo,
        //                        ID_Categoria = pro.ID_Categoria,
        //                        Nombre_Articulo = pro.Nombre_Articulo,
        //                        NombreCategoria = c.Nombre_Categoria,
        //                        NombreProveedor = p.Nombre_Proveedor,
        //                        NombreMarca = m.Nombre_Marca,
        //                        NombreBodega = b.Nombre_Bodega,
        //                        Precio_Venta = ba.Precio_Compra,
        //                        Existencia = ba.Existencia
        //                    }).ToList();

        //    return consulta;
        //}

        //public List<ClassEntArticulo> Mostrarcontruccion(int id)
        //{
        //    var consulta = (from pro in context.CatArticulo
        //                    join c in context.CatCategoria on pro.ID_Categoria equals c.ID_Categoria
        //                    join p in context.CatProveedor on pro.ID_Proveedor equals p.ID_Proveedor
        //                    join m in context.CatMarca on pro.ID_Marca equals m.IDMarca
        //                    join ba in context.tblArticulo_Bodega on pro.ID_Articulo equals ba.ID_Articulo
        //                    join b in context.CatBodega on ba.ID_Bodega equals b.ID_Bodega
        //                    where pro.ID_Articulo == id
        //                    select new ClassEntArticulo
        //                    {
        //                        ID_Articulo = pro.ID_Articulo,
        //                        ID_Categoria = pro.ID_Categoria,
        //                        Nombre_Articulo = pro.Nombre_Articulo,
        //                        NombreCategoria = c.Nombre_Categoria,
        //                        NombreProveedor = p.Nombre_Proveedor,
        //                        NombreMarca = m.Nombre_Marca,
        //                        NombreBodega = b.Nombre_Bodega,
        //                        Precio_Venta = ba.Precio_Compra,
        //                        Existencia = ba.Existencia
        //                    }).ToList();

        //    return consulta;
        //}
        #endregion
    }
}
