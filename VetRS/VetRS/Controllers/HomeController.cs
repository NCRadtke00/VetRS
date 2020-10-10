using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VetRS.Data;
using VetRS.Models;

namespace VetRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        //private readonly ApplicationDbContext _context;

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            //EduVSOViewModel eduVSOViewModel = new EduVSOViewModel();
            //List<Education> edu = new List<Education>();
            //foreach(Education person in _context.Education)
            //{
            //    edu.Add(person);
            //}
            //List<VSO> vso = new List<VSO>();
            //foreach(VSO person in _context.VSO)
            //{
            //    vso.Add(person);
            //}
            //eduVSOViewModel.educations = edu;
            //eduVSOViewModel.vSOs = vso;
            return View(db.Users.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
