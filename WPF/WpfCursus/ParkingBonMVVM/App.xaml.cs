using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ParkingBonMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Model.ParkeerBon parkeerBon = new Model.ParkeerBon();
            ViewModel.ParkingBonVM PB  = new ViewModel.ParkingBonVM(parkeerBon);
            View.ParkingBonView parkingBonView = new View.ParkingBonView();
            parkingBonView.DataContext = PB;
            parkingBonView.Show();
        }
    }
}
