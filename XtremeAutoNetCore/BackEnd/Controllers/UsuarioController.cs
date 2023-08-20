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
    public class UsuarioController : Controller
    {
        private IUsuarioDAL entidadDAL;

        private UsuarioModel Convertir(Usuario entidad)
        {
            return new UsuarioModel
            {
                UsuarioId = entidad.UsuarioId,
                Nombre = entidad.Nombre,
                Apellido = entidad.Apellido,
                Salario = entidad.Salario,
                Cedula = entidad.Cedula,
                Email = entidad.Email,
                PasswordHash = entidad.PasswordHash,
                SecurityStamp = entidad.SecurityStamp,
                Telefono = entidad.Telefono,
                Username = entidad.Username,
                RolId = entidad.RolId,
                LockoutEnabled = entidad.LockoutEnabled,
                FailedAttemptsCount = entidad.FailedAttemptsCount,
                LockoutEndDateUtc = entidad.LockoutEndDateUtc
            };
        }

        private Usuario Convertir(UsuarioModel entidad)
        {
            return new Usuario
            {
                UsuarioId = entidad.UsuarioId,
                Nombre = entidad.Nombre,
                Apellido = entidad.Apellido,
                Salario = entidad.Salario,
                Cedula = entidad.Cedula,
                Email = entidad.Email,
                PasswordHash = entidad.PasswordHash,
                SecurityStamp = entidad.SecurityStamp,
                Telefono = entidad.Telefono,
                Username = entidad.Username,
                RolId = entidad.RolId,
                LockoutEnabled = entidad.LockoutEnabled,
                FailedAttemptsCount = entidad.FailedAttemptsCount,
                LockoutEndDateUtc = entidad.LockoutEndDateUtc
            };
        }

        #region Constructores
        public UsuarioController()
        {
            entidadDAL = new UsuarioDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Usuario> entidades = entidadDAL.GetAll();
            List<UsuarioModel> models = new List<UsuarioModel>();
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
            Usuario entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] UsuarioModel entidad)
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
            Usuario entidad = new Usuario
            {
                UsuarioId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}