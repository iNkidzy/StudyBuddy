using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserRepo : IUserRepository
    {
        private StudyBuddyContext _ctx;
        public UserRepo(StudyBuddyContext ctx)
        {
            _ctx = ctx;
        }
        public User Create(User user)
        {
            User u = _ctx.Users.Add(user).Entity;
             _ctx.SaveChanges();
             return u;
            
        }

        public User Delete(long id)
        {
            User u = GetUser().ToList().Find(x => x.Id == id);
        GetUser().ToList().Remove(u);
        if (u != null) 
        {
            return u;
        }
        return null;
        }

        public User FindById(long id)
        {
            return _ctx.Users
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<User> GetUser()
        {
            
            return _ctx.Users.Include(c => c.Courses).ToList();
        }

        public User Update(User userUpdate)
        {
            var userDB = FindById(userUpdate.Id);
            if (userDB != null)
            {
                userDB.Name = userUpdate.Name;
                return userDB;
            }
            return null;
        }
    }
}
