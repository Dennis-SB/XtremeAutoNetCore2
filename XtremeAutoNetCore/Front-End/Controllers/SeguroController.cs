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
        public ActionResult Details(int SeguroId)
        {

            seguroHelper = new SeguroHelper();
            SeguroViewModel seguro = seguroHelper.GetByID(SeguroId);
            return View(seguro);
        }

        // GET: SeguroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeguroController/Create
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

        // GET: SeguroController/Edit/5
        public ActionResult Edit(int SeguroId)
        {
            seguroHelper = new SeguroHelper();
            SeguroViewModel seguro = seguroHelper.GetByID(SeguroId);
            return View(seguro);
        }

        // POST: SeguroController/Edit/5
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

        // GET: SeguroController/Delete/5
        public ActionResult Delete(int SeguroId)
        {
            seguroHelper = new SeguroHelper();
            SeguroViewModel seguro = seguroHelper.GetByID(SeguroId);
            return View(seguro);
        }

        // POST: SeguroController/Delete/5
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
