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
    public class VentumController : Controller
    {
        private IVentumDAL entidadDAL;

        private VentumModel Convertir(Ventum entidad)
        {
            return new VentumModel
            {
                VentaId = entidad.VentaId,
                UsuarioId = entidad.UsuarioId,
                CarroVendidoId = entidad.CarroVendidoId,
                Total = entidad.Total,
                Meses = entidad.Meses,
                Intereses = entidad.Intereses,
                SaldoPendiente = entidad.SaldoPendiente,
                SaldoAbonado = entidad.SaldoAbonado
            };
        }

        private Ventum Convertir(VentumModel entidad)
        {
            return new Ventum
            {
                VentaId = entidad.VentaId,
                UsuarioId = entidad.UsuarioId,
                CarroVendidoId = entidad.CarroVendidoId,
                Total = entidad.Total,
                Meses = entidad.Meses,
                Intereses = entidad.Intereses,
                SaldoPendiente = entidad.SaldoPendiente,
                SaldoAbonado = entidad.SaldoAbonado
            };
        }

        #region Constructores
        public VentumController()
        {
            entidadDAL = new VentumDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Ventum> entidades = entidadDAL.GetAll();
            List<VentumModel> models = new List<VentumModel>();
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
            Ventum entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] VentumModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] VentumModel entidad)
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
            Ventum entidad = new Ventum
            {
                VentaId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}