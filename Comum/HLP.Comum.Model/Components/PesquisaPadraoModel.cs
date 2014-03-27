using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Comum.Infrastructure.Extension;
using System.Text.RegularExpressions;
using Ninject;
using HLP.Comum.Model.Repository.Interfaces.Components;

namespace HLP.Comum.Model.Components
{
    public partial class PesquisaPadraoModel : modelBase
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
                        OwnerType = Operadores.tipo.tpString;
                        this.Operador = "Igual na Frase";
                        break;
                    case "int":
                    case "tinyint":
                        OwnerType = Operadores.tipo.tpInteiro;
                        break;
                    case "decimal":
                    case "numeric":
                        OwnerType = Operadores.tipo.tpDecimal;
                        break;
                    case "bit":
                        OwnerType = Operadores.tipo.tpBool;
                        break;
                    case "date":
                    case "datetime":
                    case "datetime2":
                    case "time":
                        OwnerType = Operadores.tipo.tpData;
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

        private bool _bEnablePesquisa = true;

        public bool bEnablePesquisa
        {
            get { return _bEnablePesquisa; }
            set { _bEnablePesquisa = value; base.NotifyPropertyChanged("bEnablePesquisa"); }
        }

        private HLP.Comum.Model.Components.Operadores.tipo _OwnerType;

