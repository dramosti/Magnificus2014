using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;

namespace HLP.Entries.Model.Models.Gerais
{
    public class RegiaoModel 
    {
        public int? _idRegiao;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idRegiao
        {
            get { return _idRegiao; }
            set
            {
                _idRegiao = value;
            }
        }

        public string _xRegiao;

        [ParameterOrder(Order = 2)]
        public string xRegiao
        {
            get { return _xRegiao; }
            set { _xRegiao = value; }
        }

        public int _idPais;

        [ParameterOrder(Order = 3)]
        public int idPais
        {
            get { return _idPais; }
            set { _idPais = value;}
        }



      
    }
}
