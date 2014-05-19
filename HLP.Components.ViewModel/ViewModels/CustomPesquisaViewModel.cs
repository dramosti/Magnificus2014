using HLP.Components.Model.Models;
using HLP.Components.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class CustomPesquisaViewModel : INotifyPropertyChanged
    {
        public ICommand searchCommand { get; set; }
        public ICommand insertCommand { get; set; }
        public ICommand goToRecordCommand { get; set; }

        Pesquisa_RapidaService objService;

        public CustomPesquisaViewModel()
        {
            this.objService = new Pesquisa_RapidaService();
            this.pesquisaModel = new CustomPesquisaModel();
        }

        private CustomPesquisaModel _pesquisaModel;

        public CustomPesquisaModel pesquisaModel
        {
            get { return _pesquisaModel; }
            set
            {
                _pesquisaModel = value;
                this.NotifyPropertyChanged(propertyName: "pesquisaModel");
            }
        }


        public void GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {
            this.pesquisaModel.xDisplay =
            objService.GetValorDisplay(
                _TableView: _TableView,
                _Items: _Items,
                _FieldPesquisa: _FieldPesquisa,
                idEmpresa: idEmpresa,
                _iValorPesquisa: _iValorPesquisa);
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
