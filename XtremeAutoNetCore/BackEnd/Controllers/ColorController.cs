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

        private IColorDAL colorDAL;

        private ColorModel Convertir(Color color)
        {
            return new ColorModel
            {
                ColorId = color.ColorId,
                Nombre = color.Nombre,
                Imagen = color.Imagen
            };
        }



        private Color Convertir(ColorModel color)
        {
            return new Color
            {
                ColorId = color.ColorId,
                Nombre = color.Nombre,
                Imagen = color.Imagen
            };
        }


        #region Constructores

        public ColorController()
        {
            colorDAL = new ColorDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Color> carroModelos = colorDAL.GetAll();
            List<ColorModel> models = new List<ColorModel>();

            foreach (var color in carroModelos)
            {

                models.Add(Convertir(color));

            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Color color = colorDAL.Get(id);


            return new JsonResult(Convertir(color));
        }
        #endregion

        #region Agregar


        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] ColorModel color)
        {

            colorDAL.Add(Convertir(color));
            return new JsonResult(color);
        }

        #endregion

        #region Modificar


        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ColorModel color)
        {
            colorDAL.Update(Convertir(color));
            return new JsonResult(color);
        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Color color = new Color
            {
                ColorId = id
            };

            colorDAL.Remove(color);

        }

        #endregion

    }
}