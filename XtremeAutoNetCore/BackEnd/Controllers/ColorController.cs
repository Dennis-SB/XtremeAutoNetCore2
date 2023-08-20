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
    public class ColorController : Controller
    {
        private IColorDAL entidadDAL;

        private ColorModel Convertir(Color entidad)
        {
            return new ColorModel
            {
                ColorId = entidad.ColorId,
                Nombre = entidad.Nombre,
                Imagen = entidad.Imagen
            };
        }
        
        private Color Convertir(ColorModel entidad)
        {
            return new Color
            {
                ColorId = entidad.ColorId,
                Nombre = entidad.Nombre,
                Imagen = entidad.Imagen
            };
        }
        
        #region Constructores
        public ColorController()
        {
            entidadDAL = new ColorDALImpl();
        }
        #endregion
        
        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Color> entidades = entidadDAL.GetAll();
            List<ColorModel> models = new List<ColorModel>();

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
            Color entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] ColorModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ColorModel entidad)
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
            Color entidad = new Color
            {
                ColorId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}