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
using HLP.Comum.Resources;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Comum.Resources.Util;
using HLP.Comum.View.Formularios;

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinEspelhoPonto.xaml
    /// </summary>
    public partial class WinEspelhoPonto : WindowsBase
    {
        public WinEspelhoPonto()
        {
            InitializeComponent();
            List<Control> lresult = StaticUtil.GetLogicalChildCollection<HlpCalendarioPonto>(this).ToList<Control>();
            this.ViewModel = new EspelhoPontoViewModel(lresult);


        }


        public EspelhoPontoViewModel ViewModel
        {
            get { return this.DataContext as EspelhoPontoViewModel; }
            set { this.DataContext = value; }
        }
    }
}
