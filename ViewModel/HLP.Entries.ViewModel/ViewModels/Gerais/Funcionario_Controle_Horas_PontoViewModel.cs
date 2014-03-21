using HLP.Comum.ViewModel.ViewModels;
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
    public class Funcionario_Controle_Horas_PontoViewModel : ViewModelBase<Funcionario_Controle_Horas_PontoCommand>
    {
        
        #region Icommands
        public ICommand commandCarregar { get; set; }
        public ICommand commandSalvar { get; set; }
        public ICommand commandCancelar { get; set; }
        #endregion

        Funcionario_Controle_Horas_PontoCommand command;
        public Funcionario_Controle_Horas_PontoViewModel(int idFuncionario, DateTime data)
        {
            this.data = data;
            this.idFuncionario = idFuncionario;
            command = new Funcionario_Controle_Horas_PontoCommand(this);
        }

        private ObservableCollection<Funcionario_Controle_Horas_PontoModel> _lPonto = new ObservableCollection<Funcionario_Controle_Horas_PontoModel>();
        public ObservableCollection<Funcionario_Controle_Horas_PontoModel> lPonto
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


    }
}
