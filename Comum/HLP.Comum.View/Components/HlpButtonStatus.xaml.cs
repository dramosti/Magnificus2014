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

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpButtonStatus.xaml
    /// </summary>
    public partial class HlpButtonStatus : UserControl
    {
        public HlpButtonStatus()
        {
            InitializeComponent();
        }



        public Visibility line
        {
            get { return (Visibility)GetValue(lineProperty); }
            set { SetValue(lineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for line.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lineProperty =
            DependencyProperty.Register("line", typeof(Visibility), typeof(HlpButtonStatus), new PropertyMetadata(Visibility.Visible));

        
    }
}
