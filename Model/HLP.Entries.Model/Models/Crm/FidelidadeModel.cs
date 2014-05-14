using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Crm
{
    public partial class FidelidadeModel : modelBase
    {
        public FidelidadeModel() : base("Fidelidade") { }
        private int? _idFidelidade;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFidelidade
        {
            get { return _idFidelidade; }
            set
            {
                _idFidelidade = value;
                base.NotifyPropertyChanged(propertyName: "idFidelidade");
            }
        }
        private string _xFidelidade;
        [ParameterOrder(Order = 2)]
        public string xFidelidade
        {
            get { return _xFidelidade; }
            set
            {
                _xFidelidade = value;
                base.NotifyPropertyChanged(propertyName: "xFidelidade");
            }
        }
        private string _xDescricao;
        [ParameterOrder(Order = 3)]
        public string xDescricao
        {
            get { return _xDescricao; }
            set
            {
                _xDescricao = value;
                base.NotifyPropertyChanged(propertyName: "xDescricao");
            }
        }

    }
    public partial class FidelidadeModel
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
