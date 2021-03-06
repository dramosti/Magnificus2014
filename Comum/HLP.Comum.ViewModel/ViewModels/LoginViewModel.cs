﻿using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class LoginViewModel : ViewModelBase<loginModel>
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
                        
                        wcf_Funcionario.FuncionarioModel objFunc = funcService.getFuncionario(idFuncionario: UserData.idUser);
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
