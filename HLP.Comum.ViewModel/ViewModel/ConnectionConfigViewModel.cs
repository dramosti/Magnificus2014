﻿using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModel
{
    public class ConnectionConfigViewModel : viewModelComum<ConnectionConfigModel>
    {
        ConnectionConfigCommand command;
        public ICommand SalvarCommand { get; set; }
        public ICommand TestarCommand { get; set; }        
        public ICommand AddCommand { get; set; }

        

        public ConnectionConfigViewModel()
        {
            command = new ConnectionConfigCommand(this);
            
        }

        private ObservableCollection<string> _servers = new ObservableCollection<string>();
        public ObservableCollection<string> servers
        {
            get { return _servers; }
            set
            {
                _servers = value;
                base.NotifyPropertyChanged(propertyName: "servers");
            }
        }

        private ObservableCollection<string> _bases;
        public ObservableCollection<string> bases
        {
            get { return _bases; }
            set
            {
                _bases = value;
                base.NotifyPropertyChanged(propertyName: "bases");
            }
        }
             
        private ObservableCollection<ConnectionConfigModel> _lConexoes = new ObservableCollection<ConnectionConfigModel>();
        public ObservableCollection<ConnectionConfigModel> lConexoes
        {
            get { return _lConexoes; }
            set
            {
                _lConexoes = value;
                base.NotifyPropertyChanged(propertyName: "lConexoes");
            }
        }

        public void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            command.CarregaBases();
        }
    }
}
