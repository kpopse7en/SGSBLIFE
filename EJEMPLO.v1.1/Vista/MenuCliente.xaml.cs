﻿using System;
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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MenuCliente.xaml
    /// </summary>
    public partial class MenuCliente : Window
    {
        public MenuCliente()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            wpfIngresoCliente cr = new wpfIngresoCliente();
            cr.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            lblFaltaFiltro.Content = ("");
            if (cboFiltro.SelectedIndex==1)
            {
                ListarRut lr = new ListarRut();
                lr.ShowDialog();
            }
            if (cboFiltro.SelectedIndex==2)
            {
                ListarSexo ls = new ListarSexo();
                ls.ShowDialog();
            }
            if (cboFiltro.SelectedIndex==3)
            {
                ListarEstado le = new ListarEstado();
                le.ShowDialog();
            }
            if (cboFiltro.SelectedIndex == 0)
            {
                lblFaltaFiltro.Content = ("Seleccione Filtro");
                   
                lblFaltaFiltro.Foreground = Brushes.Red;
            }
        }
    }
}
