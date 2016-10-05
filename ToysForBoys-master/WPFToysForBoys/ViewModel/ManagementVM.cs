using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using DataAccessLayer.Services;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WPFToysForBoys.ViewModel
{
    public partial class ManagementVM : ViewModelBase
    {

        private List<Productline> cproductlineList;
        private List<Product> cproductList;
        private List<Customer> ccustomerList;
        private List<Country> ccountryList;
        private List<Order> oorderList;
        private List<Orderdetail> oorderdetailList;
        private IProductService pService;
        private IProductlineService plineService;
        private ICustomerService cService;
        private ICountryService ccountryService;
        private IOrderService oService;
        private IOrderdetailsService oorderdetailService;
        public ManagementVM(bool adminMaster, View.ManagementWindow mw)
        {
            MW = mw;
            pService = new ProductService();
            plineService = new ProductlineService();
            cService = new CustomerService();
            ccountryService = new CountryService();
            oService = new OrderService();
            oorderdetailService = new OrderdetailService();


            ProductlineList = new List<Productline>() { new Productline() { id = -1, name = "All" } };
            PProductlineList = plineService.GetAll("products").ToList();
            productlineList.AddRange(PProductlineList);
            cproductlineList = plineService.GetAll("products").ToList();
            //SelectedProduct = ProductList.First();
            SelectedProductlineI = -1;
            SelectedProductline = null;
            SelectedCountryI = -1;
            FCountryList = new List<Country>() { new Country() { id = -1, name = "All" } };
            ccountryList = ccountryService.GetAll("customers").ToList();
            fcountryList.AddRange(ccountryList);
            CountryList = ccountryService.GetAll("customers").ToList();
            if (adminMaster)
                AdminMaster = "Visible";
            else
                AdminMaster = "Hidden";
            cproductList = pService.GetAll("productline").ToList();
            ccustomerList = cService.GetAll("country").ToList();
            oorderList = oService.GetAll("customer").ToList();
            OrderList = oService.GetAll("customer").ToList();
            oorderdetailList = oorderdetailService.GetAll().ToList();
            OStatusList = new List<string>() { "WAITING", "CANCELLED", "RESOLVED", "SHIPPED", "DISPUTED", "PROCESSING" };
            FOStatusList = new List<string>() { "ALL", "WAITING", "CANCELLED", "RESOLVED", "SHIPPED", "DISPUTED", "PROCESSING" };
            SelectedStatusI = "ALL";
            PNew();
            CNew();
            ONew();
        }

        public RelayCommand ProductStatistics
        {
            get { return new RelayCommand(ProductS); }
        }

        private void ProductS()
        {
            View.ProductStatWindow productview = new View.ProductStatWindow();
            ViewModel.ProductStatVM pvm = new ProductStatVM();
            productview.DataContext = pvm;
            productview.Show();
        }

        public RelayCommand CountryCustomer
        {
            get { return new RelayCommand(CountryC); }
        }

        private void CountryC()
        {
            View.CustomerCountryStatWindow countryview = new View.CustomerCountryStatWindow();
            ViewModel.CountryCustomerVM cvm = new CountryCustomerVM();
            countryview.DataContext = cvm;
            countryview.Show();
        }

        public RelayCommand NotImplementedCommand
        {
            get { return new RelayCommand(NotImplementedC); }
        }

        private void NotImplementedC()
        {
            MessageBox.Show("Functionality is not yet implemented!", "Function to come soon", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public View.ManagementWindow MW;

        private string adminMaster;
        public string AdminMaster
        {
            get { return adminMaster; }
            set
            {
                adminMaster = value;
                RaisePropertyChanged("AdminMaster");
            }
        }

        private List<Product> productList;
        public List<Product> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
                RaisePropertyChanged("ProductList");
            }
        }

        //public RelayCommand<CancelEventArgs> ClosingCommand
        //{
        //    get { return new RelayCommand<CancelEventArgs>(Closing); }
        //}
        //private void Closing(CancelEventArgs e)
        //{ 
        //        if (MessageBox.Show("Do you want to close the application?", "Closing", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
        //            e.Cancel = true;          
        //}

        public RelayCommand CloseCommand
        {
            get { return new RelayCommand(CloseWindow); }
        }
        private void CloseWindow()
        {
            if (MessageBox.Show("Do you want to close the application?", "Closing", MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                MW.Close();
        }

        public RelayCommand SwitchUserCommand
        {
            get { return new RelayCommand(SwitchUser); }
        }
        private void SwitchUser()
        {
            if (MessageBox.Show("Do you want to change user?", "Log out", MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                View.LoginWindow view = new View.LoginWindow();
                MW.Close();
                view.Show();

            }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value == null)
                {
                    ShowProduct = new Product() { id = -1 };
                }
                else
                {
                    selectedProduct = value;
                    ShowProduct = value;
                    RaisePropertyChanged("SelectedProduct");
                }

            }
        }


        private Product showProduct;
        public Product ShowProduct
        {
            get { return showProduct; }
            set
            {
                showProduct = value;
                if (value.productline == null)
                {
                    SelectedPProductlineI = -1;
                }
                else
                {
                    SelectedPProductlineI = value.productline.id;
                }
                RaisePropertyChanged("ShowProduct");
            }
        }



        public RelayCommand PAddCommand
        {
            get { return new RelayCommand(PAdd); }
        }
        private void PAdd()
        {
            //bool b = false;
            //foreach (Product product in ProductList)
            //{
            //    if (ShowProduct.id == product.id)
            //    {
            //        MessageBox.Show("Product ID already exists in database!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        b = true;
            //        break;
            //    }
            //}
            try
            {
                ShowProduct.productlineId = SelectedPProductlineI;
                Regex reg = new Regex("^1:[0-9]+(?:[.]{1}[0-9]+)?$");
                if (SelectedPProductlineI >= 1)
                    if ((ShowProduct.buyPrice == null || ShowProduct.buyPrice > 0) && (ShowProduct.quantityInOrder == null || ShowProduct.quantityInOrder >= 0) && (ShowProduct.quantityInStock == null || ShowProduct.quantityInStock >= 0))
                        if (ShowProduct.name != null)
                        {
                            var m = reg.Match(ShowProduct.scale);
                            if (ShowProduct.scale != null && m.Success)
                            {
                                if (!IdChecker.IdCheck(cproductList, ShowProduct))
                                {
                                    pService.Insert(new Product()
                                    {
                                        name = ShowProduct.name,
                                        description = ShowProduct.description,
                                        productlineId = ShowProduct.productlineId,
                                        scale = ShowProduct.scale,
                                        quantityInStock = ShowProduct.quantityInStock,
                                        quantityInOrder = ShowProduct.quantityInOrder,
                                        buyPrice = ShowProduct.buyPrice
                                    });
                                }
                                else
                                {
                                    pService.Edit(new Product()
                                    {
                                        id = ShowProduct.id,
                                        name = ShowProduct.name,
                                        description = ShowProduct.description,
                                        productlineId = SelectedPProductlineI,
                                        scale = ShowProduct.scale,
                                        quantityInStock = ShowProduct.quantityInStock,
                                        quantityInOrder = ShowProduct.quantityInOrder,
                                        buyPrice = ShowProduct.buyPrice
                                    });
                                }
                                SelectedProductlineI = SelectedProductlineI;
                            }
                            else
                                MessageBox.Show("Invalid scale!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                            MessageBox.Show("Invalid product name!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    else
                        MessageBox.Show("Invalid Quantities/price!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                    MessageBox.Show("No productline selected for your product!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Identical object already exists in the database!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public RelayCommand PDeleteCommand
        {
            get { return new RelayCommand(PDelete); }
        }
        private void PDelete()
        {
            try
            {
                if (IdChecker.IdCheck(cproductList, ShowProduct))
                {
                    if (MessageBox.Show("You are about to delete a modified item. \nAre you sure you want to continue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        pService.Delete(pService.GetById(ShowProduct.id));
                        PNew();
                        RefreshTab();
                    }
                }
                else
                {
                    PNew();
                    RefreshTab();
                }                      
            }
            catch (ArgumentException)
            {
                if (MessageBox.Show("You are about to delete a product from the database. \nAre you sure you want to continue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    pService.Delete(pService.GetById(ShowProduct.id));
                    PNew();
                    RefreshTab();
                }                    
            }
            //SelectedProductlineI = SelectedProductlineI;
        }

        public RelayCommand PNewCommand
        {
            get { return new RelayCommand(PNew); }
        }
        private void PNew()
        {
            SelectedProduct = null;
        }
    }
}
