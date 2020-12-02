using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class UserRepo : IUserRepository
    {
        public UserRepo()
        {
        }
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public User Delete(long id)
        {
            throw new NotImplementedException();
        }

        public User FindById(long id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public User Update(User userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
