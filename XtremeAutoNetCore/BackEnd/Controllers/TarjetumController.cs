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
    public class TarjetumController : Controller
    {

        private ITarjetumDAL tarjetumDAL;

        private TarjetumModel Convertir(Tarjetum tarjetum)
        {
            return new TarjetumModel
            {
                TarjetaId = tarjetum.TarjetaId,
                UsuarioId = tarjetum.UsuarioId,
                Nombre = tarjetum.Nombre,
                NumeroDeTarjeta = tarjetum.NumeroDeTarjeta,
                Cvv = tarjetum.Cvv,
                FechaVencimiento = tarjetum.FechaVencimiento,
                LockoutEnabled = tarjetum.LockoutEnabled
            };
        }



        private Tarjetum Convertir(TarjetumModel tarjetum)
        {
            return new Tarjetum
            {
                TarjetaId = tarjetum.TarjetaId,
                UsuarioId = tarjetum.UsuarioId,
                Nombre = tarjetum.Nombre,
                NumeroDeTarjeta = tarjetum.NumeroDeTarjeta,
                Cvv = tarjetum.Cvv,
                FechaVencimiento = tarjetum.FechaVencimiento,
                LockoutEnabled = tarjetum.LockoutEnabled
            };
        }


        #region Constructores

        public TarjetumController()
        {
            tarjetumDAL = new TarjetumDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Tarjetum> tarjetas = tarjetumDAL.GetAll();
            List<TarjetumModel> models = new List<TarjetumModel>();

            foreach (var tarjetum in tarjetas)
            {

                models.Add(Convertir(tarjetum));

            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Tarjetum tarjetum = tarjetumDAL.Get(id);


            return new JsonResult(Convertir(tarjetum));
        }
        #endregion

        #region Agregar


        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] TarjetumModel tarjetum)
        {

            tarjetumDAL.Add(Convertir(tarjetum));
            return new JsonResult(tarjetum);
        }

        #endregion

        #region Modificar


        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TarjetumModel tarjetum)
        {
            tarjetumDAL.Update(Convertir(tarjetum));
            return new JsonResult(tarjetum);
        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Tarjetum tarjetum = new Tarjetum
            {
                TarjetaId = id
            };

            tarjetumDAL.Remove(tarjetum);

        }

        #endregion

    }
}