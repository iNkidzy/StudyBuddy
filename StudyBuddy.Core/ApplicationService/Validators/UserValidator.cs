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
        }
    }
}
