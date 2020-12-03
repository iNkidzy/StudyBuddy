using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.DomainService
{
   public interface IUserRepository
    {
        User Create(User User);

        User Update(User userUpdate);

        User Delete(long id);

        User FindById(long id);

        public IEnumerable<User> GetUser();
    }
}
