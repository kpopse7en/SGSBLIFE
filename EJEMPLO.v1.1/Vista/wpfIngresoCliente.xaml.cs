using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Biblioteca.Entidades;
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para wpfIngresoCliente.xaml
    /// </summary>
    public partial class wpfIngresoCliente : Window
    {
        public wpfIngresoCliente()
        {
            InitializeComponent();

           List<Biblioteca.Entidades.Sexo> Listado = new Biblioteca.Entidades.Sexo().ListarSexo();
            foreach (Biblioteca.Entidades.Sexo item in Listado)
            {
                cboSexo.Items.Add(item.Descripcion);
            }

            List<EstadoCivil> Listado2= new EstadoCivil().ListarEstadoCivil();
            foreach (EstadoCivil item in Listado2)
            {
                cboEstado.Items.Add(item.Descripcion);
            }
        }

       

        private void ingresar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtRut.Text.Trim().Length==8))
                {
                    lblRut.Content=("ingrese un rut");
                    lblRut.Foreground = Brushes.Red;
                }
                Cliente cli = new Cliente();
                cli.RutCliente = txtRut.Text;
                cli.Nombres = txtnNombre.Text;
                cli.Apellidos = txtApellido.Text;

                DateTime fechahoy = DateTime.Now;//para contrato
                string formatoDeOro = fechahoy.ToString("YYYYMMDDHHmmSS");//

                cli.FechaNaci = (DateTime)dpkFechaNaci.SelectedDate;
                cli.IdSexo = cboSexo.SelectedIndex;
                cli.IdEstadoCivil = cboEstado.SelectedIndex;
                bool resp = cli.Grabar();
                if (resp == true)
                {
                    MessageBox.Show("Ingreso Cliente con exito");
                }
                else
                {
                    MessageBox.Show("NO Ingreso Cliente");
                }
            }
            catch (AggregateException errControlado)
            {
                //mesajes de reglas de negocio
                MessageBox.Show(errControlado.Message);

            }
            catch (Exception ex)
            {
                Biblioteca.Logger.Mensaje(ex.Message);
                MessageBox.Show("Error al Ingresar");
            }
        }
    }
}
