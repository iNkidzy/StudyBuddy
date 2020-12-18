using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface IUserValidator
    {
        void DefaultValidation(User user);
    }
}
