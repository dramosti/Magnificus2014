using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Gerais;
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

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinFuncionario.xaml
    /// </summary>
    public partial class WinFuncionario : WindowsBase
    {
        public WinFuncionario()
        {
            InitializeComponent();
            this.ViewModel = new FuncionarioViewModel();
            this.UpdateLayout();
        }

        public FuncionarioViewModel ViewModel
        {
            get
            {
                return this.DataContext as FuncionarioViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        private void cbxStCidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}
