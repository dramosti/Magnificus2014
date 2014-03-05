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
        HLP.Entries.Model.Models.Gerais.CidadeModel getCidade(int idCidade);

        [OperationContract]
        int? GetCidadeByName(string xName);

        [OperationContract]
        int saveCidade(HLP.Entries.Model.Models.Gerais.CidadeModel objCidade);

        [OperationContract]
        bool delCidade(int idCidade);

        [OperationContract]
        int copyCidade(int idCidade);

        //[OperationContract]
        //IEnumerable<HLP.Entries.Model.Models.modelToComboBox> GetAllCidadeToComboBox();
    }
}
