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
    /// Interaction logic for WinAbout.xaml
    /// </summary>
    public partial class WinSobre : Window
    {
        public WinSobre()
        {
            InitializeComponent();
            this.xVersao.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
