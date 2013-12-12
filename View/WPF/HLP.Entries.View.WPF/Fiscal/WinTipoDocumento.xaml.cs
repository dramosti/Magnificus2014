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
using HLP.Entries.ViewModel.ViewModels.Fiscal;

namespace HLP.Entries.View.WPF.Fiscal
{
    /// <summary>
    /// Interaction logic for WinTipoDocumento.xaml
    /// </summary>
    public partial class WinTipoDocumento : WindowsBase
    {
        public WinTipoDocumento()
        {
            InitializeComponent();
            this.ViewModel = new Tipo_documentoViewModel();
            
        }
        public Tipo_documentoViewModel ViewModel
        {
            get { return this.DataContext as Tipo_documentoViewModel; }
            set { this.DataContext = value; }
        }
    }
}
