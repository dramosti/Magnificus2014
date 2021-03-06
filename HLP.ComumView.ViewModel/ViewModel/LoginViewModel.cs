﻿using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.ViewModel.ViewModel;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.ComumView.ViewModel.ViewModel
{
    public class LoginViewModel : viewModelComum<loginModel>
    {
        public ICommand loginCommand { get; set; }
        public bool bLogado = false;

        wcf_Funcionario.Iwcf_FuncionarioClient funcService;

        public LoginViewModel(ModoInicial st)
        {
            LoginCommands cmm = new LoginCommands(objViewModel: this);
            this.currentModel = new loginModel();

            switch (st)
            {
                case ModoInicial.trocaUsuario:
                    {
                        this.currentModel.idEmpresa = CompanyData.idEmpresa;
                    }
                    break;
                case ModoInicial.trocaEmpresa:
                    {
                        funcService = new wcf_Funcionario.Iwcf_FuncionarioClient();

                        FuncionarioModel objFunc = funcService.getFuncionario(idFuncionario: UserData.idUser, bGetChild: false);
                        if (objFunc != null)
                            this.currentModel.xId = objFunc.xID;
                    }
                    break;
                default:
                    break;
            }
        }

    }

    public enum ModoInicial
    {
        padrao,
        trocaUsuario,
        trocaEmpresa
    }

}
