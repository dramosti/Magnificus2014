using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceFuncionario" in both code and config file together.
    [ServiceContract]
    public interface IserviceFuncionario
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel getFuncionario(int idFuncionario);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel saveFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario);

        [OperationContract]
        bool deleteFuncionario(int idFuncionario);

        [OperationContract]
        int copyFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario);
    }
}
