using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly AdminDbContext adminContext;

        public AdminRL(AdminDbContext adminContext)
        {
            this.adminContext = adminContext;
        }

        public bool Delete(int id)
        {
            Admin dbUser = this.adminContext.users.Where(user => user.UserId == id).FirstOrDefault();
           
            

            if (dbUser != null)
            {
                this.adminContext.users.Remove(dbUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Admin> GetRegister()
        {
            return this.adminContext.users.ToList();
        }

        public bool Register(Admin user)
        {
            this.adminContext.users.Add(user);
            int result = this.adminContext.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Admin admin)
        {
           Admin dbUser= this.adminContext.users.Where(user => user.UserId == admin.UserId).FirstOrDefault();
            dbUser.UserName = admin.UserName;
            dbUser.Email = admin.Email;
            dbUser.Password = admin.Password;
            int result = this.adminContext.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
