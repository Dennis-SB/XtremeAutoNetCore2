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

        public bool Add(Seguro entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Seguro> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seguro> Find(Expression<Func<Seguro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Seguro Get(int id)
        {
            Seguro category = null;
            using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
            {
                category = unidad.genericDAL.Get(id);


            }

            return category;
        }

        public IEnumerable<Seguro> GetAll()
        {
            IEnumerable<Seguro> categories = null;
            using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
            {
                categories = unidad.genericDAL.GetAll();


            }

            return categories;

        }

        public bool Remove(Seguro entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Seguro> entities)
        {
            throw new NotImplementedException();
        }

        public Seguro SingleOrDefault(Expression<Func<Seguro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Seguro entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Seguro>(new XtremeAutoNetCore2Context()))
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