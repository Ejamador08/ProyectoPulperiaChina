using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaDatos
{
    public class ClassDatDepartamento
    {
        //Variable de tipo Global
        //Pulperia_ChinaEntities context=new Pulperia_ChinaEntities();
        Respaldo_PulperiaChinaEntities context = new Respaldo_PulperiaChinaEntities();

        List<ClassEntDepartamento> departamento=new List<ClassEntDepartamento>();

    #region Guarda Departamento
		 public bool GuardaDepto(ClassEntDepartamento nuevo)
         {
             try 
	            {	        
		            var dept=new CatDepartamento();

                    dept.ID_Departamento=nuevo.ID_Departamento;
                    dept.Nombre_Depto=nuevo.Nombre_Depto;
                    dept.Estado = nuevo.Estado;

                    context.CatDepartamento.Add(dept);
                    context.SaveChanges();
                    return true;
	            }
	            catch (Exception)
	            {
		
		            return false;
	            }
             
         }
	#endregion

    #region Actualiza Departamento
		 public bool ActualizaDepto(ClassEntDepartamento nuevo)
         {
             try 
	            {	        
		            CatDepartamento dept=context.CatDepartamento.FirstOrDefault(x=>x.ID_Departamento==nuevo.ID_Departamento);

                    dept.ID_Departamento=nuevo.ID_Departamento;
                    dept.Nombre_Depto = nuevo.Nombre_Depto;
                    dept.Estado = nuevo.Estado;

                    context.SaveChanges();
                    return true;
	            }
	            catch (Exception)
	            {
		
		            return false;
	            }
         }
	#endregion
    
    #region Elimina Departamento
		 public bool EliminaDepto(int id)
         {
             try 
	            {	        
		            CatDepartamento depto=context.CatDepartamento.FirstOrDefault(x=>x.ID_Departamento==id);

                     context.CatDepartamento.Remove(depto);
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
                 CatDepartamento depto = context.CatDepartamento.FirstOrDefault(x => x.ID_Departamento == id);
                 depto.Estado = false;
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
                 CatDepartamento depto = context.CatDepartamento.FirstOrDefault(x => x.ID_Departamento == id);
                 depto.Estado = true;
                 context.SaveChanges();
                 return true;
             }
             catch (Exception)
             {

                 return false;
             }
         }

    #region Muestra Departamento
		public List<ClassEntDepartamento> MuestraDepto()
        {
            var consulta=(from depto in context.CatDepartamento
                          orderby depto.ID_Departamento descending
                          where depto.Estado==true
                          select new ClassEntDepartamento
                          {
                              ID_Departamento=depto.ID_Departamento,
                              Nombre_Depto=depto.Nombre_Depto,
                              Estado=depto.Estado
                          }).ToList();
            return consulta;
        }
	#endregion

        public List<ClassEntDepartamento> MuestraDeptoInactivos()
        {
            var consulta = (from depto in context.CatDepartamento
                            orderby depto.ID_Departamento descending
                            where depto.Estado == false
                            select new ClassEntDepartamento
                            {
                                ID_Departamento = depto.ID_Departamento,
                                Nombre_Depto = depto.Nombre_Depto,
                                Estado = depto.Estado
                            }).ToList();
            return consulta;
        }

    #region Muestra Departamento x ID
		public ClassEntDepartamento MuestraDeptoxID(int id)
        {
            CatDepartamento depto=context.CatDepartamento.FirstOrDefault(x=>x.ID_Departamento==id);
            var depart=new ClassEntDepartamento();
            if (depto!=null)
	        {
		        depart.ID_Departamento=depto.ID_Departamento;
                depart.Nombre_Depto=depto.Nombre_Depto;
                depart.Estado = depto.Estado;
	        }
            return depart;
        }
	#endregion

    #region Muestra Departamento x Nombre
		 public List<ClassEntDepartamento> MuestraDeptoxNombre(string nombre)
         {
             try 
	            {	        
		            var consulta=(from depto in context.CatDepartamento
                                       where depto.Nombre_Depto.Contains(nombre) && depto.Estado == true
                                       select new ClassEntDepartamento
                                       {
                                           ID_Departamento=depto.ID_Departamento,
                                           Nombre_Depto=depto.Nombre_Depto,
                                           Estado=depto.Estado
                                       }).ToList();
                         return consulta;
	            }
	            catch (Exception)
	            {
		
		            return departamento;
	            }
             
         }
	#endregion

         public List<ClassEntDepartamento> MuestraDeptoxNombreInactivos(string nombre)
         {
             try
             {
                 var consulta = (from depto in context.CatDepartamento
                                 where depto.Nombre_Depto.Contains(nombre) && depto.Estado == false
                                 select new ClassEntDepartamento
                                 {
                                     ID_Departamento = depto.ID_Departamento,
                                     Nombre_Depto = depto.Nombre_Depto,
                                     Estado = depto.Estado
                                 }).ToList();
                 return consulta;
             }
             catch (Exception)
             {

                 return departamento;
             }

         }

    #region Busca Duplicados
         public List<ClassEntDepartamento> BuscaDepartamentoDuplicado(ClassEntDepartamento ent)
         {
             var consulta = (from depto in context.CatDepartamento
                             where (depto.Nombre_Depto.Equals(ent.Nombre_Depto))
                             select new ClassEntDepartamento
                             {
                                 ID_Departamento = depto.ID_Departamento,
                                 Nombre_Depto = depto.Nombre_Depto,
                                 Estado = depto.Estado
                             }).ToList();
             return consulta;

         }
        #endregion
    }
}
