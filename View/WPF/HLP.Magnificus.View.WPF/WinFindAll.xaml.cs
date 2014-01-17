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
using HLP.Comum.View.Components;
using HLP.Comum.ViewModel.ViewModels;

namespace HLP.Magnificus.View.WPF
{
    /// <summary>
    /// Interaction logic for WinFindAll.xaml
    /// </summary>
    public partial class WinFindAll : Window
    {
        public WinFindAll()
        {
            InitializeComponent();
            this.ViewModel = new FindAllViewModel();
            // Supply the control with the list of sections
            List<string> sections = new List<string> { "Formulários", "Dashboards", "Relatórios" };
            m_txtTest.SectionsList = sections;
            // Choose a style for displaying sections
            m_txtTest.SectionsStyle = HlpSearchTextBox.SectionsStyles.RadioBoxStyle;
            // Add a routine handling the event OnSearch
            m_txtTest.OnSearch += new RoutedEventHandler(this.ViewModel.m_txtTest_OnSearch);
            lstResult.MouseDoubleClick += new MouseButtonEventHandler(this.ViewModel.lstResult_MouseDoubleClick);
            lstResult.KeyDown += new KeyEventHandler(this.ViewModel.lstResult_KeyDown);
        }



        public ICommand AddWindowCommand
        {
            set { this.ViewModel.AddWindowCommand = value; }
        }



        public FindAllViewModel ViewModel
        {
            get { return this.DataContext as FindAllViewModel; }
            set { this.DataContext = value; }
        }



    }
}
