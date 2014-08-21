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
using HLP.Entries.Services.Gerais;
using HLP.Entries.Model.Comercial;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Comercial;

namespace HLP.Teste.View.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.vm = new MainWindowViewModel();
        }



        public MainWindowViewModel vm
        {
            get { return this.DataContext as MainWindowViewModel; }
            set { this.DataContext = value; }
        }

    }

    public class MainWindowViewModel : viewModelComum<ProdutoModel>
    {
        public ConversaoService s { get; set; }


        public MainWindowViewModel()
        {
            s = new ConversaoService();

            this.currentModel = s.GetObject(id: 1046);            
        }
    }
}
