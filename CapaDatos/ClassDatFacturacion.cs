using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CapaDatos
{
    public class ClassDatFacturacion
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        #region  Con Estos Trabajo el Profesor Marcos
        #region Facturar Articulo
        //Pasamas como parametro la factura
        public bool Facturar(ClassEntFacturacion factura, string usuario)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    tblVenta venta = new tblVenta
                    {
                        Fecha_Vta = factura.Fecha_Vta,
                        NombreCliente = factura.NombreCliente,
                        ID_Usuario = factura.ID_Usuario,
                        Total = factura.Total,
                        
                        Anulada = factura.Anulada
                    };
                    context.tblVenta.Add(venta);
                    context.SaveChanges();

                    //extrayendo los produto de la tabla temporal
                    var detalltmp = context.tblDetalleVtaTemp.Where(d => d.UserName == usuario).ToList();

                    foreach (var art in detalltmp)
                    {
                        tblArticulo_Bodega extra = context.tblArticulo_Bodega.Where(d => d.ID_Articulo == art.ID_Articulo).FirstOrDefault();
                        extra.ID_BodegaArticulo = extra.ID_BodegaArticulo;
                        extra.ID_Articulo = extra.ID_Articulo;
                        extra.ID_Bodega = extra.ID_Bodega;
                        extra.Precio_Compra = extra.Precio_Compra;
                        extra.Precion_Venta = extra.Precion_Venta;
                        extra.Existencia = Convert.ToInt32(extra.Existencia - art.Cantidad);
                    }
                    //recorre todos los productos de la tabla temporal 
                    foreach (var item in detalltmp)
                    //asigna un valor de la temprales ala tabla definitiva detalle venta
                    {
                        var detalle = new tblDetalleVenta
                        {
                            ID_Venta = venta.ID_Venta,
                            //ID_Articulo = venta.ID_Cliente,
                            ID_Articulo=item.ID_Articulo,
                            Precio= Convert.ToSingle(item.Precio),
                            Cantidad=item.Cantidad,
                            Descuento=item.Descuento,
                            SubTotal=item.SubTotal,
                            Garantia=item.Garantia,

                        };
                        context.tblDetalleVenta.Add(detalle);
                        context.tblDetalleVtaTemp.Remove(item);

                        context.SaveChanges();
                    }
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return false;
                }
            }
        }
        #endregion

        public bool LimpiarTemp(string  usuario)
        {
            //extrayendo los produto de la tabla temporal
            var detalltmp = context.tblDetalleVtaTemp.Where(d => d.UserName == usuario).ToList();
            //recorre todos los productos de la tabla temporal 
            foreach (var item in detalltmp)
            //asigna un valor de la temprales ala tabla definitiva detalle venta
            {
               
                context.tblDetalleVtaTemp.Remove(item);

                context.SaveChanges();
            }
            return true;
        }

        #region Guarda Articulo en la tblDetalleVtaTemp--- listo Guarda
        //Guarda el producto en la tabla temporal
        public bool GuardaTemp(ClassEntDetalleTemp temp)
        {
            try
            {

                tblDetalleVtaTemp detalle = new tblDetalleVtaTemp();

                if (!context.tblDetalleVtaTemp.Any(x => x.ID_Articulo == temp.ID_Articulo))
                {
                    detalle.ID_Articulo = temp.ID_Articulo;
                    detalle.Estado = temp.Estado;
                    detalle.SubTotal = temp.SubTotal;
                    detalle.Descuento = temp.Descuento;
                    detalle.Precio = temp.Precio;
                    detalle.Cantidad = temp.Cantidad;
                    detalle.Garantia = temp.Garantia;
                    detalle.UserName = temp.UserName;
                    context.tblDetalleVtaTemp.Add(detalle);
                }
                else
                {
                    detalle = context.tblDetalleVtaTemp.FirstOrDefault(x => x.ID_Articulo == temp.ID_Articulo);
                    detalle.Precio = temp.Precio;
                    detalle.Cantidad = detalle.Cantidad + temp.Cantidad;
                    detalle.UserName = temp.UserName;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Cant(int cant, int id)
        {
            tblDetalleVtaTemp detalle = new tblDetalleVtaTemp();
            detalle = context.tblDetalleVtaTemp.FirstOrDefault(x => x.ID_DetalleTemp == id);
            detalle.Cantidad = detalle.Cantidad-cant;
            context.SaveChanges();
            return true;
        }
        #endregion

        #region  Muestra Detalle Temporal
        //Mostrar elmentos de la temporal
        public List<ClassEntDetalleTemp> MuestraTmp(string user)
        {
            List<ClassEntDetalleTemp> lista = new List<ClassEntDetalleTemp>();

            var consulta = (from dt in context.tblDetalleVtaTemp
                            join a in context.CatArticulo on dt.ID_Articulo equals a.ID_Articulo
                            where dt.UserName == user orderby dt.ID_DetalleTemp descending
                            select new ClassEntDetalleTemp
                            {
                                ID_DetalleTemp = dt.ID_DetalleTemp,
                                ID_Articulo = dt.ID_Articulo,
                                SubTotal = dt.SubTotal,
                                Estado = dt.Estado,
                                Descuento = dt.Descuento,
                                Precio = dt.Precio,
                                Cantidad = dt.Cantidad,
                                Garantia = dt.Garantia,
                                UserName=dt.UserName,
                                Nombre_Articulo=a.Nombre_Articulo
                            }).ToList();

            foreach (var item in consulta)
            {
                lista.Add(new ClassEntDetalleTemp
                {
                    ID_DetalleTemp = item.ID_DetalleTemp,
                    ID_Articulo = item.ID_Articulo,
                    SubTotal = Convert.ToSingle(item.Precio * item.Cantidad) - item.Descuento,
                    Estado = item.Estado,
                    Descuento = item.Descuento,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad,
                    Garantia=item.Garantia,
                    UserName=item.UserName,
                    Nombre_Articulo=item.Nombre_Articulo
                });
            }
            return lista;
        }
        #endregion

        
        //Eliminar un producto de la temporal
        public bool EliminaTemp(int idart)
        {
            try
            {
                tblDetalleVtaTemp temp = context.tblDetalleVtaTemp.FirstOrDefault(x => x.ID_DetalleTemp == idart);
                context.tblDetalleVtaTemp.Remove(temp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion





        //hecho x el grupo
        #region Eliminade la GridDetalle
        public bool EliminaDetalle(int id)
        {
            tblDetalleVtaTemp temp = context.tblDetalleVtaTemp.FirstOrDefault(x => x.ID_DetalleTemp == id);
            context.tblDetalleVtaTemp.Remove(temp);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Esta la hicimos por parte del grupo
        public ClassEntUsuario MuestrausuarioID(string user)
        {
            var consulta = (from ba in context.CatUsuario
                            where ba.Nombre_User == user
                            select new ClassEntUsuario
                            {
                                ID_Usuario = ba.ID_Usuario
                            }).FirstOrDefault();
            return consulta;
        }
        #endregion

        #endregion

        //Esperar para utilizarlo
        #region Muestra Articulos
        //public List<ClassEntDetalleTemp> MostrarDetalle()
        //{
        //    var consulta = (from art in context.tblDetalleVtaTemp
        //                    join c in context.CatArticulo on art.ID_Articulo equals c.ID_Articulo
        //                    join p in context.CatCategoria on c.ID_Categoria equals p.ID_Categoria

        //                    select new ClassEntDetalleTemp
        //                    {
        //                        ID_DetalleTemp = art.ID_DetalleTemp,
        //                        Nombre_Articulo = c.Nombre_Articulo,
        //                        Precio = art.Precio,
        //                        Cantidad = art.Cantidad,
        //                        SubTotal = art.SubTotal

        //                    }).ToList();
        //    return consulta;
        //}
        #endregion

        //revisar la parte del username para evitar conflicto y guardar bien
        #region Muestra Elementos en la tblDetalleVtaTemp
        //public List<ClassEntDetalleTemp> MuestraDetalleTemp(string usuario)
        //{
        //    List<ClassEntDetalleTemp> lista = new List<ClassEntDetalleTemp>();
        //    var consulta=(from t in context.tblDetalleVtaTemp
        //                  join p in context.CatArticulo on t.ID_Articulo equals p.ID_Articulo
        //                  where t.id==usuario orderby t.ID_DetalleTemp descending
        //                  select new ClassEntDetalleTemp
        //                  {

        //                  }
        //}
        #endregion

        #region Muestra Ultima Factura(ID)
        public int ultimoID()
        {
            try
            {
                return context.tblVenta.Max(x => x.ID_Venta);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion



        //ver facturas metodos
        public List<ClassEntFacturacion> MuestraFactura()
        {
            var consulta = (from f in context.tblVenta
                            join u in context.CatUsuario on f.ID_Usuario equals u.ID_Usuario
                            select new ClassEntFacturacion
                            {
                                ID_Venta=f.ID_Venta,
                                Fecha_Vta=f.Fecha_Vta,
                                ID_Usuario=f.ID_Usuario,
                                NombreCliente=f.NombreCliente,
                                Total=f.Total,
                                Anulada=f.Anulada,
                                 //prop
                                NombreEmpleado= u.Nombre_User + " " + u.Apellido1_User
                            }).ToList();

            return consulta;
        }

        public List<ClassEntFacturacion> BuscaFacturaxNombreCliente(string name)
        {
            var consulta = (from f in context.tblVenta
                            join u in context.CatUsuario on f.ID_Usuario equals u.ID_Usuario
                            where f.NombreCliente.Contains(name)
                            select new ClassEntFacturacion
                            {
                                ID_Venta = f.ID_Venta,
                                Fecha_Vta = f.Fecha_Vta,
                                ID_Usuario = f.ID_Usuario,
                                NombreCliente = f.NombreCliente,
                                Total = f.Total,
                                Anulada = f.Anulada,
                                //prop
                                NombreEmpleado = u.Nombre_User + " " + u.Apellido1_User
                            }).ToList();
            return consulta;
        }

        public List<ClassEntDetalleTemp> muestradetalleFacturaGrid(int id)
        {
            var consulta = (from f in context.tblVenta
                            join df in context.tblDetalleVenta on f.ID_Venta equals df.ID_Venta
                            join a in context.CatArticulo on df.ID_Articulo equals a.ID_Articulo
                            join ba in context.tblArticulo_Bodega on a.ID_Articulo equals ba.ID_Articulo
                            where f.ID_Venta==id
                            select new ClassEntDetalleTemp
                            {
                                ID_DetalleTemp = df.ID_DetalleVenta,
                                ID_Venta = df.ID_Venta,
                                ID_Articulo = df.ID_Articulo,
                                SubTotal = df.SubTotal,
                                Cantidad = df.Cantidad,
                                Garantia=df.Garantia,
                                Descuento = df.Descuento,
                                precioventa = df.Precio,
                                Nombre_Articulo = a.Nombre_Articulo,
                                NombreCliente = f.NombreCliente
                            }).ToList();
            return consulta;
        }
    }
}
