using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class RotaModel : modelBase
    {
        public RotaModel() : base("Rota") 
        {
            this.lRota_Praca = new ObservableCollectionBaseCadastros<Rota_pracaModel>();
        }

        private int? _idRota;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idRota
        {
            get { return _idRota; }
            set { _idRota = value; base.NotifyPropertyChanged("idRota"); }
        } 

        [ParameterOrder(Order = 2)]
        public string xRota { get; set; }

        [ParameterOrder(Order = 3)]
        public int idListaPrecoPai { get; set; }

        [ParameterOrder(Order = 4)]
        public bool Ativo { get; set; }

        private ObservableCollectionBaseCadastros<Rota_pracaModel> _lRota_Praca;

        public ObservableCollectionBaseCadastros<Rota_pracaModel> lRota_Praca
        {
            get { return _lRota_Praca; }
            set { _lRota_Praca = value; base.NotifyPropertyChanged("lRota_Praca"); }
        }
    }


    public partial class Rota_pracaModel : modelBase
    {
        public Rota_pracaModel() : base("Rota_praca") { }

        private int? _idRotaPraca;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idRotaPraca
        {
            get { return _idRotaPraca; }
            set
            {
                _idRotaPraca = value;
                base.NotifyPropertyChanged(propertyName: "idRotaPraca");
            }
        }
        private int _nOrdem;
        [ParameterOrder(Order = 2)]
        public int nOrdem
        {
            get { return _nOrdem; }
            set
            {
                _nOrdem = value;
                base.NotifyPropertyChanged(propertyName: "nOrdem");
            }
        }
        private int? _nDistanciaProximaCidade;
        [ParameterOrder(Order = 3)]
        public int? nDistanciaProximaCidade
        {
            get { return _nDistanciaProximaCidade; }
            set
            {
                _nDistanciaProximaCidade = value;
                base.NotifyPropertyChanged(propertyName: "nDistanciaProximaCidade");
            }
        }
        private int _idCidade;
        [ParameterOrder(Order = 4)]
        public int idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }
        private int _idRota;
        [ParameterOrder(Order = 5)]
        public int idRota
        {
            get { return _idRota; }
            set
            {
                _idRota = value;
                base.NotifyPropertyChanged(propertyName: "idRota");
            }
        }

    }

    #region validação
    public partial class Rota_pracaModel 
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class RotaModel 
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
    #endregion

}
