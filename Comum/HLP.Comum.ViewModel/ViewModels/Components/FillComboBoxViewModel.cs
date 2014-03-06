using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;

namespace HLP.Comum.ViewModel.ViewModels.Components
{
    public class FillComboBoxViewModel
    {
        FillComboBoxService.IserviceFillComboBoxClient servico = null;
        
        public ObservableCollection<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter = "")
        {
            if (servico == null)
                servico = new FillComboBoxService.IserviceFillComboBoxClient();
            return new ObservableCollection<modelToComboBox>(servico.GetAllValuesToComboBox(sNameView, sParameter));
        }
    }
}
