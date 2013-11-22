using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ICondicao_pagamentoRepository
    {
        Condicao_pagamentoModel GetCondicao(int idCondicaoPagamento);
        void Save(Condicao_pagamentoModel condicao);
        void Delete(int idCondicaoPagamento);
        int Copy(int idCondicaoPagamento);
    }
}
