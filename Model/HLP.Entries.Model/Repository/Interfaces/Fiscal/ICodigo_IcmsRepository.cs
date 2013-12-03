using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ICodigo_IcmsRepository
    {
        void Save(Codigo_IcmsModel objCodigo_Icms);
        void Delete(Codigo_IcmsModel objCodigo_Icms);
        void DeleteCodigosByPai(int idCodigoIcmsPai);
        void Copy(Codigo_IcmsModel objCodigo_Icms);
        Codigo_IcmsModel GetCodigo_Icms(int idCodigoIcms);
        List<Codigo_IcmsModel> GetAllCodigo_Icms(int idCodigoIcmsPai);
    }
}
