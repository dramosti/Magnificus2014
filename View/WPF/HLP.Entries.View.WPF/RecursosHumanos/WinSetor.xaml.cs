using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HLP.Entries.ViewModel.ViewModels.RecursosHumanos;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinSetor.xaml
    /// </summary>
    public partial class WinSetor : WindowsBase
    {
        public WinSetor()
        {
            this.InitializeComponent();
            this.ViewModel = new SetorViewModel();
        }

        public SetorViewModel ViewModel
        {
            get
            {
                return this.DataContext as SetorViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}