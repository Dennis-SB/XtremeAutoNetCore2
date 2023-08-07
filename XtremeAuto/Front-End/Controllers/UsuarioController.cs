using Front_End.Helpers;
using Front_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioHelper usuarioHelper;

        // GET: UsuarioController
        public ActionResult Index()
        {
            usuarioHelper = new UsuarioHelper();

            List<UsuarioViewModel> list = usuarioHelper.GetAll();

            return View(list);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int UsuarioId)
        {

            usuarioHelper = new UsuarioHelper();
            UsuarioViewModel usuario = usuarioHelper.GetByID(UsuarioId);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                usuarioHelper = new UsuarioHelper();
                usuario = usuarioHelper.Add(usuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int UsuarioId)
        {
            usuarioHelper = new UsuarioHelper();
            UsuarioViewModel usuario = usuarioHelper.GetByID(UsuarioId);
            return View(usuario);
        }


        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                usuarioHelper = new UsuarioHelper();
                usuario = usuarioHelper.Edit(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int UsuarioId)
        {
            usuarioHelper = new UsuarioHelper();
            UsuarioViewModel seguro = usuarioHelper.GetByID(UsuarioId);
            return View(seguro);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                usuarioHelper = new UsuarioHelper();
                usuarioHelper.Delete(usuario.UsuarioId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
