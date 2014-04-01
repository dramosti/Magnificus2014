﻿using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Comum.Infrastructure.Static;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class HlpCalendarioPontoCommand
    {
        FuncionarioPontoService servico;
        public HlpCalendarioPontoViewModel objViewModel { get; set; }

        public HlpCalendarioPontoCommand(HlpCalendarioPontoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            servico = new FuncionarioPontoService();
            this.objViewModel.LancamentoManualCommand = new RelayCommand(execute: paramExec => this.LoadLancamentoManual(),
                 canExecute: paramCanExec => CanLancamentoManual());
        }
        public void CarregaDados()
        {
            try
            {
                if (objViewModel.idFuncionario != 0 && objViewModel.dataPonto != "")
                    this.objViewModel.lPonto = new System.Collections.ObjectModel.ObservableCollection<Model.Models.Gerais.EspelhoPontoModel>(servico.GetHorasTrabalhadasDia
                       (
                       idFuncionario: objViewModel.idFuncionario,
                       dtDia: Convert.ToDateTime(objViewModel.dataPonto)
                       ));
                else
                    objViewModel.lPonto = new System.Collections.ObjectModel.ObservableCollection<Model.Models.Gerais.EspelhoPontoModel>();
            }
            catch (Exception)
            {
            }
        }
        public bool CanLancamentoManual()
        {
            bool breturn = false;

            if (objViewModel.idFuncionario != 0 && objViewModel.dataPonto != null && objViewModel._bMesFechado == false)
            {
                breturn = true;
            }
            return breturn;
        }
        public void LoadLancamentoManual()
        {
            try
            {
                Window win = GerenciadorModulo.Instancia.CarregaForm("WinLancamentoManualPonto", Comum.Modules.Interface.TipoExibeForm.Modal);
                Type tp = win.GetType();
                MethodInfo method = tp.GetMethod("SetDataContext");
                method.Invoke(win, new object[] { objViewModel.idFuncionario, Convert.ToDateTime(objViewModel.dataPonto) });
                win.ShowDialog();
                if (((bool)win.GetPropertyValue("bAlterou")))
                {
                    this.objViewModel.actionAtualizaWindowPrincipal.Invoke();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}