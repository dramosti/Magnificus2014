using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class FuncionarioPonto : modelBase
    {
        public FuncionarioPonto() : base() { }

        private int _idFuncionario;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; base.NotifyPropertyChanged("idFuncionario"); }
        }

        private DateTime? _data = null;

        public DateTime? data
        {
            get { return _data; }
            set { _data = value; base.NotifyPropertyChanged("data"); }
        }



    }


    public partial class FuncionarioPonto
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
}
