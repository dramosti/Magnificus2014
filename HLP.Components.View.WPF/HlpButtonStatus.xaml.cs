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

namespace HLP.Components.View.WPF
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



        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(String), typeof(HlpButtonStatus), new PropertyMetadata(String.Empty));




        public Visibility lineleft
        {
            get { return (Visibility)GetValue(lineleftProperty); }
            set { SetValue(lineleftProperty, value); }
        }

        // Using a DependencyProperty as the backing store for lineleft.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lineleftProperty =
            DependencyProperty.Register("lineleft", typeof(Visibility), typeof(HlpButtonStatus), new PropertyMetadata(Visibility.Visible));
    }
}
