using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CarroVendidoController : Controller
    {
        private CarroVendidoHelper entidadHelper;
        private RuedumHelper enlace1Helper;
        private ColorHelper enlace2Helper;
        private CarroModeloHelper enlace3Helper;
        private SeguroHelper enlace4Helper;

        #region Constructores
        public CarroVendidoController()
        {
            entidadHelper = new CarroVendidoHelper();
            enlace1Helper = new RuedumHelper();
            enlace2Helper = new ColorHelper();
            enlace3Helper = new CarroModeloHelper();
            enlace4Helper = new SeguroHelper();
        }
        #endregion

        #region Index
        // GET: ProductController
        public ActionResult Index()
        {
            List<CarroVendidoViewModel> list = entidadHelper.GetAll();
            return View(list);
        }
        #endregion

        #region Details
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            CarroVendidoViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }
        #endregion

        #region Create
        // GET: ProductController/Create
        public ActionResult Create()
        {
            CarroVendidoViewModel entidad = new CarroVendidoViewModel();
            entidad.Ruedas = enlace1Helper.GetAll();
            entidad.Colores = enlace2Helper.GetAll();
            entidad.CarroModelos = enlace3Helper.GetAll();
            entidad.Seguros = enlace4Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarroVendidoViewModel entidad)
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
            CarroVendidoViewModel entidad = entidadHelper.GetByID(id);
            entidad.Ruedas = enlace1Helper.GetAll();
            entidad.Colores = enlace2Helper.GetAll();
            entidad.CarroModelos = enlace3Helper.GetAll();
            entidad.Seguros = enlace4Helper.GetAll();
            return View(entidad);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarroVendidoViewModel entidad)
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
            CarroVendidoViewModel entidad = entidadHelper.GetByID(id);
            return View(entidad);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarroVendidoViewModel entidad)
        {
            try
            {
                entidadHelper.Delete(entidad.CarroVendidoId);
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
