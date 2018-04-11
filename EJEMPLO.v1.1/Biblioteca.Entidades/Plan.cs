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

    }
}
