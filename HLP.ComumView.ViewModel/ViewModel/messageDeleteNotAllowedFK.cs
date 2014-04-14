using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.ViewModel.ViewModel
{
    public class messageDeleteNotAllowedFK : ViewModelBase<RecordsSqlModel>
    {        
        private string _xTabela;

        public string xTabela
        {
            get { return _xTabela; }
            set
            {
                _xTabela = value;
                base.NotifyPropertyChanged(propertyName: "xTabela");
            }
        }
        
        private string _xCampo;

        public string xCampo
        {
            get { return _xCampo; }
            set
            {
                _xCampo = value;
                base.NotifyPropertyChanged(propertyName: "xCampo");
            }
        }
                
        private string _xValor;

        public string xValor
        {
            get { return _xValor; }
            set
            {
                _xValor = value;
                base.NotifyPropertyChanged(propertyName: "xValor");
            }
        }
        
        private List<RecordsSqlModel> _lRecords;

        public List<RecordsSqlModel> lRecords
        {
            get { return _lRecords; }
            set
            {
                _lRecords = value;
                base.NotifyPropertyChanged(propertyName: "lRecords");
            }
        }
        
    }
}
