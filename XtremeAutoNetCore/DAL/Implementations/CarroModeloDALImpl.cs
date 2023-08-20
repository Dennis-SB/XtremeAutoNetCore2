﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CarroModeloDALImpl : ICarroModeloDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<CarroModelo> unidad;

        public bool Add(CarroModelo entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
                {
                    unidad.genericDAL.Add(entidad);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<CarroModelo> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarroModelo> Find(Expression<Func<CarroModelo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CarroModelo Get(int id)
        {
            CarroModelo entidad = null;
            using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<CarroModelo> GetAll()
        {
            IEnumerable<CarroModelo> entidades = null;
            using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(CarroModelo entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
                {
                    unidad.genericDAL.Remove(entidad);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<CarroModelo> entidades)
        {
            throw new NotImplementedException();
        }

        public CarroModelo SingleOrDefault(Expression<Func<CarroModelo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(CarroModelo entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
                {
                    unidad.genericDAL.Update(entidad);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
