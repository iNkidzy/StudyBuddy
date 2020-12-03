using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class AdminRepo : IAdminRepository
    {
        private static List<Admin> _adminList = new List<Admin>();
        readonly IAdminService _adService;
        public AdminRepo(IAdminService adminService) 
        {
            _adService = adminService;
        }
        public Admin Create(Admin admin)
        {
            _adminList.Add(admin);
            return admin;
            /* Admin a = _ctx.Admins.Add(admin).Entity;
             _ctx.SaveChanges();
             return a;*/
          
        }

        public Admin Delete(long id)
        {
        
          /*  Admin a = GetAdmin().ToList().Find(x => x.Id == id);
            GetAdmin().ToList().Remove(a);
            if (a != null) 
            {
                return a;
            }
            return null;*/
            throw new NotImplementedException();
        }

        public Admin FindById(long id)
        {
            var admin = _adminList.Find(x => x.Id == id);
            return admin;
            /*return _ctx.Admins
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);*/
           
        }

        public IEnumerable<Admin> GetAdmin()
        {
            return _adminList.ToList();
            /*
            return _ctx.Admins.Include(c => c.Course).ToList();*/
         
        }

        public Admin Update(Admin adminUpdate)
        {
            var adminDB = FindById(adminUpdate.Id);
            if (adminDB != null) 
            {
                adminDB.Name = adminUpdate.Name;
                return adminDB;
            }
            return null; 
        }
    }
}
