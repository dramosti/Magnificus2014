using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceConta_Bancaria" in both code and config file together.
    [ServiceContract]
    public interface IserviceConta_Bancaria
    {

        [OperationContract]
        int Save(HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel Objeto);

        [OperationContract]
        HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel Objeto);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel Objeto);

    }
}
