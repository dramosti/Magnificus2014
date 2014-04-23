using HLP.Components.View.WPF;
using HLP.Entries.ViewModel.ViewModels;
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

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinUnidadeMedida.xaml
    /// </summary>
    public partial class WinUnidadeMedida : WindowsBase
    {
        public WinUnidadeMedida()
        {
            InitializeComponent();
            this.ViewModel = new Unidade_MedidaViewModel();
        }

        public Unidade_MedidaViewModel ViewModel
        {
            get
            {
                return this.DataContext as Unidade_MedidaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //bool b = this.ViewModel.IsValid(obj: this.gridPropriedades);
        }
    }
}
