using System;
using System.Collections.Generic;
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

namespace WpfOpdrachten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _wasRood;
        private bool _wasGroen;
        public MainWindow()
        {
            InitializeComponent();
            RoodLicht.Opacity = 1;
            OranjeLicht.Opacity = 0;
            GroenLicht.Opacity = 0;
            OpgeletButton.IsEnabled = true;
            GoButton.IsEnabled = false;
            StopButton.IsEnabled = false;
            _wasRood = true;

        }


        private void ButtonKleur_OnClick(object sender, RoutedEventArgs e)
        {
            Button knop = (Button) sender;
            
            VeranderKleur(knop);

        }

        private void VeranderKleur(Button knop)
        {
            
            
            if (_wasRood==true && OpgeletButton.IsEnabled)
            {
                _wasRood = false;
                RoodLicht.Opacity = 0;
                OranjeLicht.Opacity = 1;
                OpgeletButton.IsEnabled = false;
                GoButton.IsEnabled = true;



            }
            else if (_wasGroen == true && OpgeletButton.IsEnabled)
            {
                _wasGroen = false;
                GroenLicht.Opacity = 0;
                OranjeLicht.Opacity = 1;
                OpgeletButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }

            else if (GoButton.IsEnabled)
            {
                OranjeLicht.Opacity = 0;
                GroenLicht.Opacity = 1;
                _wasGroen = true;
                OpgeletButton.IsEnabled = true;
                GoButton.IsEnabled = false;

            }
             else if (StopButton.IsEnabled)
             {
                 OranjeLicht.Opacity = 0;
                 RoodLicht.Opacity = 1;
                 _wasRood = true;
                 OpgeletButton.IsEnabled = true;
                 StopButton.IsEnabled = false;
             }
            
        }
    }
}
