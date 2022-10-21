using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatEmpresa
    {
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        public bool GuardaEmpresa(ClassEntEmpresa emp)
        {
            Empresa dat = new Empresa();

            dat.ID_Informacion = emp.ID_Informacion;
            dat.Nombre_Empresa = emp.Nombre_Empresa;
            dat.Propietario = emp.Propietario;
            dat.Admonistrador = emp.Admonistrador; 
            dat.Ubicacion = emp.Ubicacion;
            dat.Descripcion = emp.Descripcion;
            dat.Municipio = emp.Municipio;
            dat.Departamento = emp.Departamento;
            dat.Telefono = emp.Telefono;
            dat.Email = emp.Email;
            dat.Logo = emp.Logo;
            dat.CambioDolar = emp.CambioDolar;

            context.Empresa.Add(dat);
            context.SaveChanges();
            return true;
        }

        public bool ActualizaEmpresa(ClassEntEmpresa emp)
        {
            Empresa dat = context.Empresa.FirstOrDefault(x => x.ID_Informacion == emp.ID_Informacion);

            dat.ID_Informacion = emp.ID_Informacion;
            dat.Nombre_Empresa = emp.Nombre_Empresa;
            dat.Propietario = emp.Propietario;
            dat.Admonistrador = emp.Admonistrador;
            dat.Ubicacion = emp.Ubicacion;
            dat.Descripcion = emp.Descripcion;
            dat.Municipio = emp.Municipio;
            dat.Departamento = emp.Departamento;
            dat.Telefono = emp.Telefono;
            dat.Email = emp.Email;
            dat.Logo = emp.Logo;
            dat.CambioDolar = emp.CambioDolar;

            context.SaveChanges();
            return true;
        }

        public List<ClassEntEmpresa> MuestraEmpresa()
        {
            var consulta = (from dat in context.Empresa
                            select new ClassEntEmpresa
                            {
                                ID_Informacion=dat.ID_Informacion,
                                Nombre_Empresa=dat.Nombre_Empresa,
                                Propietario=dat.Propietario,
                                Admonistrador=dat.Admonistrador,
                                Ubicacion=dat.Ubicacion,
                                Descripcion=dat.Descripcion,
                                Municipio=dat.Municipio,
                                Departamento=dat.Departamento,
                                Telefono=dat.Telefono,
                                Email=dat.Email,
                                Logo=dat.Logo,
                                CambioDolar=dat.CambioDolar
                            }).ToList();
            return consulta;
        }

        public List<ClassEntEmpresa> MuestraEmpresaCambio()
        {
            var consulta = (from dat in context.Empresa
                            select new ClassEntEmpresa
                            {
                                ID_Informacion = dat.ID_Informacion,
                                Nombre_Empresa = dat.Nombre_Empresa,
                                Propietario = dat.Propietario,
                                Admonistrador = dat.Admonistrador,
                                Ubicacion = dat.Ubicacion,
                                Descripcion = dat.Descripcion,
                                Municipio = dat.Municipio,
                                Departamento = dat.Departamento,
                                Telefono = dat.Telefono,
                                Email = dat.Email,
                                Logo = dat.Logo,
                                CambioDolar=dat.CambioDolar
                            }).ToList();
            return consulta;
        }
    }
}
