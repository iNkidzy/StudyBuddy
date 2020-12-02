using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface IUserService
    {
        User Createtopic(string name, string email, bool isTeacher);

        User Create(User user);

        User FindById(int id);

        User Update(User userUpdate);

        User Delete(int id);

        public List<User> GetUsers();
    }
}
