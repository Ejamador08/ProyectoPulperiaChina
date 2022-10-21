using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatProveedor
    {
        //variable tipo global
        //Pulperia_ChinaEntities context = new Pulperia_ChinaEntities();
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        //variable tipo global
        List<ClassEntProveedor> proveedor =new List<ClassEntProveedor>();


        #region Guarda Proveedor
        public bool GuardaProveedor(ClassEntProveedor nuevo)
        {
            try
            {

            var pro = new CatProveedor();

                pro.ID_Proveedor = nuevo.ID_Proveedor;
                pro.Nombre_Proveedor = nuevo.Nombre_Proveedor;
                pro.Telefono = nuevo.Telefono;
                pro.Direccion = nuevo.Direccion;
                pro.Email = nuevo.Email;
                pro.Estado = nuevo.Estado;
                pro.RutaLogo = nuevo.RutaLogo;

            context.CatProveedor.Add(pro);
            context.SaveChanges();
            return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
        #endregion

        #region Actualiza Proveedor
        public bool ActualizaProveedor(ClassEntProveedor nuevo)
        {
            try
            {
                CatProveedor pro = context.CatProveedor.FirstOrDefault(x => x.ID_Proveedor == nuevo.ID_Proveedor);

                pro.ID_Proveedor = nuevo.ID_Proveedor;
                pro.Nombre_Proveedor = nuevo.Nombre_Proveedor;
                pro.Telefono = nuevo.Telefono;
                pro.Direccion = nuevo.Direccion;
                pro.Email = nuevo.Email;
                pro.Estado = nuevo.Estado;
                pro.RutaLogo = nuevo.RutaLogo;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        #endregion

        #region Elimina Proveedor
        public bool EliminaProveedor(int id)
        {
            try
            {
                CatProveedor pro = context.CatProveedor.FirstOrDefault(x => x.ID_Proveedor == id);
                context.CatProveedor.Remove(pro);              
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
                CatProveedor pro = context.CatProveedor.FirstOrDefault(x => x.ID_Proveedor == id);
                pro.Estado = false;
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
                CatProveedor pro = context.CatProveedor.FirstOrDefault(x => x.ID_Proveedor == id);
                pro.Estado = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #region Muestra Proveedor
        public List<ClassEntProveedor> MuestraProveedor()
        {
            try
            {
                var consulta = (from pro in context.CatProveedor
                                orderby pro.ID_Proveedor descending
                                where pro.Estado == true
                                select new ClassEntProveedor
                                {
                                    ID_Proveedor = pro.ID_Proveedor,
                                    Nombre_Proveedor = pro.Nombre_Proveedor,
                                    Telefono = pro.Telefono,
                                    Direccion = pro.Direccion,
                                    Email = pro.Email,
                                    Estado = pro.Estado,
                                    RutaLogo = pro.RutaLogo
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return proveedor;
            }
        }
        #endregion

        public List<ClassEntProveedor> MuestraProveedorInactivos()
        {
            try
            {
                var consulta = (from pro in context.CatProveedor
                                orderby pro.ID_Proveedor descending
                                where pro.Estado == false
                                select new ClassEntProveedor
                                {
                                    ID_Proveedor = pro.ID_Proveedor,
                                    Nombre_Proveedor = pro.Nombre_Proveedor,
                                    Telefono = pro.Telefono,
                                    Direccion = pro.Direccion,
                                    Email = pro.Email,
                                    Estado = pro.Estado,
                                    RutaLogo = pro.RutaLogo
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {

                return proveedor;
            }
        }

        #region Muestra Proveedor x ID
        public ClassEntProveedor MuestraProveedorxID(int id)
        {
            CatProveedor pro = context.CatProveedor.FirstOrDefault(x => x.ID_Proveedor == id);
            ClassEntProveedor prov = new ClassEntProveedor();
            if (pro!=null)
            {
                prov.ID_Proveedor = pro.ID_Proveedor;
                prov.Nombre_Proveedor = pro.Nombre_Proveedor;
                prov.Direccion = pro.Direccion;
                prov.Telefono = pro.Telefono;
                prov.Email = pro.Email;
                prov.Estado = pro.Estado;
                prov.RutaLogo = pro.RutaLogo;
            }
            return prov;
            //        try 
            //{
            //    var consulta = (from pro in context.tblProveedor
            //                    where pro.ID_Proveedor == id
            //                    select new ClassEntProveedor
            //                    {
            //                        ID_Proveedor = pro.ID_Proveedor,
            //                        Nombre_Proveedor = pro.Nombre_Proveedor,
            //                        Telefono = pro.Telefono,
            //                        Direccion = pro.Direccion
            //                    }).ToList();
            //    return consulta;
            //}
            //catch (Exception)
            //{
		
            //    return proveedor;
            //}
        }
        #endregion

        #region Muestra x ID Bod-Art
        public List<ClassEntProveedor> MostrarProvsorID(int ID)
        { 
            var consulta = (from pro in context.CatProveedor
                            where pro.ID_Proveedor == ID
                            select new ClassEntProveedor
                            {
                                ID_Proveedor=pro.ID_Proveedor,
                                Nombre_Proveedor=pro.Nombre_Proveedor
                            }).ToList();

            return consulta;
        }
        #endregion

        #region Muestra Proveedor x Nombre
        public List<ClassEntProveedor> MuestraProveedorxNombre(string nombre)
        {
            try
            {
                var consulta = (from pro in context.CatProveedor
                                where pro.Nombre_Proveedor.Contains(nombre) && pro.Estado == true
                                select new ClassEntProveedor
                                {
                                    ID_Proveedor = pro.ID_Proveedor,
                                    Nombre_Proveedor = pro.Nombre_Proveedor,
                                    Telefono = pro.Telefono,
                                    Direccion = pro.Direccion,
                                    Email=pro.Email,
                                    Estado=pro.Estado,
                                    RutaLogo=pro.RutaLogo
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return proveedor;
            }
        }
        #endregion

        public List<ClassEntProveedor> MuestraProveedorxNombreInactivos(string nombre)
        {
            try
            {
                var consulta = (from pro in context.CatProveedor
                                where pro.Nombre_Proveedor.Contains(nombre) && pro.Estado == false
                                select new ClassEntProveedor
                                {
                                    ID_Proveedor = pro.ID_Proveedor,
                                    Nombre_Proveedor = pro.Nombre_Proveedor,
                                    Telefono = pro.Telefono,
                                    Direccion = pro.Direccion,
                                    Email = pro.Email,
                                    Estado = pro.Estado,
                                    RutaLogo = pro.RutaLogo
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {

                return proveedor;
            }
        }

        #region Busca Duplicados
        public List<ClassEntProveedor> BuscaProveedorDuplicado(ClassEntProveedor ent)
        {
            var consulta = (from pro in context.CatProveedor
                            where (pro.Nombre_Proveedor.Equals(ent.Nombre_Proveedor))
                            select new ClassEntProveedor
                            {
                                ID_Proveedor = pro.ID_Proveedor,
                                Nombre_Proveedor = pro.Nombre_Proveedor,
                                Telefono = pro.Telefono,
                                Direccion = pro.Direccion,
                                Email = pro.Email,
                                Estado = pro.Estado,
                                RutaLogo = pro.RutaLogo

                            }).ToList();
            return consulta;
        }
        #endregion


    }
}
