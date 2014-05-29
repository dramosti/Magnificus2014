using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                execute: e => this.SearchExecute(o: e), canExecute: eC => this.SearchCanExecute(eC));
        }

        private void SearchExecute(object o)
        {
            (o as TextBox).ApplyTemplate();


            object _dataContext = o.GetType().GetProperty(name: "DataContext").GetValue(obj: o);
            PropertyInfo _modelType = null;

            if (o != null)
                _modelType = _dataContext.GetType().GetProperty(name: "currentModel");

            object[] _params = new object[] { _modelType.PropertyType, o };

            object _return = Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Components.View.WPF",
                xType: "wdQuickSearch", xMethod: "ShowDialogWdQuickSearch",
                            parameters: _params);

            _dataContext.GetType().GetProperty(name: "currentID").SetValue(obj: _dataContext, value: _return);


            if ((int?)_return > 0)
            {
                PropertyInfo currentModelProperty =
            _dataContext.GetType().GetProperty(name: "currentModel");


                if (currentModelProperty != null)
                    currentModelProperty.SetValue(obj: _dataContext, value: null);

                MethodInfo miSetOp = _dataContext.GetType().GetMethod(
                    name: "SetValorCurrentOp");

                object[] _paramsPesquisa = new object[] { OperationModel.searching };

                miSetOp.Invoke(obj: _dataContext, parameters: _paramsPesquisa);

                _dataContext.GetType().GetProperty(name: "bIsEnabled")
                    .SetValue(obj: _dataContext, value: false);

                BackgroundWorker bw = _dataContext.GetType().GetProperty(
                    name: "bWorkerPesquisa").GetValue(obj: _dataContext) as BackgroundWorker;

                if (bw != null)
                {
                    bw.RunWorkerAsync();
                }
            }


        }

        private bool SearchCanExecute(object o)
        {
            if (o == null)
                return true;

            if ((o as Control).DataContext == null)
                return true;

            PropertyInfo piModel = (o as Control).DataContext.GetType().GetProperty(
                name: "currentModel");

            if (piModel == null)
                return true;

            Button btn = (o as Control).Template.FindName(name: "btn", templatedParent: (o as FrameworkElement)) as Button;

            object _value = piModel.GetValue(obj: (o as Control).DataContext);

            if (_value == null)
            {
                btn.Visibility = Visibility.Visible;
                return true;
            }


            bool retorno = (_value as modelBase).GetOperationModel()
                 != OperationModel.updating;

            (o as Control).ApplyTemplate();

            PropertyInfo stVisibilityBtnQuickSearchProperty
                = o.GetType().GetProperty(name: "stVisibilityBtnQuickSearch");

            StVisibilityButtonQuickSearch stVisibilityBtnQuickSearch = StVisibilityButtonQuickSearch._default;

            if (stVisibilityBtnQuickSearchProperty != null)
                stVisibilityBtnQuickSearch = (StVisibilityButtonQuickSearch)stVisibilityBtnQuickSearchProperty.GetValue(
                    obj: o);

            if ((btn != null && !retorno)
                || stVisibilityBtnQuickSearch == StVisibilityButtonQuickSearch.notVisible)
            {
                btn.Visibility = Visibility.Collapsed;
            }
            else
            {
                btn.Visibility = Visibility.Visible;
            }

            return true;
        }
    }
}
