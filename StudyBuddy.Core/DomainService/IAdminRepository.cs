using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.DomainService
{
    public interface IAdminRepository
    {
        Admin Create(Admin admin);

        Admin Update(Admin adminUpdate);

        Admin Delete(long id);

        Admin FindById(long id);

        public IEnumerable<Admin> GetAdmin();
    }
}
