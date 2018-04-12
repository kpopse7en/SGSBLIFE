﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
using System.Collections;
namespace Biblioteca.Entidades
{
    public class Clientes
    {
        private string _rutCliente;

        public string RutCliente        
        {
            get { return _rutCliente; }
            set {
                if (value.Trim().Length==8)
                {
                    _rutCliente = value;
                }
                else
                {
                    throw new ArgumentException("RUT Invalido");
                }
                 }
        }

        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public DateTime FechaNaci { get; set; }
        public int IdSexo { get; set; }
        public int IdEstadoCivil { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;
        public Clientes()
        {
            Entidades = new BeLifeEntities();
        }

        //metodos
        public bool Grabar()
        {
            try
            {
                Biblioteca.DALC.Cliente Cli;
                Cli = new  DALC.Cliente();

                Cli.RutCliente = this.RutCliente;
                Cli.Nombres = this.Nombres;
                Cli.Apellidos = this.Apellidos;
                Cli.FechaNacimiento = this.FechaNaci;
                Cli.IdSexo = this.IdSexo;
                Cli.IdEstadoCivil = this.IdEstadoCivil;
                
                
                Entidades.Cliente.Add(Cli);
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception )
            {

               return false;
            }


        }

        public bool Eliminar()
        {
            try
            {
                Biblioteca.DALC.Cliente Cli;
                Cli = Entidades.Cliente.First(a => a.RutCliente.Equals(RutCliente));
                //los clientes se asosia 'a'
                Entidades.Cliente.Remove(Cli);
                Entidades.SaveChanges();
                return true;


            }
            catch (Exception )
            {

                return false;
            }



        }

        public bool Modificar()
        {
            try
            {
                
                Biblioteca.DALC.Cliente Cli;
                Cli = Entidades.Cliente.First(b => b.RutCliente.Equals(RutCliente));

                Cli.RutCliente = this.RutCliente;
                Cli.Nombres = this.Nombres;
                Cli.Apellidos = this.Apellidos;
                Cli.FechaNacimiento = this.FechaNaci;
                Cli.IdSexo = this.IdSexo;
                Cli.IdEstadoCivil = this.IdEstadoCivil;


                
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                return false;
            }


        }

        public bool Buscar()
        {
            try
            {

                Biblioteca.DALC.Cliente Cli;
                Cli = Entidades.Cliente.
                    First(b => b.RutCliente.Equals(RutCliente));

                 this.RutCliente = Cli.RutCliente ;
                 this.Nombres = Cli.Nombres ;
                 this.Apellidos = Cli.Apellidos;
                 this.FechaNaci = Cli.FechaNacimiento ;
                 this.IdSexo =  Cli.IdSexo;
                 this.IdEstadoCivil  = Cli.IdEstadoCivil;
                
                return true;
            }
            catch (Exception )
            {

                return false;
            }


        }

        public List<Clientes> ListarTodo()
        {

            try
            {
                //coleccion del tipo clase Cliente
                List<Clientes> ListadoClientes = new List<Clientes>();
                //crear un objeto con el listado de todos los clientes
                //almacenados en el ,odelo Entidades
                var ClientesModelo = Entidades.Cliente.ToList();
                //recuperar cada uno de los registros del modelo
                //cada obeto Cliente perteneciente al Dalc
                foreach (DALC.Cliente item in ClientesModelo)
                {
                    Clientes Cli = new Clientes();
                    //Creo una clase cliente y se llena con los datos del modelo
                Cli.RutCliente = item.RutCliente;
                Cli.Nombres= item.Nombres;
                Cli.Apellidos= item.Apellidos;
                Cli.FechaNaci= item.FechaNacimiento;
                Cli.IdSexo = item.IdSexo;
                Cli.IdEstadoCivil= item.IdEstadoCivil;
                    //la clase cliente se almacena en la coleccion
                    //listado clientes
                    ListadoClientes.Add(Cli);
                }
                return ListadoClientes;
            }
            catch (Exception )
            {

                return null;
            }

        }

        public List<Clientes> ListarPorSexo(int IdSexo)
        {

            try
            {
                //coleccion del tipo clase Cliente
                List<Clientes> ListadoClientes = new List<Clientes>();
                //crear un objeto con el listado de todos los clientes
                //almacenados en el ,odelo Entidades
                var ClientesModelo = from a in Entidades.Cliente//solo tome a los a 
                                     where a.IdSexo == IdSexo
                                     select a;
                //recuperar cada uno de los registros del modelo
                //cada obeto Cliente perteneciente al Dalc
                foreach (DALC.Cliente item in ClientesModelo)
                {
                    Clientes Cli = new Clientes();
                    //Creo una clase cliente y se llena con los datos del modelo
                    Cli.RutCliente = item.RutCliente;
                    Cli.Nombres = item.Nombres;
                    Cli.Apellidos = item.Apellidos;
                    Cli.FechaNaci = item.FechaNacimiento;
                    //int edad = DateTime.Now.Date.Year  - Cli.FechaNacimiento.Year;
                    //Sacar la edad del cliente
                    Cli.IdSexo = item.IdSexo;
                    Cli.IdEstadoCivil = item.IdEstadoCivil;
                    //la clase cliente se almacena en la coleccion
                    //listado clientes
                    ListadoClientes.Add(Cli);
                }
                return ListadoClientes;
            }
            catch (Exception )
            {

                return null;
            }

        }
    }
}
