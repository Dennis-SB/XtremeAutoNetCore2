using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RuedumController : Controller
    {
        RuedumHelper entidadHelper;

        #region Index
        // GET: CategoryController
        public ActionResult Index()
        {
            entidadHelper = new RuedumHelper();
            List<RuedumViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            entidadHelper = new RuedumHelper();
            RuedumViewModel entidad = entidadHelper.GetByID(id);
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
        public ActionResult Create(RuedumViewModel entidad)
        {
            try
            {
                entidadHelper = new RuedumHelper();
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
            entidadHelper = new RuedumHelper();
            RuedumViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RuedumViewModel entidad)
        {
            try
            {
                entidadHelper = new RuedumHelper();
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
            entidadHelper = new RuedumHelper();
            RuedumViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RuedumViewModel entidad)
        {
            try
            {
                entidadHelper = new RuedumHelper();
                entidadHelper.Delete(entidad.RuedaId);
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
			entidadHelper = new RuedumHelper();
			RuedumViewModel entidad = entidadHelper.GetByID(id);
			return View(entidad);
		}


		[HttpPost]
		public ActionResult UploadImage(RuedumViewModel entidad, List<IFormFile> files)
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

			entidadHelper = new RuedumHelper();
			RuedumViewModel car = entidadHelper.GetByID(entidad.RuedaId);
			car.Imagen = entidad.Imagen;

			entidadHelper.Edit(car);


			return RedirectToAction("Details", new { id = car.RuedaId });
		}
		#endregion

	}
}