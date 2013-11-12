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
using HLP.Comum.View.Formularios;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinCidade.xaml
    /// </summary>
    public partial class WinCidade : WindowsBase
    {
        public WinCidade()
        {
            InitializeComponent();
            this.ViewModel = new CidadeViewModel();            
        }

        public CidadeViewModel ViewModel
        {
            get
            {
                return this.DataContext as CidadeViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

    }
}
