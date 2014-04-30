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
using HLP.Entries.ViewModel.ViewModels.Parametros;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Parametrização
{
    /// <summary>
    /// Interaction logic for WinParametrizacao.xaml
    /// </summary>
    public partial class WinParametrizacao : WindowsBase
    {
        public WinParametrizacao()
        {
            InitializeComponent();
            this.ViewModel = new Empresa_ParametrosViewModel();
        }

        public Empresa_ParametrosViewModel ViewModel
        {
            get
            {
                return this.DataContext as Empresa_ParametrosViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
