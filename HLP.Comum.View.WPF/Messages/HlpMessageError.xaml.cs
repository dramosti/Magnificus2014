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
    /// Interaction logic for HlpMessageError.xaml
    /// </summary>
    public partial class HlpMessageError : Window
    {
        public HlpMessageError()
        {
            InitializeComponent();
        }

        public static void ShowMessage(string xErrorCode, string xErrorMessageToUser, string xErrorMessageFramework)
        {
            HlpMessageError _message = new HlpMessageError();
            _message.DataContext = new HlpMessageErrorViewModel(xErrorCode: xErrorCode, xErrorMessageToUser: xErrorMessageToUser,
                xErrorMessageFramework: xErrorMessageFramework);

            _message.ShowDialog();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
