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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HLP.Comum.ViewModel.ViewModels.Components;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpPesquisaPadrao.xaml
    /// </summary>
    public partial class HlpPesquisaPadrao : UserControl
    {
        public HlpPesquisaPadraoViewModel ViewModel
        {
            get { return this.DataContext as HlpPesquisaPadraoViewModel; }
            set { this.DataContext = value; }
        }
        public HlpPesquisaPadrao()
        {
            InitializeComponent();           
        }



        public string NameView
        {
            get { return (string)GetValue(NameViewProperty); }
            set { SetValue(NameViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameViewProperty =
            DependencyProperty.Register("NameView", typeof(string), typeof(HlpPesquisaPadrao), new PropertyMetadata(string.Empty));

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = new HlpPesquisaPadraoViewModel(NameView);
        }


    }
}
