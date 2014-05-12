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

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(HlpEndereco), new PropertyMetadata());



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
