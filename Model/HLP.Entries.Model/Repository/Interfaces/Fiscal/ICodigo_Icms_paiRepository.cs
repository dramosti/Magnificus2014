using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ICodigo_Icms_paiRepository
    {
        void Save(Codigo_Icms_paiModel objCodigo_Icms_pai);
        void Delete(int id);
        void Copy(Codigo_Icms_paiModel objCodigo_Icms_pai);
        Codigo_Icms_paiModel GetCodigo_Icms_pai(int idCodigoIcmsPai);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
