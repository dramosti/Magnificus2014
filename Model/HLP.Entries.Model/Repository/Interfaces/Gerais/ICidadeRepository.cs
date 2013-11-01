using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Crm;

namespace HLP.Entries.Model.Repository.Interfaces.Crm
{
    public interface ICidadeRepository
    {
        ObservableCollection<CidadeModel> GetCidadeByUf(int idUf);
    }
}
