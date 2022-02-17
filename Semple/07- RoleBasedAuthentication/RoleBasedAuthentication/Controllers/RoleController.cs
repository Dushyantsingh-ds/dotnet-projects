using Microsoft.AspNet.Identity.EntityFramework;
using RoleBasedAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthentication.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _db =new ApplicationDbContext();
        // GET: Role
        public ActionResult RoleList()
        {
            var roleList = _db.Roles.ToList();
            return View(roleList);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult CreateRole(IdentityRole identity)
        {
            _db.Roles.Add(identity);
            _db.SaveChanges();
            return RedirectToAction("RoleList");
        }
        [HttpPost]
        public ActionResult DisableRole(IdentityRole identity)
        {
            var _dbs = _db.Roles.FirstOrDefault(e => e.Name == identity.Name);
            _dbs.Name = identity.Name = "Disable";
            _db.SaveChanges();
            return RedirectToAction("RoleList");
        }
        public ActionResult DeleteRole(IdentityRole identity)
        {
            var _dbs = _db.Roles.FirstOrDefault(e => e.Name == identity.Name);
            _db.Roles.Remove(_dbs);
            _db.SaveChanges();
            return RedirectToAction("RoleList");
        }
    }
}