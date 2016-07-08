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
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using AdoGemeenschap;

namespace AdoWPF
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

        private void ButtonBieren_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new BierenDbManager();
                
                using (var conBieren = manager.GetConnection())
                {

                    
                    
                    conBieren.Open();
                    LabelStatus.Content = "Bieren geopend";
                }
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message;
            }
        }

        private void ButtonBonus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new RekeningenManager(); 
                LabelStatus.Content = manager.SaldoBonus() + " rekeningen aangepast";
            }
            catch (Exception ex)
            {
                LabelStatus.Content = ex.Message; 
            }
                    }

        private void ButtonStorten_OnClick(object sender, RoutedEventArgs e)
        {
            Decimal teStorten;
            if (decimal.TryParse(TextBoxTeStorten.Text, out teStorten))
            {
                try
                {
                    var manager = new RekeningenManager();
                    if (manager.Storten(teStorten, TextBoxRekeningnr.Text))
                    {
                        LabelStatus.Content = "OK";
                    }
                    else
                    {
                        LabelStatus.Content = "Rekening nummer niet gevonden";
                    }

                }
                catch (Exception ex)
                {
                    LabelStatus.Content = ex.Message;
                }
            }
            else
            {

                LabelStatus.Content = "Tik een getal bij het storten";

            }
            
        }
    }
}
