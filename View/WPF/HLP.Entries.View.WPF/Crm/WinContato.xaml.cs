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
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Comum.ViewModel.ViewModels.Components;

namespace HLP.Entries.View.WPF.Crm
{
    /// <summary>
    /// Interaction logic for WinContato.xaml
    /// </summary>
    public partial class WinContato : WindowsBase
    {
        public WinContato()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}
