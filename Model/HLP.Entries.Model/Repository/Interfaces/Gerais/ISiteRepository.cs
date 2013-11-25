using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ISiteRepository
    {
        void Save(SiteModel objSite);
        void Delete(int idSite);
        void Copy(SiteModel objSite);
        SiteModel GetSite(int idSite);
        List<SiteModel> GetAll();

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
