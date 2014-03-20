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
    }
}
