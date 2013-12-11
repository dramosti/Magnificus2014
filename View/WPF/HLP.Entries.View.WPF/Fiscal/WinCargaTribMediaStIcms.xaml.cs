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
    /// Interaction logic for WinCargaTribMediaStIcms.xaml
    /// </summary>
    public partial class WinCargaTribMediaStIcms : WindowsBase
    {
        public WinCargaTribMediaStIcms()
        {
            InitializeComponent();
            this.ViewModel = new Carga_trib_media_st_icmsViewModel();
        }


        public Carga_trib_media_st_icmsViewModel ViewModel
        {
            get { return this.DataContext as Carga_trib_media_st_icmsViewModel; }
            set { this.DataContext = value; }
        }
    }
}
