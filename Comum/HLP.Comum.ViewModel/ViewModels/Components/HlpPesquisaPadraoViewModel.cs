using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Comum.ViewModel.Commands.Components;
using HLP.Dependencies;
using Ninject;

namespace HLP.Comum.ViewModel.ViewModels.Components
{
    public class HlpPesquisaPadraoViewModel : modelBase
    {
        HlpPesquisaPadraoCommands objCommands;

        [Inject]
        public IHlpPesquisaPadraoRepository iHlpPesquisaPadraoRepository { get; set; }

        private ObservableCollection<PesquisaPadraoModel> _lFilers;

        public ObservableCollection<PesquisaPadraoModel> lFilers
        {
            get { return _lFilers; }
            set
            {
                _lFilers = value;
                base.NotifyPropertyChanged("lFilers");
            }
        }

        private string _sView = string.Empty;
        public string sView
        {
            get { return _sView; }
            set { _sView = value; }
        }

        public HlpPesquisaPadraoViewModel(string sView)
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

            this.sView = sView;
            objCommands = new HlpPesquisaPadraoCommands(objViewModel: this);
            this.CarregaInformationTable(this.sView);
        }


        private void CarregaInformationTable(object param)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetTableInformation_Background);
            if (param != null)
                bw.RunWorkerAsync(argument: param);
        }

        private void GetTableInformation_Background(object sender, DoWorkEventArgs e)
        {
            this.lFilers = iHlpPesquisaPadraoRepository.GetTableInformation(sViewName: e.Argument.ToString());
        }




    }
}
