using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.ComumView.ViewModel.ViewModel;
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

namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for wdMain.xaml
    /// </summary>
    public partial class wdMain : Window
    {
        public wdMain()
        {
            InitializeComponent();
            GerenciadorModulo.Instancia.InicializaSistema();
            this.ViewModel = new wdMainViewModel();
            this.ViewModel.popUpSearchField = this.popUpSearchField;            
        }

        public wdMainViewModel ViewModel
        {
            get
            {
                return this.DataContext as wdMainViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.mainTabControl.SelectedItem = this.tiWindow;

            if ((sender as ListBox).SelectedIndex > 0)
                this.ViewModel.FocusOnComponent(comp: ((sender as ListBox).SelectedItem as DetailsErrorModel).comp);
        }
    }
}
