using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class CourseRepo : ICourseRepository
    {
        private StudyBuddyContext _ctx;
        public CourseRepo(StudyBuddyContext ctx)
        {
            _ctx = ctx;
        }

        public Course Create(Course course)
        {
            Course co = _ctx.Courses.Add(course).Entity;
             _ctx.SaveChanges();
             return co;
        }

        public Course Delete(long id)
        { 
            Course co = GetCourse().ToList().Find(x => x.Id == id);
           GetCourse().ToList().Remove(co);
           if (co != null) 
           {
               return co;
           }
           return null;
        }

        public Course FindById(long id)
        {
            return _ctx.Courses
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetCourse()
        {
            
            return _ctx.Courses.Include(c => c.Topics).ToList();
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
