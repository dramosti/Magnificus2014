using HLP.Components.Model.Models;
using HLP.Components.Services;
using HLP.Components.ViewModel.Commands;
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
        CustomPesquisaCommands comm;

        public CustomPesquisaViewModel()
        {
            this.objService = new Pesquisa_RapidaService();
            this.pesquisaModel = new CustomPesquisaModel();
            this.comm = new CustomPesquisaCommands(objViewModel: this);
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


        public void GetValorDisplay(string _TableView, List<string> _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {

            if (_Items != null)
            {

                string[] itens = _Items.ToArray();

                this.pesquisaModel.xDisplay =
                objService.GetValorDisplay(
                    _TableView: _TableView,
                    _Items: itens,
                    _FieldPesquisa: _FieldPesquisa,
                    idEmpresa: idEmpresa,
                    _iValorPesquisa: _iValorPesquisa);
            }
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
