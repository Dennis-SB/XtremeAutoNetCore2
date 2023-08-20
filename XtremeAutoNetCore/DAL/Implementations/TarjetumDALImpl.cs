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
    public class TarjetumDALImpl : ITarjetumDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<Tarjetum> unidad;

        public bool Add(Tarjetum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Tarjetum>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Tarjetum> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarjetum> Find(Expression<Func<Tarjetum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Tarjetum Get(int id)
        {
            Tarjetum entidad = null;
            using (unidad = new UnidadDeTrabajo<Tarjetum>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<Tarjetum> GetAll()
        {
            IEnumerable<Tarjetum> entidades = null;
            using (unidad = new UnidadDeTrabajo<Tarjetum>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;

        }

        public bool Remove(Tarjetum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Tarjetum>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Tarjetum> entidades)
        {
            throw new NotImplementedException();
        }

        public Tarjetum SingleOrDefault(Expression<Func<Tarjetum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tarjetum entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Tarjetum>(new XtremeAutoNetCore2Context()))
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