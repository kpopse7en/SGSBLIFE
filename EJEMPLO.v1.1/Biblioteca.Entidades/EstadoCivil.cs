using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
namespace Biblioteca.Entidades
{
    public class EstadoCivil
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;
        public EstadoCivil()
        {
            Entidades = new BeLifeEntities();
        }
        public List<EstadoCivil> ListarEstadoCivil()
        {
            try
            {
                //coleccion del tipo clase 
                List<EstadoCivil> ListadoEstCiv = new List<EstadoCivil>();

                var EstCivModelo = Entidades.EstadoCivil.ToList();

                foreach (DALC.EstadoCivil item in EstCivModelo)
                {
                    EstadoCivil EstCiv = new EstadoCivil();


                    EstCiv.Id = item.IdEstadoCivil;
                    EstCiv.Descripcion = item.Descripcion;

                    //listado clientes
                    ListadoEstCiv.Add(EstCiv);
                }
                return ListadoEstCiv;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }


        }
    }
}
