using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatMuncipio
    {
        //variable tipo "context" global
        //Pulperia_ChinaEntities context = new Pulperia_ChinaEntities();
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        //variable "articulo" tipo global
        List<ClassEntMunicipio> municipio = new List<ClassEntMunicipio>();

        #region Guarda Municipio
        public bool GuardaMunicipio(ClassEntMunicipio nuevo)
        {
            try
            {
                var mun = new CatMunicipio();

                mun.ID_Municipio = nuevo.ID_Municipio;
                mun.Nombre_Municipio = nuevo.Nombre_Municipio;
                mun.ID_Departamento = nuevo.ID_Departamento;
                mun.Estado = nuevo.Estado;

                context.CatMunicipio.Add(mun);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        #endregion

        #region Actualiza Municipio
        public bool ActualizaMuicipio(ClassEntMunicipio nuevo)
        {
            try
            {
                CatMunicipio mun = context.CatMunicipio.FirstOrDefault(x => x.ID_Municipio == nuevo.ID_Municipio);

                mun.ID_Municipio = nuevo.ID_Municipio;
                mun.Nombre_Municipio = nuevo.Nombre_Municipio;
                mun.ID_Departamento = nuevo.ID_Departamento;
                mun.Estado = nuevo.Estado;

                
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        #endregion

        #region Elimina Municipio
        public bool EliminaMunicipio(int id)
        {
            try
            {
                CatMunicipio mun = context.CatMunicipio.FirstOrDefault(x => x.ID_Municipio == id);

                context.CatMunicipio.Remove(mun);
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
                CatMunicipio mun = context.CatMunicipio.FirstOrDefault(x => x.ID_Municipio == id);
                mun.Estado = false;
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
                CatMunicipio mun = context.CatMunicipio.FirstOrDefault(x => x.ID_Municipio == id);
                mun.Estado = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #region Muestra Mucipio
        public List<ClassEntMunicipio> MuestraMunicipio()
        {
            var consulta = (from mun in context.CatMunicipio
                            join d in context.CatDepartamento on mun.ID_Departamento equals d.ID_Departamento
                            orderby mun.ID_Municipio descending
                            where mun.Estado == true
                            select new ClassEntMunicipio
                            {
                                ID_Municipio = mun.ID_Municipio,
                                Nombre_Municipio = mun.Nombre_Municipio,
                                ID_Departamento = mun.ID_Departamento,
                                Estado = mun.Estado,

                                NombreDepartamento=d.Nombre_Depto
                            }).ToList();
            return consulta;

        }
        #endregion

        public List<ClassEntMunicipio> MuestraMunicipioInactivos()
        {
            var consulta = (from mun in context.CatMunicipio
                            join d in context.CatDepartamento on mun.ID_Departamento equals d.ID_Departamento
                            orderby mun.ID_Municipio descending
                            where mun.Estado == false
                            select new ClassEntMunicipio
                            {
                                ID_Municipio = mun.ID_Municipio,
                                Nombre_Municipio = mun.Nombre_Municipio,
                                ID_Departamento = mun.ID_Departamento,
                                Estado = mun.Estado,

                                NombreDepartamento = d.Nombre_Depto
                            }).ToList();
            return consulta;

        }

        #region Muestra Mucipio x ID
        public ClassEntMunicipio MostrarMunicipioxID(int id)
        {
            CatMunicipio mun = context.CatMunicipio.FirstOrDefault(x => x.ID_Municipio == id);
            ClassEntMunicipio munic = new ClassEntMunicipio();
            if (mun!=null)
            {
                munic.ID_Municipio = mun.ID_Municipio;
                munic.Nombre_Municipio = mun.Nombre_Municipio;
                munic.ID_Departamento = mun.ID_Departamento;
                munic.Estado = mun.Estado;
            }
            return munic;
        }
        #endregion

        #region Muestra Mucipio x Nombre
        public List<ClassEntMunicipio> MostrarMunicipioxNombre(string nombre)
        {
            try
            {
                var consulta = (from mun in context.CatMunicipio
                                where mun.Nombre_Municipio.Contains(nombre) && mun.Estado == true
                                select new ClassEntMunicipio
                                {
                                    ID_Municipio = mun.ID_Municipio,
                                    Nombre_Municipio = mun.Nombre_Municipio,
                                    ID_Departamento = mun.ID_Departamento,
                                    Estado = mun.Estado
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {
                
                return municipio;
            }
        }
        #endregion

        public List<ClassEntMunicipio> MostrarMunicipioxNombreInactivos(string nombre)
        {
            try
            {
                var consulta = (from mun in context.CatMunicipio
                                where mun.Nombre_Municipio.Contains(nombre) && mun.Estado == false
                                select new ClassEntMunicipio
                                {
                                    ID_Municipio = mun.ID_Municipio,
                                    Nombre_Municipio = mun.Nombre_Municipio,
                                    ID_Departamento = mun.ID_Departamento,
                                    Estado = mun.Estado
                                }).ToList();
                return consulta;
            }
            catch (Exception)
            {

                return municipio;
            }
        }

        #region Busca Duplicados
        public List<ClassEntMunicipio> BuscaMunicipioDuplicado(ClassEntMunicipio ent)
        {
            var consulta = (from m in context.CatMunicipio
                            where (m.Nombre_Municipio.Equals(ent.Nombre_Municipio))
                            select new ClassEntMunicipio
                            {
                                ID_Municipio = m.ID_Municipio,
                                Nombre_Municipio = m.Nombre_Municipio,
                                ID_Departamento = m.ID_Departamento,
                                Estado = m.Estado
                            }).ToList();
            return consulta;
        }
        #endregion
    }
}
