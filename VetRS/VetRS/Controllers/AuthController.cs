using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetRS.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using VetRS.Models;
namespace VetRS.Controllers
{
    public class AuthController : Controller
    {
        private ApplicationDbContext db;
        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (user != null)
            {

                HttpContext.Session.SetString("UserName", model.UserName);
                return View();
            }

            return View();
        }
    }
}
