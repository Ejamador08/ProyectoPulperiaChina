using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatUsuario
    {
        //variable de tipo globsl
        //Pulperia_ChinaEntities context = new Pulperia_ChinaEntities();
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();


        #region Guarda Usuario
        public bool GuardaUsuario(ClassEntUsuario user)
        {
            var usu = new CatUsuario();

            usu.ID_Usuario = user.ID_Usuario;
            usu.Nombre_User = user.Nombre_User;
            usu.Apellido1_User = user.Apellido1_User;
            usu.Apellido2_User = user.Apellido2_User;
            usu.UserName = user.UserName;
            usu.Tipo_Usuario = user.Tipo_Usuario;
            usu.ImgUser = user.ImgUser;

            context.CatUsuario.Add(usu);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Actualiza Usuario
        public bool ActualizaUsuario(ClassEntUsuario user)
        {
            CatUsuario usu = context.CatUsuario.FirstOrDefault(x => x.ID_Usuario == user.ID_Usuario);

            usu.ID_Usuario = user.ID_Usuario;
            usu.Nombre_User = user.Nombre_User;
            usu.Apellido1_User = user.Apellido1_User;
            usu.Apellido2_User = user.Apellido2_User;
            usu.UserName = user.UserName;
            usu.Tipo_Usuario = user.Tipo_Usuario;
            usu.ImgUser = user.ImgUser;

            context.CatUsuario.Add(usu);
            context.SaveChanges();
            return true;
        }

        #endregion

        #region Elimina Usuario
        public bool EliminaUsuario(int id)
        {
            CatUsuario usu = context.CatUsuario.FirstOrDefault(x => x.ID_Usuario == id);
            context.CatUsuario.Remove(usu);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Muestra Usuario
        public List<ClassEntUsuario> MuestraUsuario()
        {
            var consulta = (from u in context.CatUsuario
                            select new ClassEntUsuario
                            {
                                ID_Usuario = u.ID_Usuario,
                                Nombre_User = u.Nombre_User,
                                Apellido1_User = u.Apellido1_User,
                                Apellido2_User = u.Apellido2_User,
                                UserName=u.UserName,
                                Tipo_Usuario = u.Tipo_Usuario,
                                ImgUser=u.ImgUser
                            }).ToList();
            return consulta;
        }
        #endregion
        //Método que busca un usuario logueado en la base de datos del profesor
        #region Buscar Usuario
        public ClassEntUsuario BuscarUsuario(string nameuser)
        {
            CatUsuario x = context.CatUsuario.FirstOrDefault(y => y.Nombre_User == nameuser);

            var use = new ClassEntUsuario();

            use.ID_Usuario = x.ID_Usuario;
            use.Nombre_User = x.Nombre_User;
            use.Apellido1_User = x.Apellido1_User;
            use.Apellido2_User = x.Apellido2_User;
            use.UserName = x.UserName;
            use.Tipo_Usuario = x.Tipo_Usuario;
            use.ImgUser = x.ImgUser;


            return use;
        }
        #endregion

        #region Buscar Usuarios x Nombre
        public List<ClassEntUsuario> BuscaUsuarioxNombre(string name)
        {
            var consulta = (from u in context.CatUsuario
                            where u.Nombre_User.Contains(name)
                            select new ClassEntUsuario
                            {
                                ID_Usuario = u.ID_Usuario,
                                Nombre_User = u.Nombre_User,
                                Apellido1_User = u.Apellido1_User,
                                Apellido2_User = u.Apellido2_User,
                                UserName = u.UserName,
                                Tipo_Usuario = u.Tipo_Usuario,
                                ImgUser=u.ImgUser
                            }).ToList();
            return consulta;
        }
        #endregion

        #region Busca Usuario x ID
        public ClassEntUsuario BuscaxID(int id)
        {
            CatUsuario user = context.CatUsuario.FirstOrDefault(x => x.ID_Usuario == id);
            ClassEntUsuario ent = new ClassEntUsuario();
            if (user!=null)
            {
                ent.ID_Usuario = user.ID_Usuario;
                ent.Nombre_User = user.Nombre_User;
                ent.Apellido1_User = user.Apellido1_User;
                ent.Apellido2_User = user.Apellido2_User;
                ent.UserName = user.UserName;
                ent.Tipo_Usuario = user.Tipo_Usuario;
                ent.ImgUser = user.ImgUser;
            }
            return ent;
        }
        #endregion

        #region Usuario Duplicados
        public List<ClassEntUsuario> Buscarusuariosduplicados(ClassEntUsuario dup)
        {
            var consulta = (from u in context.CatUsuario
                            where (u.Nombre_User.Equals(dup.Nombre_User) && (u.Tipo_Usuario.Equals(dup.Tipo_Usuario)))
                            select new ClassEntUsuario
                            {
                                ID_Usuario = u.ID_Usuario,
                                Nombre_User = u.Nombre_User,
                                Apellido1_User = u.Apellido1_User,
                                Apellido2_User = u.Apellido2_User,
                                UserName = u.UserName,
                                Tipo_Usuario = u.Tipo_Usuario,
                                ImgUser=u.ImgUser
                            }).ToList();
            return consulta;
        }
        #endregion
    }
}
