using HLP.Entries.Model.Models.GestaoDeMateriais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.GestaoDeMateriais
{
    public interface ILocalizacaoRepository
    {
        void Save(LocalizacaoModel objLocalizacao);
        void Delete(int idLocalizacao);
        int Copy(int idLocalizacao);
        LocalizacaoModel GetLocalizacao(int idLocalizacao);
        List<LocalizacaoModel> GetAllLocalizacao();
    }
}
