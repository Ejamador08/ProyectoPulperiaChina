using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassEmpresa
    {
        public bool GuardaEmpresa(ClassEntEmpresa emp)
        {
            if (emp.Nombre_Empresa == "" || emp.Propietario== "" || emp.Admonistrador == "" || emp.Municipio == "" || emp.Departamento == "")
            {
                return false;
            }
            var dat = new ClassDatEmpresa();
            return dat.GuardaEmpresa(emp);
        }

        public bool ActualizaEmpresa(ClassEntEmpresa emp)
        {
            var dat = new ClassDatEmpresa();
            return dat.ActualizaEmpresa(emp);
        }

        public List<ClassEntEmpresa> MuestraEmpresa()
        {
            var dat = new ClassDatEmpresa();
            return dat.MuestraEmpresa();
        }

        public List<ClassEntEmpresa> MuestraEmpresaCambio()
        {
            var dat = new ClassDatEmpresa();
            return dat.MuestraEmpresaCambio();
        }
    }
}
