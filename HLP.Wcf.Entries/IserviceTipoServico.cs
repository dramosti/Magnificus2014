using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceTipoServico" in both code and config file together.
    [ServiceContract]
    public interface IserviceTipoServico
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Tipo_servicoModel GetTipo(int idTipoServico);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Tipo_servicoModel Save(HLP.Entries.Model.Models.Gerais.Tipo_servicoModel tipo);
        [OperationContract]
        bool Delete(int idTipoServico);
        [OperationContract]
        int Copy(int idTipoServico);
    }
}
