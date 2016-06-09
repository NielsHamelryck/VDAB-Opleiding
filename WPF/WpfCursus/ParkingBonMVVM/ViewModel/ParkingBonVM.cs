using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;

namespace ParkingBonMVVM.ViewModel
{
    public class ParkingBonVM : ViewModelBase
    {
        private Model.ParkeerBon ingevuldeBon;
        public ParkingBonVM(Model.ParkeerBon bon)
        {
            ingevuldeBon = bon;
        }

        public DateTime Datum
        {
            get { return ingevuldeBon.Datum; }
            set
            {
                ingevuldeBon.Datum = value;
                RaisePropertyChanged("Datum");
            }
        }

        public string AankomstTijd
        {
            get { return ingevuldeBon.Aankomstijd; }
            set
            {
                ingevuldeBon.Aankomstijd = value;
                RaisePropertyChanged("AankomstTijd");
                
            }
        }

        public string Bedrag
        {
            get { return ingevuldeBon.TeBetalen; }
            set
            {
                ingevuldeBon.TeBetalen = value;
                RaisePropertyChanged("Bedrag");
                RaisePropertyChanged("isBedrag0");
            }
        }

        public string VertrekTijd
        {
            get
            {
                return ingevuldeBon.VertrekTijd;
                
            }
            set
            {
                ingevuldeBon.VertrekTijd = value;
                RaisePropertyChanged("VertrekTijd");
            }
        }

        public RelayCommand NieuwCommand
        {
            get { return new RelayCommand(NieuweBon); }
        }

        private void NieuweBon()
        {
            Datum= DateTime.Now;
            AankomstTijd = DateTime.Now.ToShortTimeString();
            Bedrag = "0 €";
            VertrekTijd = AankomstTijd;
            
        }

        public RelayCommand OpslaanCommand
        {
            get { return new RelayCommand(OpslaanBestand);}
        }

        private void OpslaanBestand()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                string bestandsnaam = Datum.ToShortDateString().Replace("/","-") + "om" + AankomstTijd.Remove(AankomstTijd.Length-3,3).Replace(":","-");
                dlg.FileName = bestandsnaam;
                dlg.DefaultExt = ".bon";
                dlg.Filter = "ParkeerBon document |*.bon";
                
                
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(Datum.ToString());
                        bestand.WriteLine(AankomstTijd);
                        bestand.WriteLine(Bedrag);
                        bestand.WriteLine(VertrekTijd);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan Mislukt: " + ex.Message);
            }
        }

        public RelayCommand OpenenCommand
        {
            get { return new RelayCommand(Openbestand);}
        }

        private void Openbestand()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "ParkeerBon";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "ParkeerBon document |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        Datum = Convert.ToDateTime(bestand.ReadLine());
                        AankomstTijd = bestand.ReadLine();
                        Bedrag = bestand.ReadLine();
                        VertrekTijd = bestand.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Openen mislukt: " + ex.Message);
            }
        }

        public RelayCommand AfsluitCommand {
            get { return new RelayCommand(AfsluitenApp);}
    }

        private void AfsluitenApp()
        {
            Application.Current.MainWindow.Close();
        }

        public RelayCommand<CancelEventArgs> ClosingCommand
        {
            get {  return new RelayCommand<CancelEventArgs>(OnWindowClosing);}
        }

        private void OnWindowClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Wilt u de applicatie sluiten?", "Afsluiten"
                , MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;  
            }
        
        }
        //Button Gedrag opslaan
        public Boolean isBedrag0
        {
            get { return MagOpslaan();}
        }

        private Boolean MagOpslaan()
        {
            
                var getal = int.Parse(Bedrag.Replace(" €", ""));
                var groterDan0 = false;

                if (getal > 0)
                {
                    groterDan0 = true;
                    
                }
                return groterDan0;
            
        }

        // bedrag verhogen/verlagen

        public RelayCommand Verminder
        {
            get { return new RelayCommand(minder_Click);}
        }
        private void minder_Click()
        {
            int bedrag = Convert.ToInt32(Bedrag.Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            Bedrag = bedrag.ToString() + " €";
            VertrekTijd = Convert.ToDateTime(AankomstTijd).AddHours(0.5 * bedrag).ToShortTimeString();
        }

        public RelayCommand Vermeerder
        {
            get { return new RelayCommand(meer_Click);}
        }

        private void meer_Click()
        {
            int bedrag = Convert.ToInt32(Bedrag.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstTijd).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            Bedrag = bedrag.ToString() + " €";
            VertrekTijd = Convert.ToDateTime(AankomstTijd).AddHours(0.5 * bedrag).ToShortTimeString();
        }

    }
}
