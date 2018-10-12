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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace PLAYERS
{
    /// <summary>
    /// Interaction logic for congratulations.xaml
    /// </summary>
    public partial class congratulations : Window
    {
        MainWindow mw;
        DispatcherTimer mytime;
        public congratulations(string name)
        {
            InitializeComponent();
            //start();
            lbl_winner.Content = string.Format("{0} won!!!", name);


            mytime = new DispatcherTimer();

            mytime.Interval = TimeSpan.FromMilliseconds(40);
            mytime.IsEnabled = true;
            mytime.Tick += StartTimer;

            mytime = new DispatcherTimer();

            mytime.Interval = TimeSpan.FromSeconds(5);
            mytime.IsEnabled = true;
            mytime.Tick += Mytime_Tick;


        }

        DispatcherTimer time;
        private void Mytime_Tick(object sender, EventArgs e)
        {
            time = new DispatcherTimer();

            time.Interval = TimeSpan.FromSeconds(1);
            time.IsEnabled = true;
            time.Tick += Time_Tick;
            
            

            
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(3));
            this.BeginAnimation(UIElement.OpacityProperty, anim);

            mw = (MainWindow)Application.Current.MainWindow;
            mw.Show();
            this.Hide();
            time.IsEnabled = false;

        }

        private void StartTimer(object sender, EventArgs e)
        {
                Random random = new Random();
                color(random.Next(1, 8));
            
            
        //    mw = new MainWindow();
        }
        private void color(int i)
        {
            switch (i)
            {
                case 1:
                    lbl_winner.Foreground = Brushes.Blue;
                    break;
                case 2:
                    lbl_winner.Foreground = Brushes.Yellow;
                    break;
                case 3:
                    lbl_winner.Foreground = Brushes.White;
                    break;
                case 4:
                    lbl_winner.Foreground = Brushes.Red;
                    break;
                case 5:
                    lbl_winner.Foreground = Brushes.Transparent;
                    break;
                case 6:
                    lbl_winner.Foreground = Brushes.LightGreen;
                    break;
                case 7:
                    lbl_winner.Foreground = Brushes.Beige;
                    break;
            }
        }

        
    }
}
