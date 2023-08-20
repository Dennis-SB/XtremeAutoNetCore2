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
    public class RuedumController : Controller
    {
        private IRuedumDAL entidadDAL;

        private RuedumModel Convertir(Ruedum entidad)
        {
            return new RuedumModel
            {
                RuedaId = entidad.RuedaId,
                Nombre = entidad.Nombre,
                Precio = entidad.Precio,
                Imagen = entidad.Imagen
            };
        }
        
        private Ruedum Convertir(RuedumModel entidad)
        {
            return new Ruedum
            {
                RuedaId = entidad.RuedaId,
                Nombre = entidad.Nombre,
                Precio = entidad.Precio,
                Imagen = entidad.Imagen
            };
        }
        
        #region Constructores
        public RuedumController()
        {
            entidadDAL = new RuedumDALImpl();
        }
        #endregion
        
        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Ruedum> entidades = entidadDAL.GetAll();
            List<RuedumModel> models = new List<RuedumModel>();
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
            Ruedum entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] RuedumModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RuedumModel entidad)
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
            Ruedum entidad = new Ruedum
            {
                RuedaId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}