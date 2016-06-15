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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace DragDropInCanvas
{
    /// <summary>
    /// Interaction logic for DragDropWindow.xaml
    /// </summary>
    public partial class DragDropWindow : Window
    {
        public DragDropWindow()
        {
            InitializeComponent();
        }

       
        Rectangle sleepRectangle = new Rectangle();
        private Point startPoint;
        private Point mousePos;
        private Vector diff;
        private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
           
            
            startPoint = e.GetPosition(null);
        }
        private void shape_MouseMove(object sender, MouseEventArgs e)
        {
        mousePos = e.GetPosition(null);
             diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumHorizontalDragDistance))
            {
                sleepRectangle = (Rectangle) sender;
                
                DataObject sleepshape = new DataObject("rechthoek", sleepRectangle);
                DragDrop.DoDragDrop(sleepRectangle, sleepshape, DragDropEffects.Move);
            }
        }
       


        private void DestroyObject_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("rechthoek"))
            {
                DropZone.Children.Remove(sleepRectangle);
                //Belangrijk tegen event bubbeling
                e.Handled = true;
            }
        }

        private void DropZone_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("rechthoek"))
            {
                Canvas Dropzone = (Canvas) sender;
                Point p = e.GetPosition(Dropzone);
                Rectangle rechthoekRectangle = (Rectangle) e.Data.GetData("rechthoek");
                Canvas.SetLeft(rechthoekRectangle, p.X  );
                Canvas.SetTop(rechthoekRectangle, p.Y);
                Dropzone.Children.Remove(sleepRectangle);
                Dropzone.Children.Add(rechthoekRectangle);
                
            }
        }

       
    }
}
