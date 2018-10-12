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
using ThinkLib;
using System.Threading;


namespace PLAYERS
{
    /// <summary>
    /// Interaction logic for board.xaml
    /// </summary>
    public partial class board : Window
    {
        MediaPlayer click;
        MainWindow mw;
        congratulations cw;

        private BitmapImage[] dice_faces;
        private string inThisProject = "pack://application:,,,/";

        Turtle tut_1, tut_2, tut_3, tut_4;
        int pos_1 = 1, pos_2 = 1, pos_3 = 1, pos_4 = 1, players;


        private int random()
        {
            Random random = new Random();
            int dice = random.Next(0, 6);
            return dice;
        }

        private void move(Turtle tut, int row, int pos, Label label, string player)
        {
            
            for (int i = 0; i <= row; i++)
            {
                pos++;
                label.Content = (pos);
                if ((pos == 11)||(pos == 31)||(pos == 51)||(pos == 71)||(pos == 91))
                {
                    tut.Left(90);
                    Thread.Sleep(250);
                    tut.Forward(100);
                    tut.Left(90);
                }
                else if ((pos == 21)||(pos == 41)||(pos == 61)||(pos == 81))
                {
                    Thread.Sleep(250);
                    tut.Right(90);
                    tut.Forward(100);
                    tut.Right(90);
                }
                else
                {
                    Thread.Sleep(250);
                    tut.Forward(100);
                }

                if(pos == 100)
                {
                    cw = new congratulations(player);
                    cw.Show();
                    this.Hide();
                }
            }

        }

        private void snakes(ref int pos, Turtle tut, Label label)
        {
            switch (pos)
            {
                case 23:
                    tut.Goto(650, 950);
                    pos = 7;
                    label.Content = pos;
                    break;
                case 33:
                    tut.Goto(850, 950);
                    tut.Right(180);
                    pos = 9;
                    label.Content = pos;
                    break;
                case 44:
                    tut.Goto(650, 850);
                    tut.Right(180);
                    pos = 14;
                    label.Content = pos;
                    break;
                case 68:
                    tut.Goto(450, 750);
                    pos = 25;
                    label.Content = pos;
                    break;
                case 77:
                    tut.Goto(50, 550);
                    tut.Right(180);
                    pos = 41;
                    label.Content = pos;
                    break;
                case 94:
                    tut.Goto(950, 350);
                    tut.Right(180);
                    pos = 70;
                    label.Content = pos;
                    break;
                case 97:
                    tut.Goto(550, 350);
                    tut.Right(180);
                    pos = 66;
                    label.Content = pos;
                    break;
            }
        }

