using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatCompra
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();
        
        #region Muestra Ultima Factura(ID)
        public int ultimoID()
        {
            try
            {
                return context.tblCompra.Max(x => x.ID_Compra);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        public ClassEntUsuario MuestrausuarioID(string user)
        {
            var consulta = (from ba in context.CatUsuario
                            join u in context.CatUsuario on ba.UserName equals u.UserName
                            select new ClassEntUsuario
                            {
                                ID_Usuario = ba.ID_Usuario
                            }).FirstOrDefault();
            return consulta;
        }






        public bool Comprar(ClassEntCompra compras, string usuario)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    tblCompra entrada = new tblCompra
                    {
                        Fecha_Compra=compras.Fecha_Compra,
                        Total=compras.Total
                    };
                    context.tblCompra.Add(entrada);
                    context.SaveChanges();

                    var detalletmp = context.tblDetalleCpaTemp.Where(x => x.UserName == usuario).ToList();

                    foreach (var com in detalletmp)
                    {
                        tblArticulo_Bodega extra = context.tblArticulo_Bodega.Where(d => d.ID_Articulo == com.ID_Articulo).FirstOrDefault();
                        extra.ID_BodegaArticulo = extra.ID_BodegaArticulo;
                        extra.ID_Articulo = extra.ID_Articulo;
                        extra.ID_Bodega = extra.ID_Bodega;
                        extra.Precio_Compra = Convert.ToSingle(com.Precio_Compra);
                        extra.Precion_Venta = Convert.ToSingle(com.Precio_Venta);
                        extra.Existencia = Convert.ToInt32(extra.Existencia + com.Cantidad);
                    }
                    //
                    //aki falta la parte del catarticulo
                    //

                    foreach (var item in detalletmp)
                    {
                        var detalle = new tblDetalleCompra
                        {
                            ID_Compra=entrada.ID_Compra,
                            ID_Articulo=item.ID_Articulo,
                            Precio_Compra=item.Precio_Compra,
                            Precio_Venta=item.Precio_Venta,
                            Cantidad=item.Cantidad,
                            ID_Bodega=item.ID_Bodega,
                            ID_Proveedor=item.ID_Proveedor,
                            ID_Marca = item.ID_Marca

                        };
                        context.tblDetalleCompra.Add(detalle);
                        context.tblDetalleCpaTemp.Remove(item);

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

        public bool GuardaTemp(ClassEntDetalleComp temp)
        {
            try
            {
                tblDetalleCpaTemp detalle = new tblDetalleCpaTemp();

                if (!context.tblDetalleCpaTemp.Any(x=>x.ID_Articulo==temp.ID_Articulo))
                {
                    //detalle.ID_ComraTmp=temp.ID_Compra;
                    detalle.ID_Articulo = temp.ID_Articulo;
                    detalle.SubTotal = temp.SubTotal;
                    detalle.Cantidad = temp.Cantidad;
                    detalle.Precio_Compra=temp.Precio_Compra;
                    detalle.Precio_Venta = temp.Precio_Venta;
                    detalle.ID_Proveedor = temp.ID_Proveedor;
                    detalle.ID_Marca = temp.ID_Marca;
                    detalle.ID_Bodega = temp.ID_Bodega;
                    detalle.Fecha_Entrega = temp.Fecha_Entrega;
                    detalle.UserName = temp.UserName;
                }
                else
                {
                    detalle = context.tblDetalleCpaTemp.FirstOrDefault(z => z.ID_Articulo == temp.ID_Articulo);
                    detalle.Precio_Compra = temp.Precio_Compra;
                    detalle.Precio_Venta = temp.Precio_Venta;
                    detalle.Cantidad = detalle.Cantidad + temp.Cantidad;
                    detalle.UserName = temp.UserName;
                }
                context.tblDetalleCpaTemp.Add(detalle);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<ClassEntDetalleComp> MuestraTmp(string user)
        {
            List<ClassEntDetalleComp> lista = new List<ClassEntDetalleComp>();

            var consulta = (from dc in context.tblDetalleCpaTemp
                            join a in context.CatArticulo on dc.ID_Articulo equals a.ID_Articulo
                            join p in context.CatProveedor on dc.ID_Proveedor equals p.ID_Proveedor
                            join b in context.CatBodega on dc.ID_Bodega equals b.ID_Bodega
                            join m in context.CatMarca on dc.ID_Marca equals m.IDMarca
                            where dc.UserName == user
                            orderby dc.ID_ComraTmp descending
                            select new ClassEntDetalleComp
                            {
                                ID_ComraTmp=dc.ID_ComraTmp,
                                ID_Articulo=dc.ID_Articulo,
                                ID_Bodega=dc.ID_Bodega,
                                ID_Proveedor=dc.ID_Proveedor,
                                ID_Marca=dc.ID_Marca,
                                SubTotal=dc.SubTotal,
                                Precio_Compra=dc.Precio_Compra,
                                Precio_Venta=dc.Precio_Venta,
                                Cantidad = dc.Cantidad,
                                Fecha_Entrega=dc.Fecha_Entrega,
                                UserName=dc.UserName,

                                //prop agregadas
                                NombreArticulo=a.Nombre_Articulo,
                                NombreProveedor=p.Nombre_Proveedor,
                                NombreBodega=b.Nombre_Bodega,
                                NombreMarca=m.Nombre_Marca
                            }).ToList();

            foreach (var item in consulta)
            {
                lista.Add(new ClassEntDetalleComp
                {
                    ID_ComraTmp = item.ID_ComraTmp,
                    ID_Articulo = item.ID_Articulo,
                    ID_Bodega = item.ID_Bodega,
                    ID_Proveedor = item.ID_Proveedor,
                    ID_Marca = item.ID_Marca,
                    SubTotal = item.SubTotal,
                    Precio_Compra = item.Precio_Compra,
                    Precio_Venta=item.Precio_Venta,
                    Cantidad=item.Cantidad,
                    Fecha_Entrega = item.Fecha_Entrega,
                    UserName=item.UserName,

                    NombreArticulo = item.NombreArticulo,
                    NombreProveedor = item.NombreProveedor,
                    NombreBodega = item.NombreBodega,
                    NombreMarca = item.NombreMarca
                });
            }
            return lista;
        }

        public bool EliminaTemp(int id)
        {
            try
            {
                tblDetalleCpaTemp temp = context.tblDetalleCpaTemp.FirstOrDefault(x => x.ID_ComraTmp == id);
                context.tblDetalleCpaTemp.Remove(temp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
    }
}
