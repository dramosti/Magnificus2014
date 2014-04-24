using HLP.Base.Modules;
using HLP.Comum.Model.Models;
using HLP.Comum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Comum.ViewModel.Commands
{
    public class OperacoesDataBaseCommands
    {
        OperacoesDataBaseService objService = null;
        public OperacoesDataBaseCommands()
        {
            objService = new OperacoesDataBaseService();
        }

        public void ShowWinExclusionDenied(string xMessage, string xValor)
        {
            List<RecordsSqlModel> l = objService.GetRecordsFKUsed(xMessage: xMessage, xValor: xValor);
            string xTabela = xMessage.Split(
                separator: new string[] { "table" }
                , options: StringSplitOptions.None)[1].ToString()
                .Split(separator: '"')[1].ToString().Split('"')[0].ToString();
            string xCampo = xMessage.Split(separator: new string[] { "column" }, options: StringSplitOptions.None)[1].ToString().Split(separator: '\'')[1];

            Window form = GerenciadorModulo.Instancia.CarregaForm(nome: "WinExclusionDenied", exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);

            form.DataContext.GetType().GetProperty(name: "lRecords").SetValue(obj: form.DataContext, value: l);
            form.DataContext.GetType().GetProperty(name: "xTabela").SetValue(obj: form.DataContext, value: xTabela);
            form.DataContext.GetType().GetProperty(name: "xCampo").SetValue(obj: form.DataContext, value: xCampo);
            form.DataContext.GetType().GetProperty(name: "xValor").SetValue(obj: form.DataContext, value: xValor);

            form.ShowDialog();
        }
    }
}
