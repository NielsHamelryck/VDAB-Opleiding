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

namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for BonAfdrukPreviewWindow.xaml
    /// </summary>
    public partial class BonAfdrukPreviewWindow : Window
    {
        public BonAfdrukPreviewWindow()
        {
            InitializeComponent();
        }

        public IDocumentPaginatorSource BonAfdrukken
        {
            get { return printpreview.Document; }
            set { printpreview.Document = value; }
        }
    }
}
