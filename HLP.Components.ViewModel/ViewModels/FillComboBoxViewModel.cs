using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Components.Services;
using HLP.Components.Model.Models;
using System.Collections.ObjectModel;

namespace HLP.Components.ViewModel.ViewModels
{
    public class FillComboBoxViewModel
    {
        FillComboBoxService objService;

        public FillComboBoxViewModel()
        {
            objService = new FillComboBoxService();
        }

        public ObservableCollection<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter = "")
        {
            return new ObservableCollection<modelToComboBox>(objService.GetAllValuesToComboBox(sNameView, sParameter));
        }
    }
}
