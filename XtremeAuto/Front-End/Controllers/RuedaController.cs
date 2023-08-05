using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class RuedaController : Controller
    {
        private RuedaHelper ruedaHelper;

        // GET: RuedaController
        public ActionResult Index()
        {
            ruedaHelper = new RuedaHelper();

            List<RuedaViewModel> list = ruedaHelper.GetAll();

            return View(list);
        }

        // GET: RuedaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RuedaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RuedaController/Create
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

        // GET: RuedaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RuedaController/Edit/5
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

        // GET: RuedaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RuedaController/Delete/5
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
