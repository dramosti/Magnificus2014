using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class Funcionario_Controle_Horas_PontoViewModel : ViewModelBase<Funcionario_Controle_Horas_PontoModel>
    {
        
        #region Icommands
        public ICommand commandFeriasAbono { get; set; }
        public ICommand commandFaltou { get; set; }

        public ICommand commandCarregar { get; set; }
        public ICommand commandSalvar { get; set; }
        public ICommand commandCancelar { get; set; }
        #endregion

        public object dgvLancamentos { get; set; }

        Funcionario_Controle_Horas_PontoCommand command;
        public Funcionario_Controle_Horas_PontoViewModel(int idFuncionario, DateTime data, object dgvLancamentos)
        {
            this.dgvLancamentos = dgvLancamentos;
            this.data = data;
            this.idFuncionario = idFuncionario;
            command = new Funcionario_Controle_Horas_PontoCommand(this);
            this.bAlterou = false;
        }

        public bool bAlterou { get; set; }



        private ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel> _lPonto = new ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel>();
        public ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel> lPonto
        {
            get { return _lPonto ; }
            set { _lPonto  = value; base.NotifyPropertyChanged("lPonto"); }
        }
        private int _idFuncionario;
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; base.NotifyPropertyChanged("idFuncionario"); }
        }
        private DateTime _data;
        public DateTime data
        {
            get { return _data; }
            set { _data = value; base.NotifyPropertyChanged("data"); }
        }

        
        private bool _bFaltou;

        public bool bFaltou
        {
            get { return _bFaltou; }
            set
            {
                _bFaltou = value;
                base.NotifyPropertyChanged(propertyName: "bFaltou");
            }
        }

        
        private bool _bAbono;

        public bool bAbono
        {
            get { return _bAbono; }
            set
            {
                _bAbono = value;
                base.NotifyPropertyChanged(propertyName: "bAbono");
            }
        }
        
        


    }
}
