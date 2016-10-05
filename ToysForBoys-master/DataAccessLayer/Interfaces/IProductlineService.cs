using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IProductlineService
    {
        void Insert(Productline productline);
        void Delete(Productline productline);

        void Edit(Productline productline);

        IEnumerable<Productline> GetAll();
        IEnumerable<Productline> GetAll(string includes);
        IEnumerable<Productline> GetAll(Func<Productline, bool> predicate, string includes);

        Productline GetById(int productlineID);
        Productline GetById(int productlineID, string includes);
    }
}
