using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IPlano_pagamento_linhasRepository
    {
        void Save(Plano_pagamento_linhasModel objPlano_pagamento_linhas);
        void Update(Plano_pagamento_linhasModel objPlano_pagamento_linhas);
        void Delete(int idPlanoPagamento);
        void DeleteLinhasByPlano(int idPlanoPagamento);
        void Copy(Plano_pagamento_linhasModel objPlano_pagamento_linhas);
        Plano_pagamento_linhasModel GetPlano_pagamento_linhas(int idLinhasPagamento);
        List<Plano_pagamento_linhasModel> GetAllPlano_pagamento_linhas(int idPlanoPagamento);
    }
}
