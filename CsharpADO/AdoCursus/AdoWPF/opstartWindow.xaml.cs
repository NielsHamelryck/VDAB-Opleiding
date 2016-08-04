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
using AdoGemeenschap;

namespace AdoWPF
{
    /// <summary>
    /// Interaction logic for opstartWindow.xaml
    /// </summary>
    public partial class opstartWindow : Window
    {
        public opstartWindow()
        {
            InitializeComponent();
        }

        private void ButtonOverschrijven_OnClick(object sender, RoutedEventArgs e)
        {

            Decimal bedrag;
            if (decimal.TryParse(TextBoxBedrag.Text, out bedrag))
            {
                try
                {
                    var manager = new RekeningenManager();
                    manager.Overschrijven(bedrag, TextBoxVanRekNr.Text, TextBoxNaarRekNr.Text);
                    LabelStatus.Content = "Ok";
                }
                catch (Exception ex)
                {
                    LabelStatus.Content = ex.Message;
                }
            }
            else
            {
                LabelStatus.Content = "bedrag bevat geen getal";
            }


        }
    }
}
