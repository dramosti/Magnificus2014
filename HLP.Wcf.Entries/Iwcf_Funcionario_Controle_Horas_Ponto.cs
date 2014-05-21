using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Funcionario_Controle_Horas_Ponto" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Funcionario_Controle_Horas_Ponto
    {
        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> Save(int idFuncionario, List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lobjFuncionario_Controle_Horas_Ponto);
        [OperationContract]
        void Delete(int idFuncionarioControleHorasPonto);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel GetFuncionario_Controle_Horas_Ponto(int idFuncionarioControleHorasPonto);
        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, DateTime data);
        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.EspelhoPontoModel> GetHorasTrabalhadasDia(int idFuncionario, DateTime dtDia);
        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_PontoDia(int idFuncionario, DateTime dtDia);
        [OperationContract]
        int GetTotalDiasTrabalhadosMes(int idFuncionario, DateTime dtMes);
        [OperationContract]
        TimeSpan GetHorasATrabalharMes(int idFuncionario, DateTime dtMes);
        [OperationContract]
        TimeSpan GetTotalBancoHoras(int idFuncionario, DateTime dtMes);
        [OperationContract]
        void SaveBancoHoras(HLP.Entries.Model.Models.Gerais.Funcionario_BancoHorasModel objFuncionario_BancoHoras);
        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.Calendario_DetalheModel> GetHorasAtrabalharDia(int idFuncionario, DateTime dtDia);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Funcionario_BancoHorasModel GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes);
        [OperationContract]
        void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes);
        [OperationContract]
        bool ExisteCalendarioDia(int idFuncionario, DateTime dtDia);
        /// <summary>
        /// Get a justificativa do ponto diário.
        /// </summary>
        /// <param name="idFuncionario"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [OperationContract]
        string GetJustificativaPontoDia(int idFuncionario, DateTime data);

    }
}
