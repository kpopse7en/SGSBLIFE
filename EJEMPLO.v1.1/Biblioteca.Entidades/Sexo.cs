using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;//OCUPO LA BIBLIOTECA DE ACCESO A LA bd
namespace Biblioteca.Entidades
{
   public class Sexo
    {//
        public int IdSexo { get; set; }
        public String Descripcion { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;//inicaliza
        public Sexo()
        {
            Entidades = new Biblioteca.DALC.BeLifeEntities();//crea la conexion
        }
        //metodos
        
        public List<Sexo> ListarSexo()
        {
              try
            {
                //coleccion del tipo clase 
                List<Sexo> ListadoSexo = new List<Sexo>();
                
                var SexoModelo = Entidades.Sexo.ToList();
                
                foreach (DALC.Sexo item in SexoModelo)
                {
                    Sexo Sex = new Sexo();
                
                  
                    Sex.IdSexo = item.IdSexo;
                    Sex.Descripcion = item.Descripcion;
                  
                    //listado clientes
                   ListadoSexo.Add(Sex);
                }
                return ListadoSexo;
            }
            catch (Exception )
            {

                return null;
            }


        }



    }
}
