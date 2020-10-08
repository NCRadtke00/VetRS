using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VetRS.Controllers
{
    public class MilitaryJobTranslatorController : Controller
    {
        // GET: MilitaryJobTranslatorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MilitaryJobTranslatorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MilitaryJobTranslatorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MilitaryJobTranslatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MilitaryJobTranslatorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MilitaryJobTranslatorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MilitaryJobTranslatorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MilitaryJobTranslatorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
