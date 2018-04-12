using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
namespace Biblioteca.Entidades
{
    public class Plan
    {
        public String Id { get; set; }
        public String Nombre { get; set; }
        public Double PrimaBase { get; set; }
        public String PolizaActual { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;//inicaliza
        public Plan()
        {
            Entidades = new Biblioteca.DALC.BeLifeEntities();
        }

        //public List<EstadoCivil> ListarEstadoCivil()
        //{
        //    try
        //    {
        //        //coleccion del tipo clase 
        //        List<EstadoCivil> ListadoEstCiv = new List<EstadoCivil>();

        //        var EstCivModelo = Entidades.EstadoCivil.ToList();

        //        foreach (DALC.EstadoCivil item in EstCivModelo)
        //        {
        //            EstadoCivil EstCiv = new EstadoCivil();


        //            EstCiv.Id = item.IdEstadoCivil;
        //            EstCiv.Descripcion = item.Descripcion;

        //            //listado clientes
        //            ListadoEstCiv.Add(EstCiv);
        //        }
        //        return ListadoEstCiv;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Mensaje(ex.Message);
        //        return null;
        //    }


        //}

    }
}
