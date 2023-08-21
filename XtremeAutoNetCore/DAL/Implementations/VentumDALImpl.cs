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
    public class VentumDALImpl : IVentumDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<Ventum> unidad;

        public bool Add(Ventum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ventum>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Ventum> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ventum> Find(Expression<Func<Ventum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ventum Get(int id)
        {
            Ventum entidad = null;
            using (unidad = new UnidadDeTrabajo<Ventum>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<Ventum> GetAll()
        {
            IEnumerable<Ventum> entidades = null;
            using (unidad = new UnidadDeTrabajo<Ventum>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(Ventum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ventum>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Ventum> entidades)
        {
            throw new NotImplementedException();
        }

        public Ventum SingleOrDefault(Expression<Func<Ventum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ventum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ventum>(new XtremeAutoNetCore2Context()))
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
