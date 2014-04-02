using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Components.Services;
using HLP.Components.Model.Models;

namespace HLP.Components.ViewModel.ViewModels
{
    public class FillComboBoxViewModel
    {
        FillComboBoxService objService;

        public FillComboBoxViewModel()
        {
            objService = new FillComboBoxService();
        }

        public List<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter)
        {
            return objService.GetAllValuesToComboBox(
                sNameView: sNameView, sParameter: sParameter
                );
        }
    }
}
