using HLP.Comum.ViewModel.ViewModel;
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
    /// Interaction logic for WinSelectConnection.xaml
    /// </summary>
    public partial class WinSelectConnection : Window
    {
        public WinSelectConnection()
        {
            InitializeComponent();
            this.ViewModel = new SelectConnectionViewModel();
        }

        public SelectConnectionViewModel ViewModel
        {
            get { return this.DataContext as SelectConnectionViewModel; }
            set { this.DataContext = value; }
        }


        public bool? bProssegue
        {
            get { return this.ViewModel.bProssegue; }
        }
    }
}
