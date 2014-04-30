using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_RamoAtividade" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_RamoAtividade
    {
        [OperationContract]
        Ramo_atividadeModel GetObject(int id);

        [OperationContract]
        int SaveObject(Ramo_atividadeModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Ramo_atividadeModel CopyObject(int id);
    }
}
