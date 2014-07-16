using HLP.Components.Model.Models;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections;
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

namespace HLP.Components.View.WPF
{
    /// <summary>
    /// Interaction logic for HlpEndereco.xaml
    /// </summary>
    public partial class HlpEndereco : UserControl
    {
        public HlpEndereco()
        {
            InitializeComponent();       
        }

        private HlpEnderecoViewModel _ViewModel;

        public HlpEnderecoViewModel ViewModel
        {
            get { return _ViewModel; }
            set { _ViewModel = value; }
        }
        
        

        public IEnumerable ItemsSourceEnderecos
        {
            get { return (IEnumerable)GetValue(ItemsSourceEnderecosProperty); }
            set { SetValue(ItemsSourceEnderecosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSourceEnderecos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceEnderecosProperty =
            DependencyProperty.Register("ItemsSourceEnderecos", typeof(IEnumerable), typeof(HlpEndereco),
            new PropertyMetadata(propertyChangedCallback: new PropertyChangedCallback(ItemsSourceChanged)));

        private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if ((d as HlpEndereco).ItemsSourceEnderecos != null && e.NewValue != null)
            //{
            //    if (((d as HlpEndereco).ItemsSourceEnderecos as IEnumerable<EnderecoModel>).Count()
            //        == 0)
            //    {                    
            //    }
            //}
        }

        public bool IsReadOnlyUserControl
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnlyUserControl", typeof(bool), typeof(HlpEndereco), new PropertyMetadata(false));



        public bool IsEnabledUserControl
        {
            get { return (bool)GetValue(IsEnabledUserControlProperty); }
            set { SetValue(IsEnabledUserControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnabledUserControlProperty =
            DependencyProperty.Register("IsEnabledUserControl", typeof(bool), typeof(HlpEndereco), new PropertyMetadata(true));
    }
}
