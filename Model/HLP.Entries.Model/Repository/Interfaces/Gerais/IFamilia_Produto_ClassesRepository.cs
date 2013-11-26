using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFamilia_Produto_ClassesRepository
    {
        void Save(Familia_Produto_ClassesModel objFamilia_Produto_Classes);
        void Delete(int idFamilia_Produto);
        void DeleteFamiliasPorFamilia(int idFamiliaProduto);
        void Copy(Familia_Produto_ClassesModel objFamilia_Produto_Classes);
        Familia_Produto_ClassesModel GetFamilia_Produto_Classes(int idFamilia_Produto_Classes);
        List<Familia_Produto_ClassesModel> GetAllFamilia_Produto_Classes(int idFamiliaProduto);

    }
}
