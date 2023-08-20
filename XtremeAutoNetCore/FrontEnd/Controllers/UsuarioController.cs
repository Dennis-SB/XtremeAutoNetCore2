using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {

        private UsuarioHelper entidadHelper;
        private RolHelper enlace1Helper;

        #region Constructores
        public UsuarioController()
        {
            entidadHelper = new UsuarioHelper();
            enlace1Helper = new RolHelper();
        }
        #endregion

        #region Index
        // GET: ProductController
        public ActionResult Index()
        {
            List<UsuarioViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            UsuarioViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: ProductController/Create
        public ActionResult Create()
        {
            UsuarioViewModel entidad = new UsuarioViewModel();
            entidad.Roles = enlace1Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel entidad)
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
            UsuarioViewModel entidad = entidadHelper.GetByID(id);
            entidad.Roles = enlace1Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel entidad)
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
            UsuarioViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel entidad)
        {
            try
            {
                entidadHelper.Delete(entidad.UsuarioId);
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
