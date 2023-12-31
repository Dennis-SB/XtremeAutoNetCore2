﻿using Front_End.Helpers;
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

        /*
        public ActionResult UploadImage(int id)
        {
            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(id);
            return View(carroModelo);
        }

        [HttpPost]
        public ActionResult UploadImage(CarroModeloViewModel carroModelo, List<IFormFile> files)
        {

            if (files.Count > 0)
            {
                IFormFile formFile = files[0];

                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    carroModelo.Imagen = ms.ToArray();
                }
            }


            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel cat = carroModeloHelper.GetByID(carroModelo.CarroModeloId);
            cat.Imagen = carroModelo.Imagen;

            carroModeloHelper.Edit(cat);


            return RedirectToAction("Details", new { id = cat.CarroModeloId });
        }*/

    }
}