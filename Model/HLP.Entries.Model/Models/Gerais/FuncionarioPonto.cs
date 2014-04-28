using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class FuncionarioPonto : modelBase
    {
        public FuncionarioPonto() : base() {}

        private int _idFuncionario;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; base.NotifyPropertyChanged("idFuncionario"); }
        }

        private DateTime _data = DateTime.Today;
        public DateTime data
        {
            get { return _data; }
            set { _data = value; base.NotifyPropertyChanged("data"); }
        }
        
        private Funcionario_BancoHorasModel _objFuncBancoHoras;
        public Funcionario_BancoHorasModel objFuncBancoHoras
        {
            get { return _objFuncBancoHoras; }
            set
            {
                _objFuncBancoHoras = value;
                base.NotifyPropertyChanged(propertyName: "objFuncBancoHoras");
            }
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
