using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_Security.Models;

namespace MVC_Security.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Userbeheer()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IDbSet<ApplicationUser> alleUsers = context.Users;
            return View(alleUsers);
        }

        public ActionResult Rolebeheer()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IDbSet<IdentityRole> alleRoles = context.Roles;
            return View(alleRoles);
        }

        public ActionResult VerwijderUser(string id)
        {
            ApplicationDbContext context= new ApplicationDbContext();
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult VerwijderUserDoorvoeren(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("UserBeheer");
        }

        public ActionResult UserDetail(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Find(id);
            if (user != null)
            {

                ViewBag.usernaam = user.UserName;
                var rolesVoorUser = user.Roles;
                return View(rolesVoorUser);
            }
            return RedirectToAction("Userbeheer");
        }

        public ActionResult VerwijderRoleForMember(string userid, string roleid)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault((u => u.Id == userid));
            var role = context.Roles.FirstOrDefault(r => r.Id == roleid);

            if (user != null && role != null)
            {
                IdentityUserRole userrole =
                    user.Roles.SingleOrDefault(ur => (ur.UserId == userid && ur.RoleId == roleid));
                user.Roles.Remove(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("UserDetail", "User", new {id = userid});
        }

        public ActionResult VerwijderRole(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var role = context.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult VerwijderRoleDoorvoeren(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var role = context.Roles.FirstOrDefault(u => u.Id == id);
            if (role != null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
            }
            return View("Rolebeheer");
        }

        public ActionResult RoleDetail(String id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var role = context.Roles.Find(id);

            RoleDetailViewModel vm = new RoleDetailViewModel();

            vm.RoleName = role.Name;
            vm.RoleId = role.Id;

            vm.UsersUitRole = (from usr in context.Users
                where usr.Roles.Any(r => r.RoleId == id)
                select usr).ToList();

            vm.SelectUser = new List<SelectListItem>();
            foreach (var user in context.Users)
            {
                vm.SelectUser.Add(new SelectListItem
                {
                    Text = user.UserName, Value =user.Id
                });
            }
            return View(vm);
        }

        
        [HttpPost]
        public ActionResult VerwijderMemberFromRole(string userid, string roleid)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.Id == userid);
            var role = context.Roles.FirstOrDefault(r => r.Id == roleid);

            if (user != null && role != null)
            {
                IdentityUserRole userrole = user.Roles.SingleOrDefault(
                    ur=> ur.UserId==userid && ur.RoleId == roleid);

                user.Roles.Remove(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("RoleDetail", "User", new {id = roleid});
        }


        [HttpPost]
        public ActionResult MemberToevoegen(string RoleId, string SelectUser)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var user = context.Users.FirstOrDefault(u => u.Id == SelectUser);
            var role = context.Roles.FirstOrDefault(r => r.Id == RoleId);

            if (user != null && role != null)
            {
                IdentityUserRole userrole = new IdentityUserRole();
                userrole.RoleId = RoleId;
                userrole.UserId = SelectUser;
                user.Roles.Add(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("RoleDetail", "user", new {id = RoleId});
        }
    }
}