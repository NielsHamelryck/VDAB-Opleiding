using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ParkingbonMVVMHerhaling.Model;
using ParkingbonMVVMHerhaling.ViewModel;
using ParkingBonMVVM.View;

namespace ParkingbonMVVMHerhaling
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ParkingBon bon = new ParkingBon();
            ParkingBonVM pbVM = new ParkingBonVM(bon);
            ParkingBonView bonView = new ParkingBonView();
            bonView.DataContext = pbVM;
            bonView.Show();
        }
    }
}
