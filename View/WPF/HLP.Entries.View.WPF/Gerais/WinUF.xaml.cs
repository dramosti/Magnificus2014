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
using HLP.Entries.ViewModel.ViewModels;
using HLP.Entries.View.WPF.UIUtilities;
using HLP.Comum.View.Formularios;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinUF.xaml
    /// </summary>
    public partial class WinUF : WindowsBase
    {
        public UFViewModel ViewModel
        {
            get { return this.DataContext as UFViewModel; }
            set { this.DataContext = value; }
        }

        public WinUF()
        {
            InitializeComponent();
            this.ViewModel = new UFViewModel();           
                        
        }

        
    }
}
