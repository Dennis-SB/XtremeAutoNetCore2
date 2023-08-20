using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TarjetumController : Controller
    {
        private TarjetumHelper entidadHelper;
        private UsuarioHelper enlace1Helper;

        #region Constructores
        public TarjetumController()
        {
            entidadHelper = new TarjetumHelper();
            enlace1Helper = new UsuarioHelper();
        }
        #endregion

        #region Index
        // GET: ProductController
        public ActionResult Index()
        {
            List<TarjetumViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            TarjetumViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: ProductController/Create
        public ActionResult Create()
        {
            TarjetumViewModel entidad = new TarjetumViewModel();
            entidad.Usuarios = enlace1Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarjetumViewModel entidad)
        {
            try
            {
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
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            TarjetumViewModel entidad = entidadHelper.GetByID(id);
            entidad.Usuarios = enlace1Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarjetumViewModel entidad)
        {
            try
            {
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
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            TarjetumViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TarjetumViewModel entidad)
        {
            try
            {
                entidadHelper.Delete(entidad.TarjetaId);
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