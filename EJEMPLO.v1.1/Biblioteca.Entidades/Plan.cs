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

        public List<Plan> ListarPlan()
        {
            try
            {
                //coleccion del tipo clase 
                List<Plan> ListadoPlan = new List<Plan>();

                var PlanModelo = Entidades.Plan.ToList();

                foreach (DALC.Plan item in PlanModelo)
                {
                    Plan plan = new Plan();


                    plan.Id= item.IdPlan;
                    plan.Nombre = item.Nombre;
                    plan.PrimaBase = item.PrimaBase;
                    plan.PolizaActual = item.PolizaActual;
                   
                    //listado clientes
                    ListadoPlan.Add(plan);
                }
                return ListadoPlan;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }


        }

    }
}
