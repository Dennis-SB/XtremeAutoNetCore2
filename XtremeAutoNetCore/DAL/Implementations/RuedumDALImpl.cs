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
    public class RuedumDALImpl : IRuedumDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<Ruedum> unidad;

        public bool Add(Ruedum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Ruedum> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ruedum> Find(Expression<Func<Ruedum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ruedum Get(int id)
        {
            Ruedum entidad = null;
            using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<Ruedum> GetAll()
        {
            IEnumerable<Ruedum> entidades = null;
            using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Ruedum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Ruedum> entidades)
        {
            throw new NotImplementedException();
        }

        public Ruedum SingleOrDefault(Expression<Func<Ruedum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ruedum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
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