using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegMunicipio
    {
        #region Guarda Municipio
        public bool GuardaMunicipio(ClassEntMunicipio nuevo)
        {
            if (nuevo.Nombre_Municipio=="")
            {
                return false;
            }
            var mun=new ClassDatMuncipio();
            return mun.GuardaMunicipio(nuevo);
        }
        #endregion

        #region Actualiza Municipio
        public bool ActualizaMunicipio(ClassEntMunicipio nuevo)
        {
            if (nuevo.Nombre_Municipio=="")
            {
                return false;
            }
            var mun = new ClassDatMuncipio();
            return mun.ActualizaMuicipio(nuevo);
        }
        #endregion

        #region Elimina Municipio
        public bool EliminaMunicipio(int id)
        {
            var mun = new ClassDatMuncipio();
            return mun.EliminaMunicipio(id);
        }
        #endregion

        public bool DardeBaja(int id)
        {
            var dat = new ClassDatMuncipio();
            return dat.DardeBaja(id);
        }

        public bool Restaurar(int id)
        {
            var dat = new ClassDatMuncipio();
            return dat.Restaurar(id);
        }

        #region Muestra Municipio
        public List<ClassEntMunicipio> MostrarMunicipio()
        {
            ClassDatMuncipio mun = new ClassDatMuncipio();
            return mun.MuestraMunicipio();
        }
        #endregion

        public List<ClassEntMunicipio> MuestraMunicipioInactivos()
        {
            var dat = new ClassDatMuncipio();
            return dat.MuestraMunicipioInactivos();
        }

        #region Muestra Muncicpio x ID
        public ClassEntMunicipio MostrarMunicipioxID(int id)
        {
            var mun = new ClassDatMuncipio();
            return mun.MostrarMunicipioxID(id);
        }
        #endregion

        #region Muestra Municipio x Nombre
        public List<ClassEntMunicipio> MostrarMunicipioxNombre(string nombre)
        {
            var mun = new ClassDatMuncipio();
            return mun.MostrarMunicipioxNombre(nombre);
        }
        #endregion

        public List<ClassEntMunicipio> MostrarMunicipioxNombreInactivos(string nombre)
        {
            var dat = new ClassDatMuncipio();
            return dat.MostrarMunicipioxNombreInactivos(nombre);
        }

        #region Busca Duplicados
        public List<ClassEntMunicipio> BuscaMunicipioDuplicado(ClassEntMunicipio ent)
        {
            var datos = new ClassDatMuncipio();
            return datos.BuscaMunicipioDuplicado(ent);
        }
        #endregion
    }
}
