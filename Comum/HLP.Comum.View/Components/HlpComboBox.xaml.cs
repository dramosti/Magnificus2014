﻿using System;
using System.Collections;
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

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpComboBox.xaml
    /// </summary>
    public partial class HlpComboBox : BaseControl
    {
        public HlpComboBox()
        {
            InitializeComponent();
        }

        #region ComboBox's Property

        [Category("HLP.Owner")]
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayMemberPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(HlpComboBox), new PropertyMetadata(string.Empty));



        [Category("HLP.Owner")]
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(HlpComboBox), new PropertyMetadata());


        [Category("HLP.Owner")]
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(HlpComboBox), new PropertyMetadata(0));



        [Category("HLP.Owner")]
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(HlpComboBox), new PropertyMetadata());


        [Category("HLP.Owner")]
        public string SelectedValuePath
        {
            get { return (string)GetValue(SelectedValuePathProperty); }
            set { SetValue(SelectedValuePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValuePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(HlpComboBox), new PropertyMetadata(string.Empty));


        [Category("HLP.Owner")]
        public object SelectedValue
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(object), typeof(HlpComboBox), new PropertyMetadata());


        private List<string> _Items = new List<string>();
        [Category("HLP.Owner")]
        public List<string> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        #endregion

        public event SelectionChangedEventHandler UCSelectionChanged;

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UCSelectionChanged != null)
            {
                UCSelectionChanged(this, e);
            }
        }

        private void BaseControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBox.Items.Count == 0)
                {
                    if (this.Items != null)
                    {
                        foreach (var item in this.Items)
                        {
                            comboBox.Items.Add(item.ToString().ToUpper());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}