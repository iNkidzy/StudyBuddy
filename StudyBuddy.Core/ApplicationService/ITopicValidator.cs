using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core
{
    public interface ITopicValidator
    {
        public void DefaultValidation(Topic topic);
    }
}
