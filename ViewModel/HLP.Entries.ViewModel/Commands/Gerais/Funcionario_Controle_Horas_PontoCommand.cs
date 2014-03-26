using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            objViewModel.commandSalvar = new RelayCommand(execute: paramExec => this.Salvar(win: paramExec),
                 canExecute: paramCanExec => true);
        }


        public void Salvar(object win)
        {
            try
            {
                foreach (int id in this.objViewModel.lPonto.idExcluidos)
                {
                    this.objViewModel.lPonto.Add(
                        new Funcionario_Controle_Horas_PontoModel
                        {
                            idFuncionarioControleHorasPonto = id,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }


                List<Funcionario_Controle_Horas_PontoModel> lreturn = servico.Salvar(objViewModel.idFuncionario, new List<Funcionario_Controle_Horas_PontoModel>(objViewModel.lPonto));
                this.objViewModel.lPonto = null;
                this.objViewModel.lPonto =new ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel>(lreturn);

                ((Window)win).Close();
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }


        public void CarregarDados()
        {
            try
            {
                List<Funcionario_Controle_Horas_PontoModel> result = servico.GetAllFuncionario_Controle_Horas_Ponto(objViewModel.idFuncionario, objViewModel.data);
                if (result != null)
                {
                    objViewModel.lPonto = new ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
