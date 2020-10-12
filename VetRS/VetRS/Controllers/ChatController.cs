using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VetRS.Data;
using VetRS.Models;

namespace VetRS.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext groupDb;
        public ChatController(
          UserManager<IdentityUser> userManager,
          ApplicationDbContext context
          )
        {
            _userManager = userManager;
            groupDb = context;
        }
        public IActionResult Index()
        {

            var groups = groupDb.UserGroup
                      .Where(gp => gp.UserName == _userManager.GetUserName(User))
                      .Join(groupDb.Group, ug => ug.GroupId, g => g.ID, (ug, g) =>
                              new UserGroupViewModel
                              {
                                  UserName = ug.UserName,
                                  GroupId = g.ID,
                                  GroupName = g.GroupName
                              })
                      .ToList();

            ViewData["UserGroups"] = groups;

            // get all users      
            ViewData["Users"] = _userManager.Users;
            return View();
        }
    }
}