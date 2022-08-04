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
    public class DrugGistRepository : IRepository<DrugGist>
    {
        private static int id;
        public DrugGist Create(DrugGist entity)
        {
            id++;
            entity.ID = id;
            try
            {
                DbContext.DrugGists.Add(entity);
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Delete(DrugGist entity)
        {
            try
            {
                DbContext.DrugGists.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void Update(DrugGist entity)
        {
            try
            {
                var drugGist = DbContext.DrugGists.Find(s => s.ID == entity.ID);
                if (drugGist != null)
                {
                    drugGist.Name = entity.Name;
                    drugGist.Surname = entity.Surname;
                    drugGist.Age = entity.Age;
                    drugGist.Experience = entity.Experience;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public DrugGist Get(Predicate<DrugGist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugGists[0];
                }
                else
                {
                    return DbContext.DrugGists.Find(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<DrugGist> GetAll(Predicate<DrugGist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugGists;
                }
                else
                {
                    return DbContext.DrugGists.FindAll(filter);
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
