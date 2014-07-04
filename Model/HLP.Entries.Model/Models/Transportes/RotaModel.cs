using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class RotaModel : modelComum
    {
        private static RotaModel _currentModel;

        public static RotaModel currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; }
        }


        public RotaModel()
            : base("Rota")
        {
            currentModel = this;

            this.lRota_Praca = new ObservableCollectionBaseCadastros<Rota_pracaModel>();
            this.lRota_Praca.CollectionChanged += lRota_Praca_CollectionChanged;


        }

        public void lRota_Praca_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Rota_pracaModel r in e.NewItems)
                {
                    r.nOrdem = this.lRota_Praca.Max(i => i.nOrdem) + 1;
                }
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

        private int? _idListaPrecoPai;
        [ParameterOrder(Order = 3)]
        public int? idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }

        private bool _Ativo;
        [ParameterOrder(Order = 4)]
        public bool Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }

        private ObservableCollectionBaseCadastros<Rota_pracaModel> _lRota_Praca;

        public ObservableCollectionBaseCadastros<Rota_pracaModel> lRota_Praca
        {
            get { return _lRota_Praca; }
            set
            {
                _lRota_Praca = value;
                base.NotifyPropertyChanged("lRota_Praca");
            }
        }
    }


    public partial class Rota_pracaModel : modelComum
    {
        public Rota_pracaModel()
            : base("Rota_praca")
        {
        }

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
                string xErro = base[columnName];

                if (string.IsNullOrEmpty(value: xErro))
                {
                    if (columnName == "nOrdem")
                    {
                        RotaModel rotaModel = RotaModel.currentModel;

                        if (rotaModel != null)
                            if (rotaModel.GetOperationModel() == Base.EnumsBases.OperationModel.updating)
                            {
                                if (rotaModel != null)
                                    if (rotaModel.lRota_Praca.Count(i => i.nOrdem == this.nOrdem) > 1)
                                    {
                                        xErro = "Número de ordem da rota já foi informada.";
                                    }
                            }
                    }
                }

                return xErro;
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
