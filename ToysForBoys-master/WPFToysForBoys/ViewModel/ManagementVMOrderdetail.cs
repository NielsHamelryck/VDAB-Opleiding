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

namespace WPFToysForBoys.ViewModel
{
    public partial class ManagementVM : ViewModelBase
    {
        


        private Orderdetail selectedOrderdetail;
        public Orderdetail SelectedOrderdetail
        {
            get { return selectedOrderdetail; }
            set
            {
                if (value == null)
                {
                    ShowOrderdetail = new Orderdetail() { productId= -1, orderId = -1 };
                }
                else
                {
                    selectedOrderdetail = value;
                    ShowOrderdetail = value;
                    RaisePropertyChanged("SelectedOrderdetail");
                }

            }
        }

        private Orderdetail showOrderdetail;
        public Orderdetail ShowOrderdetail
        {
            get { return showOrderdetail; }
            set
            {
                showOrderdetail = value;
                //if (value.country == null)
                //{
                //    SelectedCCountryI = -1;
                //}
                //else
                //{
                //    SelectedCCountryI = value.country.id;
                //}
                RaisePropertyChanged("ShowOrderdetail");
            }
        }



        public RelayCommand OdAddCommand
        {
            get { return new RelayCommand(OdAdd); }
        }
        private void OdAdd()
        {
            try
            {
                if (!IdChecker.IdCheck(oorderdetailList, ShowOrderdetail))
                {
                    oorderdetailService.Insert(new Orderdetail()
                    {
                        priceEach = ShowOrderdetail.priceEach,
                        productId = ShowOrderdetail.productId,
                        quantityOrdered = ShowOrderdetail.quantityOrdered
                    });                    
                }
                else
                {
                    oorderdetailService.Edit(new Orderdetail()
                    {
                        orderId = ShowOrderdetail.orderId,
                        priceEach = ShowOrderdetail.priceEach,
                        productId = ShowOrderdetail.productId,
                        quantityOrdered = ShowOrderdetail.quantityOrdered
                    });
                    
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Identical object already exists in the database!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public RelayCommand OdNewCommand
        {
            get { return new RelayCommand(OdNew); }
        }
        private void OdNew()
        {
            SelectedOrderdetail = null;
        }


        //Order details:
        public RelayCommand OrderDetailCommand
        {
            get { return new RelayCommand(OrderDetail); }
        }
        private void OrderDetail()
        {
            View.OrderdetailWindow orderview = new View.OrderdetailWindow();
            List<Orderdetail> od = oService.GetOrderDetails(ShowOrder).ToList();
            List<Product> pl = oService.GetProducts(ShowOrder).ToList();
            foreach (Orderdetail o in od)
                foreach (Product p in pl)
                {
                    if (o.productId == p.id)
                        o.product = p;
                }
            ViewModel.OrderDetailVM ovm = new OrderDetailVM(od);
            orderview.DataContext = ovm;
            orderview.Show();
        }

        public RelayCommand OrderDetailCommand2
        {
            get { return new RelayCommand(OrderDetail2); }
        }
        private void OrderDetail2()
        {
            View.OrderdetailupdateWindow orderview = new View.OrderdetailupdateWindow();
            List<Orderdetail> od = oService.GetOrderDetails(ShowOrder).ToList();
            List<Product> pl = oService.GetProducts(ShowOrder).ToList();
            foreach (Orderdetail o in od)
                foreach (Product p in pl)
                {
                    if (o.productId == p.id)
                        o.product = p;
                }
            ViewModel.OrderDetailUpdateVM ovm = new OrderDetailUpdateVM(od);
            orderview.DataContext = ovm;
            orderview.Show();
        }



    }
}
