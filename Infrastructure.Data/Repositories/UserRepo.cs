using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class UserRepo : IUserRepository
    {
        private static List<User> _userList = new List<User>();
        readonly IUserService _usrService;
        public UserRepo(IUserService userService)
        {
            _usrService = userService;
        }
        public User Create(User user)
        {
            _userList.Add(user);
            return user;
            /* User u = _ctx.Users.Add(user).Entity;
             _ctx.SaveChanges();
             return u;*/
            
        }

        public User Delete(long id)
        {
            /*  User u = GetUser().ToList().Find(x => x.Id == id);
        GetUser).ToList().Remove(u);
        if (u != null) 
        {
            return u;
        }
        return null;*/
            throw new NotImplementedException();
           
        }

        public User FindById(long id)
        {
            var user = _userList.Find(x => x.Id == id);
            return user;
            /*return _ctx.Users
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);*/
        }

        public IEnumerable<User> GetUser()
        {
            return _userList.ToList();
            /*
            return _ctx.Users.Include(c => c.Course).ToList();*/
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
