using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;

namespace HLP.Comum.Model.Components
{
    public class PesquisaPadraoModel : modelBase
    {
        private string _COLUMN_NAME = string.Empty;
        public string COLUMN_NAME
        {
            get { return _COLUMN_NAME; }
            set { _COLUMN_NAME = value; base.NotifyPropertyChanged("COLUMN_NAME"); }
        }

        private string _DATA_TYPE = string.Empty;
        public string DATA_TYPE
        {
            get { return _DATA_TYPE; }
            set
            {
                _DATA_TYPE = value;
                base.NotifyPropertyChanged("DATA_TYPE");
                switch (value)
                {
                    case "varchar":
                    case "char":
                    case "nvarchar":
                        this.lOperadores = new Operadores(Operadores.tipo.tpString);
                        this.Operador = "Igual na Frase";
                        break;
                    case "int":
                    case "tinyint":
                        this.lOperadores = new Operadores(Operadores.tipo.tpInteiro);
                        break;
                    case "decimal":
                    case "numeric":
                        this.lOperadores = new Operadores(Operadores.tipo.tpDecimal);
                        break;
                    case "bit":
                        this.lOperadores = new Operadores(Operadores.tipo.tpBool);
                        break;
                    case "date":
                    case "datetime":
                    case "datetime2":
                    case "time":
                        this.lOperadores = new Operadores(Operadores.tipo.tpData);
                        break;
                    default:
                        break;
                }
            }
        }

        private string _HeaderText = string.Empty;
        public string HeaderText
        {
            get { return _HeaderText; }
            set { _HeaderText = value; base.NotifyPropertyChanged("HeaderText"); }
        }

        private string _Operador = "Igual a";
        public string Operador
        {
            get { return _Operador; }
            set { _Operador = value; base.NotifyPropertyChanged("Operador"); }
        }

        private string _Valor = string.Empty;
        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; base.NotifyPropertyChanged("Valor"); }
        }

        private string _EOU = "E";
        public string EOU
        {
            get { return _EOU; }
            set { _EOU = value; base.NotifyPropertyChanged("EOU"); }
        }


        private ObservableCollection<string> _lOperadores = new ObservableCollection<string>();
        public ObservableCollection<string> lOperadores
        {
            get { return _lOperadores; }
            set { _lOperadores = value; base.NotifyPropertyChanged("lOperadores"); }
        }

        private ObservableCollection<string> _leou = new ObservableCollection<string>((new string[] { "E", "OU" }).ToList());
        public ObservableCollection<string> leou
        {
            get { return _leou; }
            set { _leou = value; base.NotifyPropertyChanged("leou"); }
        }


    }


    public class Operadores : ObservableCollection<string>
    {
        public enum tipo { tpInteiro, tpString, tpDecimal, tpData, tpBool };

        public Operadores(tipo tipoCollection)
        {
            switch (tipoCollection)
            {
                case tipo.tpInteiro:
                    this.Add("Igual a");
                    this.Add("Entre");
                    this.Add("Não Entre");
                    this.Add("Não na Lista");
                    this.Add("Na Lista");
                    this.Add("Diferente que");
                    this.Add("Maior que");
                    this.Add("Maior Igual que");
                    this.Add("Menor que");
                    this.Add("Menor Igual que");
                    break;
                case tipo.tpString:
                    this.Add("Igual a");
                    this.Add("Igual na Frase");
                    this.Add("Começando com");
                    this.Add("Diferente que");
                    this.Add("Branco");
                    this.Add("Não Branco");
                    break;
                case tipo.tpDecimal:
                    this.Add("Igual a");
                    this.Add("Entre");
                    this.Add("Não Entre");
                    this.Add("Na Lista");
                    this.Add("Não na Lista");
                    this.Add("Diferente que");
                    this.Add("Maior que");
                    this.Add("Maior Igual que");
                    this.Add("Menor que");
                    this.Add("Menor Igual que");
                    break;
                case tipo.tpData:
                    this.Add("Igual a");
                    this.Add("Maior que");
                    this.Add("Maior Igual que");
                    this.Add("Menor que");
                    this.Add("Menor Igual que");
                    this.Add("Entre");
                    this.Add("Não Entre");
                    this.Add("Diferente que");
                    break;
                case tipo.tpBool:
                    this.Add("Igual a");
                    break;
                default:
                    break;
            }
        }

    }


}
