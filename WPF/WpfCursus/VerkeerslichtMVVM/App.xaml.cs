using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VerkeerslichtMVVM.ViewModel;
using VerkeerslichtMVVM.View;
using VerkeerslichtMVVM.Model;
using VerkeersLicht = VerkeerslichtMVVM.Model.VerkeersLicht;

namespace VerkeerslichtMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            VerkeersLicht licht = new VerkeersLicht();
            VerkeerslichtMV VLMV = new VerkeerslichtMV(licht);
            VerkeersLichtView VL = new VerkeersLichtView();
            VL.DataContext = VLMV;
            VL.Show();

        }
    }
}
