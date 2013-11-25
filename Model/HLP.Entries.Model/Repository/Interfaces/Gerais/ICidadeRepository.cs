using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ICidadeRepository
    {
        ObservableCollection<CidadeModel> GetCidadeByUf(int idUf);
        int Copy(int idCidade);
        void Save(CidadeModel cidade);
        void Delete(int idCidade);
        CidadeModel GetCidade(int idCidade);
        IEnumerable<HLP.Comum.Model.Models.modelToComboBox> GetAllCidadeToComboBox();
    }
}
