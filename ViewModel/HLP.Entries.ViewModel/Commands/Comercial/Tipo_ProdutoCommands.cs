using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Entries.ViewModel.ViewModels;
using System.Windows.Controls;
using System.ComponentModel;

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    public class Tipo_ProdutoCommands
    {
        Tipo_ProdutoViewModel objViewModel;

        private TipoProdutoService.IserviceTipoProdutoClient servicoProduto = new TipoProdutoService.IserviceTipoProdutoClient();

        public Tipo_ProdutoCommands(Tipo_ProdutoViewModel _objViewModel)
        {


            this.objViewModel = _objViewModel;


        }


        async void save()
        {

            await servicoProduto.SaveAsync(objViewModel.currentModel);

        }










    }
}
