using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceDescontosAvista" in both code and config file together.
    [ServiceContract]
    public interface IserviceDescontosAvista
    {
        [OperationContract]
        HLP.Entries.Model.Models.Financeiro.Descontos_AvistaModel GetObject(int idDescontosAvista);
        [OperationContract]
        List<HLP.Entries.Model.Models.Financeiro.Descontos_AvistaModel> GetAll();
        [OperationContract]
        int Save(HLP.Entries.Model.Models.Financeiro.Descontos_AvistaModel desconto);
        [OperationContract]
        bool Delete(int idDescontosAvista);
        [OperationContract]
        int Copy(int idDescontosAvista);
    }
}