        private void ladders(ref int pos, Turtle tut, Label label)
        {
            switch (pos)
            {
                case 5:
                    tut.Goto(550, 750);
                    pos = 26;
                    label.Content = pos;
                    break;
                case 13:
                    tut.Goto(550, 550);
                    tut.Right(180);
                    pos = 46;
                    label.Content = pos;
                    break;
                case 18://carry on from here
                    tut.Goto(150, 650);
                    pos = 39;
                    label.Content = pos;
                    break;
                case 37:
                    tut.Goto(150, 350);
                    tut.Right(180);
                    pos = 62;
                    label.Content = pos;
                    break;
                case 48:
                    tut.Goto(850, 250);
                    tut.Right(180);
                    pos = 72;
                    label.Content = pos;
                    break;
                case 60:
                    tut.Goto(150, 150);
                    tut.Right(180);
                    pos = 82;
                    label.Content = pos;
                    break;
                case 65:
                    tut.Goto(550, 50);
                    tut.Right(180);
                    pos = 95;
                    label.Content = pos;
                    break;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            row_1.Visibility = Visibility.Hidden;
            int row = random();
            dice_1.Source = dice_faces[row];

            move(tut_1, row, pos_1, lbl_pos1, mw.sname_1);
            pos_1 = pos_1 + (row + 1);

            snakes(ref pos_1, tut_1, lbl_pos1);
            ladders(ref pos_1, tut_1, lbl_pos1);

            
            Thread.Sleep(20);
            if (players == 1)
            {
                int com_row = random();

                dice_2.Source = dice_faces[com_row];

                move(tut_2, com_row, pos_2, lbl_pos2, "Iverson");
                pos_2 = pos_2 + (com_row + 1);

                snakes(ref pos_2, tut_2, lbl_pos2);
                ladders(ref pos_2, tut_2, lbl_pos2);

                Thread.Sleep(20);
                row_1.Visibility = Visibility.Visible;
            }
            else if (players > 1)
            {
                row_2.Visibility = Visibility.Visible;
                
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            row_2.Visibility = Visibility.Hidden;

            int row = random();
            dice_2.Source = dice_faces[row];

            move(tut_2, row, pos_2, lbl_pos2, mw.sname_2);
            pos_2 = pos_2 + (row + 1);

            snakes(ref pos_2, tut_2, lbl_pos2);
            ladders(ref pos_2, tut_2, lbl_pos2);

            Thread.Sleep(20);
            
            if (players > 2)
            {
                row_3.Visibility = Visibility.Visible;
            }
            else
            {
                row_1.Visibility = Visibility.Visible;
            }
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            row_3.Visibility = Visibility.Hidden;

            int row = random();
            dice_3.Source = dice_faces[row];

            move(tut_3, row, pos_3, lbl_pos3, mw.sname_3);
            pos_3 = pos_3 + (row + 1);

            snakes(ref pos_3, tut_3, lbl_pos3);
            ladders(ref pos_3, tut_3, lbl_pos3);

            Thread.Sleep(20);
            
            if (players > 3)
            {
                row_4.Visibility = Visibility.Visible;
                
            }
            else
            {
                row_1.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            row_4.Visibility = Visibility.Hidden;

            int row = random();
            dice_4.Source = dice_faces[row];

            move(tut_4, row, pos_4, lbl_pos4, mw.sname_4);
            pos_4 = pos_4 + (row + 1);

            snakes(ref pos_4, tut_4, lbl_pos4);
            ladders(ref pos_4, tut_4, lbl_pos4);

            Thread.Sleep(20);
            
            row_1.Visibility = Visibility.Visible;

        }

        //turtle colour
        private SolidColorBrush color(string color)
        {
            switch (color)
            {
                case "WHITE":
                    return Brushes.WhiteSmoke;
                case "BLACK":
                    return Brushes.Black;
                case "GOLD":
                    return Brushes.Gold;
                case "SILVER":
                    return Brushes.Silver;
                case "PINK":
                    return Brushes.Pink;
            }
            return Brushes.Black;
        }

        public void Button(Button but, string col)
        {
            switch (col)
            {
                case "WHITE":
                    but.BorderBrush = Brushes.WhiteSmoke;
                break;
                case "BLACK":
                    but.BorderBrush = Brushes.Black;
                break;
                case "GOLD":
                    but.BorderBrush = Brushes.Gold;
                break;
                case "SILVER":
                    but.BorderBrush = Brushes.Silver;
                break;
                case "PINK":
                    but.BorderBrush = Brushes.Pink;
                break;

            }

        }

        public void apperance(Turtle tut, String shape, string col)
        {
            switch (shape)
            {
                case "TURTLE":
                    tut.BodyBrush = color(col);
                    tut.OutlineBrush = color(col);
                    break;
                case "CIRCLE":
                    tut.SetAppearance(new EllipseGeometry(new Point(0, 0), 10, 10), color(col), color(col));
                    break;
                case "SQUARE":
                    tut.SetAppearance(new RectangleGeometry(new Rect(-10, -15, 25, 25)), color(col), color(col));
                    break;
            }
        }
        
        //intializer
        public board()
        {
            InitializeComponent();

            click = new MediaPlayer();
            click.Open(new Uri(@"\\ict.ru.ac.za\DFS\UGHomes\g18m2569\Desktop\MULENGA !\SNAKES AND LADDERS\PLAYERS\click.wav"));

            mw = (MainWindow)Application.Current.MainWindow;
            players = mw.player_count;

            row_2.Visibility = Visibility.Hidden;
            row_3.Visibility = Visibility.Hidden;
            row_4.Visibility = Visibility.Hidden;

            label_1.Content = mw.sname_1;
            label_2.Content = mw.sname_2;
            label_3.Content = mw.sname_3;
            label_4.Content = mw.sname_4;

            dice_faces = new BitmapImage[] {
                        new BitmapImage(new Uri(inThisProject + "face1.jpg")),
                        new BitmapImage(new Uri(inThisProject + "face2.jpg")),
                        new BitmapImage(new Uri(inThisProject + "face3.jpg")),
                        new BitmapImage(new Uri(inThisProject + "face4.jpg")),
                        new BitmapImage(new Uri(inThisProject + "face5.jpg")),
                        new BitmapImage(new Uri(inThisProject + "face6.jpg")),
            };
            switch (mw.player_count)// win.playeer_count
            {
                
                case 1:
                    label_2.Content = "Iverson";

                    tut_1 = new Turtle(board_main, 50, 950);
                    tut_2 = new Turtle(board_main, 50, 950);

                    

                    tut_1.BrushDown = false;
                    tut_2.BrushDown = false;

                    apperance(tut_1, mw.one, mw.colour_1.Text);

                    lbl_pos3.Visibility = Visibility.Hidden;
                    lbl_pos4.Visibility = Visibility.Hidden;

                    Button(row_1, mw.colour_1.Text);

                    row_2.BorderBrush = Brushes.Purple;

                    break;
                case 2:
                    tut_1 = new Turtle(board_main, 50, 950);
                    tut_2 = new Turtle(board_main, 50, 950);

                    tut_1.BrushDown = false;
                    tut_2.BrushDown = false;

                    apperance(tut_1, mw.type_1.Text, mw.colour_1.Text);
                    apperance(tut_2, mw.type_2.Text, mw.colour_2.Text);

                    lbl_pos3.Visibility = Visibility.Hidden;
                    lbl_pos4.Visibility = Visibility.Hidden;

                    Button(row_1, mw.colour_1.Text);
                    Button(row_2, mw.colour_2.Text);

                    break;
                case 3:
                    tut_1 = new Turtle(board_main, 50, 950);
                    tut_2 = new Turtle(board_main, 50, 950);
                    tut_3 = new Turtle(board_main, 50, 950);

                    tut_1.BrushDown = false;
                    tut_2.BrushDown = false;
                    tut_3.BrushDown = false;

                    apperance(tut_1, mw.one, mw.colour_1.Text);
                    apperance(tut_2, mw.two, mw.colour_2.Text);
                    apperance(tut_3, mw.three, mw.colour_3.Text);

                    lbl_pos4.Visibility = Visibility.Hidden;

                    Button(row_1, mw.colour_1.Text);
                    Button(row_2, mw.colour_2.Text);
                    Button(row_3, mw.colour_3.Text);

                    break;
                case 4:
                    tut_1 = new Turtle(board_main, 50, 950);
                    tut_2 = new Turtle(board_main, 50, 950);
                    tut_3 = new Turtle(board_main, 50, 950);
                    tut_4 = new Turtle(board_main, 50, 950);

                    tut_1.BrushDown = false;
                    tut_2.BrushDown = false;
                    tut_3.BrushDown = false;
                    tut_4.BrushDown = false;

                    apperance(tut_1, mw.one, mw.colour_1.Text);
                    apperance(tut_2, mw.two, mw.colour_2.Text);
                    apperance(tut_3, mw.three, mw.colour_3.Text);
                    apperance(tut_4, mw.four, mw.colour_4.Text);

                    Button(row_1, mw.colour_1.Text);
                    Button(row_2, mw.colour_2.Text);
                    Button(row_3, mw.colour_3.Text);
                    Button(row_4, mw.colour_4.Text);

                    break;
            }
           
        }
        
        private void main_menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void options_Click(object sender, RoutedEventArgs e)
        {
            options ow = new options();
            ow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
