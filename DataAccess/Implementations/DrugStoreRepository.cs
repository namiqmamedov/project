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
    public class DrugStoreRepository : IRepository<DrugStore>
    {
        private static int id;
        public DrugStore Create(DrugStore entity)
        {
            id++;
            entity.ID = id;
            try
            {
                DbContext.DrugStores.Add(entity);
                return entity;
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Delete(DrugStore entity)
        {
            try
            {
                DbContext.DrugStores.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
        public void Update(DrugStore entity)
        {
            try
            {
                var drugstore = DbContext.DrugStores.Find(d => d.ID == entity.ID);
                if (drugstore != null)
                {
                    drugstore.Name = entity.Name;
                    drugstore.Address = entity.Address;
                    drugstore.ContactNumber = entity.ContactNumber;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public DrugStore Get(Predicate<DrugStore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugStores[0];
                }
                else
                {
                    return DbContext.DrugStores.Find(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }

        }

        public List<DrugStore> GetAll(Predicate<DrugStore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugStores;
                }
                else
                {
                    return DbContext.DrugStores.FindAll(filter);
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
