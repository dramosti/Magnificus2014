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
    /// Interaction logic for HlpButtonNavigation.xaml
    /// </summary>
    public partial class HlpButtonNavigation : UserControl
    {
        public string xContentBtn
        {
            get { return this.btn.Content.ToString(); }
            set { this.btn.Content = value; }
        }

        public HlpButtonNavigation()
        {
            InitializeComponent();
        }
    }
}
