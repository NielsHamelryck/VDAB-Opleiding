using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using pizzaBestellenMVVM.Model;
using pizzaBestellenMVVM.View;


namespace pizzaBestellenMVVM.ViewModel
{
    public class PizzaBestellenViewModel : ViewModelBase
    {
        private PizzaBestelling bestelling;

        public PizzaBestellenViewModel(PizzaBestelling bon)
        {
            bestelling = bon;
        }

        public Boolean SmallPizza
        {
            get
            {
                return bestelling.SmallPizza; 
                
            }
            set
            {
                bestelling.SmallPizza = value;
                RaisePropertyChanged("SmallPizza");
            }
        }
        public Boolean MediumPizza
        {
            get
            {
                return bestelling.MediumPizza;

            }
            set
            {
                bestelling.MediumPizza = value;
                RaisePropertyChanged("MediumPizza");
            }
        }
        public Boolean LargePizza
        {
            get
            {
                return bestelling.LargePizza;

            }
            set
            {
                bestelling.LargePizza = value;
                RaisePropertyChanged("LargePizza");
            }
        }
        public Boolean DikkeKorst
        {
            get { return bestelling.DikkeKorst; }
            set
            {
                bestelling.DikkeKorst = value; 
                RaisePropertyChanged("DikkeKorst");
            }
        }

        public Boolean ExtraKaas
        {
            get { return bestelling.ExtraKaas; }
            set
            {
                bestelling.ExtraKaas=value;
                RaisePropertyChanged("ExtraKaas");
            }
        }

        public string AantalPizzas
        {
            get { return bestelling.AantalPizzas; }
            set
            {
                bestelling.AantalPizzas = value;
                RaisePropertyChanged("AantalPizzas");
            }
        }

        public Boolean Tomaat
        {
            get { return bestelling.Tomaat; }
            set
            {
                bestelling.Tomaat = value;
                RaisePropertyChanged("Tomaat");
            }
        }

        public Boolean Kaas
        {
            get { return bestelling.Kaas; }
            set
            {
                bestelling.Kaas = value;
                RaisePropertyChanged("Kaas");
            }
        }

        public Boolean Ham
        {
            get { return bestelling.Ham; }
            set
            {
                bestelling.Ham = value;
                RaisePropertyChanged("Ham");
            }
        }

        public Boolean Ananas
        {
            get { return bestelling.Ananas; }
            set
            {
                bestelling.Ananas = value;
                RaisePropertyChanged("Ananas");
            }
        }

        public Boolean Salami
        {
            get { return bestelling.Salami; }
            set
            {
                bestelling.Salami = value;
                RaisePropertyChanged("Salami");
            }
        }
        public BitmapImage Logo
        {
            get { return bestelling.Logo; }
            set
            {
                bestelling.Logo = value;
                RaisePropertyChanged("Logo");
            }
        }

        public RelayCommand NieuwCommand
        {
            get { return new RelayCommand(Nieuw);}

        }

        private void Nieuw()
        {
            LargePizza = true;
            DikkeKorst = false;
            ExtraKaas = false;
            AantalPizzas = "1";
            Ham = false;
            Ananas = false;
            Salami = false;
            Logo = new BitmapImage(new Uri("images/pizza.jpg", UriKind.Relative));
        }

        public RelayCommand<StartupEventArgs> WindowLoaded
        {
            get { return new RelayCommand<StartupEventArgs>(Window_Loaded); }
        }

        private void Window_Loaded(StartupEventArgs e)
        {
            Nieuw();
        }

        public RelayCommand OpslaanCommand
        {
            get {  return new RelayCommand(Opslaan);}
        }

