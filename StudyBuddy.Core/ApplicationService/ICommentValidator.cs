using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface ICommentValidator
    {
        public void DefaultValidation(Comment comment);
    }
}
