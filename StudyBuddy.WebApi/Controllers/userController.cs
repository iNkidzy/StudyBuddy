using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Core.ApplicationService;

namespace StudyBuddy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserService _uService;

        public userController(IUserService userService)
        {
            _uService = userService;
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _uService.GetUsers();
        }

        // GET: api/user/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(long id)
        {
            return _uService.FindById(id);
        }

        // POST: api/user
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return _uService.Create(user);
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(long id, [FromBody] User user)
        {
            return _uService.Update(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(long id)
        {
            return _uService.Delete(id);
        }
    }
}
