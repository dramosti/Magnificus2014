﻿using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class EmpresaViewModel : viewModelComum<EmpresaModel>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion

        public EmpresaViewModel()
        {
            EmpresaCommands com = new EmpresaCommands(objViewModel: this);
        }

        public string GetEmpresaFantasia(int idEmpresa)
        {
            if (idEmpresa == ((HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel).idEmpresa ?? 0))
                return (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel).xFantasia;

            return string.Empty;
        }

    }
}
