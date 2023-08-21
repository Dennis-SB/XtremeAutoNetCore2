using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : Controller
    {
        private ITransaccionDAL entidadDAL;

        private TransaccionModel Convertir(Transaccion entidad)
        {
            return new TransaccionModel
            {
                TransaccionId = entidad.TransaccionId,
                VentaId = entidad.VentaId,
                TarjetaId = entidad.TarjetaId,
                FechaTransaccion = entidad.FechaTransaccion,
                FechaCorte = entidad.FechaCorte,
                InteresesMorosidad = entidad.InteresesMorosidad,
                Pagado = entidad.Pagado,
                Precio = entidad.Precio
            };
        }

        private Transaccion Convertir(TransaccionModel entidad)
        {
            return new Transaccion
            {
                TransaccionId = entidad.TransaccionId,
                VentaId = entidad.VentaId,
                TarjetaId = entidad.TarjetaId,
                FechaTransaccion = entidad.FechaTransaccion,
                FechaCorte = entidad.FechaCorte,
                InteresesMorosidad = entidad.InteresesMorosidad,
                Pagado = entidad.Pagado,
                Precio = entidad.Precio
            };
        }

        #region Constructores
        public TransaccionController()
        {
            entidadDAL = new TransaccionDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Transaccion> entidades = entidadDAL.GetAll();
            List<TransaccionModel> models = new List<TransaccionModel>();
            foreach (var entidad in entidades)
            {
                models.Add(Convertir(entidad));
            }
            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Transaccion entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] TransaccionModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TransaccionModel entidad)
        {
            entidadDAL.Update(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Transaccion entidad = new Transaccion
            {
                TransaccionId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}