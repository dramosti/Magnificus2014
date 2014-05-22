using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Services;
using HLP.Components.ViewModel.ViewModels.WindowComponents;
using System.Reflection;
using HLP.Base.EnumsBases;
using HLP.Base.ClassesBases;
using System.Windows;

namespace HLP.Components.ViewModel.Commands.WindowComponents
{
    public class QuickSearchCommands
    {
        QuickSearchViewModel objViewModel;
        OperacoesDataBaseService objService;

        public QuickSearchCommands(QuickSearchViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objService = new OperacoesDataBaseService();
            this.objViewModel.searchCommad = new RelayCommand(
                execute: e => this.SearchExecute(o: e), canExecute: cE => this.SearchCanExecute());

            this.objViewModel.ChangeToEqualCommand = new RelayCommand(
                execute: e => this.ChangeToEqualExecute());

            this.objViewModel.ChangeToContainsCommand = new RelayCommand(
                execute: e => this.ChangeToStartWithExecute());

            this.objViewModel.ChangeToStartWithCommand = new RelayCommand(
                execute: e => this.ChangeToStartWithExecute());
        }

        private void ChangeToEqualExecute()
        {
            this.objViewModel.stFilterQs = stFilterQuickSearch.equal;
        }

        private void ChangeToStartWithExecute()
        {
            this.objViewModel.stFilterQs = stFilterQuickSearch.startWith;
        }

        private void ChangeToContainsExecute()
        {
            this.objViewModel.stFilterQs = stFilterQuickSearch.contains;
        }

        private void SearchExecute(object o)
        {

            string xNameTable = "UF";

            this.objViewModel.returnedId = objService.GetIdRecordToQuickSearch(
                xNameTable: xNameTable,
                xCampo: this.objViewModel.xNameBinding,
                xValue: this.objViewModel.xValue,
                stFilterQS: this.objViewModel.stFilterQs);

            (o as Window).DialogResult = true;
            (o as Window).Close();
        }

        private bool SearchCanExecute()
        {
            return !(string.IsNullOrEmpty(value: this.objViewModel.xValue));
        }
    }
}
