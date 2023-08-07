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

        }

        // GET: CarroModeloController/Details/5
        public ActionResult Details(int CarroModeloId)
        {

            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(CarroModeloId);
            return View(carroModelo);
        }

        // GET: CarroModeloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarroModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarroModeloViewModel carroModelo)
        {
            try
            {
                carroModeloHelper = new CarroModeloHelper();
                carroModelo = carroModeloHelper.Add(carroModelo);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarroModeloController/Edit/5
        public ActionResult Edit(int CarroModeloId)
        {
            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(CarroModeloId);
            return View(carroModelo);
        }


        // POST: CarroModeloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarroModeloViewModel carroModelo)
        {
            try
            {
                carroModeloHelper = new CarroModeloHelper();
                carroModelo = carroModeloHelper.Edit(carroModelo);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarroModeloController/Delete/5
        public ActionResult Delete(int CarroModeloId)
        { 
            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(CarroModeloId);
            return View(carroModelo);
        }

        // POST: CarroModeloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarroModeloViewModel carroModelo)
        {
            try
            {
                carroModeloHelper = new CarroModeloHelper();
                carroModeloHelper.Delete(carroModelo.CarroModeloId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
