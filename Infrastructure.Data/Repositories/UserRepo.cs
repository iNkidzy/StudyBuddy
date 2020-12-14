using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Helper;

namespace Infrastructure.Data.Repositories
{
    public class UserRepo : IUserRepository
    {
        private StudyBuddyContext _ctx;
        private IAuthenticationHelper _authenticationHelper;
        public UserRepo(StudyBuddyContext ctx, IAuthenticationHelper authHelp)
        {
            _ctx = ctx;
            _authenticationHelper = authHelp;
        }
        public User Create(User user)
        {
            User u = _ctx.Users.Add(user).Entity;
             _ctx.SaveChanges();
             return u;
            
        }

        public User Delete(long id)
        {
            User u = FindById(id);
            _ctx.Attach(u).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return u;
        }

        public User FindById(long id)
        {
            User user = _ctx.Users
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
            byte[] passHash;
            byte[] passSalt;
            _authenticationHelper.CreatePasswordHash(user.Password, out passHash, out passSalt );
            user.PasswordHash = passHash;
            user.PasswordSalt = passSalt;
            user.Password = null;
            return user;
        }

        public IEnumerable<User> GetUser()
        {
            
            return _ctx.Users.Include(c => c.Courses).ToList();
        }

        public User Update(User userUpdate)
        {
            _ctx.Attach(userUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return userUpdate;
        }
    }
}
