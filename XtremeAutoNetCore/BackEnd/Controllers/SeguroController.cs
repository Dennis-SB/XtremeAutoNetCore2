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

        private ISeguroDAL seguroDAL;

        private SeguroModel Convertir(Seguro seguro)
        {
            return new SeguroModel
            {
                SeguroId = seguro.SeguroId,
                Nombre = seguro.Nombre,
                Plazo = seguro.Plazo,
                Precio = seguro.Precio
            };
        }



        private Seguro Convertir(SeguroModel seguro)
        {
            return new Seguro
            {
                SeguroId = seguro.SeguroId,
                Nombre = seguro.Nombre,
                Plazo = seguro.Plazo,
                Precio = seguro.Precio
            };
        }


        #region Constructores

        public SeguroController()
        {
            seguroDAL = new SeguroDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Seguro> seguros = seguroDAL.GetAll();
            List<SeguroModel> models = new List<SeguroModel>();

            foreach (var seguro in seguros)
            {

                models.Add(Convertir(seguro));

            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Seguro seguro = seguroDAL.Get(id);


            return new JsonResult(Convertir(seguro));
        }
        #endregion

        #region Agregar


        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] SeguroModel seguro)
        {

            seguroDAL.Add(Convertir(seguro));
            return new JsonResult(seguro);
        }

        #endregion

        #region Modificar


        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] SeguroModel seguro)
        {
            seguroDAL.Update(Convertir(seguro));
            return new JsonResult(seguro);
        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Seguro seguro = new Seguro
            {
                SeguroId = id
            };

            seguroDAL.Remove(seguro);

        }

        #endregion

    }
}