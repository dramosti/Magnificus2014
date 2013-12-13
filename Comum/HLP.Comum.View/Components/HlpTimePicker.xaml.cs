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
    public partial class HlpTimePicker : BaseControl
    {
        public HlpTimePicker()
        {
            InitializeComponent();


        }


        [Category("HLP.Owner")]
        public bool ShowButtonSpinner
        {
            get { return (bool)GetValue(ShowButtonSpinnerProperty); }
            set { SetValue(ShowButtonSpinnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowButtonSpinner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowButtonSpinnerProperty =
            DependencyProperty.Register("ShowButtonSpinner", typeof(bool), typeof(HlpTimePicker), new PropertyMetadata(true));

        [Category("HLP.Owner")]
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(HlpTimePicker), new PropertyMetadata(false));

        [Category("HLP.Owner")]
        public TimeSpan StartTime
        {
            get { return (TimeSpan)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(TimeSpan), typeof(HlpTimePicker), new PropertyMetadata(new TimeSpan(0, 0, 0)));


        [Category("HLP.Owner")]
        public TimeSpan TimeInterval
        {
            get { return (TimeSpan)GetValue(TimeIntervalProperty); }
            set { SetValue(TimeIntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeIntervalProperty =
            DependencyProperty.Register("TimeInterval", typeof(TimeSpan), typeof(HlpTimePicker), new PropertyMetadata(new TimeSpan(1, 0, 0)));


        [Category("HLP.Owner")]
        public DateTime Value
        {
            get { return (DateTime)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(DateTime), typeof(HlpTimePicker), new PropertyMetadata(DateTime.Today));




        public object Watermark
        {
            get { return (object)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Watermark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(object), typeof(HlpTimePicker), new PropertyMetadata());














    }
}
