using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface ICourseService
    {
        Course CreateCourse(string name, List<Topic> topics);

        Course Create(Course course);

        Course FindById(long id);

        Course Update(Course courseUpdate);

        Course Delete(long id);

        public List<Course> GetCourse();
    }
}
