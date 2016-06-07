using System;
using System.Collections.Generic;
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
using System.Reflection;

namespace BloemSamenstelling
{
    /// <summary>
    /// Interaction logic for BloemWindow.xaml
    /// </summary>
    public partial class BloemWindow : Window
    {
        public List<Kleur> list { get; set; }
         public BloemWindow()
        {
            InitializeComponent();
             cirkelsKleuren.DataContext = this;
             list = new List<Kleur>();
             foreach (PropertyInfo info in typeof(Colors).GetProperties())
             {
                 BrushConverter bc = new BrushConverter();
                 SolidColorBrush dekleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                 Kleur kleurtje = new Kleur();
                 kleurtje.Borstel = dekleur;
                 kleurtje.Naam = info.Name;
                 kleurtje.Hex = dekleur.ToString();
                 kleurtje.Rood = dekleur.Color.R;
                 kleurtje.Groen = dekleur.Color.G;
                 kleurtje.Blauw = dekleur.Color.B;
                 //cirkelsKleuren.Items.Add(kleurtje);
                 cirkelKaderKleuren.Items.Add(kleurtje);
                 rechthoekenKleuren.Items.Add(kleurtje);
                 rechthoekKaderKleuren.Items.Add(kleurtje);

                 list.Add(kleurtje);

                 if (kleurtje.Naam == "Black")
                 {
                     cirkelsKleuren.SelectedItem = kleurtje;
                     cirkelKaderKleuren.SelectedItem = kleurtje;
                     rechthoekenKleuren.SelectedItem = kleurtje;
                     rechthoekKaderKleuren.SelectedItem = kleurtje;
                 }
                 
             }
             
        }
    }
}
