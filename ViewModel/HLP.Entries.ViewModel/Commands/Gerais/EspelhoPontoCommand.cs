using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class EspelhoPontoCommand
    {
        FuncionarioPontoService servico;
        public EspelhoPontoViewModel objViwModel;


        public EspelhoPontoCommand(EspelhoPontoViewModel objViwModel)
        {
            this.objViwModel = objViwModel;
            servico = new FuncionarioPontoService();

            this.objViwModel.lPonto = new System.Collections.ObjectModel.ObservableCollection<Model.Models.Gerais.EspelhoPontoModel>(servico.GetHorasAtrabalhadasDia
                (
                idFuncionario: objViwModel.idFuncionario,
                dtDia: objViwModel.dataPonto
                ));

        }





    }
}
