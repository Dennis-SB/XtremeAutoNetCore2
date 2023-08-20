using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RuedumController : Controller
    {
        RuedumHelper ruedumHelper;

        // GET: CategoryController
        public ActionResult Index()
        {
            ruedumHelper = new RuedumHelper();
            List<RuedumViewModel> list = ruedumHelper.GetAll();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            ruedumHelper = new RuedumHelper();
            RuedumViewModel ruedum = ruedumHelper.GetByID(id);
            return View(ruedum);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RuedumViewModel ruedum)
        {
            try
            {
                ruedumHelper = new RuedumHelper();
                ruedum = ruedumHelper.Add(ruedum);


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
            ruedumHelper = new RuedumHelper();
            RuedumViewModel ruedum = ruedumHelper.GetByID(id);
            return View(ruedum);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RuedumViewModel ruedum)
        {
            try
            {
                ruedumHelper = new RuedumHelper();
                ruedum = ruedumHelper.Edit(ruedum);


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

            ruedumHelper = new RuedumHelper();
            RuedumViewModel ruedum = ruedumHelper.GetByID(id);
            return View(ruedum);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RuedumViewModel ruedum)
        {
            try
            {

                ruedumHelper = new RuedumHelper();
                ruedumHelper.Delete(ruedum.RuedaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}