using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Funcionario_Controle_Horas_Ponto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Funcionario_Controle_Horas_Ponto.svc or wcf_Funcionario_Controle_Horas_Ponto.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Funcionario_Controle_Horas_Ponto : Iwcf_Funcionario_Controle_Horas_Ponto
    {
        [Inject]
        public HLP.Entries.Model.Repository.Interfaces.Gerais.IFuncionario_Controle_Horas_PontoRepository funcionario_Controle_Horas_PontoRepository { get; set; }

        public wcf_Funcionario_Controle_Horas_Ponto()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> Save(int idFuncionario, List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lobjFuncionario_Controle_Horas_Ponto)
        {
            try
            {
                this.funcionario_Controle_Horas_PontoRepository.BeginTransaction();
                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel item in lobjFuncionario_Controle_Horas_Ponto)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idFuncionario = idFuncionario;
                                this.funcionario_Controle_Horas_PontoRepository.Save(item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.funcionario_Controle_Horas_PontoRepository.Delete(idFuncionarioControleHorasPonto: (int)item.idFuncionarioControleHorasPonto);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.funcionario_Controle_Horas_PontoRepository.RollbackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
            finally
            {
                this.funcionario_Controle_Horas_PontoRepository.CommitTransaction();                
            }
            return lobjFuncionario_Controle_Horas_Ponto;
        }

        public void Delete(int idFuncionarioControleHorasPonto)
        {
            this.funcionario_Controle_Horas_PontoRepository.Delete(idFuncionarioControleHorasPonto);
        }

        public HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel GetFuncionario_Controle_Horas_Ponto(int idFuncionarioControleHorasPonto)
        {
            return this.funcionario_Controle_Horas_PontoRepository.GetFuncionario_Controle_Horas_Ponto(idFuncionarioControleHorasPonto);
        }

        public List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, DateTime data)
        {
            return this.funcionario_Controle_Horas_PontoRepository.GetAllFuncionario_Controle_Horas_Ponto(idFuncionario, data);
        }

       
    }
}
