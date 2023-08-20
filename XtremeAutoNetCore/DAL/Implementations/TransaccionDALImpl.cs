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
    public class TransaccionDALImpl : ITransaccionDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<Transaccion> unidad;

        public bool Add(Transaccion entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Transaccion>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Transaccion> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaccion> Find(Expression<Func<Transaccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Transaccion Get(int id)
        {
            Transaccion entidad = null;
            using (unidad = new UnidadDeTrabajo<Transaccion>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<Transaccion> GetAll()
        {
            IEnumerable<Transaccion> entidades = null;
            using (unidad = new UnidadDeTrabajo<Transaccion>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Transaccion entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Transaccion>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Transaccion> entidades)
        {
            throw new NotImplementedException();
        }

        public Transaccion SingleOrDefault(Expression<Func<Transaccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Transaccion entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Transaccion>(new XtremeAutoNetCore2Context()))
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
