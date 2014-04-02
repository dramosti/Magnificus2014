﻿using HLP.Base.ClassesBases;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Components.ViewModel.Commands
{
    public class HlpPesquisaFiltradaCommands
    {
        HlpPesquisaFiltradaViewModel objViewModel;

        public HlpPesquisaFiltradaCommands(HlpPesquisaFiltradaViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.filtrarCommand = new RelayCommand(execute: execParam => this.ExecFiltrar(
                window: execParam));
        }

        public void ExecFiltrar(object window)
        {
            (window as Window).DialogResult = true;
            (window as Window).Close();
        }
    }
}
