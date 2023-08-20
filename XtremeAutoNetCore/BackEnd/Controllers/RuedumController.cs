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

        private IRuedumDAL ruedumDAL;

        private RuedumModel Convertir(Ruedum ruedum)
        {
            return new RuedumModel
            {
                RuedaId = ruedum.RuedaId,
                Nombre = ruedum.Nombre,
                Precio = ruedum.Precio,
                Imagen = ruedum.Imagen
            };
        }



        private Ruedum Convertir(RuedumModel ruedum)
        {
            return new Ruedum
            {
                RuedaId = ruedum.RuedaId,
                Nombre = ruedum.Nombre,
                Precio = ruedum.Precio,
                Imagen = ruedum.Imagen
            };
        }


        #region Constructores

        public RuedumController()
        {
            ruedumDAL = new RuedumDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Ruedum> carroModelos = ruedumDAL.GetAll();
            List<RuedumModel> models = new List<RuedumModel>();

            foreach (var ruedum in carroModelos)
            {

                models.Add(Convertir(ruedum));

            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Ruedum ruedum = ruedumDAL.Get(id);


            return new JsonResult(Convertir(ruedum));
        }
        #endregion

        #region Agregar


        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] RuedumModel ruedum)
        {

            ruedumDAL.Add(Convertir(ruedum));
            return new JsonResult(ruedum);
        }

        #endregion

        #region Modificar


        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RuedumModel ruedum)
        {
            ruedumDAL.Update(Convertir(ruedum));
            return new JsonResult(ruedum);
        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Ruedum ruedum = new Ruedum
            {
                RuedaId = id
            };

            ruedumDAL.Remove(ruedum);

        }

        #endregion

    }
}