using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brush = System.Windows.Media.Brush;
using Point = System.Drawing.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace OmzettenKleurInCirkel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur= (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleurtje = new Kleur();
                kleurtje.Borstel = deKleur;
                kleurtje.Naam = info.Name;
                kleurtje.Hex = deKleur.ToString();
                kleurtje.Rood = deKleur.Color.R;
                kleurtje.Groen = deKleur.Color.G;
                kleurtje.Blauw = deKleur.Color.B;
                Kleuren.Items.Add(kleurtje);
                if(kleurtje.Naam=="Black")
                {
                    Kleuren.SelectedItem = kleurtje;
                }

            }

            
       
        
        }

        //private ComboBoxItem VindComboBoxItem(Object sleepitem)
        //{
        //    DependencyObject keuze = (DependencyObject) sleepitem;
        //    while (keuze != null)
        //    {
        //        if (keuze is ComboBoxItem)
        //            return (ComboBoxItem) keuze;
        //        keuze = VisualTreeHelper.GetParent(keuze);

        //    }
        //    return null;
        //}

       

        private void DragComboBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               
                Label kleurLabel = (Label) sender;
                string kleur = kleurLabel.Content.ToString();
                
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(kleur);
                foreach (Kleur kleurtje in Kleuren.Items)
                {
                    if (kleurtje.Naam == kleur)
                    {
                        Kleuren.SelectedItem = kleurtje;
                    }
                }


                SolidColorBrush randKleur = (SolidColorBrush)bc.ConvertFromString("Black");
                    Ellipse cirkel = new Ellipse();
                    cirkel.Fill = deKleur;
                    cirkel.Stroke = randKleur;
                    cirkel.StrokeThickness = 2;
                    cirkel.Width = 30;
                    cirkel.Height = 30;

                    DataObject SleepCirkel = new DataObject("SleepCirkel", cirkel);
                    DragDrop.DoDragDrop(cirkel, SleepCirkel, DragDropEffects.Move);
                
            }
        }

        private void DropComboBox_drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("SleepCirkel"))
            {
                
                Canvas canvas = (Canvas) sender;
                System.Windows.Point p = e.GetPosition(canvas);
                Ellipse GesleepteCirkel = (Ellipse) e.Data.GetData("SleepCirkel");
                
                if (Dropzone.Width - 30 <= p.X)
                {
                    Canvas.SetLeft(GesleepteCirkel, p.X - 30);
                }
                else Canvas.SetLeft(GesleepteCirkel, p.X);
                if (Dropzone.Height - 30 <= p.Y)
                {
                    Canvas.SetTop(GesleepteCirkel, p.Y- 30);
                }
                else Canvas.SetTop(GesleepteCirkel, p.Y);





               

                //linken mousemove event 
                GesleepteCirkel.MouseMove += GemaaktObject_MouseMove;
                GesleepteCirkel.MouseLeftButtonDown += shape_MouseLeftButtonDown;
                Dropzone.Children.Add(GesleepteCirkel);
                

            }
            if (e.Data.GetDataPresent("gemaakt"))
            {
                Canvas Dropzone = (Canvas)sender;
                System.Windows.Point p = e.GetPosition(Dropzone);
                Ellipse GesleepteCirkel = (Ellipse)e.Data.GetData("gemaakt");
                if (Dropzone.Width - 30 <= p.X)
                {
                    Canvas.SetLeft(GesleepteCirkel, p.X - 30);
                }
                else Canvas.SetLeft(GesleepteCirkel, p.X);
                if (Dropzone.Height - 30 <= p.Y)
                {
                    Canvas.SetTop(GesleepteCirkel, p.Y - 30);
                }
                else Canvas.SetTop(GesleepteCirkel, p.Y);
                Dropzone.Children.Remove(sleepEllipse);
                Dropzone.Children.Add(GesleepteCirkel);
            }
        }
        //NIEUWE aanpassingen
        private void GemaaktObject_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.GetPosition(null);
            diff = startPoint - mousePos;

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
        
        private System.Windows.Point startPoint;
        private System.Windows.Point mousePos;
        private Vector diff;
        private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



            startPoint = e.GetPosition(null);
        }

        //private bool ddIsMouseDown;
        //private bool ddIsBeingDragged;
        //private Ellipse ddOrgineleCirkel;
        //private Ellipse ddOverlayEllipse;
        //private System.Windows.Point ddStartPoint;
        

        //private void DropZone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.Source == Dropzone)
        //    {
        //        return;
        //    }
        //    ddIsMouseDown = true;
        //        ddStartPoint = e.GetPosition(Dropzone);
        //        ddOrgineleCirkel = (Ellipse) e.Source;
        //        Dropzone.CaptureMouse();
        //        e.Handled = true;
            
        //    }

        //private void Dropzone_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    if (ddIsMouseDown)
        //    {
        //        if (!ddIsBeingDragged)
        //        {
                    
        //        }
        //    }
        //}
        private void RemoveCirkel_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("gemaakt"))
            {
                Dropzone.Children.Remove(sleepEllipse);
                //Belangrijk tegen event bubbeling
                e.Handled = true;
            }
        }

        private void ClearCanvas_OnClick(object sender, RoutedEventArgs e)
        {
            Dropzone.Children.Clear();
        }

        private void Foto1_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                Dropzone.Background =
                    new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/kerstboom.jpg")));
            }
            catch (Exception ex)
            {
                MessageBox.Show("kan de image niet laden\n" + ex.Message);
            }
        }

        private void Foto2_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                Dropzone.Background =
                    new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/CrashBandicoot.jpg")));
            }
            catch (Exception ex)
            {
                MessageBox.Show("kan de image niet laden\n" + ex.Message);
            }
        }
    }
}
