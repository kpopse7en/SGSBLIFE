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


    }
}
