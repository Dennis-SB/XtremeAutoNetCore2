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

        private ICarroModeloDAL carroModeloDAL;

        private CarroModeloModel Convertir(CarroModelo carroModelo)
        {
            return new CarroModeloModel
            {
                CarroModeloId = carroModelo.CarroModeloId,
                Disponible = carroModelo.Disponible,
                Tipo = carroModelo.Tipo,
                Marca = carroModelo.Marca,
                Modelo = carroModelo.Modelo,
                Descripcion = carroModelo.Descripcion,
                Precio = carroModelo.Precio,
                Cantidad = carroModelo.Cantidad,
                Imagen = carroModelo.Imagen
            };
        }



        private CarroModelo Convertir(CarroModeloModel carroModelo)
        {
            return new CarroModelo
            {
                CarroModeloId = carroModelo.CarroModeloId,
                Disponible = carroModelo.Disponible,
                Tipo = carroModelo.Tipo,
                Marca = carroModelo.Marca,
                Modelo = carroModelo.Modelo,
                Descripcion = carroModelo.Descripcion,
                Precio = carroModelo.Precio,
                Cantidad = carroModelo.Cantidad,
                Imagen = carroModelo.Imagen
            };
        }


        #region Constructores

        public CarroModeloController()
        {
            carroModeloDAL = new CarroModeloDALImpl();

        }

        #endregion


        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<CarroModelo> carroModelos = carroModeloDAL.GetAll();
            List<CarroModeloModel> models = new List<CarroModeloModel>();

            foreach (var carroModelo in carroModelos)
            {

                models.Add(Convertir(carroModelo));

            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            CarroModelo carroModelo = carroModeloDAL.Get(id);


            return new JsonResult(Convertir(carroModelo));
        }
        #endregion

        #region Agregar


        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] CarroModeloModel carroModelo)
        {

            carroModeloDAL.Add(Convertir(carroModelo));
            return new JsonResult(carroModelo);
        }

        #endregion

        #region Modificar


        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CarroModeloModel carroModelo)
        {
            carroModeloDAL.Update(Convertir(carroModelo));
            return new JsonResult(carroModelo);
        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CarroModelo carroModelo = new CarroModelo
            {
                CarroModeloId = id
            };

            carroModeloDAL.Remove(carroModelo);

        }

        #endregion

    }
}