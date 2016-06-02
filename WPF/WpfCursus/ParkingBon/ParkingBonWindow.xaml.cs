using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for ParkingBonWindow.xaml
    /// </summary>
    public partial class ParkingBonWindow : Window
    {
        public ParkingBonWindow()
        {
            InitializeComponent();
            Nieuw();
        }


        private void Nieuw()
        { 
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;        
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
        }

        private void NieuweBon_OnClick(object sender, RoutedEventArgs e)
        {
            Nieuw();
        }

        private void OpenBon_OnClick(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "BonNaam";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Bon documenten |*.bon";
                

                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        DatumBon.SelectedDate = DateTime.Parse(bestand.ReadLine());
                        VertrekLabelTijd.Content = bestand.ReadLine();
                        TeBetalenLabel.Content = bestand.ReadLine();
                        AankomstLabelTijd.Content = bestand.ReadLine();

                    }StatusBarItem.Content = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kan het bestand niet openen" + ex.Message);
            }
        }

        private void OpslaanBon_OnClick(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string teBetalen = TeBetalenLabel.Content.ToString();
                teBetalen= teBetalen.Replace(" €", "");
                string vertrektijd = VertrekLabelTijd.Content.ToString();
                vertrektijd = vertrektijd.Replace(":", "-");

                SaveFileDialog dlg = new SaveFileDialog();

                var stringetje = String.Format("{0:dd-MM-yyyy}om{1}", DatumBon.SelectedDate, vertrektijd);
                dlg.FileName = stringetje;
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Bon documenten |*.bon";
                if (int.Parse(teBetalen) > 0)
                {
                    if (dlg.ShowDialog() == true)
                    {
                        using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                        {
                            bestand.WriteLine(DatumBon.SelectedDate);
                            bestand.WriteLine(VertrekLabelTijd.Content);
                            bestand.WriteLine(BedragLabel.Content);
                            bestand.WriteLine(AankomstLabelTijd.Content);
                        }
                        StatusBarItem.Content = dlg.FileName;
                    }
                    
                    

                }else
                        MessageBox.Show("Het te betalen bedrag mag niet 0 zijn!", "Te betalen bedrag",
                            MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kan het bestand niet opslaan" + ex.Message);
            }
        }
    }
}
