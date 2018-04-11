﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Entidades
{
    public class Contrato
    {
        public String NumeroContrato { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public String Titular { get; set; }
        public String Poliza{ get; set; }
        public String PlanAsociado { get; set; }
        //poliza?? la realizo aca en el diagrama de clases sale pero en el modelo no aparece
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public Boolean Vigente { get; set; }
        public Boolean ConDeclaracionSalud { get; set; }
        public Double PrimaAnual { get; set; }
        public Double PrimaMensual { get; set; }
        public String Observaciones { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;

        public Contrato()
        {
            Entidades = new BeLifeEntities();

        }
        //METODOS CRUD
        public bool GrabarContrato()
        {
            try
            {
                Biblioteca.DALC.Contrato Con;
                Con = new DALC.Contrato();
                Biblioteca.DALC.Plan Plan;
                Plan = new DALC.Plan();
                
                Con.Numero = this.NumeroContrato;
                Con.FechaCreacion = this.Creacion;
                Con.RutCliente = this.Titular;
                Con.CodigoPlan = this.PlanAsociado;
                //creo que debo recorrer los planes para saber que la poliza pertenece a cierto plan
                Plan.PolizaActual = this.Poliza;//Poliza
                Con.FechaInicioVigencia = this.InicioVigencia;
                Con.FechaFinVigencia = this.FinVigencia;
                Con.Vigente = this.Vigente;
                Con.DeclaracionSalud = this.ConDeclaracionSalud;
                Con.PrimaAnual = this.PrimaAnual;
                Con.PrimaMensual = this.PrimaMensual;
                Con.Observaciones = this.Observaciones;

                Entidades.Contrato.Add(Con);
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }

        }

        public bool EliminarContrato()
        {
            try
            {

                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(NumeroContrato));
                Con.Vigente = this.Vigente;//Modificar el estado a no vigente
                Con.FechaTermino = this.Termino;
                //fecha fin al contrato *
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public bool ActualizarContrato()
        {
            try
            {
                Biblioteca.DALC.Contrato Con;

                Con = Entidades.Contrato.First(a => a.Numero.Equals(NumeroContrato));

                Biblioteca.DALC.Plan Plan;
                Plan = new DALC.Plan();

                Con.Numero = this.NumeroContrato;
                Con.FechaCreacion = this.Creacion;
                Con.FechaTermino = this.Termino;//e.e
                Con.RutCliente = this.Titular;
                Con.CodigoPlan = this.PlanAsociado;
                Plan.PolizaActual = this.Poliza;
                Con.FechaInicioVigencia = this.InicioVigencia;
                Con.FechaFinVigencia = this.FinVigencia;
                Con.Vigente = this.Vigente;
                Con.DeclaracionSalud = this.ConDeclaracionSalud;
                Con.PrimaAnual = this.PrimaAnual;
                Con.PrimaMensual = this.PrimaMensual;
                Con.Observaciones = this.Observaciones;


                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }

        }

        public bool BuscarContrato()
        {
            try
            {
                Biblioteca.DALC.Plan Plan;
                Plan = new DALC.Plan();
                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(NumeroContrato));
                this.NumeroContrato = Con.Numero;
                this.Creacion = Con.FechaCreacion;
                this.Termino = (DateTime)Con.FechaTermino;
                this.Titular = Con.RutCliente;
                this.PlanAsociado = Con.CodigoPlan;
                this.Poliza = Plan.PolizaActual;
                this.InicioVigencia = Con.FechaInicioVigencia;
                this.FinVigencia = Con.FechaFinVigencia;
                this.Vigente = Con.Vigente;
                this.ConDeclaracionSalud = Con.DeclaracionSalud;
                this.PrimaAnual = Con.PrimaAnual;
                this.PrimaMensual = Con.PrimaMensual;
                this.Observaciones = Con.Observaciones;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }


        }

        public List<Contrato> ListarTodo()
        {
            try
            {
                List<Contrato> ListadoContrato = new List<Contrato>();
                var ContratoModelo = Entidades.Contrato.ToList();

                Biblioteca.DALC.Plan Plan;
                Plan = new DALC.Plan();

                foreach (var item in ContratoModelo)
                {
                    Contrato Con = new Contrato();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }
        }
        public List<Contrato> ListarporNroContrato(String NumeroContrato)
        {
            try
            {
                List<Contrato> ListadoContrato = new List<Contrato>();
                var ContratoModelo = from c in Entidades.Contrato
                                     where c.Numero == NumeroContrato
                                     select c;

                foreach (var item in ContratoModelo)
                {
                    Contrato Con = new Contrato();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }
        public List<Contrato> ListarporRut(String Rut)
        {
            try
            {
                List<Contrato> ListadoContrato = new List<Contrato>();
                var ContratoModelo = from r in Entidades.Contrato
                                     where r.RutCliente == Rut
                                     select r;

                foreach (var item in ContratoModelo)
                {
                    Contrato Con = new Contrato();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }
        //FILTRAR POR NUMERO DE POLIZA ???
        public List<Contrato> ListarporNroPoliza(String Poliza)
        {
            try
            {
                //hay que corregir lo de poliza para que esto funcione
                List<Contrato> ListadoContrato = new List<Contrato>();
                var ContratoModelo = from c in Entidades.Contrato
                                     where c.Numero == NumeroContrato
                                     select c;

                foreach (var item in ContratoModelo)
                {
                    Contrato Con = new Contrato();

                    Con.NumeroContrato = item.Numero;
                    Con.Creacion = item.FechaCreacion;
                    Con.Termino = (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.InicioVigencia = item.FechaInicioVigencia;
                    Con.FinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.ConDeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }

    }




}

