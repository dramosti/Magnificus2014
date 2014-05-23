using HLP.ComumView.ViewModel.Messages.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HLP.Comum.View.WPF.Messages
{
    /// <summary>
    /// Interaction logic for HlpMessageYesNo.xaml
    /// </summary>
    public partial class HlpMessageYesNo : Window
    {
        public HlpMessageYesNo()
        {
            InitializeComponent();            
        }

        public static MessageBoxResult ShowMessage(string xMessageToUser)
        {
            HlpMessageYesNo _message = new HlpMessageYesNo();

            _message.DataContext = new HlpMessageYesNoViewModel(xMessageToUser: xMessageToUser);

            if (_message.ShowDialog() == true)
            {
                return MessageBoxResult.Yes;
            }
            else
            {
                return MessageBoxResult.No;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}
