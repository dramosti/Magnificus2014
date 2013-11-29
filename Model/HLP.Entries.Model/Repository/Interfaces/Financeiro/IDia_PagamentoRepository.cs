using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Financeiro;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IDia_PagamentoRepository
    {
        void Save(Dia_pagamentoModel objDia_pagamento);
        void Delete(Dia_pagamentoModel objDia_pagamento);
        void Copy(Dia_pagamentoModel objDia_pagamento);
        Dia_pagamentoModel GetDia_pagamento(int idDiaPagamento);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
