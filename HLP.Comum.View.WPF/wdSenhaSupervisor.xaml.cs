﻿using HLP.ComumView.ViewModel.ViewModel;
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

namespace HLP.Comum.View.WPF
{
    /// <summary>
    /// Interaction logic for wdSenhaSupervisor.xaml
    /// </summary>
    public partial class wdSenhaSupervisor : Window
    {
        public static bool WindowShowDialog()
        {
            return Application.Current.Dispatcher.Invoke((Func<bool>)(()
                =>
                {
                    wdSenhaSupervisor wd = new wdSenhaSupervisor();

                    return wd.ShowDialog() ?? false;
                }));
        }

        public wdSenhaSupervisor()
        {
            InitializeComponent();
            this.ViewModel = new SenhaSupervisorViewModel();
        }

        public SenhaSupervisorViewModel ViewModel
        {
            get
            {
                return this.DataContext as SenhaSupervisorViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
