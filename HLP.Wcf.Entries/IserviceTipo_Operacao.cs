using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceTipo_Operacao" in both code and config file together.
    [ServiceContract]
    public interface IserviceTipo_Operacao
    {

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Save(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto);

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto);

    }
}
