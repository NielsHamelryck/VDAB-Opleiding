using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICustomerService
    {
        void Insert(Customer customer);
        //throws exception if email is already in use

        void Delete(Customer customer);

        void Edit(Customer customer);

        IEnumerable<Customer> GetAll();

        IEnumerable<Customer> GetAll(string includes);
        IEnumerable<Customer> GetAll(Func<Customer, bool> predicate, string includes);

        Customer GetById(int customerID);

        Customer GetById(int customerID, string  includes);

        Customer LoginVerification(string email, string password);
        //returns null if login fails

        void AddEmailAndPassword(string name, string email, string password);

        void ChangePassword(string email, string oldPassword, string newPassword);
        //throws exception if email is already in use
    }
}
