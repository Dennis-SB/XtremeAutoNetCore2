using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ColorController : Controller
    {
        ColorHelper entidadHelper;

        #region Index
        // GET: CategoryController
        public ActionResult Index()
        {
            entidadHelper = new ColorHelper();
            List<ColorViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            entidadHelper = new ColorHelper();
            ColorViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColorViewModel entidad)
        {
            try
            {
                entidadHelper = new ColorHelper();
                entidad = entidadHelper.Add(entidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Edit
        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            entidadHelper = new ColorHelper();
            ColorViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColorViewModel entidad)
        {
            try
            {
                entidadHelper = new ColorHelper();
                entidad = entidadHelper.Edit(entidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            entidadHelper = new ColorHelper();
            ColorViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ColorViewModel entidad)
        {
            try
            {
                entidadHelper = new ColorHelper();
                entidadHelper.Delete(entidad.ColorId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}