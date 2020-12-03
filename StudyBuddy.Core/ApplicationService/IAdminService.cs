using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
   public interface IAdminService
    {
        Admin CreateAdmin(string name);

        Admin Create(Admin admin);

        Admin FindById(long id);

        Admin Update(Admin adminUpdate);

        Admin Delete(long id);

        public List<Admin> GetAdmin();
    }
}
