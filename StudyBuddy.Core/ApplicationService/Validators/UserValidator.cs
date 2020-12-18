using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Validators
{
    public class UserValidator : IUserValidator
    {
        public void DefaultValidation(User user)
        {
            if(user == null)
            {
                throw new NullReferenceException("User can not be null");
            }
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("User's Name can not be empty");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentException("User's Email can not be empty");
            }
        }
    }
}
