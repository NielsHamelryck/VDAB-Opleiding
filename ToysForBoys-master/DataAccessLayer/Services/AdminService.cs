using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Services
{
    public class AdminService : IAdminService
    {
        public void Insert(Admin admin)
        {
            using (var entities = new toysforboysEntities())
            {
                if (admin.username!=null && admin.password!=null)
                {
                    var query = from a in entities.admins
                                where a.username == admin.username
                                select a;

                    if (query.Count()==0)
                    {
                        entities.admins.Add(admin);
                        entities.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Username already in use");
                    }
                }
                else
                {
                    if(admin.username==null)
                        throw new Exception("No username given");

                    if (admin.password == null)
                        throw new Exception("No password given");
                }
                
                                  
            }
        }

        public void Delete(Admin admin)
        {
            using (var entities = new toysforboysEntities())
            {
                entities.admins.Remove(admin);
                entities.SaveChanges();
            }
        }

        public void Edit(Admin admin)
        {

            using (var entities = new toysforboysEntities())
            {
                var originalAdmin = entities.admins.Find(admin.id);

                if (admin.username != null)
                    originalAdmin.username = admin.username;

                if (admin.password != null)
                    originalAdmin.password = admin.password;

                entities.SaveChanges();
            }
        }

        public IEnumerable<Admin> GetAll()
        {
            List<Admin> AllAdmins = new List<Admin>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var admin in entities.admins)
                {
                    AllAdmins.Add(admin);
                }
            }

            return AllAdmins;
        }

        public IEnumerable<Admin> GetAll(string includes)
        {
            return GetAll(a => true, includes);
        }

        public IEnumerable<Admin> GetAll(Func<Admin, bool> predicate, string includes)
        {
            List<Admin> AllAdmins = new List<Admin>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var admin in (String.IsNullOrEmpty(includes) ? entities.admins : entities.admins.Include(includes)).Where(predicate))
                {
                    AllAdmins.Add((Admin)admin);
                }
            }

            return AllAdmins;
        }

        public Admin GetById(int adminId)
        {
            return GetById(adminId, string.Empty);
        }

        public Admin GetById(int adminId, string includes)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from admin in entities.admins
                             where admin.id == adminId
                             orderby admin.id
                             select admin).Include(includes).First();

                return query;
            }
        }

        public Admin LoginVerification(string username, string password)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from admin in entities.admins
                             where admin.username == username &&
                             admin.password == password
                             select admin).FirstOrDefault();
                return query;
            }
            



        }

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from admin in entities.admins
                             where admin.username == username
                             select admin).First();

                if (query != null && query.password == oldPassword)
                {
                    query.password = newPassword;
                    entities.SaveChanges();
                }
                else
                {
                    if (query.password!=oldPassword)
                    {
                        throw new Exception("Old password is wrong");
                    }
                }
            }
            
            
        }
    }
}
