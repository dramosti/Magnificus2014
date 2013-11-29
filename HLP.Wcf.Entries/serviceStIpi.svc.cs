using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceStIpi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceStIpi.svc or serviceStIpi.svc.cs at the Solution Explorer and start debugging.
    public class serviceStIpi : IserviceStIpi
    {
        [Inject]
        public ISituacao_tributaria_ipiRepository situacao_tributaria_ipiRepository { get; set; }


        public serviceStIpi()
        {
        }

        public int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel Objeto)
        {
            throw new NotImplementedException();
        }

        public HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel GetObjeto(int idObjeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel Objeto)
        {
            throw new NotImplementedException();
        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
