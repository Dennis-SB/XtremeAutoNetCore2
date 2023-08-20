﻿using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CarroModeloController : Controller
    {
        CarroModeloHelper carroModeloHelper;

        // GET: CategoryController
        public ActionResult Index()
        {
            carroModeloHelper = new CarroModeloHelper();
            List<CarroModeloViewModel> list = carroModeloHelper.GetAll();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(id);
            return View(carroModelo);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(id);
            return View(carroModelo);
        }

        // POST: CategoryController/Edit/5
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {

            carroModeloHelper = new CarroModeloHelper();
            CarroModeloViewModel carroModelo = carroModeloHelper.GetByID(id);
            return View(carroModelo);
        }

        // POST: CategoryController/Delete/5
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