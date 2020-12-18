using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _usrRepo;
        readonly IUserValidator _userValidator;
        public UserService(IUserRepository userRepository, IUserValidator userValidator) 
        {
            _usrRepo = userRepository;
            _userValidator = userValidator;
        }

        public User Create(User user)
        {
            _userValidator.DefaultValidation(user);
            return _usrRepo.Create(user);
        }

        //
        // a User is not a teacher boolean, we need to figure this out in meeting!!
        //
        public User CreateUser(string name, string email)
           
        {
            var user = new User()
            {
                Name = name,
                Email = email
            };
            return user;
        }

        public User Delete(long id)
        {
            return _usrRepo.Delete(id);
        }

        public User FindById(long id)
        {
            return _usrRepo.FindById(id);
        }

        public List<User> GetUsers()
        {
            return _usrRepo.GetUser().ToList();
        }

        public User Update(User userUpdate)
        {
            if (userUpdate.Name.Length < 1)
            {
                throw new InvalidDataException("username must be atleast 1 character");
            }
            else
            {
                return _usrRepo.Update(userUpdate);
            }
        }
    }
}
