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
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinCalendarioDetalhe.xaml
    /// </summary>
    public partial class WinCalendarioDetalhe : WindowsBase
    {
        public WinCalendarioDetalhe()
        {
            InitializeComponent();
            this.ViewModel = new CalendarioDetalheViewModel();
            
        }


        public CalendarioDetalheViewModel ViewModel
        {
            get { return this.DataContext as CalendarioDetalheViewModel; }
            set { this.DataContext = value; }
        }
    }
}
