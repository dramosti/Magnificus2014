using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Components.ViewModel.Commands
{
    public class CustomTextBoxCommands
    {
        CustomTextBoxViewModel objViewModel;

        public CustomTextBoxCommands(CustomTextBoxViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.searchCommand = new RelayCommand(
                execute: e => this.SearchExecute(o: e));
        }

        private void SearchExecute(object o)
        {
            (o as TextBox).ApplyTemplate();


            object _dataContext = o.GetType().GetProperty(name: "DataContext").GetValue(obj: o);
            object _model = null;

            if (o != null)
                _model = _dataContext.GetType().GetProperty(name: "currentModel").GetValue(obj: _dataContext);

            object[] _params = new object[] { _model, o };

            object _return = Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Components.View.WPF",
                xType: "wdQuickSearch", xMethod: "ShowDialogWdQuickSearch",
                            parameters: _params);
        }
    }
}
