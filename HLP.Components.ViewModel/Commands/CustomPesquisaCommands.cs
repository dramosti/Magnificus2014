﻿using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Modules;
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
using System.Windows.Input;

namespace HLP.Components.ViewModel.Commands
{
    public class CustomPesquisaCommands
    {
        CustomPesquisaViewModel objViewModel;

        public CustomPesquisaCommands(CustomPesquisaViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.searchCommand = new RelayCommand(
                execute: e => this.SearchExecute(o: e));
            this.objViewModel.insertCommand = new RelayCommand(
                execute: e => this.InsertExecute(o: e),
                canExecute: cE => this.InsertCanExecute(o: cE));
            this.objViewModel.goToRecordCommand = new RelayCommand(
                execute: e => this.GoToRecord(o: e),
                canExecute: cE => this.GoToRecordCanExecute(o: cE));
        }

        private void SearchExecute(object o)
        {
            Window winPesquisa = GerenciadorModulo.Instancia.CarregaForm("WinPesquisaPadrao", Base.InterfacesBases.TipoExibeForm.Normal);

            if (winPesquisa != null)
            {
                winPesquisa.WindowState = WindowState.Maximized;
                winPesquisa.GetType().GetProperty(name: "NameView").SetValue(obj: winPesquisa, value:
                    o.GetType().GetProperty(name: "TableView").GetValue(obj: o));
                winPesquisa.GetType().GetProperty(name: "NameWindowCadastro").SetValue(obj: winPesquisa,
                    value: o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o));

                winPesquisa.ShowDialog();

                if ((winPesquisa.GetType().GetProperty(name: "lResult").GetValue(obj: winPesquisa)
                    as List<int>).Count > 0)
                {
                    int result = (winPesquisa.GetType().GetProperty(name: "lResult").GetValue(obj: winPesquisa)
                    as List<int>).FirstOrDefault();
                    o.GetType().GetProperty(name: "xIdPesquisa").SetValue(
                        obj: o, value: result.ToString());
                }
            }
        }

        private void InsertExecute(object o)
        {
            object nameWindow = o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o);

            if (nameWindow != null)
            {
                ICommand AddCommand = Application.Current.MainWindow.DataContext.GetType()
                    .GetProperty(name: "AddWindowCommand").GetValue(obj: Application.Current.MainWindow.DataContext) as ICommand;


                if (AddCommand != null)
                {


                    AddCommand.Execute(parameter: nameWindow);

                    object winManPropertyValue = Application.Current.MainWindow.DataContext.GetType()
                                    .GetProperty(name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

                    object _currentTab = winManPropertyValue.GetType().GetProperty(name: "_currentTab")
                        .GetValue(obj: winManPropertyValue);

                    object _DataContext = _currentTab.GetType().GetProperty(name: "_currentDataContext")
                        .GetValue(obj: _currentTab);

                    ICommand comm = _DataContext.GetType().GetProperty(name: "commandNovo").GetValue(obj: _DataContext) as ICommand;

                    if (comm != null)
                        comm.Execute(parameter: null);
                    else
                        throw new Exception(message: "Command Novo não configurado para a tela corrente");
                }
            }
        }

        private bool InsertCanExecute(object o)
        {
            if (o == null)
                return false;

            object nameWindow = o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o);

            return nameWindow != null;
        }

        private void GoToRecord(object o)
        {
            if (o != null)
            {
                object nameWindow = o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o);

                if (nameWindow != null)
                {
                    ICommand AddCommand = Application.Current.MainWindow.DataContext.GetType()
                        .GetProperty(name: "AddWindowCommand").GetValue(obj: Application.Current.MainWindow.DataContext) as ICommand;

                    if (AddCommand != null)
                    {
                        AddCommand.Execute(parameter: nameWindow);
                        int id = 0;
                        object _id = o.GetType().GetProperty(name: "xIdPesquisa").GetValue(
                            obj: o);

                        if (_id != null)
                        {
                            if (int.TryParse(s: _id.ToString(), result: out id))
                            {
                                object winManPropertyValue = Application.Current.MainWindow.DataContext.GetType()
                                    .GetProperty(name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

                                object _currentTab = winManPropertyValue.GetType().GetProperty(name: "_currentTab")
                                    .GetValue(obj: winManPropertyValue);

                                object _DataContext = _currentTab.GetType().GetProperty(name: "_currentDataContext")
                                    .GetValue(obj: _currentTab);

                                _DataContext.GetType().GetProperty(name: "currentID").SetValue(obj: _DataContext, value: id);


                                object currentModel =
                                    _DataContext.GetType().GetProperty(name: "currentModel").GetValue(obj: _DataContext);

                                if (currentModel != null)
                                {

                                    if (MessageHlp.Show(stMessage: StMessage.stYesNo,
                                        xMessageToUser: "Window está sendo utilizada no momento, deseja cancelar a operação corrente " +
                                        " e pesquisar o registro?") != MessageBoxResult.Yes)
                                    {
                                        return;
                                    }

                                    _DataContext.GetType().GetProperty(name: "currentModel").SetValue(obj:
                                        _DataContext, value: null);
                                }

                                //MethodInfo miSetOp = _DataContext.GetType().GetMethod(
                                //    name: "SetValorCurrentOp");

                                //object[] _params = new object[] { OperationModel.searching };

                                //miSetOp.Invoke(obj: _DataContext, parameters: _params);

                                _DataContext.GetType().GetProperty(name: "bIsEnabled")
                                    .SetValue(obj: _DataContext, value: false);

                                BackgroundWorker bw = _DataContext.GetType().GetProperty(
                                    name: "bWorkerPesquisa").GetValue(obj: _DataContext) as BackgroundWorker;

                                if (bw != null)
                                {
                                    bw.RunWorkerAsync();
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool GoToRecordCanExecute(object o)
        {
            if (o == null)
                return false;
            object id = o.GetType().GetProperty(name: "xIdPesquisa").GetValue(obj: o);

            return !(string.IsNullOrEmpty(value: id as string));
        }
    }
}
