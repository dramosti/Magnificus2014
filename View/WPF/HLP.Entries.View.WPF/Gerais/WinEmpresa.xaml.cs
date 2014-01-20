using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels;
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
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinEmpresa.xaml
    /// </summary>
    public partial class WinEmpresa : WindowsBase
    {
        public WinEmpresa()
        {
            InitializeComponent();
            try
            {
                this.ViewModel = new EmpresaViewModel();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmpresaViewModel ViewModel
        {
            get
            {
                return this.DataContext as EmpresaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

    



    }
}
