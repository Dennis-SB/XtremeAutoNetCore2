using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ColorController : Controller
    {
        ColorHelper colorHelper;

        // GET: CategoryController
        public ActionResult Index()
        {
            colorHelper = new ColorHelper();
            List<ColorViewModel> list = colorHelper.GetAll();

            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            colorHelper = new ColorHelper();
            ColorViewModel color = colorHelper.GetByID(id);
            return View(color);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColorViewModel color)
        {
            try
            {
                colorHelper = new ColorHelper();
                color = colorHelper.Add(color);


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
            colorHelper = new ColorHelper();
            ColorViewModel color = colorHelper.GetByID(id);
            return View(color);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColorViewModel color)
        {
            try
            {
                colorHelper = new ColorHelper();
                color = colorHelper.Edit(color);


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

            colorHelper = new ColorHelper();
            ColorViewModel color = colorHelper.GetByID(id);
            return View(color);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ColorViewModel color)
        {
            try
            {

                colorHelper = new ColorHelper();
                colorHelper.Delete(color.ColorId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}