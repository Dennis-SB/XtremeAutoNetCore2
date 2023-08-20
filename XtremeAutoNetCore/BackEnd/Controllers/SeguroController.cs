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
    public class SeguroController : Controller
    {
        private ISeguroDAL entidadDAL;

        private SeguroModel Convertir(Seguro entidad)
        {
            return new SeguroModel
            {
                SeguroId = entidad.SeguroId,
                Nombre = entidad.Nombre,
                Plazo = entidad.Plazo,
                Precio = entidad.Precio
            };
        }
        
        private Seguro Convertir(SeguroModel entidad)
        {
            return new Seguro
            {
                SeguroId = entidad.SeguroId,
                Nombre = entidad.Nombre,
                Plazo = entidad.Plazo,
                Precio = entidad.Precio
            };
        }
        
        #region Constructores
        public SeguroController()
        {
            entidadDAL = new SeguroDALImpl();
        }
        #endregion
        
        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Seguro> entidades = entidadDAL.GetAll();
            List<SeguroModel> models = new List<SeguroModel>();
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
            Seguro entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] SeguroModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] SeguroModel entidad)
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
            Seguro entidad = new Seguro
            {
                SeguroId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}