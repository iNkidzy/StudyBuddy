using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class AdminService : IAdminService
    {
        readonly IAdminRepository _adRepo;
        public AdminService(IAdminRepository adminRepository) 
        {
            _adRepo = adminRepository;
        }
        public Admin Create(Admin admin)
        {
            return _adRepo.Create(admin);
        }

        public Admin CreateAdmin(string name)
        {
            var admin = new Admin()
            {
                Name = name
            };
            return admin;
        }

        public Admin Delete(long id)
        {
            return _adRepo.Delete(id);
        }

        public Admin FindById(long id)
        {
            return _adRepo.FindById(id);
        }

        public List<Admin> GetAdmin()
        {
            return _adRepo.GetAdmin().ToList();
        }

        public Admin Update(Admin adminUpdate)
        {
            if (adminUpdate.Name.Length < 1)
            {
                throw new InvalidDataException("admin must be atleast 1 character");
            }
            else
            {
                var admin = FindById(adminUpdate.Id);
                admin.Name = adminUpdate.Name;
                return admin;
            }
        }
    }
}
