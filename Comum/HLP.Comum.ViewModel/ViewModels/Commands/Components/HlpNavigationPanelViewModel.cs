using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Comum.ViewModel.ViewModels.Commands.Components
{
    public class HlpNavigationPanelViewModel: INotifyPropertyChanged
    {
        public HlpNavigationPanelViewModel()
        {
            this.lIdsNavegacao = new List<int>();
        }

        private List<int> _lIdsNavegacao;

        public List<int> lIdsNavegacao
        {
            get { return _lIdsNavegacao; }
            set
            {
                _lIdsNavegacao = value;
                this.NotifyPropertyChanged(propertyName: "stkItens");
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
