using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
namespace Biblioteca.Entidades
{
    public class Contrato
    {
        public int NumeroContrato { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public String Titular { get; set; }
        public String PlanAsociado { get; set; }
        //poliza?? la realizo aca en el diagrama de clases sale pero en el modelo no aparece
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public Char Vigente { get; set; }//dice que es bit deberia guardarlo como char
        public Char ConDeclaracionSalud { get; set; }//dice que es bit deberia guardarlo como char
        public Double PrimaAnual { get; set; }
        public Double PrimaMensual { get; set; }
        public String Observaciones { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;

        public Contrato()
        {
            Entidades = new BeLifeEntities();

        }
        //METODOS CRUD
      
}
}
