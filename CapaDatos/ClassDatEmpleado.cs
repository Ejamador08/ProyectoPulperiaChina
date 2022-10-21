using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatEmpleado
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        #region Guarda Empleado
        public bool GuardaEmpleado(ClassEntEmpleado nuevo)
        {
            var emp = new CatEmpleado();

            emp.IDEmpleado = nuevo.IDEmpleado;
            emp.Nombre = nuevo.Nombre;
            emp.Apellido1 = nuevo.Apellido1;
            emp.Apellido2 = nuevo.Apellido2;
            emp.Direccion = nuevo.Direccion;
            emp.Telefono = nuevo.Telefono;
            emp.E_Mail = nuevo.E_Mail;
            emp.UserName = nuevo.UserName;
            emp.Estado = nuevo.Estado;
            emp.ImgEmpleado = nuevo.ImgEmpleado;

            context.CatEmpleado.Add(emp);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Actualiza Empleado
        public bool ActualizaEmpleado(ClassEntEmpleado nuevo)
        {
            var emp = context.CatEmpleado.FirstOrDefault(x => x.IDEmpleado == nuevo.IDEmpleado);

            emp.IDEmpleado = nuevo.IDEmpleado;
            emp.Nombre = nuevo.Nombre;
            emp.Apellido1 = nuevo.Apellido1;
            emp.Apellido2 = nuevo.Apellido2;
            emp.Direccion = nuevo.Direccion;
            emp.Telefono = nuevo.Telefono;
            emp.E_Mail = nuevo.E_Mail;
            emp.UserName = nuevo.UserName;
            emp.Estado = nuevo.Estado;
            emp.ImgEmpleado = nuevo.ImgEmpleado;

            context.SaveChanges();
            return true;
        }
        #endregion

        #region Elimina Empleado
        public bool EiminaEmpleado(int id)
        {
            var emp = context.CatEmpleado.FirstOrDefault(x => x.IDEmpleado == id);
            context.CatEmpleado.Remove(emp);
            context.SaveChanges();
            return true;
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var emp = context.CatEmpleado.FirstOrDefault(x => x.IDEmpleado == id);
            emp.Estado = false;
            context.SaveChanges();
            return true;
        }

        public bool Restaurar(int id)
        {
            var emp = context.CatEmpleado.FirstOrDefault(x => x.IDEmpleado == id);
            emp.Estado = true;
            context.SaveChanges();
            return true;
        }

        #region Muestra Empleado
        public List<ClassEntEmpleado> MuestraEmpleado()
        {
            var consulta = (from e in context.CatEmpleado
                            orderby e.IDEmpleado descending
                            where e.Estado==true
                            select new ClassEntEmpleado
                            {
                                IDEmpleado = e.IDEmpleado,
                                Nombre = e.Nombre,
                                Apellido1 = e.Apellido1,
                                Apellido2 = e.Apellido2,
                                Direccion = e.Direccion,
                                Telefono = e.Telefono,
                                E_Mail = e.E_Mail,
                                UserName = e.UserName,
                                Estado = e.Estado,
                                ImgEmpleado = e.ImgEmpleado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntEmpleado> MuestraEmpleadoInactivos()
        {
            var consulta = (from e in context.CatEmpleado
                            orderby e.IDEmpleado descending
                            where e.Estado == false
                            select new ClassEntEmpleado
                            {
                                IDEmpleado = e.IDEmpleado,
                                Nombre = e.Nombre,
                                Apellido1 = e.Apellido1,
                                Apellido2 = e.Apellido2,
                                Direccion = e.Direccion,
                                Telefono = e.Telefono,
                                E_Mail = e.E_Mail,
                                UserName = e.UserName,
                                Estado = e.Estado,
                                ImgEmpleado = e.ImgEmpleado
                            }).ToList();
            return consulta;
        }

        #region Muestra Empleado x ID
        public ClassEntEmpleado MuestraEmpleadoxID(int id)
        {
            var emp = context.CatEmpleado.FirstOrDefault(x => x.IDEmpleado == id);
            var emplea = new ClassEntEmpleado();
            if (emp!=null)
            {
                emplea.IDEmpleado = emp.IDEmpleado;
                emplea.Nombre = emp.Nombre;
                emplea.Apellido1 = emp.Apellido1;
                emplea.Apellido2 = emp.Apellido2;
                emplea.Direccion = emp.Direccion;
                emplea.Telefono = emp.Telefono;
                emplea.E_Mail = emp.E_Mail;
                emplea.UserName = emp.UserName;
                emplea.Estado = emp.Estado;
                emplea.ImgEmpleado = emp.ImgEmpleado;
            }
            return emplea;
        }
        #endregion

        #region Muestra Empleado x Nombre
        public List<ClassEntEmpleado> MuestaEmpleadoxNombre(string name)
        {
            var consulta = (from e in context.CatEmpleado
                            where e.Nombre.Contains(name) && e.Estado == true
                            select new ClassEntEmpleado
                            {
                                IDEmpleado = e.IDEmpleado,
                                Nombre = e.Nombre,
                                Apellido1 = e.Apellido1,
                                Apellido2 = e.Apellido2,
                                Direccion = e.Direccion,
                                Telefono = e.Telefono,
                                E_Mail = e.E_Mail,
                                UserName = e.UserName,
                                Estado = e.Estado,
                                ImgEmpleado = e.ImgEmpleado
                            }).ToList();
            return consulta;
        }
        #endregion

        public List<ClassEntEmpleado> MuestaEmpleadoxNombreInactivos(string name)
        {
            var consulta = (from e in context.CatEmpleado
                            where e.Nombre.Contains(name) && e.Estado == false
                            select new ClassEntEmpleado
                            {
                                IDEmpleado = e.IDEmpleado,
                                Nombre = e.Nombre,
                                Apellido1 = e.Apellido1,
                                Apellido2 = e.Apellido2,
                                Direccion = e.Direccion,
                                Telefono = e.Telefono,
                                E_Mail = e.E_Mail,
                                UserName = e.UserName,
                                Estado = e.Estado,
                                ImgEmpleado = e.ImgEmpleado
                            }).ToList();
            return consulta;
        }

        #region Busca Duplicados
        public List<ClassEntEmpleado> BuscaEmpleadoDuplicado(ClassEntEmpleado ent)
        {
            var consulta = (from e in context.CatEmpleado
                            where (e.Nombre.Equals(ent.Nombre))
                            select new ClassEntEmpleado
                            {
                                IDEmpleado = e.IDEmpleado,
                                Nombre = e.Nombre,
                                Apellido1 = e.Apellido1,
                                Apellido2 = e.Apellido2,
                                Direccion = e.Direccion,
                                Telefono = e.Telefono,
                                E_Mail = e.E_Mail,
                                UserName = e.UserName,
                                Estado = e.Estado,
                                ImgEmpleado = e.ImgEmpleado
                            }).ToList();
            return consulta;
        }
        #endregion
    }
}
