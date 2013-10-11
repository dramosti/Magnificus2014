using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class TabPagesAtivasViewModel : ModelBase
    {
        #region Assinatura de comandos
        public ICommand AddWindowCommand { get; set; }
        public ICommand DelWindowCommand { get; set; }
        #endregion

        private ObservableCollection<TabPagesAtivasModel> lTabPagesAtivas;

        public ObservableCollection<TabPagesAtivasModel> _lTabPagesAtivas
        {
            get { return lTabPagesAtivas; }
            set
            {
                lTabPagesAtivas = value;
                base.NotifyPropertyChanged(propertyName: "_lTabPagesAtivas");
            }
        }

        public TabPagesAtivasViewModel()
        {
        }
    }
}
