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
    public class CarroVendidoController : Controller
    {
        private ICarroVendidoDAL entidadDAL;

        private CarroVendidoModel Convertir(CarroVendido entidad)
        {
            return new CarroVendidoModel
            {
                CarroVendidoId = entidad.CarroVendidoId,
                RuedaId = entidad.RuedaId,
                ColorId = entidad.ColorId,
                CarroModeloId = entidad.CarroModeloId,
                SeguroId = entidad.SeguroId,
                PrecioTotal = entidad.PrecioTotal
            };
        }

        private CarroVendido Convertir(CarroVendidoModel entidad)
        {
            return new CarroVendido
            {
                CarroVendidoId = entidad.CarroVendidoId,
                RuedaId = entidad.RuedaId,
                ColorId = entidad.ColorId,
                CarroModeloId = entidad.CarroModeloId,
                SeguroId = entidad.SeguroId,
                PrecioTotal = entidad.PrecioTotal
            };
        }

        #region Constructores
        public CarroVendidoController()
        {
            entidadDAL = new CarroVendidoDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<CarroVendido> entidades = entidadDAL.GetAll();
            List<CarroVendidoModel> models = new List<CarroVendidoModel>();
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
            CarroVendido entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] CarroVendidoModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CarroVendidoModel entidad)
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
            CarroVendido entidad = new CarroVendido
            {
                CarroVendidoId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}