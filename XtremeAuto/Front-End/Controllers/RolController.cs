using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class RolController : Controller
    {
        private RolHelper rolHelper;

        // GET: RolController
        public ActionResult Index()
        {
            rolHelper = new RolHelper();

            List<RolViewModel> list = rolHelper.GetAll();

            return View(list);
        }
        // GET: RolController/Details/5
        public ActionResult Details(int RolId)
        {
            rolHelper = new RolHelper();
            RolViewModel rol = rolHelper.GetByID(RolId);
            return View(rol);
        }

        // GET: RolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolViewModel rol)
        {
            try
            {
                rolHelper = new RolHelper();
                rol = rolHelper.Add(rol);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Edit/5
        public ActionResult Edit(int RolId)
        {
            rolHelper = new RolHelper();
            RolViewModel rol = rolHelper.GetByID(RolId);
            return View(rol);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolViewModel rol)
        {
            try
            {
                rolHelper = new RolHelper();
                rol = rolHelper.Edit(rol);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Delete/5
        public ActionResult Delete(int RolId)
        {
            rolHelper = new RolHelper();
            RolViewModel seguro = rolHelper.GetByID(RolId);
            return View(seguro);
        }


        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RolViewModel rol)
        {
            try
            {
                rolHelper = new RolHelper();
                rolHelper.Delete(rol.RolId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
