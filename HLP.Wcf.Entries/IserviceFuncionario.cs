using HLP.Entries.Model.Models.Gerais;
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
        FuncionarioModel getFuncionario(int idFuncionario);

        [OperationContract]
        int saveFuncionario(FuncionarioModel objFuncionario);

        [OperationContract]
        bool deleteFuncionario(int idFuncionario);

        [OperationContract]
        int copyFuncionario(FuncionarioModel objFuncionario);
    }
}
