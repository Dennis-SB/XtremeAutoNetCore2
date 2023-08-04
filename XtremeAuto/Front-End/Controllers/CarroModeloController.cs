using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class CarroModeloController : Controller
    {
        CarroModeloHelper carroModeloHelper;



        // GET: CarroModeloController
        public ActionResult Index()
        {
            carroModeloHelper = new CarroModeloHelper();
           
            List<CarroModeloViewModel> list = carroModeloHelper.GetAll();

            return View(list);

            return View();
        }

        // GET: CarroModeloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarroModeloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarroModeloController/Create
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

        // GET: CarroModeloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarroModeloController/Edit/5
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

        // GET: CarroModeloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarroModeloController/Delete/5
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
