﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;
using System.Reflection;
using HLP.Comum.Model.StaticModels;

namespace HLP.Comum.Model.Models
{
    public class modelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public List<campoSqlModel> lcamposSqlNotNull;
        camposBaseDadosService.IcamposBaseDadosServiceClient service = new camposBaseDadosService.IcamposBaseDadosServiceClient();

        public statusModel status { get; set; }

        public modelBase()
        {
        }

        public modelBase(string xTabela)
        {
            if (lCamposSqlNotNull._lCamposSqlNotNull.Count(i => i.xTabela == xTabela)
                == 0)
            {
                CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                lCampos.xTabela = xTabela;
                //TODO: Chamar wcf para retornar campos
                lCamposSqlNotNull.AddCampoSqlNotNull(objCamposSqlNotNull: lCampos);
            }
            else
            {
                lcamposSqlNotNull = lCamposSqlNotNull._lCamposSqlNotNull.FirstOrDefault(i => i.xTabela
                    == xTabela).lCamposSqlModel;
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (this.status == statusModel.nenhum)
                    this.status = statusModel.alterado;
            }
        }

        #endregion

        #region Validação de Dados

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string this[string columnName]
        {
            get
            {
                return this.GetValidationErrorEmpty(columnName: columnName, objeto: this);
            }
        }

        #endregion

        public void CarregaEmptyString()
        {
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string) && pi.Name != "Item" && pi.Name != "Error")
                {
                    pi.SetValue(this, "");
                }
            }
        }

        protected string GetValidationErrorEmpty<T>(string columnName, T objeto) where T : class
        {
            if (lcamposSqlNotNull != null)
            {
                campoSqlModel campo = lcamposSqlNotNull.FirstOrDefault(predicate:
                    i => i.COLUMN_NAME == columnName);
                if (campo != null)
                {
                    object valor = objeto.GetType().GetProperty(columnName).GetValue(objeto);
                    if (campo.TYPE == "F " && valor == "0")
                        return "Necessário que campo possua valor!";
                    else if ((campo.TYPE == null || campo.TYPE == "UQ")
                        && (valor == "" || valor == null))
                    {
                        return "Necessário que campo possua valor!";
                    }
                }
            }
            return null;
        }
    }
}
