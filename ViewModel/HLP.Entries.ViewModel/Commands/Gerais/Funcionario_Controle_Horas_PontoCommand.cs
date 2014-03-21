using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class Funcionario_Controle_Horas_PontoCommand
    {
        public Funcionario_Controle_Horas_PontoViewModel objViewModel { get; set; }
        FuncionarioPontoService servico;

        public Funcionario_Controle_Horas_PontoCommand(Funcionario_Controle_Horas_PontoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            servico = new FuncionarioPontoService();
            this.CarregarDados();
        }




        public void CarregarDados()
        {
            try
            {
                List<Funcionario_Controle_Horas_PontoModel> result = servico.GetAllFuncionario_Controle_Horas_Ponto(objViewModel.idFuncionario, objViewModel.data);
                if (result != null)
                {
                    objViewModel.lPonto = new System.Collections.ObjectModel.ObservableCollection<Funcionario_Controle_Horas_PontoModel>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
