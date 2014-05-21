using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCalendario" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Calendario
    {
        [OperationContract]
         HLP.Entries.Model.Models.Gerais.CalendarioModel Save(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel, int idUsuario);

        [OperationContract]
         HLP.Entries.Model.Models.Gerais.CalendarioModel GetObjeto(int idObjeto, bool bGetChild = true);

        [OperationContract]
         bool Delete(HLP.Entries.Model.Models.Gerais.CalendarioModel objModel, int idUsuario);

        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.Calendario_IntervalosModel> GetIntervalos(int idCalendario);
        
    }
}
