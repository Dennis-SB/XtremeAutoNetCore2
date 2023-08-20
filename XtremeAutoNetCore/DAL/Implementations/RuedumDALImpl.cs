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

        public bool Add(Ruedum entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
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

        public void AddRange(IEnumerable<Ruedum> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ruedum> Find(Expression<Func<Ruedum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ruedum Get(int id)
        {
            Ruedum category = null;
            using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
            {
                category = unidad.genericDAL.Get(id);


            }

            return category;
        }

        public IEnumerable<Ruedum> GetAll()
        {
            IEnumerable<Ruedum> categories = null;
            using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
            {
                categories = unidad.genericDAL.GetAll();


            }

            return categories;

        }

        public bool Remove(Ruedum entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
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

        public void RemoveRange(IEnumerable<Ruedum> entities)
        {
            throw new NotImplementedException();
        }

        public Ruedum SingleOrDefault(Expression<Func<Ruedum, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ruedum entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ruedum>(new XtremeAutoNetCore2Context()))
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