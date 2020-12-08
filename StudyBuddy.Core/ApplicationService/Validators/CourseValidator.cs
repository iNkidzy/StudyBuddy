using System;
using Core.Entity;
using StudyBuddy.Core.ApplicationService;

namespace StudyBuddy.Core.Validators
{
    public class CourseValidator:ICourseValidator
    {
        public CourseValidator()
        {
        }

        public void DefaultValidation(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException("Course can not be null");
            }
            if (string.IsNullOrEmpty(course.Name))
            {
                throw new ArgumentException("Course Name can not be empty");
            }
        }
    }
}
