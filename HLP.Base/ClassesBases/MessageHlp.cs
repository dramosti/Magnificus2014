using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Base.ClassesBases
{
    public class MessageHlp
    {
        private bool _bSave = false;
        public bool bSave
        {
            get { return _bSave; }
            set { _bSave = value; }
        }
        public bool Save()
        {

            if (MessageBox.Show(messageBoxText: "Deseja salvar o registro?",
                caption: "Salvar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                == MessageBoxResult.Yes)
                return bSave = true;
            else
                return bSave = false;
        }


        public bool Excluir() 
        {
             if (MessageBox.Show(messageBoxText: "Deseja excluir o registro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                 return  true;
             else
                 return false;                
        }

        public void Excluido() 
        {
            MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                           button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
        }
    }
}
