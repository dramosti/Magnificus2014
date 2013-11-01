using System.Collections.ObjectModel;
using HLP.Entries.Model.Models.Crm;

namespace HLP.Entries.Model.Repository.Interfaces.Crm
{
    public interface IRegiaoRepository
    {
        ObservableCollection<RegiaoModel> GetAll();
    }
}
