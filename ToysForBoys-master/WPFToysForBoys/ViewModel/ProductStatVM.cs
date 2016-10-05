using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFToysForBoys.Model;

namespace WPFToysForBoys.ViewModel
{
    public class ProductStatVM : ViewModelBase
    {
        public IProductlineService plService;
        public IProductService pService;
        public IOrderdetailsService odService;
        public IOrderStatisticService oService;

        public ProductStatVM()
        {
            plService = new ProductlineService();
            pService = new ProductService();
            odService = new OrderdetailService();
            oService = new OrderStatisticService();

            {
                List<YearStruct> yl = new List<YearStruct>() { new YearStruct() { year = -1, display = "---All---" } };

                List<int> year = oService.GetDistinctYear(SortDateEnum.orderDate).ToList();
                year.Sort();
                foreach (int y in year)
                    yl.Add(new YearStruct() { year = y, display = "--" + y.ToString() + "--" });

                YearList = yl;
            }

            MonthList = new List<MonthStruct>() { new MonthStruct() { month = -1, display = "All" }, new MonthStruct() { month = 1, display = "January" }, new MonthStruct() { month = 2, display = "February" }, new MonthStruct() { month = 3, display = "March" }, new MonthStruct() { month = 4, display = "April" }, new MonthStruct() { month = 5, display = "May" }, new MonthStruct() { month = 6, display = "June" }, new MonthStruct() { month = 7, display = "July" }, new MonthStruct() { month = 8, display = "August" }, new MonthStruct() { month = 9, display = "September" }, new MonthStruct() { month = 10, display = "October" }, new MonthStruct() { month = 11, display = "November" }, new MonthStruct() { month = 12, display = "December" } };

            SelectedMonth = -1;
            SelectedYear = -1;
        }

        private void ProductlineListRefresh()
        {
            List<ProductStatStruct> prod = ProductlineList;

            //foreach (ProductStatStruct p in prod)
            //    p.countProductsSold = plService.GetCountSold(p.id);

            ProductlineList = prod;
        }

        private int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                ProductlineListRefresh();
                RaisePropertyChanged("SelectedYear");
            }
        }

        private int selectedMonth;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                selectedMonth = value;
                ProductlineListRefresh();
                RaisePropertyChanged("SelectedMonth");
            }
        }

        private List<YearStruct> yearList;
        public List<YearStruct> YearList
        {
            get { return yearList; }
            set
            {
                yearList = value;
                RaisePropertyChanged("YearList");
            }
        }

        private List<MonthStruct> monthList;
        public List<MonthStruct> MonthList
        {
            get { return monthList; }
            set
            {
                monthList = value;
                RaisePropertyChanged("MonthList");
            }
        }

        private List<ProductStatStruct> productlineList;
        public List<ProductStatStruct> ProductlineList
        {
            get { return productlineList; }
            set
            {
                productlineList = value;
                RaisePropertyChanged("ProductlineList");
            }
        }

        private ProductStatStruct selectedProductline;
        public ProductStatStruct SelectedProductline
        {
            get { return selectedProductline; }
            set
            {
                selectedProductline = value;
                RaisePropertyChanged("SelectedProductline");
            }
        }
    }
}
