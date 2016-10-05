using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAdminService
    {
        void Insert(Admin admin);
        //throws exception if username is already in use

        void Delete(Admin admin);

        void Edit(Admin admin);

        IEnumerable<Admin> GetAll();
        IEnumerable<Admin> GetAll(string includes);
        IEnumerable<Admin> GetAll(Func<Admin, bool> predicate, string includes);

        Admin GetById(int AdminId);
        Admin GetById(int AdminId, string includes);

        Admin LoginVerification(string username, string password);
        //returns null if verification fails

        void ChangePassword(string username, string oldPassword, string newPassword);
        //throws exception if old password is wrong

    }
}
