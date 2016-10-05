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
        private List<Order> orderList;
        public List<Order> OrderList
        {
            get { return orderList; }
            set
            {
                orderList = value;
                RaisePropertyChanged("OrderList");
            }
        }


        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (value == null)
                {
                    ShowOrder = new Order() { id = -1 };
                }
                else
                {
                    selectedOrder = value;
                    ShowOrder = value;
                    RaisePropertyChanged("SelectedOrder");
                }

            }
        }

        private Order showOrder;
        public Order ShowOrder
        {
            get { return showOrder; }
            set
            {
                showOrder = value;
                if (value.customer == null)
                {
                    SelectedCCustomerI = -1;
                    SelectedOStatus = null;
                }
                else
                {
                    SelectedCCustomerI = value.customer.id;
                    SelectedOStatus = value.status.Trim();
                }
                RaisePropertyChanged("ShowOrder");
            }
        }



        public RelayCommand OAddCommand
        {
            get { return new RelayCommand(OAdd); }
        }
        private void OAdd()
        {
            try
            {
                //if (ShowOrder.shippedDate != null)
                //{
                    if (SelectedOStatus != null)
                    {
                        ShowOrder.status = SelectedOStatus;
                        if (IdChecker.IdCheck(oorderList, ShowOrder))
                        {
                            oService.Edit(new Order()
                            {
                                id = ShowOrder.id,
                                customerId = SelectedCCustomerI, //ShowOrder.customerId,
                                orderDate = ShowOrder.orderDate,
                                requiredDate = ShowOrder.requiredDate,
                                shippedDate = ShowOrder.shippedDate,
                                status = ShowOrder.status,
                                comments = ShowOrder.comments
                            });
                            OrderList = oService.GetAll("customer").ToList();
                            oorderList = oService.GetAll("customer").ToList();
                        }
                    }
                    else
                        MessageBox.Show("Invalid Status!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               // }
                //else
                  //  MessageBox.Show("Invalid Shipdate!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Identical object already exists in the database!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public RelayCommand ONewCommand
        {
            get { return new RelayCommand(ONew); }
        }
        private void ONew()
        {
            SelectedOrder = null;
        }

        private string selectedOStatus;

        public string SelectedOStatus
        {
            get { return selectedOStatus; }
            set
            {
                selectedOStatus = value;
                RaisePropertyChanged("SelectedOStatus");
            }
        }

        private List<string> oStatusList;

        public List<string> OStatusList
        {
            get { return oStatusList; }
            set
            {
                oStatusList = value;
                RaisePropertyChanged("OStatusList");
            }
        }

        private List<string> foStatusList;

        public List<string> FOStatusList
        {
            get { return foStatusList; }
            set
            {
                foStatusList = value;
                RaisePropertyChanged("FOStatusList");
            }
        }

        private string selectedStatusI;
        public string SelectedStatusI
        {
            get { return selectedStatusI; }
            set
            {
                selectedStatusI = value;

                if (value != "ALL")
                {
                    OrderList = oService.GetAll("customer").ToList().FindAll(user => user.status.Equals(value));
                }
                else
                {
                    OrderList = oService.GetAll("customer").ToList();
                }

                RaisePropertyChanged("SelectedStatusI");
            }
        }





    }
}
