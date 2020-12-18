using Core.Entity;
using System;
namespace StudyBuddy.Core.ApplicationService
{
    public interface ICourseValidator
    {
        public void DefaultValidation(Course course);
    }
}
