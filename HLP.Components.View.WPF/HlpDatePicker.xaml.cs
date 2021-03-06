﻿using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for HlpDatePicker.xaml
    /// </summary>
    public partial class HlpDatePicker : UserControl
    {
        public HlpDatePicker()
        {
            InitializeComponent();

            this.btnCalendar.Content = DateTime.Now.Day;

            this.LostFocus += HlpDatePicker_LostFocus;
        }

        void HlpDatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.actionOnLostFocus != null)
            {
                Type t = this.actionOnLostFocus.GetType();

                if (t == typeof(RelayCommand))
                {
                    if (((RelayCommand)this.actionOnLostFocus).CanExecute(parameter: null))
                        ((RelayCommand)this.actionOnLostFocus).Execute(parameter: null);
                }
                else if (t == typeof(Action<object>))
                {
                    ((Action<object>)this.actionOnLostFocus).Invoke(obj: this.actionParameter);
                }
                else
                {
                    ((Action)this.actionOnLostFocus).Invoke();
                }
            }
        }

        private object _actionOnLostFocus;

        public object actionOnLostFocus
        {
            get { return _actionOnLostFocus; }
            set { _actionOnLostFocus = value; }
        }

        private object _actionParameter;

        public object actionParameter
        {
            get { return _actionParameter; }
            set { _actionParameter = value; }
        }

        public StFormatoDatePicker stFormatoDtPicker
        {
            get { return (StFormatoDatePicker)GetValue(stFormatoDtPickerProperty); }
            set
            {
                SetValue(stFormatoDtPickerProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for stFormatoDtPicker.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty stFormatoDtPickerProperty =
            DependencyProperty.Register("stFormatoDtPicker", typeof(StFormatoDatePicker), typeof(HlpDatePicker), new PropertyMetadata(StFormatoDatePicker.date));

        public string xTextDate
        {
            get { return (string)GetValue(xTextDateProperty); }
            set { SetValue(xTextDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xTextDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xTextDateProperty =
            DependencyProperty.Register("xTextDate", typeof(string), typeof(HlpDatePicker), new PropertyMetadata(String.Empty));

        public string xTextTime
        {
            get { return (string)GetValue(xTextTimeProperty); }
            set { SetValue(xTextTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xTextTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xTextTimeProperty =
            DependencyProperty.Register("xTextTime", typeof(string), typeof(HlpDatePicker), new PropertyMetadata(String.Empty));

        [Category("HLP.Base")]
        public string Help
        {
            get { return (string)GetValue(HelpProperty); }
            set { SetValue(HelpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Help.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HelpProperty =
            DependencyProperty.Register("Help", typeof(string), typeof(HlpDatePicker), new PropertyMetadata(string.Empty));

        private statusComponentePosicao _stCompPosicao;

        public statusComponentePosicao stCompPosicao
        {
            get { return _stCompPosicao; }
            set { _stCompPosicao = value; }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtData.Text = (sender as Calendar).SelectedDate.Value.Date.ToShortDateString();
            this.txtHora.Text = (sender as Calendar).SelectedDate.Value.Date.ToLongTimeString();
            this.btnCalendar.ContextMenu.IsOpen = false;

            if (txtData.Visibility == System.Windows.Visibility.Visible)
                this.txtData.Focus();
            else
                this.txtHora.Focus();
        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            Calendar c = this.btnCalendar.ContextMenu.FindName(name: "compCalendar") as Calendar;

            this.btnCalendar.ContextMenu.PlacementTarget = this.btnCalendar;
            this.btnCalendar.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            this.btnCalendar.ContextMenu.IsOpen = true;
        }



        public bool isReadOnlyUserControl
        {
            get { return (bool)GetValue(isReadOnlyUserControlProperty); }
            set { SetValue(isReadOnlyUserControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isReadOnlyUserControl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isReadOnlyUserControlProperty =
            DependencyProperty.Register("isReadOnlyUserControl", typeof(bool), typeof(HlpDatePicker),
            new PropertyMetadata(defaultValue: false, propertyChangedCallback: new PropertyChangedCallback(readOnlyChanged)));

        public static void readOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d != null)
            {
                (d as HlpDatePicker).txtData.IsReadOnly = (d as HlpDatePicker).txtHora.IsReadOnly =
                    ((bool)args.NewValue);

                (d as HlpDatePicker).btnCalendar.Visibility = Visibility.Collapsed;
            }
        }
    }

    public enum StFormatoDatePicker
    {
        date,
        time,
        datetime
    }
}
