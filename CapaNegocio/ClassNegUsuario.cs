using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class ClassNegUsuario
    {
        #region Guarda Usuario
        public bool GuardaUsuario(ClassEntUsuario user)
        {
            var datos = new ClassDatUsuario();
            return datos.GuardaUsuario(user);
        }
        #endregion
        #region Actualiza Usuario
        public bool ActualizaUsuario(ClassEntUsuario user) 
        {
            var datos = new ClassDatUsuario();
            return datos.ActualizaUsuario(user);
        }
        #endregion
        #region Elimina Usuario
        public bool EliminaUsuario(int id)
        {
            var datos = new ClassDatUsuario();
            return datos.EliminaUsuario(id);
        }
        #endregion
        #region Muestra Usuario
        public List<ClassEntUsuario> MuestraUsuario()
        {
            var datos = new ClassDatUsuario();
            return datos.MuestraUsuario();
        }
        #endregion
        //Método que busca un usuario logueado en la base de datos
        #region Buscar Usuario
        public ClassEntUsuario BuscaUsuario(string user)
        {
            var use = new ClassDatUsuario();
            return use.BuscarUsuario(user);
        }
        #endregion

        #region Buscar Usuarios x Nombre
        public List<ClassEntUsuario> BuscaUsuarioxNombre(string name)
        {
            var datos = new ClassDatUsuario();
            return datos.BuscaUsuarioxNombre(name);
        }
        #endregion

        #region Busca Usuario x ID
        public ClassEntUsuario BuscaxID(int id)
        {
            var datos = new ClassDatUsuario();
            return datos.BuscaxID(id);
        }
        #endregion

        #region Usuario Duplicados
        public List<ClassEntUsuario> Buscarusuariosduplicados(ClassEntUsuario dup)
        {
            var datos = new ClassDatUsuario();
            return datos.Buscarusuariosduplicados(dup);
        }
        #endregion
    }
}
