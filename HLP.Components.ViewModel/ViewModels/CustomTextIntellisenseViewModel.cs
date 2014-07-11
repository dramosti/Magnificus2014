using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class CustomTextIntellisenseViewModel : ViewModelBase<CustomPesquisaModel>
    {
        CustomTextIntellisenseCommands comm;

        public CustomTextIntellisenseViewModel()
        {
            this.lItems = new List<CustomPesquisaModel>();
            comm = new CustomTextIntellisenseCommands(objViewModel: this);
        }

        private List<CustomPesquisaModel> _lItems;

        public List<CustomPesquisaModel> lItems
        {
            get { return _lItems; }
            set
            {
                _lItems = value;
                base.NotifyPropertyChanged(propertyName: "lItems");
            }
        }

        private CustomPesquisaModel _selectedItem;

        public CustomPesquisaModel selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                base.NotifyPropertyChanged(propertyName: "selectedItem");
            }
        }
    }
}
