using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Services;
using DataAccessLayer;
using System.Collections.Generic;
using System.Text;

namespace DataLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CustomerGetAllTest()
        {
            var service = new CustomerService();
            foreach (var item in service.GetAll())
            {
                Console.WriteLine(item.name);
            }
        }

        [TestMethod]

        public void CustomerInsertIsLastIndexOfCustomers()
        {
            var customer = new Customer{name="name", streetAndNumber="street", city="city", state="state", postalCode="postal",countryId= 5};
            var service = new CustomerService();            
            
            service.Insert(customer);
            Assert.AreEqual(true, customer.id != 0);
            
        }

        [TestMethod]
        public void CustomerGetByID()
        {
           
            var service = new CustomerService();
            Customer testCustomer = service.GetById(2);

            Assert.AreEqual(2, testCustomer.id);
        }

        [TestMethod]
        public void DeleteCustomer()
        {
            var service = new CustomerService();
            var customer = service.GetById(12);
            service.Delete(12);
            List<Customer> all = (List<Customer>)service.GetAll();

            bool verwijderd;
            if (all.Contains(customer))
            {
                verwijderd = false;
            }
            else
            {
                verwijderd = true;
            }

            Assert.AreEqual(true, verwijderd);


            
         }

        [TestMethod]
        public void EditCustomer()
        {
            var customer = new Customer {id=2, name = "name", streetAndNumber = "strt", city = "city", state = "state", postalCode = "pst", countryId = 6 };
            var service = new CustomerService();
            service.Edit(customer);
            var editedCustomer = service.GetById(2);
            Assert.AreEqual(customer.name, editedCustomer.name);

        }

        [TestMethod]
        public void LoginVerificationSucces()
        {
            var service = new CustomerService();
            Customer customer = service.GetById(6);



            Assert.IsFalse(service.LoginVerification(customer.name, customer.postalCode) == null);
        }

        [TestMethod]

        public void LoginVerificationFail()
        {
            var service = new CustomerService();
            Customer customer = service.GetById(6);

            Assert.IsTrue(service.LoginVerification(customer.name, "T4000")==null);
        }
    }
}
