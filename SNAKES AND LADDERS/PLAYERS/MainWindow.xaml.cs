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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;
using WMPLib;
using System.Windows.Media.Animation;
using System.IO;
using System.Diagnostics;

namespace PLAYERS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LOADING first;
        DispatcherTimer myTimer;
        public int player_count, player_1, player_2, player_3, player_4;
        public string pcolour_1, pcolour_2, pcolour_3, pcolour_4;
        public string sname_1, sname_2, sname_3, sname_4;
        public string one, two, three, four;
        int i = 0;

        public MediaPlayer sound;
        public bool play = true;
        public MainWindow()
        {
            InitializeComponent();

            sound = new MediaPlayer();
            sound.Open(new Uri(@"\\ict.ru.ac.za\DFS\UGHomes\g18m2569\Desktop\MULENGA !\SNAKES AND LADDERS\PLAYERS\sound.wav"));
            sound.Play();

            

            myTimer = new DispatcherTimer();
            myTimer.Interval = TimeSpan.FromSeconds(10);
            myTimer.IsEnabled = true;
            myTimer.Tick += theTime;
            first = new LOADING();
            first.Show();
            player_win.Hide();

            

            out_1.Background = System.Windows.Media.Brushes.LightBlue;
            out_2.Background = System.Windows.Media.Brushes.LightBlue;
            out_3.Background = System.Windows.Media.Brushes.LightBlue;
            out_4.Background = System.Windows.Media.Brushes.LightBlue;
        }
        

        private void theTime(object sender, EventArgs e)
        {
            player_win.Show();
            myTimer.IsEnabled = false;
        }

        DispatcherTimer time;
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(2));
            this.BeginAnimation(UIElement.OpacityProperty, anim);

            time = new DispatcherTimer();

            time.Interval = TimeSpan.FromSeconds(3);
            time.IsEnabled = true;
            time.Tick += Time_Tick;

            
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            first.Close();
            Environment.Exit(0);
        }

        private void btn_options_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            player_count = player_1 + player_2 + player_3 + player_4;
            if (player_count > 0)
            {
                one = type_1.Text;
                two = type_2.Text;
                three = type_3.Text;
                four = type_4.Text;

                board board = new board();
                board.Show();
                player_win.Hide();
            }
            
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"help.txt");
        }

        public void bsound_Click(object sender, RoutedEventArgs e)
        {
            if (play)
            {
                sound.Pause();
                play = false;
            }
            else
            {
                sound.Play();
                play = true;
            }
            if (bsound.Content.ToString() == "🔇")
            {
                bsound.Content = "🔊";
                bsound.Foreground = Brushes.Blue;
            }
            else
            {
                bsound.Content = "🔇";
                bsound.Foreground = Brushes.Red;
            }
        }

        private void colour_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            if ((name_1.Text == "")||(type_1.Text == "") || (colour_1.Text == ""))
            {
                if (name_1.Text == "")
                   name_1.BorderBrush = System.Windows.Media.Brushes.Red;
                if (type_1.Text == "")
                    type_1.BorderBrush = System.Windows.Media.Brushes.Red;
                if (colour_1.Text == "")
                    colour_1.BorderBrush = System.Windows.Media.Brushes.Red;
                MessageBox.Show("FILL IN THE MISSING FIELDS...");
            }
            else
            {
                player_1 = 1;
                pcolour_1 = colour_1.Text;
                
                sname_1 = name_1.Text;
                name_2.BorderBrush = System.Windows.Media.Brushes.LightGray;
                in_1.Background = System.Windows.Media.Brushes.LightBlue;
                out_1.Background = System.Windows.Media.Brushes.LightGray;
            }
                

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btn_in2_Click(object sender, RoutedEventArgs e)
        {
            if(player_1 == 1)
            {
                if ((name_2.Text == "") || (type_2.Text == "") || (colour_2.Text == ""))
                {
                    if (name_2.Text == "")
                        name_2.BorderBrush = System.Windows.Media.Brushes.Red;
                    if (type_2.Text == "")
                        type_2.Background = System.Windows.Media.Brushes.Red;
                    if (colour_2.Text == "")
                        colour_2.BorderBrush = System.Windows.Media.Brushes.Red;
                    MessageBox.Show("FILL IN THE MISSING FIELDS...");
                }
                else
                {
                    player_2 = 1;
                    pcolour_2 = colour_2.Text;
                    
                    sname_2 = name_2.Text;
                    name_2.BorderBrush = System.Windows.Media.Brushes.LightGray;
                    in_2.Background = System.Windows.Media.Brushes.LightBlue;
                    out_2.Background = System.Windows.Media.Brushes.LightGray;
                }
            }
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void out_2_Click(object sender, RoutedEventArgs e)
        {
            sname_2 = "";
            sname_3 = "";
            sname_4 = "";

            player_2 = 0;
            player_3 = 0;
            player_4 = 0;
            
            out_2.Background = System.Windows.Media.Brushes.LightBlue;
            out_3.Background = System.Windows.Media.Brushes.LightBlue;
            out_4.Background = System.Windows.Media.Brushes.LightBlue;
            
            in_2.Background = System.Windows.Media.Brushes.LightGray;
            in_3.Background = System.Windows.Media.Brushes.LightGray;
            in_4.Background = System.Windows.Media.Brushes.LightGray;
        }

        private void name_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(name_2.Text != "")
                name_2.BorderBrush = System.Windows.Media.Brushes.LightGray;
        }

        private void out_1_Click(object sender, RoutedEventArgs e)
        {
            sname_1 = "";
            sname_2 = "";
            sname_3 = "";
            sname_4 = "";

            player_1 = 0;
            player_2 = 0;
            player_3 = 0;
            player_4 = 0;

            out_1.Background = System.Windows.Media.Brushes.LightBlue;
            out_2.Background = System.Windows.Media.Brushes.LightBlue;
            out_3.Background = System.Windows.Media.Brushes.LightBlue;
            out_4.Background = System.Windows.Media.Brushes.LightBlue;

            in_1.Background = System.Windows.Media.Brushes.LightGray;
            in_2.Background = System.Windows.Media.Brushes.LightGray;
            in_3.Background = System.Windows.Media.Brushes.LightGray;
            in_4.Background = System.Windows.Media.Brushes.LightGray;
            
        }

        private void colour_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void in_3_Click(object sender, RoutedEventArgs e)
        {
            if(player_2 == 1)
            {
                if ((name_3.Text == "") || (type_3.Text == "") || (colour_3.Text == ""))
                {
                    if (name_3.Text == "")
                        name_3.BorderBrush = System.Windows.Media.Brushes.Red;
                    if (type_3.Text == "")
                        type_3.BorderBrush = System.Windows.Media.Brushes.Red;
                    if (colour_3.Text == "")
                        colour_3.BorderBrush = System.Windows.Media.Brushes.Red;
                    MessageBox.Show("FILL IN THE MISSING FIELDS...");
                }
                else
                {
                    player_3 = 1;
                    pcolour_3 = colour_3.Text;
                    
                    sname_3 = name_3.Text;
                    name_3.BorderBrush = System.Windows.Media.Brushes.LightGray;
                    in_3.Background = System.Windows.Media.Brushes.LightBlue;
                    out_3.Background = System.Windows.Media.Brushes.LightGray;
                }
            }
            
        }

        private void out_3_Click(object sender, RoutedEventArgs e)
        {
            sname_3 = "";
            sname_4 = "";

            player_3 = 0;
            player_4 = 0;
            
            out_3.Background = System.Windows.Media.Brushes.LightBlue;
            out_4.Background = System.Windows.Media.Brushes.LightBlue;
            
            in_3.Background = System.Windows.Media.Brushes.LightGray;
            in_4.Background = System.Windows.Media.Brushes.LightGray;
        }

        private void in_4_Click(object sender, RoutedEventArgs e)
        {
            if(player_3 == 1)
            {
                if ((name_4.Text == "") || (type_3.Text == "") || (colour_3.Text == ""))
                {
                    if (name_4.Text == "")
                        name_4.BorderBrush = System.Windows.Media.Brushes.Red;
                    if (type_4.Text == "")
                        type_4.BorderBrush = System.Windows.Media.Brushes.Red;
                    if (colour_4.Text == "")
                        colour_4.BorderBrush = System.Windows.Media.Brushes.Red;
                    MessageBox.Show("FILL IN THE MISSING FIELDS...");
                }
                else
                {
                    player_4 = 1;
                    pcolour_4 = colour_4.Text;
                    sname_4 = name_4.Text;
                    name_4.BorderBrush = System.Windows.Media.Brushes.LightGray;
                    in_4.Background = System.Windows.Media.Brushes.LightBlue;
                    out_4.Background = System.Windows.Media.Brushes.LightGray;
                }
            }
            
        }

        private void out_4_Click(object sender, RoutedEventArgs e)
        {
            sname_4 = "";

            player_4 = 0;
            
            out_4.Background = System.Windows.Media.Brushes.LightBlue;
            
            in_4.Background = System.Windows.Media.Brushes.LightGray;
        }
    }
}
