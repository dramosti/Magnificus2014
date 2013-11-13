using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels;

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinDepartamento.xaml
    /// </summary>
    public partial class WinDepartamento : WindowsBase
    {
        public WinDepartamento()
        {
            this.InitializeComponent();
            try
            {
                this.ViewModel = new DepartamentoViewModel();
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

        public DepartamentoViewModel ViewModel
        {
            get
            {
                return this.DataContext as DepartamentoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}