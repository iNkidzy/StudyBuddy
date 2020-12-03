using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface IUserService
    {
        User CreateUser(string name, string email);

        User Create(User user);

        User FindById(long id);

        User Update(User userUpdate);

        User Delete(long id);

        public List<User> GetUsers();
    }
}
