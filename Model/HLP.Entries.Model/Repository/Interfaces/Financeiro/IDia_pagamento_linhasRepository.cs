using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Financeiro;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IDia_pagamento_linhasRepository
    {

        void Save(Dia_pagamento_linhasModel objDia_pagamento_linhas);


        void Delete(Dia_pagamento_linhasModel objDia_pagamento_linhas);

        void DeleteLinhasByDia(int idDiaPagamento);

        void Copy(Dia_pagamento_linhasModel objDia_pagamento_linhas);

        Dia_pagamento_linhasModel GetDia_pagamento_linhas(int idDiaPagamentoLinhas);

        List<Dia_pagamento_linhasModel> GetAllDia_pagamento_linhas(int idDiaPagamento);

    }
}
