using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoViewModel : ViewModelBase<Orcamento_ideModel>
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
        public ICommand aprovarDescontosCommand { get; set; }
        public ICommand alterarStatusItenCommand { get; set; }
        public ICommand gerarVersaoCommand { get; set; }

        #endregion

        public OrcamentoViewModel()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/Sales/Orcamento/Template/Buttons_Shurtcut.xaml", UriKind.RelativeOrAbsolute)
            };

            OrcamentoCommands comm = new OrcamentoCommands(objViewModel: this);

            Button btnAprovarDescontos = new Button();
            btnAprovarDescontos.Content = "Aprovar descontos?";
            btnAprovarDescontos.Command = this.aprovarDescontosCommand;
            btnAprovarDescontos.Template = resource["ControlTemplateBotaoAprovar"] as ControlTemplate;

            Button btnEnviarItens = new Button();
            btnEnviarItens.Template = resource["ControlTemplateBotaoEnviar"] as ControlTemplate;

            Button btnConfirmarItens = new Button();
            btnConfirmarItens.Content = "Confirmar Itens";
            btnConfirmarItens.Command = this.alterarStatusItenCommand;
            btnConfirmarItens.CommandParameter = 'c';
            btnConfirmarItens.Template = resource["ControlTemplateBotaoConfirmar"] as ControlTemplate;

            Button btnItensPerdidos = new Button();
            btnItensPerdidos.Content = "Definir Itens Perdidos";
            btnItensPerdidos.Command = this.alterarStatusItenCommand;
            btnItensPerdidos.CommandParameter = 'p';

            Button btnItensCancelados = new Button();
            btnItensCancelados.Content = "Definir Itens Cancelados";
            btnItensCancelados.Command = this.alterarStatusItenCommand;
            btnItensCancelados.CommandParameter = 'e';
            btnItensCancelados.Template = resource["ControlTemplateBotaoCancelado"] as ControlTemplate;

            Button btnGerarVersao = new Button();
            btnGerarVersao.Content = "Gerar Nova Versão";
            btnGerarVersao.Command = this.gerarVersaoCommand;

            this.Botoes.Children.Add(element: btnAprovarDescontos);
            this.Botoes.Children.Add(element: btnEnviarItens);
            this.Botoes.Children.Add(element: btnConfirmarItens);
            this.Botoes.Children.Add(element: btnItensPerdidos);
            this.Botoes.Children.Add(element: btnItensCancelados);
            this.Botoes.Children.Add(element: btnGerarVersao);
        }

        public bool bListaPrecoHabilitado
        {
            get
            {
                if (currentModel != null)
                    return !this.currentModel.bListaPrecoItemHabil;
                return false;
            }
        }

        private Orcamento_ItemModel _currentItem;

        public Orcamento_ItemModel currentItem
        {
            get { return _currentItem; }
            set
            {
                if (value != null)
                {
                    _currentItem = value;
                    this.currentItemImposto = value.objImposto;
                    base.NotifyPropertyChanged(propertyName: "currentItem");
                }
            }
        }


        private Orcamento_Item_ImpostosModel _currentItemImposto;

        public Orcamento_Item_ImpostosModel currentItemImposto
        {
            get { return _currentItemImposto; }
            set
            {
                _currentItemImposto = value;
                base.NotifyPropertyChanged(propertyName: "currentItemImposto");
            }
        }


        #region Métodos Públicos
        public void AtualizarTotais()
        {
            if (currentModel != null)
                this.currentModel.orcamento_Total_Impostos.CalcularTotais();
        }

        #endregion
    }
}
