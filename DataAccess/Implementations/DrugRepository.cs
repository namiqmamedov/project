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
    public class DrugRepository : IRepository<Drug>
    {
        private static int id;
        public Drug Create(Drug entity)
        {
            id++;
            entity.ID = id;
            try
            {
                DbContext.Drugs.Add(entity);
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Delete(Drug entity)
        {
            try
            {
                DbContext.Drugs.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Update(Drug entity)
        {
            try
            {
                var drug = DbContext.Drugs.Find(d => d.ID == entity.ID);
                if (drug != null)
                {
                    drug.Name = entity.Name;
                    drug.Price = entity.Price;
                    drug.Count = entity.Count;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public Drug Get(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugs[0];
                }
                else
                {
                    return DbContext.Drugs.Find(filter);

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }

        }

        public List<Drug> GetAll(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugs;
                }
                else
                {
                    return DbContext.Drugs.FindAll(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
