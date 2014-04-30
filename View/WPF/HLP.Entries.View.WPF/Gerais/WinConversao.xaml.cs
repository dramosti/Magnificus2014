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
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinConversao.xaml
    /// </summary>
    public partial class WinConversao : WindowsBase
    {
        public WinConversao()
        {
            try
            {
                InitializeComponent();
                this.ViewModel = new ConversaoViewModel();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ConversaoViewModel ViewModel
        {
            get
            {
                return this.DataContext as ConversaoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void gridConversao_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            this.gridConversao.BindingGroup.UpdateSources();
        }
    }
}
