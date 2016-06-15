﻿using System;
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
                Random random = new Random();
                Canvas canvas = (Canvas) sender;
                System.Windows.Point p = e.GetPosition(canvas);
                Ellipse GesleepteCirkel = (Ellipse) e.Data.GetData("SleepCirkel");
                //GesleepteCirkel.Margin = new Thickness(random.Next(30, 230), random.Next(30, 220), random.Next(30, 230), random.Next(30, 220));
                Canvas.SetLeft(GesleepteCirkel,p.X);
                Canvas.SetTop(GesleepteCirkel,p.Y);
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
                Canvas.SetLeft(GesleepteCirkel, p.X);
                Canvas.SetTop(GesleepteCirkel, p.Y);
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
    }
}
