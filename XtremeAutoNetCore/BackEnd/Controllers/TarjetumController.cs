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
    public class TarjetumController : Controller
    {
        private ITarjetumDAL entidadDAL;

        private TarjetumModel Convertir(Tarjetum entidad)
        {
            return new TarjetumModel
            {
                TarjetaId = entidad.TarjetaId,
                UsuarioId = entidad.UsuarioId,
                Nombre = entidad.Nombre,
                NumeroDeTarjeta = entidad.NumeroDeTarjeta,
                Cvv = entidad.Cvv,
                FechaVencimiento = entidad.FechaVencimiento,
                LockoutEnabled = entidad.LockoutEnabled
            };
        }

        private Tarjetum Convertir(TarjetumModel entidad)
        {
            return new Tarjetum
            {
                TarjetaId = entidad.TarjetaId,
                UsuarioId = entidad.UsuarioId,
                Nombre = entidad.Nombre,
                NumeroDeTarjeta = entidad.NumeroDeTarjeta,
                Cvv = entidad.Cvv,
                FechaVencimiento = entidad.FechaVencimiento,
                LockoutEnabled = entidad.LockoutEnabled
            };
        }

        #region Constructores
        public TarjetumController()
        {
            entidadDAL = new TarjetumDALImpl();
        }
        #endregion

        #region Consultas
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Tarjetum> entidades = entidadDAL.GetAll();
            List<TarjetumModel> models = new List<TarjetumModel>();
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
            Tarjetum entidad = entidadDAL.Get(id);
            return new JsonResult(Convertir(entidad));
        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] TarjetumModel entidad)
        {
            entidadDAL.Add(Convertir(entidad));
            return new JsonResult(entidad);
        }
        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TarjetumModel entidad)
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
            Tarjetum entidad = new Tarjetum
            {
                TarjetaId = id
            };
            entidadDAL.Remove(entidad);
        }
        #endregion
    }
}