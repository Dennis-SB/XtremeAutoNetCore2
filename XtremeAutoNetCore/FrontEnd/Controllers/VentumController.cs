using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class VentumController : Controller
    {
        private VentumHelper entidadHelper;
        private UsuarioHelper enlace1Helper;
        private CarroVendidoHelper enlace2Helper;

        #region Constructores
        public VentumController()
        {
            entidadHelper = new VentumHelper();
            enlace1Helper = new UsuarioHelper();
            enlace2Helper = new CarroVendidoHelper();
        }
        #endregion

        #region Index
        // GET: ProductController
        public ActionResult Index()
        {
            List<VentumViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            VentumViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: ProductController/Create
        public ActionResult Create()
        {
            VentumViewModel entidad = new VentumViewModel();
            entidad.Usuarios = enlace1Helper.GetAll();
            entidad.CarroVendidos = enlace2Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VentumViewModel entidad)
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
            VentumViewModel entidad = entidadHelper.GetByID(id);
            entidad.Usuarios = enlace1Helper.GetAll();
            entidad.CarroVendidos = enlace2Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VentumViewModel entidad)
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
            VentumViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VentumViewModel entidad)
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
