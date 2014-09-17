using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.ViewModel.Commands.Transportes;
using HLP.Comum.ViewModel.ViewModel;
using System.Collections;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Threading;

namespace HLP.Entries.ViewModel.ViewModels.Transportes
{
    public class RotaViewModel : viewModelComum<RotaModel>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion

        public RotaViewModel()
        {
            commands = new RotaCommand(objViewModel: this);
            this.getCidade = commands.getCidade;
        }

        RotaCommand commands;

        public void Rota_PracaSort()
        {
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(source: this.currentModel.lRota_Praca);

            lcv.CustomSort = new Rota_PracaSortByNOrdem();
        }


        private Func<int, bool, object> _getCidade;

        public Func<int, bool, object> getCidade
        {
            get { return _getCidade; }
            set { _getCidade = value; }
        }
        
    }

    public class Rota_PracaSortByNOrdem : IComparer
    {
        public int Compare(object x, object y)
        {
            if ((x as Rota_pracaModel).nOrdem < (y as Rota_pracaModel).nOrdem) return -1;
            else if ((x as Rota_pracaModel).nOrdem > (y as Rota_pracaModel).nOrdem) return 1;
            else return 0;
        }
    }
}
