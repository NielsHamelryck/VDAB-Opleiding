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
        public bool edit;
        public MainWindow()
        {
            InitializeComponent();
        }

        private ObservableCollection<Plant> plantenOb = new ObservableCollection<Plant>();
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxKleur.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            var manager = new TuincentrumManager();
            ComboBoxSoort.ItemsSource = manager.GetSoorten();
            ComboBoxSoort.SelectedValuePath = "SoortNr";
            ComboBoxSoort.DisplayMemberPath = "Naam";
            edit = false;
           
            foreach (StackPanel stackpanel in StackPanelTextBoxen.Children)
            {
                foreach (Control c in stackpanel.Children )
                {
                    if (c is TextBox)
                    {
                        TextBox tb = c as TextBox;
                        tb.IsEnabled = false;
                    }
                }
            } ComboBoxSoort.IsEnabled = false;
        }

        private void ComboBoxSoort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var manager = new TuincentrumManager();
            plantenOb = manager.GetPlanten();// manager.GetPlanten(Convert.ToInt32(ComboBoxSoort.SelectedValue))
            ListBoxPlanten.ItemsSource = plantenOb;
            ListBoxPlanten.DisplayMemberPath = "Naam";
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            VergrendelenTextboxen();
        }

        private void ButtonNieuw_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxKleur.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (edit == false)
            {
                VergrendelenTextboxen();
            }
            plantenOb.Add(new Plant(0,"-",0,0,"-",0));
            ListBoxPlanten.ItemsSource = plantenOb;
            ListBoxPlanten.DisplayMemberPath = "Naam";
            ListBoxPlanten.SelectedItem = plantenOb.Last();

        }

        public void VergrendelenTextboxen()
        {
            if (!edit)
            {
                foreach (StackPanel stackpanel in StackPanelTextBoxen.Children)
                    foreach (Control c in stackpanel.Children)
                    {
                        if (c is TextBox)
                        {
                            TextBox tb = c as TextBox;
                            tb.IsEnabled = true;
                        }
                    }
                edit = true;
            }
            else if (edit)
            {
                foreach (StackPanel stackpanel in StackPanelTextBoxen.Children)
                    foreach (Control c in stackpanel.Children)
                    {
                        if (c is TextBox)
                        {
                            TextBox tb = c as TextBox;
                            tb.IsEnabled = false;
                        }
                    }
                edit = false;
            }
        }
    }
    }

