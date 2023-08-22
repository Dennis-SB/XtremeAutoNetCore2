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
    public class ColorDALImpl : IColorDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<Color>? unidad;

        public bool Add(Color entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Color>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Color> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Color> Find(Expression<Func<Color, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Color Get(int id)
        {
            Color entidad = null;
            using (unidad = new UnidadDeTrabajo<Color>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<Color> GetAll()
        {
            IEnumerable<Color> entidades = null;
            using (unidad = new UnidadDeTrabajo<Color>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Color entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Color>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Color> entidades)
        {
            throw new NotImplementedException();
        }

        public Color SingleOrDefault(Expression<Func<Color, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Color entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Color>(new XtremeAutoNetCore2Context()))
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
