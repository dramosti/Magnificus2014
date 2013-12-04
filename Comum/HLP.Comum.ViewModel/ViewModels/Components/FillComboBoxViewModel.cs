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
        FillComboBoxService.IserviceFillComboBoxClient servico = new FillComboBoxService.IserviceFillComboBoxClient();

        public FillComboBoxViewModel()
        {

        }

        public ObservableCollection<modelToComboBox> GetAllValuesToComboBox(string sNameView)
        {
            return new ObservableCollection<modelToComboBox>(servico.GetAllValuesToComboBox(sNameView));
        }
    }
}
