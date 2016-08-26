using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using AdoGemeenschappelijk;
using ComboboxAanpassen.Annotations;

namespace ComboboxAanpassen
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

        private void ComboBoxSoort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private int textValue;

        public int text
        {
            get { return textValue; }
            set
            {
                textValue = value;
                
            }
        }
        

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var manager = new TuincentrumManager();
            ListBoxLijst.ItemsSource = manager.GetPlanten();
            ListBoxLijst.DisplayMemberPath = "Naam";
            
            List<Soort> comboboxVullen = new List<Soort>();
            comboboxVullen= manager.GetSoorten();
            comboboxVullen.Insert(0,new Soort(0,""));
            ComboBoxSoort.ItemsSource = comboboxVullen;
            ComboBoxSoort.DisplayMemberPath = "Naam";


            



        }


        private void ListBoxLijst_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxSoortNr.DataContext = ComboBoxSoort.SelectedItem;
            TextBoxTest.DataContext = this;
            
        }

        private void ButtonShowObject_OnClick(object sender, RoutedEventArgs e)
        {
            Plant plant = (Plant) ListBoxLijst.SelectedItem;
            Soort soort = (Soort) ComboBoxSoort.SelectedItem;
            
            if (ListBoxLijst.SelectedItem != null)
            {
                StringBuilder info = new StringBuilder();
                info.Append(plant.Naam + "\n" + plant.SoortNr + "\n" + soort.Naam + "\n" + plant.Levnr + "\n" +
                            plant.Kleur +
                            "\n" + plant.VerkoopPrijs);
                
                MessageBox.Show(info.ToString(), "Gegevens", MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }

       
    }
}
