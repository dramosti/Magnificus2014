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

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for HlpCalendarioPonto.xaml
    /// </summary>
    public partial class HlpCalendarioPonto : UserControl
    {
        public HlpCalendarioPonto()
        {
            InitializeComponent();
        }


        public int idFuncionario
        {
            get { return (int)GetValue(idFuncionarioProperty); }
            set { SetValue(idFuncionarioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for idFuncionario.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty idFuncionarioProperty =
            DependencyProperty.Register("idFuncionario", typeof(int), typeof(HlpCalendarioPonto), new PropertyMetadata());




        public DateTime dtPonto
        {
            get { return (DateTime)GetValue(dtPontoProperty); }
            set { SetValue(dtPontoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dtPonto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dtPontoProperty =
            DependencyProperty.Register("dtPonto", typeof(DateTime), typeof(HlpCalendarioPonto), new PropertyMetadata(null));

        
              
        
    }
}
