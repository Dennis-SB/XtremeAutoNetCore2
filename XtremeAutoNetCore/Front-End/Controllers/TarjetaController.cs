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
        public ActionResult Details(int TarjetaId)
        {

            tarjetaHelper = new TarjetaHelper();
            TarjetaViewModel tarjeta = tarjetaHelper.GetByID(TarjetaId);
            return View(tarjeta);
        }

        // GET: TarjetaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarjetaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarjetaViewModel tarjeta)
        {
            try
            {
                tarjetaHelper = new TarjetaHelper();
                tarjeta = tarjetaHelper.Add(tarjeta);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarjetaController/Edit/5
        public ActionResult Edit(int TarjetaId)
        {
            tarjetaHelper = new TarjetaHelper();
            TarjetaViewModel tarjeta = tarjetaHelper.GetByID(TarjetaId);
            return View(tarjeta);
        }

        // POST: TarjetaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarjetaViewModel tarjeta)
        {
            try
            {
                tarjetaHelper = new TarjetaHelper();
                tarjeta = tarjetaHelper.Edit(tarjeta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TarjetaController/Delete/5
        public ActionResult Delete(int TarjetaId)
        {
            tarjetaHelper = new TarjetaHelper();
            TarjetaViewModel seguro = tarjetaHelper.GetByID(TarjetaId);
            return View(seguro);
        }

        // POST: TarjetaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TarjetaViewModel tarjeta)
        {
            try
            {
                tarjetaHelper = new TarjetaHelper();
                tarjetaHelper.Delete(tarjeta.TarjetaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
