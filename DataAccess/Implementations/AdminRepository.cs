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
    public class AdminRepository : IRepository<Admin>
    {
        private static int id;
        public Admin Create(Admin entity)
        {

            id++;
            entity.ID = id;
            try
            {
                DbContext.Admins.Add(entity);
                return entity;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Delete(Admin entity)
        {
            try
            {
                DbContext.Admins.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Update(Admin entity)
        {
            try
            {
                var admin = DbContext.Admins.Find(a => a.ID == entity.ID);
                if (admin != null)
                {
                    admin.Username = entity.Username;
                    admin.Password = entity.Password;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Admins[0];
                }
                else
                {
                    return DbContext.Admins.Find(filter);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {

            try
            {
                if (filter == null)
                {
                    return DbContext.Admins;
                }
                else
                {
                    return DbContext.Admins.FindAll(filter);
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
