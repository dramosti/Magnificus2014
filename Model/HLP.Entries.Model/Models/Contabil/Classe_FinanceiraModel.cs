using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Contabil
{
    public partial class Classe_FinanceiraModel : modelComum
    {
        private int? _idClasseFinanceira;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClasseFinanceira
        {
            get { return _idClasseFinanceira; }
            set
            {
                _idClasseFinanceira = value;
                base.NotifyPropertyChanged(propertyName: "idClasseFinanceira");
            }
        }
        private string _xClasseFinanceira;
        [ParameterOrder(Order = 2)]
        public string xClasseFinanceira
        {
            get { return _xClasseFinanceira; }
            set
            {
                _xClasseFinanceira = value;
                base.NotifyPropertyChanged(propertyName: "xClasseFinanceira");
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
        private byte _stClasse;
        [ParameterOrder(Order = 4)]
        public byte stClasse
        {
            get { return _stClasse; }
            set
            {
                _stClasse = value;
                base.NotifyPropertyChanged(propertyName: "stClasse");
            }
        }
        private byte _stNatureza;
        [ParameterOrder(Order = 5)]
        public byte stNatureza
        {
            get { return _stNatureza; }
            set
            {
                _stNatureza = value;
                base.NotifyPropertyChanged(propertyName: "stNatureza");
            }
        }
        private byte _stDespesasFixas;
        [ParameterOrder(Order = 6)]
        public byte stDespesasFixas
        {
            get { return _stDespesasFixas; }
            set
            {
                _stDespesasFixas = value;
                base.NotifyPropertyChanged(propertyName: "stDespesasFixas");
            }
        }

    }


    public partial class Classe_FinanceiraModel 
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
