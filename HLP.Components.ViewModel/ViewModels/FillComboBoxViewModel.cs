using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Components.Services;
using HLP.Components.Model.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace HLP.Components.ViewModel.ViewModels
{
    public class FillComboBoxViewModel
    {
        FillComboBoxService objService;
        bool designTime = false;

        public FillComboBoxViewModel()
        {
            designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                objService = new FillComboBoxService();
            }
        }

        public ObservableCollection<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter = "")
        {
            if (!designTime)
            {
                return new ObservableCollection<modelToComboBox>(objService.GetAllValuesToComboBox(sNameView, sParameter));
            }
            return null;
        }

        public string GetDisplay(object source, int value)
        {
            modelToComboBox it = (source as ObservableCollection<modelToComboBox>).FirstOrDefault(
                i => i.id == value);

            if (it != null)
                return it.display;

            return string.Empty;
        }
    }
}
