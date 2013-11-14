using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Components;

namespace HLP.Comum.Model.Repository.Interfaces.Components
{
    public interface IHlpPesquisaRapidaRepository
    {
        string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int? _iValorPesquisa);

    }
}
