using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class CourseService : ICourseService
    {
        readonly ICourseRepository _crRepo;

        public CourseService(ICourseRepository courseRepository) 
        {
            _crRepo = courseRepository;
        }
        public Course Create(Course course)
        {
            return _crRepo.Create(course);
        }

        public Course CreateCourse(string name, List<Topic> topics)
        {
            var course = new Course()
            {
                Name = name,
                Topics = topics
                
            };
            return course;
        }

        public Course Delete(long id)
        {
            return _crRepo.Delete(id);
        }

        public Course FindById(long id)
        {
            return _crRepo.FindById(id);
        }

        public List<Course> GetCourse()
        {
            return _crRepo.GetCourse().ToList();
        }

        public Course Update(Course courseUpdate)
        {

            if (courseUpdate.Name.Length < 1)
            {
                throw new InvalidDataException("coursename must be atleast 1 character");
            }
            else
            {
                var course = FindById(courseUpdate.Id);
                course.Name = courseUpdate.Name;
                course.Topics = courseUpdate.Topics;
              
                return course;
            }
        
        }
    }
}
