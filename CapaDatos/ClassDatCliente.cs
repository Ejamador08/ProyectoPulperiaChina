using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatCliente
    {
        //variable tipo "context" global
        //Pulperia_ChinaEntities context = new Pulperia_ChinaEntities();
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        //variable "articulo" tipo global
        List<ClassEntCliente> cliente = new List<ClassEntCliente>();

        #region Guarda Cliente
        public bool GuardaCliente(ClassEntCliente nuevo)
        {
                CatCliente cli = new CatCliente();

                cli.ID_Cliente = nuevo.ID_Cliente;
                cli.Nombre_Cliente = nuevo.Nombre_Cliente;
                cli.Apellido1_Cliente = nuevo.Apellido1_Cliente;
                cli.Direccion = nuevo.Direccion;
                cli.N__de_Cedula = nuevo.N__de_Cedula;
                cli.Telefono_Celular = nuevo.Telefono_Celular;
                cli.Estado = nuevo.Estado;
                cli.ID_Municipio = nuevo.ID_Municipio;
                cli.UserName = nuevo.UserName;
                cli.Email = nuevo.Email;

                context.CatCliente.Add(cli);
                context.SaveChanges();
                return true;
        }
        #endregion

        #region Actualiza Cliente
        public bool ActualizarCliente(ClassEntCliente nuevo)
        {
            try
            {
                CatCliente cli = context.CatCliente.FirstOrDefault(x => x.ID_Cliente == nuevo.ID_Cliente );

                cli.ID_Cliente = nuevo.ID_Cliente;
                cli.Nombre_Cliente = nuevo.Nombre_Cliente;
                cli.Apellido1_Cliente = nuevo.Apellido1_Cliente;
                cli.Direccion = nuevo.Direccion;
                cli.N__de_Cedula = nuevo.N__de_Cedula;
                cli.Telefono_Celular = nuevo.Telefono_Celular;
                cli.Estado = nuevo.Estado;
                cli.ID_Municipio = nuevo.ID_Municipio;
                cli.Email = nuevo.Email;
                cli.UserName = nuevo.UserName;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        #endregion

        #region Elimina Cliente
        public bool EliminaCliente(int id)
        {
            try
            {
                CatCliente cli = context.CatCliente.FirstOrDefault(x => x.ID_Cliente == id);
                context.CatCliente.Remove(cli);
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                
                return true;
            }
        }
        #endregion

        public bool Restaurar(int id)
        {
            try
            {
                CatCliente cli = context.CatCliente.FirstOrDefault(x => x.ID_Cliente == id);
                cli.Estado = true;
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool DardeBaja(int id)
        {
            try
            {
                CatCliente cli = context.CatCliente.FirstOrDefault(x => x.ID_Cliente == id);
                cli.Estado = false;
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return true;
            }
        }

        #region Muestra Cliente
        public List<ClassEntCliente> MuestraCliente()
        {
            try
            {
                var consulta = (from cli in context.CatCliente
                                join m in context.CatMunicipio on cli.ID_Municipio equals m.ID_Municipio
                                orderby cli.ID_Cliente descending
                                where cli.Estado==true
                                select new ClassEntCliente
                                {
                                    ID_Cliente = cli.ID_Cliente,
                                    Nombre_Cliente = cli.Nombre_Cliente,
                                    Apellido1_Cliente = cli.Apellido1_Cliente,
                                    Direccion = cli.Direccion,
                                    N__de_Cedula = cli.N__de_Cedula,
                                    Telefono_Celular = cli.Telefono_Celular,
                                    Estado = cli.Estado,
                                    ID_Municipio = cli.ID_Municipio,
                                    Email=cli.Email,
                                    UserName = cli.UserName,

                                    //campo agregado
                                    NombreMunicipio=m.Nombre_Municipio
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return cliente;
            }
        }
        #endregion

        public List<ClassEntCliente> MuestraClienteInactivos()
        {
            try
            {
                var consulta = (from cli in context.CatCliente
                                join m in context.CatMunicipio on cli.ID_Municipio equals m.ID_Municipio
                                orderby cli.ID_Cliente descending
                                where cli.Estado==false
                                select new ClassEntCliente
                                {
                                    ID_Cliente = cli.ID_Cliente,
                                    Nombre_Cliente = cli.Nombre_Cliente,
                                    Apellido1_Cliente = cli.Apellido1_Cliente,
                                    Direccion = cli.Direccion,
                                    N__de_Cedula = cli.N__de_Cedula,
                                    Telefono_Celular = cli.Telefono_Celular,
                                    Estado = cli.Estado,
                                    ID_Municipio = cli.ID_Municipio,
                                    Email = cli.Email,
                                    UserName = cli.UserName,

                                    //campo agregado
                                    NombreMunicipio = m.Nombre_Municipio
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {

                return cliente;
            }
        }

        #region Muestra Cliente x "ID_Cliente"
        public ClassEntCliente MuestraClientexID(int id)
        {
            CatCliente cli = context.CatCliente.FirstOrDefault(x => x.ID_Cliente == id);
            ClassEntCliente client = new ClassEntCliente();
            if (cli!=null)
            {
                client.ID_Cliente = cli.ID_Cliente;
                client.Nombre_Cliente = cli.Nombre_Cliente;
                client.Apellido1_Cliente = cli.Apellido1_Cliente;
                client.Direccion = cli.Direccion;
                client.N__de_Cedula = cli.N__de_Cedula;
                client.Telefono_Celular = cli.Telefono_Celular;
                client.Estado = cli.Estado;
                client.ID_Municipio = cli.ID_Municipio;
                client.Email = cli.Email;
                client.UserName = cli.UserName;
            }
            return client;

            //try
            //{
            //    var consulta = (from cli in context.tblCliente
            //                    where cli.ID_Cliente == id
            //                    select new ClassEntCliente
            //                    {
            //                        ID_Cliente = cli.ID_Cliente,
            //                        Nombre_Cliente = cli.Nombre_Cliente,
            //                        Apellido1_Cliente = cli.Apellido1_Cliente,
            //                        Direccion = cli.Direccion,
            //                        N__de_Cedula = cli.N__de_Cedula,
            //                        Telefono_Celular = cli.Telefono_Celular,
            //                        Estado = cli.Estado,
            //                        ID_Municipio = cli.ID_Municipio,
            //                        Lìmite = cli.Lìmite,
            //                        UserName = cli.UserName,

            //                        //campo agregado
            //                        NombreCompleto = cli.Nombre_Cliente + " " + cli.Apellido1_Cliente
            //                    }).ToList();
            //    return consulta;
            //}
            //catch (Exception)
            //{

            //    return cliente;
            //}
        }
        #endregion

        #region Muestra Cliente x "Nombre_Cliente"
        public List<ClassEntCliente> MuestraClientxNombre(string nombre)
        {
            try
            {
                var consulta = (from cli in context.CatCliente
                                where cli.Nombre_Cliente.Contains(nombre) && cli.Estado==true
                                select new ClassEntCliente
                                {
                                    ID_Cliente = cli.ID_Cliente,
                                    Nombre_Cliente = cli.Nombre_Cliente,
                                    Apellido1_Cliente = cli.Apellido1_Cliente,
                                    Direccion = cli.Direccion,
                                    N__de_Cedula = cli.N__de_Cedula,
                                    Telefono_Celular = cli.Telefono_Celular,
                                    Estado = cli.Estado,
                                    ID_Municipio = cli.ID_Municipio,
                                    Email=cli.Email,
                                    UserName = cli.UserName
                                }).ToList();
                return consulta;

            }
            catch (Exception)
            {
                
                return cliente;
            }
        }
        #endregion

        public List<ClassEntCliente> MuestraClientxNombreInactivos(string nombre)
        {
            try
            {
                var consulta = (from cli in context.CatCliente
                                where cli.Nombre_Cliente.Contains(nombre) && cli.Estado == false
                                select new ClassEntCliente
                                {
                                    ID_Cliente = cli.ID_Cliente,
                                    Nombre_Cliente = cli.Nombre_Cliente,
                                    Apellido1_Cliente = cli.Apellido1_Cliente,
                                    Direccion = cli.Direccion,
                                    N__de_Cedula = cli.N__de_Cedula,
                                    Telefono_Celular = cli.Telefono_Celular,
                                    Estado = cli.Estado,
                                    ID_Municipio = cli.ID_Municipio,
                                    Email = cli.Email,
                                    UserName = cli.UserName
                                }).ToList();
                return consulta;

            }
            catch (Exception)
            {

                return cliente;
            }
        }

        #region Busca Duplicados
        public List<ClassEntCliente> BuscaClientesDuplicados(ClassEntCliente ent)
        {
            var consulta = (from cli in context.CatCliente
                            where (cli.Nombre_Cliente.Equals(ent.Nombre_Cliente) &&
                                  (cli.Apellido1_Cliente.Equals(ent.Apellido1_Cliente) &&  
                                  (cli.UserName.Equals(ent.UserName))))
                            select new ClassEntCliente
                            {
                                ID_Cliente = cli.ID_Cliente,
                                Nombre_Cliente = cli.Nombre_Cliente,
                                Apellido1_Cliente = cli.Apellido1_Cliente,
                                Direccion = cli.Direccion,
                                N__de_Cedula = cli.N__de_Cedula,
                                Telefono_Celular = cli.Telefono_Celular,
                                Estado = cli.Estado,
                                ID_Municipio = cli.ID_Municipio,
                                Email = cli.Email,
                                UserName = cli.UserName
                            }).ToList();
            return consulta;
        }
        #endregion

        #region Muestra Cliente x "ID_Municipio"
        public List<ClassEntCliente> MuestraClientexMunicipio(int id)
        {
            try
            {
                var consulta = (from cli in context.CatCliente
                                where cli.ID_Municipio == id
                                select new ClassEntCliente
                                {
                                    ID_Cliente = cli.ID_Cliente,
                                    Nombre_Cliente = cli.Nombre_Cliente,
                                    Apellido1_Cliente = cli.Apellido1_Cliente,
                                    Direccion = cli.Direccion,
                                    N__de_Cedula = cli.N__de_Cedula,
                                    Telefono_Celular = cli.Telefono_Celular,
                                    Estado = cli.Estado,
                                    ID_Municipio = cli.ID_Municipio,
                                    Email=cli.Email,
                                    UserName = cli.UserName
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return cliente;
            }
        }
        #endregion

        #region Muestra Cliente x "Estado"
        public List<ClassEntCliente> MuestraClientexEstado()
        {
            try
            {
                var consulta = (from cli in context.CatCliente
                                where cli.Estado.Equals("true")
                                select new ClassEntCliente
                                {
                                    ID_Cliente = cli.ID_Cliente,
                                    Nombre_Cliente = cli.Nombre_Cliente,
                                    Apellido1_Cliente = cli.Apellido1_Cliente,
                                    Direccion = cli.Direccion,
                                    N__de_Cedula = cli.N__de_Cedula,
                                    Telefono_Celular = cli.Telefono_Celular,
                                    Estado = cli.Estado,
                                    ID_Municipio = cli.ID_Municipio,
                                    Email=cli.Email,
                                    UserName = cli.UserName
                                }).ToList();
                return consulta;

            }
            catch (Exception)
            {
                
                return cliente;
            }
        }
        #endregion

    }
}
