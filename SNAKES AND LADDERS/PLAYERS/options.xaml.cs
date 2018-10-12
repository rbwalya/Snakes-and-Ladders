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
using System.Windows.Threading;
using System.Diagnostics;

namespace PLAYERS
{
    /// <summary>
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Window
    {
        board bw;
        MainWindow mw;
        congratulations cw;

        DispatcherTimer timer;

        public options()
        {
            InitializeComponent();
            mw = (MainWindow)Application.Current.MainWindow;

            if (mw.play)
            {
                bsound.Content = "🔊";
            }
            else
                bsound.Content = "🔇";
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(3));
            this.BeginAnimation(UIElement.OpacityProperty, anim);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bw = new board();
            bw.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            mw.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"\help.txt");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (mw.play)
            {
                mw.sound.Stop();
                mw.play = false;
            }
            else
            {
                mw.sound.Play();
                mw.play = true;
            }

            if (bsound.Content.ToString() == "🔇")
            {
                bsound.Content = "🔊";
                mw.bsound.Content = "🔊";
                bsound.Foreground = Brushes.Blue;
                mw.bsound.Foreground = Brushes.Blue;
            }
            else
            {
                bsound.Content = "🔇";
                mw.bsound.Content = "🔇";
                bsound.Foreground = Brushes.Red;
                mw.bsound.Foreground = Brushes.Red;
            }
                
            
        }
    }
}
