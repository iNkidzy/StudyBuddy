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
            Course course = FindById(id);
            _ctx.Attach(course).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return course;
        }

        public Course FindById(long id)
        {
            return _ctx.Courses.Include(c => c.Topics)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetCourse()
        {
            
            return _ctx.Courses.Include(c => c.Topics).ToList();
        }

        public Course Update(Course courseUpdate)
        {
            _ctx.Attach(courseUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return courseUpdate;

        }
    }
}
