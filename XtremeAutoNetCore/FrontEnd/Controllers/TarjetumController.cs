using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TarjetumController : Controller
    {
        TarjetumHelper tarjetumHelper;

        // GET: CategoryController
        public ActionResult Index()
        {
            tarjetumHelper = new TarjetumHelper();
            List<TarjetumViewModel> list = tarjetumHelper.GetAll();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            tarjetumHelper = new TarjetumHelper();
            TarjetumViewModel tarjetum = tarjetumHelper.GetByID(id);
            return View(tarjetum);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarjetumViewModel tarjetum)
        {
            try
            {
                tarjetumHelper = new TarjetumHelper();
                tarjetum = tarjetumHelper.Add(tarjetum);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            tarjetumHelper = new TarjetumHelper();
            TarjetumViewModel tarjetum = tarjetumHelper.GetByID(id);
            return View(tarjetum);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarjetumViewModel tarjetum)
        {
            try
            {
                tarjetumHelper = new TarjetumHelper();
                tarjetum = tarjetumHelper.Edit(tarjetum);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {

            tarjetumHelper = new TarjetumHelper();
            TarjetumViewModel tarjetum = tarjetumHelper.GetByID(id);
            return View(tarjetum);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TarjetumViewModel tarjetum)
        {
            try
            {

                tarjetumHelper = new TarjetumHelper();
                tarjetumHelper.Delete(tarjetum.TarjetaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}