﻿using HLP.Base.ClassesBases;
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
            PropertyInfo _modelType = null;

            if (o != null)
                _modelType = _dataContext.GetType().GetProperty(name: "currentModel");

            object[] _params = new object[] { _modelType.PropertyType, o };

            object _return = Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Components.View.WPF",
                xType: "wdQuickSearch", xMethod: "ShowDialogWdQuickSearch",
                            parameters: _params);

            _dataContext.GetType().GetProperty(name: "currentID").SetValue(obj: _dataContext, value: _return);


            PropertyInfo currentModelProperty =
                _dataContext.GetType().GetProperty(name: "currentModel");


            if (currentModelProperty != null)
                currentModelProperty.SetValue(obj: _dataContext, value: null);

            MethodInfo miSetOp = _dataContext.GetType().GetMethod(
                name: "SetValorCurrentOp");

            object[] _paramsPesquisa = new object[] { OperacaoCadastro.pesquisando };

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
}
