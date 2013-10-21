using System.Collections.ObjectModel;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IRegiaoRepository
    {
        ObservableCollection<RegiaoModel> GetAll();
    }
}
