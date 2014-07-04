using HLP.Base.ClassesBases;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Comum.Model.Models
{
    public class modelComum : modelBase
    {
        public modelComum()
        {
            this.lDocumentos = new ObservableCollectionBaseCadastros<DocumentosModel>();
        }


        private ObservableCollectionBaseCadastros<DocumentosModel> _lDocumentos;

        public ObservableCollectionBaseCadastros<DocumentosModel> lDocumentos
        {
            get { return _lDocumentos; }
            set
            {
                _lDocumentos = value;
                base.NotifyPropertyChanged(propertyName: "lDocumentos");
            }
        }
        
        public modelComum(string xTabela)
            : base(xTabela: xTabela)
        {
            this.lDocumentos = new ObservableCollectionBaseCadastros<DocumentosModel>();
        }

        protected override void NotifyPropertyChanged(string propertyName)
        {
            base.NotifyPropertyChanged(propertyName);
        }
    }
}
