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
    public class CarroVendidoDALImpl : ICarroVendidoDAL
    {
        private XtremeAutoNetCore2Context Context;
        private UnidadDeTrabajo<CarroVendido> unidad;

        public bool Add(CarroVendido entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroVendido>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<CarroVendido> entidades)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarroVendido> Find(Expression<Func<CarroVendido, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CarroVendido Get(int id)
        {
            CarroVendido entidad = null;
            using (unidad = new UnidadDeTrabajo<CarroVendido>(new XtremeAutoNetCore2Context()))
            {
                entidad = unidad.genericDAL.Get(id);
            }
            return entidad;
        }

        public IEnumerable<CarroVendido> GetAll()
        {
            IEnumerable<CarroVendido> entidades = null;
            using (unidad = new UnidadDeTrabajo<CarroVendido>(new XtremeAutoNetCore2Context()))
            {
                entidades = unidad.genericDAL.GetAll();
            }
            return entidades;
        }

        public bool Remove(CarroVendido entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroVendido>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<CarroVendido> entidades)
        {
            throw new NotImplementedException();
        }

        public CarroVendido SingleOrDefault(Expression<Func<CarroVendido, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(CarroVendido entidad)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<CarroVendido>(new XtremeAutoNetCore2Context()))
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
