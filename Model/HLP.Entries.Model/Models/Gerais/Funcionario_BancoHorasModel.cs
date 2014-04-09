using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Funcionario_BancoHorasModel : modelBase
    {
        public Funcionario_BancoHorasModel() : base() { }

        private int? _idFuncionarioBancoHoras;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFuncionarioBancoHoras
        {
            get { return _idFuncionarioBancoHoras; }
            set
            {
                _idFuncionarioBancoHoras = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionarioBancoHoras");
            }
        }
        private int _idFuncionario;
        [ParameterOrder(Order = 2)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }

        private string _xMesAno;
        [ParameterOrder(Order = 3)]
        public string xMesAno
        {
            get { return _xMesAno; }
            set
            {
                _xMesAno = value;
                base.NotifyPropertyChanged(propertyName: "xMesAno");
            }
        }

        private String _tBancoHoras;
        [ParameterOrder(Order = 4)]
        public string tBancoHoras
        {
            get { return _tBancoHoras; }
            set
            {
                _tBancoHoras = value;
                base.NotifyPropertyChanged(propertyName: "tBancoHoras");
            }
        }

    }


    public partial class Funcionario_BancoHorasModel
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
