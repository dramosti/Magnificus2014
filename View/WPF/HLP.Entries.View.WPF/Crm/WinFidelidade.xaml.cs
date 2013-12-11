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
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Crm;


namespace HLP.Entries.View.WPF.Crm
{
    /// <summary>
    /// Interaction logic for WinFidelidade.xaml
    /// </summary>
    public partial class WinFidelidade : WindowsBase
    {
        public WinFidelidade()
        {
            InitializeComponent();
            this.viewModel = new FidelidadeViewModel();
        }
        public FidelidadeViewModel viewModel
        {
            get
            {
                return this.DataContext as FidelidadeViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
