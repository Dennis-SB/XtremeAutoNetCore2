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

		#region Imagen
		public ActionResult UploadImage(int id)
		{
			entidadHelper = new ColorHelper();
			ColorViewModel entidad = entidadHelper.GetByID(id);
			return View(entidad);
		}


		[HttpPost]
		public ActionResult UploadImage(ColorViewModel entidad, List<IFormFile> files)
		{

			if (files.Count > 0)
			{
				IFormFile formFile = files[0];

				using (var ms = new MemoryStream())
				{
					formFile.CopyTo(ms);
					byte[] fileBytes = ms.ToArray();
					string base64String = Convert.ToBase64String(fileBytes);

					entidad.Imagen = base64String;
				}


			}

			entidadHelper = new ColorHelper();
			ColorViewModel car = entidadHelper.GetByID(entidad.ColorId);
			car.Imagen = entidad.Imagen;

			entidadHelper.Edit(car);


			return RedirectToAction("Details", new { id = car.ColorId });
		}
		#endregion
	}
}