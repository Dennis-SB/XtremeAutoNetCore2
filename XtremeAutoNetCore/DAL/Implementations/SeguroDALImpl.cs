using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SeguroDALImpl : ISeguroDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<Seguro> unidad;

        public bool Add(Seguro entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Seguro> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seguro> Find(Expression<Func<Seguro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Seguro Get(int id)
        {
            Seguro entidad = null;
            using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<Seguro> GetAll()
        {
            IEnumerable<Seguro> entidades = null;
            using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Seguro entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Seguro> entidades)
        {
            throw new NotImplementedException();
        }

        public Seguro SingleOrDefault(Expression<Func<Seguro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Seguro entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
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