﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Components.View.WPF
{
    /// <summary>
    /// Interaction logic for LoadingAnimation.xaml
    /// </summary>
    public partial class LoadingAnimation : UserControl
    {
        public LoadingAnimation()
        {
            InitializeComponent();
        }




        public string xLabel
        {
            get { return (string)GetValue(xLabelProperty); }
            set { SetValue(xLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xLabelProperty =
            DependencyProperty.Register("xLabel", typeof(string), typeof(LoadingAnimation), new PropertyMetadata(string.Empty));


    }
}
