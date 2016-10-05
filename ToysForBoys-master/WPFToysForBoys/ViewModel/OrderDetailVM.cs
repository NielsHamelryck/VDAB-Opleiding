using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using DataAccessLayer;

namespace WPFToysForBoys.ViewModel
{
    public class OrderDetailVM: ViewModelBase
    {
        private List<Orderdetail> orderdetailList;
        public List<Orderdetail> OrderdetailList
        {
            get { return orderdetailList; }
            set
            {
                orderdetailList = value;
                RaisePropertyChanged("OrderdetailList");
            }
        }

        public OrderDetailVM(List<Orderdetail> nOrderdetailList)
        {
            OrderdetailList = nOrderdetailList;
        }
    }
}
