using DataAccessLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFToysForBoys.ViewModel
{
    public partial class ManagementVM : ViewModelBase
    {
        private List<Productline> productlineList;
        public List<Productline> ProductlineList
        {
            get { return productlineList; }
            set
            {
                productlineList = value;
                RaisePropertyChanged("ProductlineList");
            }
        }

        private List<Productline> pProductlineList;
        public List<Productline> PProductlineList
        {
            get { return pProductlineList; }
            set
            {
                pProductlineList = value;
                RaisePropertyChanged("PProductlineList");
            }
        }

        private int selectedPProductlineI;
        public int SelectedPProductlineI
        {
            get { return selectedPProductlineI; }
            set
            {
                selectedPProductlineI = value;
                RaisePropertyChanged("SelectedPProductlineI");
            }
        }

        private int selectedProductlineI;
        public int SelectedProductlineI
        {
            get { return selectedProductlineI; }
            set
            {
                selectedProductlineI = value;

                if (value != -1)
                {
                    ProductList = plineService.GetById(value, "products").products.ToList();
                }
                else
                {
                    ProductList = pService.GetAll("productline").ToList();
                }
                cproductList = pService.GetAll("productline ").ToList();
                RaisePropertyChanged("SelectedProductlineI");
            }
        }



        //productline management:

        public RelayCommand NewProductlineCommand
        {
            get { return new RelayCommand(NewProductline); }
        }
        private void NewProductline()
        {
            SelectedProductline = null;
        }


        private Productline selectedProductline;
        public Productline SelectedProductline
        {
            get { return selectedProductline; }
            set
            {
                if (value == null)
                {
                    ShowProductline = new Productline() { id = -1 };
                }
                else
                {
                    selectedProductline = value;
                    ShowProductline = value;
                    RaisePropertyChanged("SelectedProductline");
                }

            }
        }

        private Productline showProductline;
        public Productline ShowProductline
        {
            get { return showProductline; }
            set
            {
                showProductline = value;
                RaisePropertyChanged("ShowProductline");
            }
        }


        public RelayCommand PLAddCommand
        {
            get { return new RelayCommand(PLAdd); }
        }
        private void PLAdd()
        {
            try
            {
                if (!IdChecker.IdCheck(cproductlineList, ShowProductline))
                {
                    if (!string.IsNullOrEmpty(ShowProductline.name) && !string.IsNullOrWhiteSpace(ShowProductline.name))
                        plineService.Insert(new Productline()
                        {
                            name = ShowProductline.name,
                            description = ShowProductline.description,
                        });
                    else
                        MessageBox.Show("Invalid productline name!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    plineService.Edit(new Productline()
                    {
                        id = ShowProductline.id,
                        name = ShowProductline.name,
                        description = ShowProductline.description,
                    });
                }
                cproductlineList = plineService.GetAll("products").ToList();
                PProductlineList = plineService.GetAll("products").ToList();
                RefreshTab();
                var ProductlineList = new List<Productline>() { new Productline() { id = -1, name = "All" } };
                ProductlineList.AddRange(cproductlineList);
                this.ProductlineList = ProductlineList;
                SelectedProductlineI = -1;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Identical object already exists in the database!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }




        public RelayCommand PLDeleteCommand
        {
            get { return new RelayCommand(PLDelete); }
        }
        private void PLDelete()
        {
            try
            {
                if (IdChecker.IdCheck(cproductlineList, ShowProductline))
                {
                    if (MessageBox.Show("You are about to delete a modified item. \nAre you sure you want to continue?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        plineService.Delete(plineService.GetById(ShowProductline.id));
                        PLNew();
                    }
                }
                else
                    PLNew();
            }
            catch (ArgumentException)
            {
                if (MessageBox.Show("You are about to delete a productline from the database. \nAre you sure you want to continue? \n(all existing products & orders belonging to this productline will be deleted)", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    plineService.Delete(plineService.GetById(ShowProductline.id));
                    PLNew();
                }
            }
            SelectedProductlineI = -1;
        }

        private void PLNew()
        {
            ProductlineList = new List<Productline>() { new Productline() { id = -1, name = "All" } };
            PProductlineList = plineService.GetAll("products").ToList();
            productlineList.AddRange(PProductlineList);
            cproductlineList = plineService.GetAll("products").ToList();
        }


        private void RefreshTab()
        {
            SelectedProductlineI = SelectedProductlineI;
        }

    }
}
