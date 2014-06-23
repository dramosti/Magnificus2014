using HLP.Base.EnumsBases;
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
        [Inject]
        public HLP.Entries.Model.Repository.Interfaces.Gerais.IFuncionario_BancoHorasRepository funcionario_BancoHorasRepository { get; set; }


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

        public List<HLP.Entries.Model.Models.Gerais.EspelhoPontoModel> GetHorasTrabalhadasDia(int idFuncionario, DateTime dtDia)
        {
            return this.funcionario_Controle_Horas_PontoRepository.GetHorasTrabalhadasDia(idFuncionario, dtDia);
        }
      

        public List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_PontoDia(int idFuncionario, DateTime dtDia)
        {
            return this.funcionario_Controle_Horas_PontoRepository.GetAllFuncionario_Controle_Horas_PontoDia(idFuncionario, dtDia);
        }

        public HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel GetLastFuncionario_Controle_Horas_PontoDia(int idFuncionario, DateTime dtDia)
        {
            return this.funcionario_Controle_Horas_PontoRepository.GetLastFuncionario_Controle_Horas_PontoDia(idFuncionario, dtDia);
        }

        public int GetTotalDiasTrabalhadosMes(int idFuncionario, DateTime dtMes)
        {
            return funcionario_Controle_Horas_PontoRepository.GetTotalDiasTrabalhadosMes(idFuncionario, dtMes);
        }

        public TimeSpan GetHorasATrabalharMes(int idFuncionario, DateTime dtMes)
        {
            return funcionario_Controle_Horas_PontoRepository.GetHorasATrabalharMes(idFuncionario, dtMes);
        }

        public TimeSpan GetTotalBancoHoras(int idFuncionario, DateTime dtMes)
        {
          return  funcionario_BancoHorasRepository.GetTotalBancoHoras(idFuncionario, dtMes);
        }

        public void SaveBancoHoras(HLP.Entries.Model.Models.Gerais.Funcionario_BancoHorasModel objFuncionario_BancoHoras)
        {
            funcionario_BancoHorasRepository.Save(objFuncionario_BancoHoras);
        }

        public List<HLP.Entries.Model.Models.Gerais.Calendario_DetalheModel> GetHorasAtrabalharDia(int idFuncionario, DateTime dtDia)
        {
            return funcionario_Controle_Horas_PontoRepository.GetHorasAtrabalharDia(idFuncionario, dtDia);
        }

        public HLP.Entries.Model.Models.Gerais.Funcionario_BancoHorasModel GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes)
        {
            return funcionario_BancoHorasRepository.GetTotalBancoHorasMesAtual(idFuncionario, dtMes);
        }
        
        public void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes)
        {
            funcionario_BancoHorasRepository.DeleteBancoHorasMes(idFuncionario, dtMes);
        }
        
        public bool ExisteCalendarioDia(int idFuncionario, DateTime dtDia)
        {
            return funcionario_Controle_Horas_PontoRepository.ExisteCalendarioDia(idFuncionario, dtDia);
        }


        public string GetJustificativaPontoDia(int idFuncionario, DateTime data)
        {
            return funcionario_BancoHorasRepository.GetJustificativaPontoDia(idFuncionario, data);
        }
    }
}
