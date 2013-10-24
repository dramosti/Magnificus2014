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
using HLP.Entries.View.WPF.Gerais;

namespace HLP.Entries.View.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
               //WinUF uf = new WinUF();
               //uf.ShowDialog();


                WinRegiao reg = new WinRegiao();
                reg.ShowDialog();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
