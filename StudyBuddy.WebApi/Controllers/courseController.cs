using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;

namespace StudyBuddy.WebApi.Controllers
{
    // [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {

        private readonly ICourseService _cService;

        public CourseController(ICourseService courseService)
        {
            _cService = courseService;
        }

        // GET: api/course
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _cService.GetCourse();
        }

        // GET: api/course/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(long id)
        {
            return _cService.FindById(id);

            //    var course = _cService.GetCourse(id);
            //    if(course == null)
            //    {
            //        return NotFound();
            //    }
            //    return new ObjectResult(course);
        }

        // POST: api/course
        [HttpPost]
        public ActionResult<Course> Post([FromBody] Course course)
        {
            return _cService.Create(course);
        }

        // PUT: api/course/5
        [HttpPut("{id}")]
        public ActionResult<Course> Put(long id, [FromBody] Course course)
        {
            return _cService.Update(course);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Course> Delete(long id)
        {
            return _cService.Delete(id);
        }
    }
}
