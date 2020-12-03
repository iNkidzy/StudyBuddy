using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class CourseRepo : ICourseRepository
    {
        private static List<Course> _courseList = new List<Course>();
        readonly ICourseService _corService;
        public CourseRepo(ICourseService courseService)
        {
            _corService = courseService;
        }

        public Course Create(Course course)
        {
            _courseList.Add(course);
            return course;
            /* Course co = _ctx.Courses.Add(course).Entity;
             _ctx.SaveChanges();
             return co;*/

            
        }

       /* public Course CreateCourse(long id, string name, List<Topic> topics)
        {

            throw new NotImplementedException();
        }*/

        public Course Delete(long id)
        {
            /*  Course co = GetCourse().ToList().Find(x => x.Id == id);
           GetCourse().ToList().Remove(co);
           if (co != null) 
           
               return co;
           }
           return null;*/
            throw new NotImplementedException();
        }

        public Course FindById(long id)
        {
            var course = _courseList.Find(x => x.Id == id);
            return course;
            /*return _ctx.Courses
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);*/
         
        }

        public IEnumerable<Course> GetCourse()
        {
            return _courseList.ToList();
            /*
            return _ctx.Course.Include(c => c.Course).ToList();*/

        }

        public Course Update(Course courseUpdate)
        {
            var courseDB = FindById(courseUpdate.Id);
            if (courseDB != null)
            {
                courseDB.Name = courseUpdate.Name;
                return courseDB;
            }
            return null;
         
        }
    }
}
