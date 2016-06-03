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
using System.ComponentModel;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        public Persoon persoon = new Persoon("Joeri",3500m,new DateTime(2011,2,13));
        public DataBindingWindow()
        {
            InitializeComponent();
            
            SortDescription sd = new SortDescription("Source", ListSortDirection.Ascending);
            lettertypeComboBox.Items.SortDescriptions.Add(sd);
            lettertypeComboBox.SelectedItem = new FontFamily("Arial");
            VeranderPanel.DataContext = persoon;

        }

        private void ToonNaamButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deze persoon heet: " + persoon.Naam, "Naam", MessageBoxButton.OK);
        }

        private void VeranderButton_OnClick(object sender, RoutedEventArgs e)
        {
           persoon.Naam="Ben";
            persoon.Wedde = 4125.52m;
            persoon.InDienst= new DateTime(2010,12,21);
        }
    }
}