        private void Opslaan()
        {
            try
            {
                string stringetje = "Bestelling_" + DateTime.Now.ToShortDateString().Replace("/", "-") + "om" +
                                    DateTime.Now.ToShortTimeString().Replace(":", "-");
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = stringetje;
                dlg.DefaultExt = ".pizza";
                dlg.Filter = "Pizza bestelDocument |*.pizza";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(SmallPizza.ToString());
                        bestand.WriteLine(MediumPizza.ToString());
                        bestand.WriteLine(LargePizza.ToString());
                        bestand.WriteLine(DikkeKorst.ToString());
                        bestand.WriteLine(ExtraKaas.ToString());
                        bestand.WriteLine(AantalPizzas);
                        bestand.WriteLine(Ham.ToString());
                        bestand.WriteLine(Ananas.ToString());
                        bestand.WriteLine(Salami.ToString());
                        
                    } }

        }
            catch (Exception ex)
            {
                MessageBox.Show("Kan het bestand niet opslaan \n" + ex.Message);
            }
        }

        public RelayCommand OpenenCommand
        {
            get { return new RelayCommand(Openen);}
        }

        private void Openen()
        {
            try
            {
               OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "PizzaBestelling";
                dlg.DefaultExt = ".pizza";
                dlg.Filter="Pizza bestelDocument |*.pizza";

                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        SmallPizza = Convert.ToBoolean(bestand.ReadLine());
                        MediumPizza = Convert.ToBoolean(bestand.ReadLine());
                        LargePizza = Convert.ToBoolean(bestand.ReadLine());
                        DikkeKorst = Convert.ToBoolean(bestand.ReadLine());
                        ExtraKaas = Convert.ToBoolean(bestand.ReadLine());
                        AantalPizzas = bestand.ReadLine();
                        Ham = Convert.ToBoolean(bestand.ReadLine());
                        Ananas = Convert.ToBoolean(bestand.ReadLine());
                        Salami= Convert.ToBoolean(bestand.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kan de bestelling niet opslaan \n"+ex.Message);
                
            }
        }

        public RelayCommand MeerPizzasCommand
        {
            get { return new RelayCommand(Verhoog);}
        }

        private void Verhoog()
        {
            if (Convert.ToInt32(AantalPizzas) < 10) {
                int aantal = Convert.ToInt32(AantalPizzas);

            aantal += 1;

            AantalPizzas = aantal.ToString();}
        }
        public RelayCommand MinderPizzasCommand
        {
            get { return new RelayCommand(Verminder); }
        }

        private void Verminder()
        {
            if (Convert.ToInt32(AantalPizzas) > 1)
            {
                int aantal = Convert.ToInt32(AantalPizzas);

                aantal -= 1;

                AantalPizzas = aantal.ToString();
            }
        }

        public RelayCommand BestellenCommand
        {
            get { return new RelayCommand(Preview);}
        }

        private string pizzaGrootte;
        private string toppings="Tomaat\nKaas\n";

        private void Preview()
        {
            string bestellinggegevens = "U heeft " + AantalPizzas;

            if (SmallPizza)
            {
                bestellinggegevens += " small pizza('s) besteld met:\n" +
                                      "-Tomaat\n-Kaas";
                pizzaGrootte = "small pizza";
            }
            if (MediumPizza)
            {
                bestellinggegevens += " medium pizza('s) besteld met:\n" +
                                      "-Tomaat\n-Kaas";
                pizzaGrootte = "medium pizza";
            }
            if (LargePizza)
            {
                bestellinggegevens += " Large pizza('s) besteld met:\n" +
                                      "-Tomaat\n-Kaas";
                pizzaGrootte = "large pizza";
            }
            if (Ham)
            {
                bestellinggegevens += "\n-Ham";
                toppings += "Ham\n";
            }
            if (Ananas)
            {
                bestellinggegevens += "\n-Ananas";
                toppings += "Ananas\n";
            }
            if (Salami)
            {
                bestellinggegevens += "\n-Salami";
                toppings += "Salami\n";
            }

            if (DikkeKorst)
            {
                bestellinggegevens += "\n-extra dikke korst";
                toppings += "extra dikke korst\n";
            }
            if (ExtraKaas)
            {
                bestellinggegevens += "\n-extra kaas";
                toppings += "extra kaas";
            }

           // if (
                MessageBox.Show(bestellinggegevens + "\n\nTicket afdrukken", "Ticket", MessageBoxButton.YesNo,
                    MessageBoxImage.Question, MessageBoxResult.Yes);// == MessageBoxResult.Yes)


                
        }

        public RelayCommand TicketDrukkenCommand
        {
            get { return new RelayCommand(Afdrukken);}
        }

        
        private void Afdrukken()
        {
 //           // printing with Preview

 //var pd = new PrintDialog();

 //// calculate page size
 //var sz = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);

 //// create paginator
 //var paginator = new FlexPaginator(_flex, ScaleMode.PageWidth, sz, new Thickness(96 / 4), 100);
 //string tempFileName = System.IO.Path.GetTempFileName();

 //File.Delete(tempFileName);

 //using (XpsDocument xpsDocument = new XpsDocument(tempFileName, FileAccess.ReadWrite))
 //{
 //XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
 //writer.Write(paginator);
 //DocumentViewer previewWindow = new DocumentViewer
 //{
 //Document = xpsDocument.GetFixedDocumentSequence()
 //};

 //Window printpriview = new Window();
 //printpriview.Content = previewWindow;
 //printpriview.Title = "C1FlexGrid: Print Preview";
 //printpriview.Show();
 //}
}
        

        private double Ticketbreedte = 300;
        private double Tickethoogte = 800;
        private double vertPos = 100;
        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(Ticketbreedte,Tickethoogte);

            PageContent inhoud =new PageContent();
            document.Pages.Add(inhoud);

            FixedPage page = new FixedPage();
            inhoud.Child = page;

            page.Width = Ticketbreedte;
            page.Height = Tickethoogte;

            page.Children.Add(Foto());
            page.Children.Add(Regel("Bestelling"));
            page.Children.Add(Regel(pizzaGrootte + "    x " + AantalPizzas));
            page.Children.Add(Regel(toppings));

            return document;
        }

        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel =  new TextBlock();
            deRegel.Text = tekst;
            deRegel.Margin=new Thickness(50,vertPos,50,50);
            vertPos += 30;
            return deRegel;
        }

        private Image Foto()
        {
            Image foto=new Image();
            BitmapImage deFoto = Logo;
            deFoto.UriSource = Logo.UriSource;
            foto.Source = deFoto;
            return foto;
        }
       }

}


