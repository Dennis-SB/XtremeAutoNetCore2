using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class SeguroController : Controller
    {
        SeguroHelper seguroHelper;

        // GET: CategoryController
        public ActionResult Index()
        {
            seguroHelper = new SeguroHelper();
            List<SeguroViewModel> list = seguroHelper.GetAll();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            seguroHelper = new SeguroHelper();
            SeguroViewModel ruedum = seguroHelper.GetByID(id);
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
        public ActionResult Create(SeguroViewModel seguro)
        {
            try
            {
                seguroHelper = new SeguroHelper();
                seguro = seguroHelper.Add(seguro);


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
            seguroHelper = new SeguroHelper();
            SeguroViewModel seguro = seguroHelper.GetByID(id);
            return View(seguro);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeguroViewModel seguro)
        {
            try
            {
                seguroHelper = new SeguroHelper();
                seguro = seguroHelper.Edit(seguro);


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

            seguroHelper = new SeguroHelper();
            SeguroViewModel seguro = seguroHelper.GetByID(id);
            return View(seguro);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SeguroViewModel seguro)
        {
            try
            {

                seguroHelper = new SeguroHelper();
                seguroHelper.Delete(seguro.SeguroId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}