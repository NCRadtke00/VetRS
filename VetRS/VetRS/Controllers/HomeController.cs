using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using VetRS.Hubs;
using VetRS.Data;

namespace VetRS.Controllers
{
    //[Authorize(Roles = "VSO")]
    //[Authorize(Roles = "Veteran")]
    //[Authorize(Roles = "Education Rep.")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Name { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (ChatHub.Users.Contains(Input.Name))
            {
                ModelState.AddModelError("Name", "Username already in use");
            }

            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Input.Name),
                    new Claim(ClaimTypes.Role, "Chatter"),
                    new Claim(ClaimTypes.NameIdentifier, Input.Name),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = false,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                _logger.LogInformation("User {Name} logged in at {Time}.",
                    Input.Name, DateTime.UtcNow);

                if (!Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect(Url.Page("/Index"));
                }

                return LocalRedirect(returnUrl);
            }

            // Something failed. Redisplay the form.
            return View();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using VetRS.Data;
//using VetRS.Models;

//namespace VetRS.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }
//        //private readonly ApplicationDbContext _context;

//        //public HomeController(ApplicationDbContext context)
//        //{
//        //    _context = context;
//        //}
//        public IActionResult Index()
//        {
//            //EduVSOViewModel eduVSOViewModel = new EduVSOViewModel();
//            //List<Education> edu = new List<Education>();
//            //foreach(Education person in _context.Education)
//            //{
//            //    edu.Add(person);
//            //}
//            //List<VSO> vso = new List<VSO>();
//            //foreach(VSO person in _context.VSO)
//            //{
//            //    vso.Add(person);
//            //}
//            //eduVSOViewModel.educations = edu;
//            //eduVSOViewModel.vSOs = vso;
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
