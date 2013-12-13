using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class CalendarioDetalheCommand
    {

        CalendarioDetalheViewModel objViewModel;

        public CalendarioDetalheCommand(CalendarioDetalheViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
        }




        public void GerarDetalhamento() 
        {
            try
            {                
                //if (ValidaIntervalosDia())
                //{
                //    if (ValidaDiasSemProgramacao())
                //    {
                //        if (VerificaHorarios())
                //        {
                //            GeraGradeHoraria();
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
