using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class TarjetaController : Controller
    {
        TarjetaHelper tarjetaHelper;

        // GET: TarjetaController
        public ActionResult Index()
        {
            tarjetaHelper = new TarjetaHelper();

            List<TarjetaViewModel> list = tarjetaHelper.GetAll();

            return View(list);
        }

        // GET: TarjetaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TarjetaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarjetaController/Create
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

        // GET: TarjetaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TarjetaController/Edit/5
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

        // GET: TarjetaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TarjetaController/Delete/5
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
