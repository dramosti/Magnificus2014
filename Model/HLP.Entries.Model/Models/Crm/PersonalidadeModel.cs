using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Crm
{
    public partial class PersonalidadeModel : modelBase
    {
        public PersonalidadeModel() : base("Personalidade") { }
        public int? _idPersonalidade;

        [ParameterOrder(Order = 1)]
        public int? idPersonalidade
        {
            get { return _idPersonalidade; }
            set { _idPersonalidade = value; base.NotifyPropertyChanged("idPersonalidade"); }
        }
        [ParameterOrder(Order = 2)]
        public string xPersonalidade { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
    }

    public partial class PersonalidadeModel 
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