        public HLP.Comum.Model.Components.Operadores.tipo OwnerType
        {
            get { return _OwnerType; }
            set
            {
                base.NotifyPropertyChanged("OwnerType");
                _OwnerType = value;
                switch (value)
                {
                    case Operadores.tipo.tpInteiro:
                        this.lOperadores = new Operadores(Operadores.tipo.tpInteiro);
                        break;
                    case Operadores.tipo.tpString:
                        this.lOperadores = new Operadores(Operadores.tipo.tpString);
                        break;
                    case Operadores.tipo.tpDecimal:
                        this.lOperadores = new Operadores(Operadores.tipo.tpDecimal);
                        break;
                    case Operadores.tipo.tpData:
                        this.lOperadores = new Operadores(Operadores.tipo.tpData);
                        break;
                    case Operadores.tipo.tpBool:
                        this.lOperadores = new Operadores(Operadores.tipo.tpBool);
                        break;
                    default:
                        break;
                }
            }
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

    public partial class PesquisaPadraoModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sReturn = null;

                if (columnName == "Valor")
                {
                    if (this.Valor != "")
                    {
                        Regex IsInt = new Regex("(([!]?)(([0-9]+[-|;])?)|([<|>|!|&|\"\"|=|>=|<=]?))([0-9]+)$");
                        if (this.OwnerType == Operadores.tipo.tpInteiro)
                        {
                            if (!IsInt.IsMatch(this.Valor))
                                sReturn = "Esse Campo é numérico inteiro. Não digite letras ou valores numéricos com vírgula.";
                        }
                        else if (this.OwnerType == Operadores.tipo.tpString)
                        {
                            string[] Ncontem = { ">", "<", "<=", ">=" };
                            bool tag = false;
                            foreach (var item in Ncontem)
                            {
                                if (this.Valor.StartsWith(item))
                                {
                                    tag = true;
                                    break;
                                }
                            }
                            if (tag == true)
                            {
                                sReturn = "Esse campo nao pode iniciar com caracteres que interfiram em operações. " + Environment.NewLine +
                                                     "Esses caracteres são \">\", \"<\", \"<=\", \">=\"";
                            }
                        }

                        if (sReturn != string.Empty)
                        {
                            this.ValidaValorAtalhoCell();
                            if (this.Valor.Contains("-")) //ENTRE
                            {
                                string[] valores = this.Valor.Split('-');
                                if (valores.Count() <= 2)
                                {
                                    foreach (string item in valores)
                                    {
                                        if (item.Equals(""))
                                            sReturn = "Valor de pesquisa inválido.";
                                    }
                                }
                                else
                                {
                                    sReturn = "Operador Entre só aceita dois valores.";
                                }
                            }
                        }
                    }
                }
                if (string.IsNullOrEmpty(sReturn))
                    bEnablePesquisa = true;
                else
                    bEnablePesquisa = false;
                return sReturn;
            }
        }

        void ValidaValorAtalhoCell()
        {
            if (this.Valor.StartsWith("!"))
            {
                if (this.lOperadores.Contains("Diferente que"))
                {
                    this.Operador = "Diferente que";
                }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("!"), 1).Trim();

            }
            else if (this.Valor.StartsWith("="))
            {
                if (this.lOperadores.Contains(""))
                { }
                this.Operador = "Igual a";
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("="), 1).Trim();
            }
            else if (this.Valor.StartsWith(">="))
            {
                if (this.lOperadores.Contains("Maior Igual que"))
                { this.Operador = "Maior Igual que"; }

                this.Valor = this.Valor.Remove(this.Valor.IndexOf(">="), 2).Trim();
            }
            else if (this.Valor.StartsWith("<="))
            {
                if (this.lOperadores.Contains("Menor Igual que"))
                { this.Operador = "Menor Igual que"; }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("<="), 2).Trim();
            }
            else if (this.Valor.StartsWith(">"))
            {
                if (this.lOperadores.Contains("Maior que"))
                { this.Operador = "Maior que"; }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf(">"), 1).Trim();
            }
            else if (this.Valor.StartsWith("<"))
            {
                if (this.lOperadores.Contains("Menor que"))
                { this.Operador = "Menor que"; }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("<"), 1).Trim();
            }
            else if ((this.Valor.Contains(";")) && (!this.Valor.StartsWith("!")))
            {
                if (this.lOperadores.Contains("Na Lista"))
                { this.Operador = "Na Lista"; }
            }
            else if ((this.Valor.Contains(";")) && (this.Valor.StartsWith("!")))
            {
                if (this.lOperadores.Contains("Não na Lista"))
                { this.Operador = "Não na Lista"; }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("!"), 1).Trim();
            }
            else if ((this.Valor.Contains("-")) && (!this.Valor.StartsWith("!")))
            {
                if (this.lOperadores.Contains("Entre"))
                { this.Operador = "Entre"; }
            }
            else if ((this.Valor.Contains("-")) && (this.Valor.StartsWith("!")))
            {
                if (this.lOperadores.Contains("Não Entre"))
                { this.Operador = "Não Entre"; }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("!"), 1).Trim();
            }
            else if (this.Valor.StartsWith("&"))
            {
                if (this.lOperadores.Contains("Igual na Frase"))
                { this.Operador = "Igual na Frase"; }
                this.Valor = this.Valor.Remove(this.Valor.IndexOf("&"), 1).Trim();
            }
            else if (this.Valor == "\"\"")
            {
                if (this.lOperadores.Contains("Branco"))
                { this.Operador = "Branco"; }
            }
            else if (this.Valor == "!\"\"")
            {
                if (this.lOperadores.Contains("Não Branco"))
                { this.Operador = "Não Branco"; }
            }
        }

        public string GetFilter()
        {
            string sql = "";
            string[] valores;
            List<string> sVal = new List<string>();

            switch (this.Operador)
            {
                case "Entre":
                    #region Codigo_Entre

                    if (this.Valor.Contains('-') == false)
                    {
                        this.Valor += "-" + ValidValue(this.Valor, this.DATA_TYPE);
                    }

                    valores = this.Valor.Split('-');

                    sql = " BETWEEN '" + ValidValue(valores[0], this.DATA_TYPE) + "' AND '" + ValidValue(valores[1], this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Não Entre":
                    #region Codigo_Não_Entre

                    if (this.Valor.Contains('-') == false)
                    {
                        this.Valor += "-" + ValidValue(this.Valor, this.DATA_TYPE);
                    }

                    valores = this.Valor.Split('-');

                    sql = " NOT BETWEEN '" + ValidValue(valores[0], this.DATA_TYPE) + "' AND '" + ValidValue(valores[1], this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Maior que":
                    #region Codigo_Maior_que

                    sql = " > '" + ValidValue(this.Valor, this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Maior Igual que":
                    #region Codigo_Maior_Igual_que

                    sql = " >= '" + ValidValue(this.Valor, this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Menor que":
                    #region Codigo_Menor_que

                    sql = " < '" + ValidValue(this.Valor, this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Menor Igual que":
                    #region Codigo_Menor_Igual_que

                    sql = " <= '" + ValidValue(this.Valor, this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Na Lista":
                    #region Codigo_Na_Lista

                    valores = this.Valor.Split(';');
                    foreach (string i in valores)
                    {
                        if (!String.IsNullOrEmpty(i))
                        {
                            sVal.Add(ValidValue(i, this.DATA_TYPE));
                        }
                    }

                    sql = " IN (";
                    foreach (string item in sVal)
                    {
                        sql += "'" + item + "' ";
                        if (sVal.IndexOf(item) == sVal.Count() - 1)
                        {
                            sql += ")";
                        }
                        else { sql += ","; }

                    }


                    #endregion
                    break;

                case "Não na Lista":
                    #region Codigo_Não_na_Lista

                    valores = this.Valor.Split(';');

                    foreach (string i in valores)
                    {
                        if (!String.IsNullOrEmpty(i))
                        {
                            sVal.Add(ValidValue(i, this.DATA_TYPE));
                        }
                    }

                    sql = " NOT IN (";
                    foreach (string item in sVal)
                    {
                        sql += "'" + item + "' ";
                        if (sVal.IndexOf(item) == sVal.Count() - 1)
                        {
                            sql += ")";
                        }
                        else { sql += ","; }

                    }

                    #endregion
                    break;

                case "Igual a":
                    #region Codigo_Igual_que

                    sql = " = '" + ValidValue(this.Valor, this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Diferente que":
                    #region Codigo_Diferente_que

                    sql = " <> '" + ValidValue(this.Valor, this.DATA_TYPE) + "'";

                    #endregion
                    break;

                case "Começando com":
                    #region Codigo_Começando_com

                    sql = " LIKE '" + ValidValue(this.Valor, this.DATA_TYPE) + "%'";

                    #endregion
                    break;

                case "Igual na Frase":
                    #region Codigo_Igual_na_Frase

                    sql = " LIKE '%" + ValidValue(this.Valor, this.DATA_TYPE) + "%'";

                    #endregion
                    break;

                case "Branco":
                    #region Codigo_Branco

                    sql = " = '' OR " + this.COLUMN_NAME + " IS NULL";

                    #endregion
                    break;

                case "Não Branco":
                    #region Codigo_Não_Branco

                    sql = " <> '' AND " + this.COLUMN_NAME + " IS NOT NULL";

                    #endregion
                    break;
            }
            return sql;

        }

        public string ValidValue(string Value, string sType)
        {
            object objValor = "";
            string strValorCorreto = "";
            try
            {
                switch (sType)
                {
                    case "int":
                        strValorCorreto = "O valor " + Value + " não é um Número Inteiro válido" + Environment.NewLine + "Caso queira Pesquisar mais que um valor,deve-se separar por ';'(ponto e virgula)"; ;
                        objValor = Convert.ToInt32(Value);
                        break;

                    case "tinyint":
                        strValorCorreto = "O valor " + Value + " não é um Número válido" + Environment.NewLine + "Caso queira Pesquisar mais que um valor,deve-se separar por ';'(ponto e virgula)"; ;
                        objValor = Convert.ToByte(Value);
                        break;

                    case "string":
                    case "char":
                    case "varchar":
                    case "nvarchar":
                        objValor = Value;
                        break;

                    case "float":
                        strValorCorreto = "O valor " + Value + " não é um Número Decimal válido";
                        objValor = Convert.ToDouble(Value);
                        break;

                    case "datetime":
                        strValorCorreto = "O valor " + Value + " não é uma Data válida";
                        objValor = Convert.ToDateTime(Convert.ToDateTime(Value).ToShortDateString());
                        break;

                    case "decimal":
                        strValorCorreto = "O valor " + Value + " não é um Número Decimal válido";
                        objValor = Convert.ToDecimal(Value);
                        break;

                    case "bool":
                    case "bit":
                        if (Value.ToUpper().Trim() == "SIM" || Value.ToUpper().Trim() == "TRUE")
                        {
                            objValor = true;
                        }
                        else if (Value.ToUpper().Trim() == "NAO" || Value.ToUpper().Trim() == "NÃO" || Value.ToUpper().Trim() == "FALSE")
                        {
                            objValor = false;
                        }
                        else
                        {
                            strValorCorreto = "O valor " + Value + " não é válido!" + Environment.NewLine + "Valores esperados - SIM, NAO, TRUE, FALSE";
                            throw new System.Exception();

                        }
                        break;

                    case "":
                        objValor = Value;
                        break;
                }

                return objValor.ToString();
            }
            catch (System.Exception)
            {
                throw new System.Exception("Valor Inválido para Pesquisa!"
                    + Environment.NewLine
                    + Environment.NewLine
                    + strValorCorreto);
            }

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
