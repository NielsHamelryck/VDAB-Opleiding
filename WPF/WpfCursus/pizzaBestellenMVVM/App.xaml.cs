using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using pizzaBestellenMVVM.Model;
using pizzaBestellenMVVM.View;
using pizzaBestellenMVVM.ViewModel;

namespace pizzaBestellenMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            PizzaBestelling bestelling = new PizzaBestelling();
            PizzaBestellenViewModel bestellenViewModel = new PizzaBestellenViewModel(bestelling);
            PizzaBestellenWindowView pizzaView = new PizzaBestellenWindowView();
            
            
            pizzaView.DataContext = bestellenViewModel;
            
            pizzaView.Show();
        }
    }
}
