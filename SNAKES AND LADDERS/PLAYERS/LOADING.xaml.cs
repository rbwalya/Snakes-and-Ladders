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
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Threading;

namespace PLAYERS
{
    /// <summary>
    /// Interaction logic for LOADING.xaml
    /// </summary>
    public partial class LOADING : Window
    {
        DispatcherTimer mytime;
        DispatcherTimer timer;
        int i = 0;
        public LOADING()
        {
            InitializeComponent();
            Duration duration = new Duration(TimeSpan.FromSeconds(20));
            DoubleAnimation doubleAnimation = new DoubleAnimation(200, duration);
            progress_bar.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;

            mytime = new DispatcherTimer();

            mytime.Interval = TimeSpan.FromSeconds(10);
            mytime.IsEnabled = true;
            mytime.Tick += StartTimer;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            List<string> dots = new List<string> { ".", "..", "...", "....", "....." };
            lbldots.Content = dots[i];
            i++;
            if (i == 5)
                i = 0;
        }

        private void StartTimer(object sender, EventArgs e)
        {
                mytime.IsEnabled = false;
                loading_wn.Close();
        }

        private void progress_bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }
    }
}
