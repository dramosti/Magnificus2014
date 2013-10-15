using HLP.Comum.Model.Models;
using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class vWindows : ModelBase
    {
        private string xNome;

        public string _xNome
        {
            get { return xNome; }
            set
            {
                xNome = value;
                this.NotifyPropertyChanged(propertyName: "_xNome");
            }
        }
    }
    public class MainViewModel : ModelBase
    {
        #region Assinatura de comandos
        public ICommand AddWindowCommand { get; set; }
        public ICommand DelWindowCommand { get; set; }
        #endregion

        private ObservableCollection<TabPagesAtivasModel> lTabPagesAtivas;

        public ObservableCollection<TabPagesAtivasModel> _lTabPagesAtivas
        {
            get { return lTabPagesAtivas; }
            set
            {
                lTabPagesAtivas = value;
                base.NotifyPropertyChanged(propertyName: "_lTabPagesAtivas");
            }
        }

        private ObservableCollection<vWindows> lWindows;

        public ObservableCollection<vWindows> _lWindows
        {
            get { return lWindows; }
            set
            {
                lWindows = value;
                base.NotifyPropertyChanged(propertyName: "_lWindows");
            }
        }

        public MainViewModel()
        {
            MainCommands objCommands = new MainCommands(objTabPagesAtivasViewModel: this);
            this._lTabPagesAtivas = new ObservableCollection<TabPagesAtivasModel>();
            this._lWindows = new ObservableCollection<vWindows>();
            vWindows objWindow;

            foreach (var item in GerenciadorModulo.Instancia.Modulos[0].objectModulo.lFormularios)
            {
                objWindow = new vWindows();
                objWindow._xNome = item.xName;
                this._lWindows.Add(item: objWindow);
            }

            //this._lWindows = (from l in GerenciadorModulo.Instancia.Modulos[0].objectModulo.lFormularios
            //                  select (new vWindows
            //                  {
            //                      xNome = l.xName
            //                  })) as ObservableCollection<vWindows>;
        }
    }
}
