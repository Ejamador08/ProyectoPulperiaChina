using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegCliente
    {
        #region Guarda Cliente
        public bool GuardaCliente(ClassEntCliente nuevo)
        {
            if (nuevo.Nombre_Cliente=="")
            {
                return false;
            }
            ClassDatCliente cli = new ClassDatCliente();
            return cli.GuardaCliente(nuevo);
        }
        #endregion

        #region Actualiza Cliente
        public bool ActualizaCliente(ClassEntCliente nuevo)
        {
            if (nuevo.Nombre_Cliente=="")
            {
                return false;
            }
            ClassDatCliente cli = new ClassDatCliente();
            return cli.ActualizarCliente(nuevo);
        }
        #endregion

        #region Elimina Cliente
        public bool EliminaCliente(int id)
        {
            ClassDatCliente cli = new ClassDatCliente();
            return cli.EliminaCliente(id);
        }
        #endregion

        //hacerlo en los otros catalogos
        public bool Restaurar(int id)
        {
            var dat = new ClassDatCliente();
            return dat.Restaurar(id);
        }

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatCliente();
            return dat.DardeBaja(id);
        }

        #region Muestra Cliente
        public List<ClassEntCliente> MuestraCliente()
        {
            ClassDatCliente cli = new ClassDatCliente();
            return cli.MuestraCliente();
        }
        #endregion

        public List<ClassEntCliente> MuestraClienteInactivos()
        {
            var dat = new ClassDatCliente();
            return dat.MuestraClienteInactivos();
        }

        #region Muestra Cliente x "ID_Cliente"
        public ClassEntCliente MuestraClientexID(int id)
        {
            ClassDatCliente cli = new ClassDatCliente();
            return cli.MuestraClientexID(id);
        }
        #endregion

        #region Muestra Cliente x "Nombre_Cliente" cuyo estado es TRUE
        public List<ClassEntCliente> MuestraClientexNombre(string nombre)
        {
            ClassDatCliente cli=new ClassDatCliente();
            return cli.MuestraClientxNombre(nombre);
        }
        #endregion

        public List<ClassEntCliente> MuestraClientxNombreInactivos(string nombre)
        {
            var dat = new ClassDatCliente();
            return dat.MuestraClientxNombreInactivos(nombre);
        }

        #region Busca Duplicados
        public List<ClassEntCliente> BuscaClientesDuplicados(ClassEntCliente ent)
        {
            var datos = new ClassDatCliente();
            return datos.BuscaClientesDuplicados(ent);
        }
        #endregion

        #region Muestra Cliente x "ID_Municipio"
        public List<ClassEntCliente> MuestraClientexMunicipio(int id)
        {
            ClassDatCliente cli = new ClassDatCliente();
            return cli.MuestraClientexMunicipio(id);
        }
        #endregion

        #region Muestra Cliente x "Estado"
        public List<ClassEntCliente> MuestraClientexEstado()
        {
            ClassDatCliente cli = new ClassDatCliente();
            return cli.MuestraClientexEstado();
        }
        #endregion
    }

}
