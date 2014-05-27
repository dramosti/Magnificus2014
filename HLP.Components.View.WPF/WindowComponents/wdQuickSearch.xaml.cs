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

        public wdQuickSearch(Type modelType, object sender)
        {
            InitializeComponent();
            this.ViewModel = new QuickSearchViewModel(modelType: modelType, sender: sender);
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

        public static int ShowDialogWdQuickSearch(Type modelType, object sender)
        {
            wdQuickSearch wd = new wdQuickSearch(modelType: modelType, sender: sender);
            wd.ShowDialog();

            return wd.ViewModel.returnedId;
        }                     

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
