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
    public class RolController : Controller
    {

        private IRolDAL entidadDAL;

        private RolModel Convertir(Rol entidad)
        {
            return new RolModel
            {
                RolId = entidad.RolId,
                Nombre = entidad.Nombre
            };
        }



        private Rol Convertir(RolModel entidad)
        {
            return new Rol
            {
                RolId = entidad.RolId,
                Nombre = entidad.Nombre
            };
        }


        #region Constructores

        public RolController()
        {
            entidadDAL = new RolDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Rol> entidades = entidadDAL.GetAll();
            List<RolModel> models = new List<RolModel>();

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
            Rol entidad = entidadDAL.Get(id);


            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar


        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] RolModel entidad)
        {

            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }

        #endregion

        #region Modificar


        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RolModel entidad)
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
            Rol entidad = new Rol
            {
                RolId = id
            };

            entidadDAL.Remove(entidad);

        }

        #endregion

    }
}