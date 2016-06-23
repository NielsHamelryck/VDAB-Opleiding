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
using System.Drawing;
using System.IO;
using System.Reflection;
using Microsoft.Win32;


namespace WpfEindoefening
{
    /// <summary>
    /// Interaction logic for Wenskaarten.xaml
    /// </summary>
    public partial class Wenskaarten : Window
    {
        public Wenskaarten()
        {
            InitializeComponent();
            Nieuw();
        }

        private void Nieuw()
        {
            StatusBarItem.Content = "nieuw";
            WindowOpacity.Opacity = 0;
            //MenuItemSave.IsEnabled = false;
            Dropzone_Canvas.Children.Clear();
            Dropzone_Canvas.Background=Brushes.White;
            TextBox_Wens.Text=string.Empty;
            GebruikteImage = string.Empty;
            AantalBallen = 0;
            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush) bc.ConvertFromString(info.Name);
                Kleur kleurtje = new Kleur();
                kleurtje.Borstel = deKleur;
                kleurtje.Naam = info.Name;
                kleurtje.Hex = deKleur.ToString();
                kleurtje.Rood = deKleur.Color.R;
                kleurtje.Groen = deKleur.Color.G;
                kleurtje.Blauw = deKleur.Color.B;
                ComboBoxKleuren.Items.Add(kleurtje);
            }
            //List<string> fonts = new List<string>();
            var fonts = Fonts.SystemFontFamilies.OrderBy(f => f.ToString());
            foreach (FontFamily font in fonts )
            {
                ComboBox_Lettertype.Items.Add(font);
            }
            
            
        }

        private string GebruikteImage = String.Empty;

        private void Kerstkaart_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Nieuw();
                WindowOpacity.Opacity = 1;
                GebruikteImage ="images/kerstkaart.jpg";
                    Dropzone_Canvas.Background = 
                    new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), GebruikteImage)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("kan de image niet laden\n" + ex.Message);
            }
        }

        private void Geboortekaart_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Nieuw();
                WindowOpacity.Opacity = 1;
                GebruikteImage = "images/geboortekaart.jpg";
                Dropzone_Canvas.Background =
                    new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), GebruikteImage)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("kan de image niet laden\n" + ex.Message);
            }
        }
       
        private void VerminderenRepeatButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox_Wens.FontSize > 10)
                TextBox_Wens.FontSize--;
        }

        private void VermeerderRepeatButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox_Wens.FontSize < 40)
                TextBox_Wens.FontSize++;
                
        }

        //drag drop voor de ballen
        private decimal AantalBallen = 0;
        private void OrgineleCirkelKleur_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && PreviewBall.Fill!=null)
            {

                Ellipse orgineleEllipse = (Ellipse)sender;

                 

                
                SolidColorBrush deKleur = (SolidColorBrush)orgineleEllipse.Fill;
               
                Ellipse cirkel = new Ellipse();
                cirkel.Fill = deKleur;
                
                

                DataObject SleepCirkel = new DataObject("SleepCirkel", cirkel);
                DragDrop.DoDragDrop(cirkel, SleepCirkel, DragDropEffects.Move);

            }
        }


        private void Canvas_drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("SleepCirkel") && Dropzone_Canvas.Background != Brushes.White)
            {

                Canvas canvas = (Canvas) sender;
                Point p = e.GetPosition(canvas);
                Ellipse GesleepteCirkel = (Ellipse) e.Data.GetData("SleepCirkel");

                if (Dropzone_Canvas.Width - 20 <= p.X)
                {
                    Canvas.SetLeft(GesleepteCirkel, p.X - 40);
                }
                else Canvas.SetLeft(GesleepteCirkel, p.X-20);
                if (Dropzone_Canvas.Height - 20 <= p.Y)
                {
                    Canvas.SetTop(GesleepteCirkel, p.Y - 40);
                }
                else Canvas.SetTop(GesleepteCirkel, p.Y-20);







                //linken mousemove event 
                GesleepteCirkel.MouseMove += GemaaktObject_MouseMove;
                GesleepteCirkel.MouseLeftButtonDown += shape_MouseLeftButtonDown;
                Dropzone_Canvas.Children.Add(GesleepteCirkel);
                AantalBallen++;


            }
            if (e.Data.GetDataPresent("gemaakt"))
            {
                Canvas Dropzone = (Canvas) sender;
                Point p = e.GetPosition(Dropzone);
                Ellipse GesleepteCirkel = (Ellipse) e.Data.GetData("gemaakt");
                if (Dropzone.Width - 20 <= p.X)
                {
                    Canvas.SetLeft(GesleepteCirkel, p.X - 40);
                }
                else Canvas.SetLeft(GesleepteCirkel, p.X-20);
                if (Dropzone.Height - 20 <= p.Y)
                {
                    Canvas.SetTop(GesleepteCirkel, p.Y - 40);
                }
                else Canvas.SetTop(GesleepteCirkel, p.Y-20);
                Dropzone.Children.Remove(sleepEllipse);
                Dropzone.Children.Add(GesleepteCirkel);
                AantalBallen++;
            }
        }

        private void RemoveCirkel_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("gemaakt"))
            {
                Dropzone_Canvas.Children.Remove(sleepEllipse);
                AantalBallen--;
                e.Handled = true;
            }
        }

        private void GemaaktObject_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.GetPosition(null);
            diff = startPoint - mousePos;
            if (AantalBallen > 0)
            {
                MenuItemSave.IsEnabled = true;
            }
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumHorizontalDragDistance))
            {
                sleepEllipse = (Ellipse)sender;

                DataObject sleepshape = new DataObject("gemaakt", sleepEllipse);
                DragDrop.DoDragDrop(sleepEllipse, sleepshape, DragDropEffects.Move);
            }
        }

        private Ellipse sleepEllipse;
        
        private Point startPoint;
        private Point mousePos;
        private Vector diff;
        private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



            startPoint = e.GetPosition(null);
        }

        private void Nieuw_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void Opslaan_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg= new SaveFileDialog();
                dlg.FileName = "Wenskaart";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Wenskaarten |*.txt";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(GebruikteImage);
                        bestand.WriteLine(AantalBallen);
                        foreach (Ellipse child in Dropzone_Canvas.Children)
                        {
                           
                            bestand.WriteLine(child.Fill);
                            bestand.WriteLine(Canvas.GetLeft(child));
                            bestand.WriteLine(Canvas.GetTop(child));
                        }
                        bestand.WriteLine(TextBox_Wens.Text);
                        bestand.WriteLine(TextBox_Wens.FontFamily.ToString());
                        bestand.WriteLine(TextBox_Wens.FontSize.ToString());
                    }
                }
                StatusBarItem.Content = dlg.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kan het bestandniet opslaan\n" + ex.Message);
            }
        }

        private void Window_closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Wilt u het programma sluiten?",
                "Afsluiten",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Close_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Open_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Wenskaart";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Wenskaarten |*.txt";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        WindowOpacity.Opacity = 1;
                        Dropzone_Canvas.Children.Clear();
                        AantalBallen = 0;
                        Dropzone_Canvas.Background =
                   new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this),bestand.ReadLine())));
                        AantalBallen = decimal.Parse(bestand.ReadLine());
                        for (var i = 0; i < AantalBallen; i++)
                        {
                            Ellipse cirkel = new Ellipse();
                            BrushConverter bc = new BrushConverter();
                            SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(bestand.ReadLine());
                            cirkel.Fill = deKleur;
                            
                            Canvas.SetLeft(cirkel,double.Parse(bestand.ReadLine()));
                            Canvas.SetTop(cirkel,double.Parse(bestand.ReadLine()));
                            cirkel.MouseMove += GemaaktObject_MouseMove;
                            cirkel.MouseLeftButtonDown += shape_MouseLeftButtonDown;
                            Dropzone_Canvas.Children.Add(cirkel);
                        }
                        TextBox_Wens.Text = bestand.ReadLine();
                        
                        
                        ComboBox_Lettertype.SelectedValue = new FontFamily(bestand.ReadLine());
                        TextBox_Wens.FontSize = double.Parse(bestand.ReadLine());


                       
                       
                    }
                }
                StatusBarItem.Content = dlg.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kan het bestand niet openen\n" + ex.Message);
            }
        }
    }
    }


