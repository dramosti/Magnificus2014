﻿using HLP.Comum.Model.Models;
using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Assinatura de comandos
        public ICommand AddWindowCommand { get; set; }
        public ICommand DelWindowCommand { get; set; }
        public ICommand pesquisarBaseCommand { get; set; }

        public ICommand anteriorCommand { get; set; }
        public ICommand primeiroCommand { get; set; }
        public ICommand proximoCommand { get; set; }
        public ICommand ultimoCommand { get; set; }

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

        private ObservableCollection<windowsModel> lWindows;

        public ObservableCollection<windowsModel> _lWindows
        {
            get { return lWindows; }
            set
            {
                lWindows = value;
                base.NotifyPropertyChanged(propertyName: "_lWindows");
            }
        }

        private TabPagesAtivasModel currentTab;

        public TabPagesAtivasModel _currentTab
        {
            get { return currentTab; }
            set
            {
                currentTab = value;
                base.NotifyPropertyChanged(propertyName: "_currentTab");
            }
        }

        private string _sText = "0 de 0";
        public string sText
        {
            get { return _sText; }
            set { _sText = value; base.NotifyPropertyChanged("sText"); }

        }

        private BindingSource _bsPesquisa = new BindingSource();
        public BindingSource bsPesquisa
        {
            get { return _bsPesquisa; }
            set { _bsPesquisa = value; base.NotifyPropertyChanged("bsPesquisa"); }
        }

        private Visibility _visibilityNavegacao = Visibility.Collapsed;

        public Visibility visibilityNavegacao
        {
            get { return _visibilityNavegacao; }
            set { _visibilityNavegacao = value; base.NotifyPropertyChanged("visibilityNavegacao"); }
        }


        public MainViewModel()
        {
            MainCommands objCommands = new MainCommands(objTabPagesAtivasViewModel: this);
            this._lTabPagesAtivas = new ObservableCollection<TabPagesAtivasModel>();
            this._lWindows = new ObservableCollection<windowsModel>();
            windowsModel objWindow;

            foreach (var item in GerenciadorModulo.Instancia.Modulos[0].objectModulo.lFormularios)
            {
                objWindow = new windowsModel();
                objWindow.xName = item.xName;
                objWindow.xHeader = this.getHeaderWindow(xNomeForm: objWindow.xName);
                this.lWindows.Add(item: objWindow);
            }
        }

        private string getHeaderWindow(string xNomeForm)
        {
            Window w;
            try
            {
                w = GerenciadorModulo.Instancia.CarregaForm(nome: xNomeForm.ToString(),
                exibeForm: Modules.Interface.TipoExibeForm.Modal);
                return w != null ? w.Title : xNomeForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                w = null;
            }
        }
    }
}
