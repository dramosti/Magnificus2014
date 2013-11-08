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

namespace HLP.Comum.View.Formularios
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WinPesquisaPadrao : Window
    {
        public WinPesquisaPadrao()
        {
            InitializeComponent();
        }



        public string NameView
        {
            get { return hlpCompPesquisaPadrao.NameView; }
            set
            {
                hlpCompPesquisaPadrao.NameView = value;
            }
        }

        public List<int> lResult
        {
            get { return hlpCompPesquisaPadrao.lResult; }
        }

        private void hlpCompPesquisaPadrao_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (hlpCompPesquisaPadrao.Visibility == System.Windows.Visibility.Collapsed)
            {
                this.Close();
            }
        }







    }
}
