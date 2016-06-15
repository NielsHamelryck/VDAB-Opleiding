using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragShapes
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    bool captured = false;
    double x_shape, x_canvas, y_shape, y_canvas;
    UIElement source = null;

    private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      source = (UIElement)sender;
      Mouse.Capture(source);
      captured = true;
      x_shape = Canvas.GetLeft(source);
      x_canvas = e.GetPosition(LayoutRoot).X;
      y_shape = Canvas.GetTop(source);
      y_canvas = e.GetPosition(LayoutRoot).Y;
    }

    private void shape_MouseMove(object sender, MouseEventArgs e)
    {
      if (captured)
      {
        double x = e.GetPosition(LayoutRoot).X;
        double y = e.GetPosition(LayoutRoot).Y;
        x_shape += x - x_canvas;
        Canvas.SetLeft(source, x_shape);
        x_canvas = x;
        y_shape += y - y_canvas;
        Canvas.SetTop(source, y_shape);
        y_canvas = y;
      }
    }

    private void shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      Mouse.Capture(null);
      captured = false;
    }
  }
}
