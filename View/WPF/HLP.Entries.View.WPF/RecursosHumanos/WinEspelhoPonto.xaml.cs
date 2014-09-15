using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using HLP.Resources.View.WPF;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Components.View.WPF;
using HLP.Base.Static;

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
            List<Control> lresult = Util.GetLogicalChildCollection<HlpCalendarioPonto>(this).ToList<Control>();
            this.ViewModel = new EspelhoPontoViewModel(lresult, this.btnCarregar);
           
        }


        public EspelhoPontoViewModel ViewModel
        {
            get { return this.DataContext as EspelhoPontoViewModel; }
            set { this.DataContext = value; }
        }

        private void WindowsBase_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
