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
        wcf_FuncionarioControlePonto.Iwcf_Funcionario_Controle_Horas_PontoClient servicoInternet;
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
                        this.servicoInternet = new wcf_FuncionarioControlePonto.Iwcf_Funcionario_Controle_Horas_PontoClient();
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
        public List<HLP.Entries.Model.Models.Gerais.EspelhoPontoModel> GetHorasAtrabalhadasDia(int idFuncionario, DateTime dtDia)
        {

            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetHorasAtrabalhadasDia(idFuncionario, dtDia);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetHorasAtrabalhadasDia(idFuncionario, dtDia);
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

    }

}
