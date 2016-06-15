using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ParkingBonHerhaling;


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
            vertPositie = 96;
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            StatusBarLabel.Content = "nieuwe bon";
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (
                MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question,
                    MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content =
                Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5*bedrag).ToLongTimeString();
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5*bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content =
                Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5*bedrag).ToLongTimeString();
        }


        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                vertPositie = 96;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Bestand";
                dlg.DefaultExt = ".Bon";
                dlg.Filter = "Bon bestanden |*.Bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))

                    {

                        DatumBon.SelectedDate = DateTime.Parse(bestand.ReadLine());
                        AankomstLabelTijd.Content = bestand.ReadLine();
                        TeBetalenLabel.Content = bestand.ReadLine();
                        VertrekLabelTijd.Content = bestand.ReadLine();
                        StatusBarLabel.Content = dlg.FileName;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bestand kan niet geopend worden" + ex.Message);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                string stringetje = DatumBon.SelectedDate.Value.ToShortDateString().Replace("/", "-") +
                                    "om" + AankomstLabelTijd.Content.ToString().Replace(":", "-");
                dlg.FileName = stringetje;
                dlg.DefaultExt = ".Bon";
                dlg.Filter = "Bon bestanden |*.Bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {

                        bestand.WriteLine(DatumBon.SelectedDate);
                        bestand.WriteLine(AankomstLabelTijd.Content);
                        bestand.WriteLine(TeBetalenLabel.Content);
                        bestand.WriteLine(VertrekLabelTijd.Content);
                        StatusBarLabel.Content = dlg.FileName;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bestand kan niet opgeslagen worden" + ex.Message);
            }
        }

        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

        private double AfdrukvoorbeeldBreedte = 640d;
        private double AfdrukvoorbeeldHoogte = 320d;
        private double vertPositie = 96;

        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(AfdrukvoorbeeldBreedte, AfdrukvoorbeeldHoogte);

            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);

            FixedPage page = new FixedPage();
            inhoud.Child = page;

            page.Width = AfdrukvoorbeeldBreedte;
            page.Height = AfdrukvoorbeeldHoogte;

            page.Children.Add(fotoImage());
            page.Children.Add(Regel("Datum : " + DatumBon.SelectedDate.Value.ToLongDateString()));
            page.Children.Add(Regel("Starttijd: " + AankomstLabelTijd.Content));
            page.Children.Add(Regel("Eindtijd: " + VertrekLabelTijd.Content));
            page.Children.Add(Regel("Bedrag betaald: " + TeBetalenLabel.Content));

            return document;
        }

        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Text = tekst;
            deRegel.FontSize = 18;
            deRegel.Margin = new Thickness(300, vertPositie, 0, 0);
            vertPositie += 36;
            return deRegel;
        }

        private Image fotoImage()
        {
            Image img = new Image();

            img.Source = logoImage.Source;
            img.Margin = new Thickness(96, 96, 0, 0);
            return img;
        }

        


        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
