using Core.Entities;
using DataAccess.Base;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class OwnerRepository : IRepository<Owner>
    {
        private static int id;
        public Owner Create(Owner entity)
        {
            id++;
            entity.ID = id;          
            try
            {
                DbContext.Owners.Add(entity);
                return entity;
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Delete(Owner entity)
        {
            try
            {
                DbContext.Owners.Remove(entity);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Update(Owner entity)
        {
            try
            {
                var owner = DbContext.Owners.Find(o => o.ID == entity.ID);
                if (owner != null)
                {
                    owner.Name = entity.Name;
                    owner.Surname = entity.Surname;                  
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public Owner Get(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Owners[0];
                }
                else
                {
                    return DbContext.Owners.Find(filter);

                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Owner> GetAll(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Owners;
                }
                else
                {
                    return DbContext.Owners.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

    }
}
