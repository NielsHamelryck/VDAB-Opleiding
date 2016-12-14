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

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point currentPosition;
        private Point startingpoint = new Point(190,310);
        private List<Point> bonusPoints = new List<Point>();
        Random rnd = new Random();
        private Enum MOVINGDIRECTION
        {
            UPWARDS = 8,
            DOWNWARDS = 2,
            TOLEFT = 4,
            TORIGHT = 6
        };
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            /*Hier kan de gebruiker de snelheid van de Snake aanpassen.
             * Snelheden zijn FAST , MODERATE , SLOW and DAMNSLOW*/

            timer.Interval = new TimeSpan(0,0,0,1); //MODERATE;
            timer.Start();
            
            this.KeyDown += new KeyEventHandler(OnButtenKeyDown);
            PaintSnake(startingpoint);
            currentPosition = startingpoint;

            //aanmaken van de appels

            for (int n = 0; n < 10; n++)
            {
                paintBonus(n);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //verlengen van het lichaam van de snake in de richting waarin deze zich begeeft

            switch (direction)
            {
                case (int)MOVINGDIRECTION.DOWNWARDS:
                    currentPosition.Y += 1;
                    PaintSnake(currentPosition);
                    break;
                case (int)MOVINGDIRECTION.UPNWARDS:
                    currentPosition.Y -= 1;
                    PaintSnake(currentPosition);
                    break;
                case (int)MOVINGDIRECTION.TORIGHT:
                    currentPosition.X -= 1;
                    PaintSnake(currentPosition);
                    break;
                case (int)MOVINGDIRECTION.TOLEFT:
                    currentPosition.X += 1;
                    PaintSnake(currentPosition);
                    break;
            }
            // ristricties voor de randen van de canvas

            if ((currentPosition.X < 5) || (currentPosition.X > 620) ||
                (currentPosition.Y < 5) || (currentPosition.Y > 380))
            {
                GameOver();
            }

            //het eten van een appel zorgt ervoor dat de lengte van de Snake verlengt

            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if (Math.Abs(point.X - currentPosition.X) < headSize &&
                    (Math.Abs(point.Y - currentPosition.Y) < headSize))
                {
                    length += 10;
                    score += 10;

                    //als de apple opgegeten word, verwijder dit object
                    //van de lijst apples en ook van de canvas
                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);
                    paintBonus(n);
                    break;
                }
                n++;
            }
            
            //Verhinderen van dat de snake zijn eigen body eet
            for (int q = 0; q < (snakePoints.Count - headSize*2); q++)
            {
                Point point = new Point(snakePoints[q].X,sankePoints[q].Y);
                if (Math.Abs(point.X - currentPosition.X) < (headSize) &&
                    (Math.Abs(point.Y - currentPosition.Y) < (headSize)))
                {
                    GameOver();
                    break;
                }
            }

        }

        private void OnButtenKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (previousDirection != (int) MOVINGDIRECTION.UPWARDS)
                        direction = (int) MOVINGDIRECTION.DOWNWARDS;
                    break;
                case Key.Up:
                     if (previousDirection != (int) MOVINGDIRECTION.DOWNWARDS)
                        direction = (int) MOVINGDIRECTION.UPWARDS;
                    break;
                case Key.Left:
                     if (previousDirection != (int) MOVINGDIRECTION.TORIGHT)
                        direction = (int) MOVINGDIRECTION.TOLEFT;
                    break;
                case Key.Right:
                    if (previousDirection != (int)MOVINGDIRECTION.TOLEFT)
                        direction = (int)MOVINGDIRECTION.TORIGHT;
                    break;
            }
            previousDirection = direction;
        }

        private void paintBonus(int index)
        {
            Point bonusPoint = new Point(rnd.Next(5,620, rnd.Next(5,380)));

            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Red;
            newEllipse.Width = headSize;
            newEllipse.Width = headSize;

            Canvas.SetTop(newEllipse, bonusPoint.Y);
            Canvas.SetLeft(newEllipse, bonusPoint.X);
            
            paintCanvas.Children.Insert(index,newEllipse);
            bonusPoints.Insert(index, bonusPoint);

        }

        public void PaintSnake(Point currentposition)
        {
            /*Deze methode word gebruikt om een frame te tekenen van het lichaam van de snake
             * elke keer deze aangeroepen word*/
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = snakeColor;
            newEllipse.Width = headSize;
            newEllipse.Height = headSize;

            Canvas.SetTop(newEllipse,currentposition.Y);
            Canvas.SetLeft(newEllipse,currentposition.X);

            int count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(newEllipse);
            snakePoints.Add(currentposition);

            //begrens de staart van de snake

            if (count > lenght)
            {
                paintCanvas.Children.RemoveAt(count-length +10);
                snakePoints.RemoveAt(count - lenght);
            }

        }
    }
}
