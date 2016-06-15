using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using ParkingbonMVVMHerhaling.Model;
using ParkingbonMVVMHerhaling.ViewModel;

namespace ParkingbonMVVMHerhaling.ViewModel
{
    public class ParkingBonVM : ViewModelBase
    {
        private ParkingBon bonnetje;

        public ParkingBonVM(ParkingBon bon)
        {
            bonnetje = bon;
            //Nieuw();
            
        }

        public DateTime DatumBon
        {
            get { return bonnetje.DatumBon; }
            set
            {
                bonnetje.DatumBon = value;
                RaisePropertyChanged("DatumBon");
            }
        }

        public string AankomstTijd
        {
            get { return bonnetje.AankomstTijd; }
            set
            {
                bonnetje.AankomstTijd = value;
                RaisePropertyChanged("AankomstTijd");
            }
        }

        public string VertrekTijd
        {
            get { return bonnetje.VertrekTijd; }
            set
            {
                bonnetje.VertrekTijd = value;
                RaisePropertyChanged("VertrekTijd");
            }
        }

        public string TeBetalenBedrag
        {
            get { return bonnetje.TeBetalenBedrag; }
            set
            {
                bonnetje.TeBetalenBedrag = value;
                RaisePropertyChanged("TeBetalenBedrag");
            }
        }


        public RelayCommand NieuwCommand
        {
            get { return new RelayCommand(Nieuw);}
        }

        private void Nieuw()
        {
            DatumBon = DateTime.Now;
            AankomstTijd = DateTime.Now.ToShortTimeString();
            VertrekTijd = AankomstTijd;
            TeBetalenBedrag = "0 €";
        }

        public RelayCommand OpenCommand
        {
            get {  return new RelayCommand(BestandOpenen);}
        }

        private void BestandOpenen()
        {
            try
            {
                OpenFileDialog dlg= new OpenFileDialog();
                dlg.FileName = "document";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Bon bestand |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        DatumBon = DateTime.Parse(bestand.ReadLine());
                        AankomstTijd = bestand.ReadLine();
                        TeBetalenBedrag = bestand.ReadLine();
                        VertrekTijd = bestand.ReadLine();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kan het bestand niet openen : \n" + ex.Message);
            }
            
        }

        public RelayCommand OpslaanCommand
        {
            get {  return new RelayCommand(OpslaanBestand);}
        }

        private void OpslaanBestand()
        {
            try
            {
                string opslaanstring = DatumBon.ToShortDateString().Replace("/","-")+"om"
                    +AankomstTijd.Replace(":","-");
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = opslaanstring;
                dlg.DefaultExt = ".bon";
                dlg.Filter = "bon bestand |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(DatumBon);
                        bestand.WriteLine(AankomstTijd);
                        bestand.WriteLine(TeBetalenBedrag);
                        bestand.WriteLine(VertrekTijd);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Kan het bestand niet opslaan : \n" + ex.Message);
            }
        }

        public RelayCommand AfsluitCommand
        {
            get {  return new RelayCommand(Afsluiten);}
        }

        private void Afsluiten()
        {
            Application.Current.MainWindow.Close();
        }

        public RelayCommand<CancelEventArgs> ClosingCommand
        {
            get { return new RelayCommand<CancelEventArgs>(OnWindowClosing);}
        }

        private void OnWindowClosing(CancelEventArgs e)
        {
            if (
                MessageBox.Show("Afsluiten", "Wilt u het programma sluiten?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        public RelayCommand Verminderen
        {
            get {  return new RelayCommand(verminder);}
        }
        private void verminder()
        {
            int bedrag = Convert.ToInt32(TeBetalenBedrag.Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            TeBetalenBedrag = bedrag.ToString() + " €";
            VertrekTijd = Convert.ToDateTime(AankomstTijd).AddHours(0.5 * bedrag).ToShortTimeString();
        }

        public RelayCommand Vermeerderen
        {
            get {  return new RelayCommand(Vermeerder);}
        }

        private void Vermeerder()
        {
            int bedrag = Convert.ToInt32(TeBetalenBedrag.Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstTijd).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenBedrag= bedrag + " €";
            VertrekTijd = Convert.ToDateTime(AankomstTijd).AddHours(0.5 * bedrag).ToShortTimeString();
        }
    }

    public class TextToBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != string.Empty)
            {
                string text = value.ToString();
                text = text.Remove(text.Length-2,2);
            int bedrag = int.Parse(text);
            
            if (bedrag == 0)
                return false;
            else return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
