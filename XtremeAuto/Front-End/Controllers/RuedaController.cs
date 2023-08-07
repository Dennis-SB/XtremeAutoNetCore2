using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class RuedaController : Controller
    {
       RuedaHelper ruedaHelper;

        // GET: RuedaController
        public ActionResult Index()
        {
            ruedaHelper = new RuedaHelper();

            List<RuedaViewModel> list = ruedaHelper.GetAll();

            return View(list);
        }

        // GET: RuedaController/Details/5
        public ActionResult Details(int RuedaId)
        {
            ruedaHelper = new RuedaHelper();
            RuedaViewModel rueda = ruedaHelper.GetByID(RuedaId);
            return View(rueda);
        }

        // GET: RuedaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RuedaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RuedaViewModel rueda)
        {
            try
            {
                ruedaHelper = new RuedaHelper();
                rueda = ruedaHelper.Add(rueda);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RuedaController/Edit/5
        public ActionResult Edit(int RuedaId)
        {
            ruedaHelper = new RuedaHelper();
            RuedaViewModel rueda = ruedaHelper.GetByID(RuedaId);
            return View(rueda);
        }

        // POST: RuedaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RuedaViewModel rueda)
        {
            try
            {
                ruedaHelper = new RuedaHelper();
                rueda = ruedaHelper.Edit(rueda);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RuedaController/Delete/5
        public ActionResult Delete(int RuedaId)
        {
            ruedaHelper = new RuedaHelper();
            RuedaViewModel seguro = ruedaHelper.GetByID(RuedaId);
            return View(seguro);
        }

        // POST: RuedaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RuedaViewModel rueda)
        {
            try
            {
                ruedaHelper = new RuedaHelper();
                ruedaHelper.Delete(rueda.RuedaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
