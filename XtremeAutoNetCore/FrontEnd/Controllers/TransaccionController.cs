using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TransaccionController : Controller
    {
        private TransaccionHelper entidadHelper;
        private VentumHelper enlace1Helper;
        private TarjetumHelper enlace2Helper;

        #region Constructores
        public TransaccionController()
        {
            entidadHelper = new TransaccionHelper();
            enlace1Helper = new VentumHelper();
            enlace2Helper = new TarjetumHelper();
        }
        #endregion

        #region Index
        // GET: ProductController
        public ActionResult Index()
        {
            List<TransaccionViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            TransaccionViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: ProductController/Create
        public ActionResult Create()
        {
            TransaccionViewModel entidad = new TransaccionViewModel();
            entidad.Ventas = enlace1Helper.GetAll();
            entidad.Tarjetas = enlace2Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransaccionViewModel entidad)
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
            TransaccionViewModel entidad = entidadHelper.GetByID(id);
            entidad.Ventas = enlace1Helper.GetAll();
            entidad.Tarjetas = enlace2Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransaccionViewModel entidad)
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
            TransaccionViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TransaccionViewModel entidad)
        {
            try
            {
                entidadHelper.Delete(entidad.VentaId);
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