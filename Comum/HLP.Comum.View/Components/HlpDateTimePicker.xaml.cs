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

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpDateTimePicker.xaml
    /// </summary>
    public partial class HlpDateTimePicker : BaseControl
    {
        public HlpDateTimePicker()
        {
            InitializeComponent();

            
        }


        [Category("HLP.Owner")]
        public DatePickerFormat SelectedDateFormat
        {
            get { return (DatePickerFormat)GetValue(SelectedDateFormatProperty); }
            set { SetValue(SelectedDateFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDateFormat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateFormatProperty =
            DependencyProperty.Register("SelectedDateFormat", typeof(DatePickerFormat), typeof(HlpDateTimePicker), new PropertyMetadata(DatePickerFormat.Short));




        [Category("HLP.Owner")]
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(HlpDateTimePicker), new PropertyMetadata(DateTime.Now));




    }
}
