using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace HLP.Comum.View.Formularios
{
    /// <summary>
    /// Interaction logic for HlpPesquisaInsert.xaml
    /// </summary>
    public partial class HlpPesquisaInsert : Window
    {
        public HlpPesquisaInsert()
        {
            InitializeComponent();
        }

        private int _idSalvo;

        public int idSalvo
        {
            get { return _idSalvo; }
            set { _idSalvo = value; }
        }
    }
}
