using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VetRS.ActionFilter
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("VSO"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "VSOes", null);
                }
                else if (_claimsPrincipal.IsInRole("Veteran"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Veteran", null);
                }
                else if (_claimsPrincipal.IsInRole("Education Rep."))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Educations", null);
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
