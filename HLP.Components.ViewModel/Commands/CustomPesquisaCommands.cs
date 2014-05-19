using HLP.Base.ClassesBases;
using HLP.Base.Modules;
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
                        obj: o, value: result);
                }
            }
        }

        private void InsertExecute(object o)
        {
            if (o != null)
            {
                object form = GerenciadorModulo.Instancia.CarregaForm(
                    nome: o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o).ToString(),
                    exibeForm: Base.InterfacesBases.TipoExibeForm.Normal);

                Type t = form.GetType();
                ConstructorInfo constr = t.GetConstructor(Type.EmptyTypes);
                object inst = constr.Invoke(new object[] { });


                Window w = GerenciadorModulo.Instancia.CarregaForm(nome: "HlpPesquisaInsert",
                exibeForm: Base.InterfacesBases.TipoExibeForm.Normal);

                (w.FindName(name: "ctrContent") as ContentControl).DataContext = (inst as Window).DataContext;
                (w.FindName(name: "ctrContent") as ContentControl).Content = (inst as Window).Content;

                Type tVm = (w.FindName(name: "ctrContent") as ContentControl).DataContext.GetType();
                object instVm = (w.FindName(name: "ctrContent") as ContentControl).DataContext;
                MethodInfo met = tVm.GetMethod(name: "get_commandNovo");
                ICommand comm = met.Invoke(instVm, new object[] { }) as ICommand;
                comm.Execute(parameter: (w.FindName(name: "ctrContent") as ContentControl).Content);
                if (w.ShowDialog() == true)
                {
                    o.GetType().GetProperty(name: "xIdPesquisa").SetValue(
                            obj: o, value: w.GetType().GetProperty(name: "idSalvo").GetValue(obj: w));
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
                    Window w = GerenciadorModulo.Instancia.CarregaForm(
                        nome: nameWindow.ToString(), exibeForm: Base.InterfacesBases.TipoExibeForm.Normal);

                    if (w != null)
                    {
                        int id = 0;
                        object _id = o.GetType().GetProperty(name: "xIdPesquisa").GetValue(
                            obj: o);

                        if (_id != null)
                        {
                            if (int.TryParse(s: _id.ToString(), result: out id))
                            {
                                w.DataContext.GetType().GetProperty(name: "currentID").SetValue(obj: w, value: id);

                                BackgroundWorker bw = w.DataContext.GetType().GetProperty(
                                    name: "bWorkerPesquisa").GetValue(obj: w.DataContext) as BackgroundWorker;

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
            object id = o.GetType().GetProperty(name: "xIdPesquisa").GetValue(obj: o);

            return !(string.IsNullOrEmpty(value: id as string));
        }
    }
}
