using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Core.DomainService;

namespace StudyBuddy.WebApi.Controllers
{
    // [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : Controller
    {

        private readonly ICourseRepository repository;

        public courseController(ICourseRepository repos)
        {
            repository = repos;
        }

        // GET: api/course
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return repository.GetCourse();
        }

        // GET: api/course/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            return new NoContentResult();
        //    var course = repository.GetCourse(id);
        //    if(course == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(course);
        }

        // POST: api/course
        [HttpPost]
        public ActionResult<Course>Post([FromBody] Course course)
        {
            return repository.Create(course);
        }

        // PUT: api/course/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Course course)
        {
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return new NoContentResult();
        }
    }
}
