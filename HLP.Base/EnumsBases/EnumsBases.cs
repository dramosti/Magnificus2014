using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.EnumsBases
{
    public enum statusModel
    {
        nenhum,
        criado,
        alterado,
        excluido
    }

    public enum OperacaoCadastro
    {
        livre,
        criando,
        alterando,
        pesquisando
    }

    public enum statusComponentePosicao
    {
        _default,
        first,
        last
    }
}
