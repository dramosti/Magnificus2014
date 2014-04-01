using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Repository.Interfaces
{
    public interface IHlpPesquisaRapidaRepository
    {
        string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa);
    }
}
