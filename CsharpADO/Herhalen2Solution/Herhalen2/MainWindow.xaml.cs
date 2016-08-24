using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AdoGemeenschappelijk;

namespace Herhalen2
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

        private ObservableCollection<Plant> plantenOb = new ObservableCollection<Plant>();
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var manager = new TuincentrumManager();
            ComboBoxSoort.ItemsSource = manager.GetSoorten();
            ComboBoxSoort.SelectedValuePath = "SoortNr";
            ComboBoxSoort.DisplayMemberPath = "Naam";
        }

        private void ComboBoxSoort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var manager = new TuincentrumManager();
            plantenOb = manager.GetPlanten(Convert.ToInt32(ComboBoxSoort.SelectedValue));
            ListBoxPlanten.ItemsSource = plantenOb;
            ListBoxPlanten.DisplayMemberPath = "Naam";
        }
    }
    }

