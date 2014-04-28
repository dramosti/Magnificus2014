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

namespace HLP.Entries.View.WPF.Crm
{
    /// <summary>
    /// Interaction logic for WinDecisao.xaml
    /// </summary>
    public partial class WinDecisao : WindowsBase
    {
        public WinDecisao()
        {
            InitializeComponent();
            this.viewModel = new DecisaoViewModel();
        }

        public DecisaoViewModel viewModel
        {
            get
            {
                return this.DataContext as DecisaoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
