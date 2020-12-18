using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.DomainService
{
   public interface ICourseRepository
    {

        Course Create(Course course);

        Course Update(Course courseUpdate);

        Course Delete(long id);

        Course FindById(long id);

        public IEnumerable<Course> GetCourse();
    }
}
