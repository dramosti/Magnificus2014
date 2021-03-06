﻿using System;
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

    public enum OperationModel
    {
        noAction,
        updating,
        searching
    }

    public enum statusComponentePosicao
    {
        _default,
        fieldId,
        first,
        last
    }

    public enum stFilterQuickSearch
    {
        equal,
        startWith,
        contains
    }

    public enum StVisibilityButtonQuickSearch
    {        
        _default,
        notVisible
    }

    public enum stAcoesHierarquia
    {
        load,
        clear,
        nothing,
    }
}
