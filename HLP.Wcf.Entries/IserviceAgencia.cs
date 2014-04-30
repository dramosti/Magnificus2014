using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    [ServiceContract]
    public interface IserviceAgencia
    {
        [OperationContract]
        int Save(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);

        [OperationContract]
        HLP.Entries.Model.Models.Financeiro.AgenciaModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Financeiro.AgenciaModel Objeto);
    }
}