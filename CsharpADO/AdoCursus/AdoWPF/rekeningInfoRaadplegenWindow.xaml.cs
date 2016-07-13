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
    /// Interaction logic for rekeningInfoRaadplegenWindow.xaml
    /// </summary>
    public partial class rekeningInfoRaadplegenWindow : Window
    {
        public rekeningInfoRaadplegenWindow()
        {
            InitializeComponent();
        }

        private void ButtonInfo_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager= new RekeningenManager();
                var info= manager.RekeningInfoRaadlplegen(TextBoxRekeningNr.Text);
                LabelSaldo.Content = info.Saldo.ToString("N");
                LabelKlantNaam.Content = info.KlantNaam;
                LabelStatus.Content = String.Empty;
            }
            catch (Exception ex)
            {
                LabelKlantNaam.Content = String.Empty;
                LabelSaldo.Content = String.Empty;
                LabelStatus.Content = ex.Message;
            }
           
            

        }
    }
}
