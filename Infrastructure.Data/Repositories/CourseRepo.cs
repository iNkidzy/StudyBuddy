using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class CourseRepo : ICourseRepository
    {
        public CourseRepo()
        {
        }

        public Course Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Course CreateCourse(long id, string name, List<Topic> topics)
        {
            throw new NotImplementedException();
        }

        public Course Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Course FindById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourse()
        {
            throw new NotImplementedException();
        }

        public Course Update(Course courseUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
