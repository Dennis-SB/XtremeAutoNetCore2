using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Front_End.Controllers
{
    public class ColorController : Controller
    {
        ColorHelper colorHelper;

        // GET: colorController
        public ActionResult Index()
        {
            colorHelper = new ColorHelper();

            List<ColorViewModel> list = colorHelper.GetAll();

            return View(list);
        }

        // GET: ColorController/Details/5
        public ActionResult Details(int ColorId)
        {
            colorHelper = new ColorHelper();
            ColorViewModel color = colorHelper.GetByID(ColorId);
            return View(color);
        }

        // GET: ColorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorController/Create
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

        // GET: ColorController/Edit/5
        public ActionResult Edit(int ColorId)
        {
            colorHelper = new ColorHelper();
            ColorViewModel color = colorHelper.GetByID(ColorId);
            return View(color);
        }

        // POST: ColorController/Edit/5
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

        // GET: ColorController/Delete/5
        public ActionResult Delete(int ColorId)
        {
            colorHelper = new ColorHelper();
            ColorViewModel seguro = colorHelper.GetByID(ColorId);
            return View(seguro);
        }

        // POST: ColorController/Delete/5
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
