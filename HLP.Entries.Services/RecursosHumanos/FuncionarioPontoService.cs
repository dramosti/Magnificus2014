using HLP.Base.Static;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.RecursosHumanos
{
    public class FuncionarioPontoService
    {
        wcf_Funcionario_ControlePonto.Iwcf_Funcionario_Controle_Horas_PontoClient servicoInternet;
        HLP.Wcf.Entries.wcf_Funcionario_Controle_Horas_Ponto servicoRede;

        public FuncionarioPontoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Funcionario_Controle_Horas_Ponto();
                    }
                    break;
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetAllFuncionario_Controle_Horas_PontoDia(idFuncionario, data);
                    }
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetHorasTrabalhadasDia(idFuncionario, dtDia);
                    }
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetHorasAtrabalharDia(idFuncionario, dtDia);
                    }
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(idFuncionario, lPonto);
                    }
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetTotalDiasTrabalhadosMes(idFuncionario, dtMes);
                    }
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetHorasATrabalharMes(idFuncionario, dtMes);
                    }
                case StConnection.OnlineWeb:
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
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetTotalBancoHoras(idFuncionario, dtMes);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetTotalBancoHoras(idFuncionario, dtMes);
                    }
            }
            return new TimeSpan();

        }
        public Funcionario_BancoHorasModel GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetTotalBancoHorasMesAtual(idFuncionario, dtMes);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetTotalBancoHorasMesAtual(idFuncionario, dtMes);
                    }
            }
            return null;

        }
        public void SaveBancoHoras(HLP.Entries.Model.Models.Gerais.Funcionario_BancoHorasModel objFuncionario_BancoHoras)
        {
            if (Sistema.bOnline == StConnection.OnlineNetwork)
            {
                this.servicoRede.SaveBancoHoras(objFuncionario_BancoHoras);
            }
            else if (Sistema.bOnline == StConnection.OnlineWeb)
            {
                this.servicoInternet.SaveBancoHoras(objFuncionario_BancoHoras);
            }
        }
        public void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes)
        {
            if (Sistema.bOnline == StConnection.OnlineNetwork)
            {
                this.servicoRede.DeleteBancoHorasMes(idFuncionario, dtMes);
            }
            else if (Sistema.bOnline == StConnection.OnlineWeb)
            {
                this.servicoInternet.DeleteBancoHorasMes(idFuncionario, dtMes);
            }
        }
        public bool ExisteCalendarioDia(int idFuncionario, DateTime dtDia)
        {
            if (Sistema.bOnline == StConnection.OnlineNetwork)
            {
                return this.servicoRede.ExisteCalendarioDia(idFuncionario, dtDia);
            }
            else if (Sistema.bOnline == StConnection.OnlineWeb)
            {
                return this.servicoInternet.ExisteCalendarioDia(idFuncionario, dtDia);
            }
            else
                return false;
        }
        public string GetJustificativaPontoDia(int idFuncionario, DateTime data)
        {
            if (Sistema.bOnline == StConnection.OnlineNetwork)
            {
                return this.servicoRede.GetJustificativaPontoDia(idFuncionario, data);
            }
            else if (Sistema.bOnline == StConnection.OnlineWeb)
            {
                return ""; // return this.servicoInternet.ExisteCalendarioDia(idFuncionario, dtDia);
            }
            else
                return "";

        }
    }
}
