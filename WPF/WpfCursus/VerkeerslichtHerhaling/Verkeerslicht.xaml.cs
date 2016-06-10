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
using System.Windows.Shapes;

namespace VerkeerslichtHerhaling
{
    /// <summary>
    /// Interaction logic for Verkeerslicht.xaml
    /// </summary>
    public partial class Verkeerslicht : Window
    {
        private Boolean wasRood;
        public Verkeerslicht()
        {
            InitializeComponent();
            Roodlicht.Opacity = 1;
            OranjeLicht.Opacity = 0;
            GroenLicht.Opacity = 0;
            OpgeletButton.IsEnabled = true;
            GoButton.IsEnabled = false;
            StopButton.IsEnabled = false;
            wasRood = true;
        }

        
        private void VeranderKleur_OnClick(object sender, RoutedEventArgs e)
        {
            if (Roodlicht.Opacity != 0 && wasRood)
            {
                Roodlicht.Opacity = 0;
                OranjeLicht.Opacity = 1;
                wasRood = true;
                OpgeletButton.IsEnabled = false;
                GoButton.IsEnabled = true;
            }
            else if (OranjeLicht.Opacity != 0 && wasRood)
            {
                OranjeLicht.Opacity = 0;
                GroenLicht.Opacity = 1;
                wasRood = false;
                OpgeletButton.IsEnabled = true;
                GoButton.IsEnabled = false;
            }
            else if (OranjeLicht.Opacity !=0 && !wasRood)
            {
                OranjeLicht.Opacity = 0;
                Roodlicht.Opacity = 1;
                wasRood = true;
                OpgeletButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            } else if (GroenLicht.Opacity != 0 && !wasRood)
            {
                GroenLicht.Opacity = 0;
                OranjeLicht.Opacity = 1;
                wasRood = false;
                OpgeletButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
        }
    }
}
