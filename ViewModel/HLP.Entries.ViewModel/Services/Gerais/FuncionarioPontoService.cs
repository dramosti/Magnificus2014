using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Gerais
{
    public class FuncionarioPontoService
    {
        wcf_Funcionario_ControlePonto.Iwcf_Funcionario_Controle_Horas_PontoClient servicoInternet;
        HLP.Wcf.Entries.wcf_Funcionario_Controle_Horas_Ponto servicoRede;

        public FuncionarioPontoService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Funcionario_Controle_Horas_Ponto();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_Funcionario_ControlePonto.Iwcf_Funcionario_Controle_Horas_PontoClient();
                    }
                    break;
            }
        }

        public List<Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, DateTime data)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetAllFuncionario_Controle_Horas_PontoDia(idFuncionario, data);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetAllFuncionario_Controle_Horas_PontoDia(idFuncionario, data);
                    }
            }
            return null;

        }
        public List<HLP.Entries.Model.Models.Gerais.EspelhoPontoModel> GetHorasTrabalhadasDia(int idFuncionario, DateTime dtDia)
        {

            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetHorasTrabalhadasDia(idFuncionario, dtDia);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetHorasTrabalhadasDia(idFuncionario, dtDia);
                    }
            }
            return null;
        }
        public List<HLP.Entries.Model.Models.Gerais.Calendario_DetalheModel> GetHorasAtrabalhadarDia(int idFuncionario, DateTime dtDia)
        {

            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetHorasAtrabalharDia(idFuncionario, dtDia);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetHorasAtrabalharDia(idFuncionario, dtDia);
                    }
            }
            return null;
        }
        public List<Funcionario_Controle_Horas_PontoModel> Salvar(int idFuncionario, List<Funcionario_Controle_Horas_PontoModel> lPonto)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Save(idFuncionario, lPonto);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.Save(idFuncionario, lPonto);
                    }
            }
            return null;
        }
        public int GetTotalDiasTrabalhadosMes(int idFuncionario, DateTime dtMes)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetTotalDiasTrabalhadosMes(idFuncionario, dtMes);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetTotalDiasTrabalhadosMes(idFuncionario, dtMes);
                    }
            }
            return 0;
        }
        public TimeSpan GetHorasATrabalharMes(int idFuncionario, DateTime dtMes)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetHorasATrabalharMes(idFuncionario, dtMes);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetHorasATrabalharMes(idFuncionario, dtMes);
                    }
            }
            return new TimeSpan();
        }
        public TimeSpan GetTotalBancoHoras(int idFuncionario, DateTime dtMes)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetTotalBancoHoras(idFuncionario, dtMes);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetTotalBancoHoras(idFuncionario, dtMes);
                    }
            }
            return new TimeSpan();

        }

        public TimeSpan GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetTotalBancoHorasMesAtual(idFuncionario, dtMes);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetTotalBancoHorasMesAtual(idFuncionario, dtMes);
                    }
            }
            return new TimeSpan();

        }

        public void SaveBancoHoras(HLP.Entries.Model.Models.Gerais.Funcionario_BancoHorasModel objFuncionario_BancoHoras)
        {
            if (Sistema.bOnline == TipoConexao.OnlineRede)
            {
                this.servicoRede.SaveBancoHoras(objFuncionario_BancoHoras);
            }
            else if (Sistema.bOnline == TipoConexao.Offline)
            {
                this.servicoInternet.SaveBancoHoras(objFuncionario_BancoHoras);
            }
        }
        public void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes)
        {
            if (Sistema.bOnline == TipoConexao.OnlineRede)
            {
                this.servicoRede.DeleteBancoHorasMes(idFuncionario,dtMes);
            }
            else if (Sistema.bOnline == TipoConexao.Offline)
            {
                this.servicoInternet.DeleteBancoHorasMes(idFuncionario, dtMes);
            }
        }
    }

}
