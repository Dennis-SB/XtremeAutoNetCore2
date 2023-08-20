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

        public bool Add(CarroModelo entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<CarroModelo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarroModelo> Find(Expression<Func<CarroModelo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CarroModelo Get(int id)
        {
            CarroModelo category = null;
            using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
            {
                category = unidad.genericDAL.Get(id);


            }

            return category;
        }

        public IEnumerable<CarroModelo> GetAll()
        {
            IEnumerable<CarroModelo> categories = null;
            using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
            {
                categories = unidad.genericDAL.GetAll();


            }

            return categories;

        }

        public bool Remove(CarroModelo entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void RemoveRange(IEnumerable<CarroModelo> entities)
        {
            throw new NotImplementedException();
        }

        public CarroModelo SingleOrDefault(Expression<Func<CarroModelo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(CarroModelo entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroModelo>(new XtremeAutoNetCore2Context()))
                {
                    unidad.genericDAL.Update(entity);
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
