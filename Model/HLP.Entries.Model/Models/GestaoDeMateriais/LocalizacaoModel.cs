using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.GestaoDeMateriais
{
    public partial class LocalizacaoModel : modelComum
    {
        public LocalizacaoModel()
        {

        }

        private int? _idLocalizacao;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idLocalizacao
        {
            get { return _idLocalizacao; }
            set
            {
                _idLocalizacao = value;
                base.NotifyPropertyChanged(propertyName: "idLocalizacao");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 2)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
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

    public partial class LocalizacaoModel
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
