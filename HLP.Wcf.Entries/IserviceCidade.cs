using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCidade" in both code and config file together.
    [ServiceContract]
    public interface IserviceCidade
    {
        [OperationContract]
        CidadeModel getCidade(int idCidade);

        [OperationContract]
        int saveCidade(CidadeModel objCidade);

        [OperationContract]
        bool delCidade(int idCidade);

        [OperationContract]
        int copyCidade(int idCidade);

        [OperationContract]
        IEnumerable<HLP.Comum.Model.Models.modelToComboBox> GetAllCidadeToComboBox();
    }
}
