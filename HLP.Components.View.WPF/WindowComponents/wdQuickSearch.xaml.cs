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
using HLP.Components.ViewModel.ViewModels.WindowComponents;

namespace HLP.Components.View.WPF.WindowComponents
{
    /// <summary>
    /// Interaction logic for wdQuickSearch.xaml
    /// </summary>
    public partial class wdQuickSearch : Window
    {
        public wdQuickSearch()
        {
            InitializeComponent();
        }

        public wdQuickSearch(object model, object sender)
        {
            InitializeComponent();
            this.ViewModel = new QuickSearchViewModel(sender: sender);
        }

        public QuickSearchViewModel ViewModel
        {
            get
            {
                return this.DataContext as QuickSearchViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public static int ShowDialogWdQuickSearch(object model, object sender)
        {
            wdQuickSearch wd = new wdQuickSearch(model: model, sender: sender);
            wd.ShowDialog();

            return wd.ViewModel.returnedId;
        }
    }
}
