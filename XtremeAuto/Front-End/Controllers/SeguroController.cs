using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class SeguroController : Controller
    {
        SeguroHelper seguroHelper;

        // GET: SeguroController
        public ActionResult Index()
        {
            seguroHelper = new SeguroHelper();

            List<SeguroViewModel> list = seguroHelper.GetAll();

            return View(list);
        }

        // GET: SeguroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeguroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeguroController/Create
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

        // GET: SeguroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeguroController/Edit/5
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

        // GET: SeguroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeguroController/Delete/5
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
