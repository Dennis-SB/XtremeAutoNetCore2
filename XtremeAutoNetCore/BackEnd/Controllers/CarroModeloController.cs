﻿using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroModeloController : Controller
    {
        private ICarroModeloDAL entidadDAL;

        private CarroModeloModel Convertir(CarroModelo entidad)
        {
            return new CarroModeloModel
            {
                CarroModeloId = entidad.CarroModeloId,
                Disponible = entidad.Disponible,
                Tipo = entidad.Tipo,
                Marca = entidad.Marca,
                Modelo = entidad.Modelo,
                Descripcion = entidad.Descripcion,
                Precio = entidad.Precio,
                Cantidad = entidad.Cantidad,
                Imagen = entidad.Imagen
            };
        }
        
        private CarroModelo Convertir(CarroModeloModel entidad)
        {
            return new CarroModelo
            {
                CarroModeloId = entidad.CarroModeloId,
                Disponible = entidad.Disponible,
                Tipo = entidad.Tipo,
                Marca = entidad.Marca,
                Modelo = entidad.Modelo,
                Descripcion = entidad.Descripcion,
                Precio = entidad.Precio,
                Cantidad = entidad.Cantidad,
                Imagen = entidad.Imagen
            };
        }
        
        #region Constructores
        public CarroModeloController()
        {
            entidadDAL = new CarroModeloDALImpl();
        }
        #endregion
        
        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<CarroModelo> entidades = entidadDAL.GetAll();
            List<CarroModeloModel> models = new List<CarroModeloModel>();
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
            CarroModelo entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] CarroModeloModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CarroModeloModel entidad)
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
            CarroModelo entidad = new CarroModelo
            {
                CarroModeloId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}