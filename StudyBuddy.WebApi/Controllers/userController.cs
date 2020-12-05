using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Core.ApplicationService;

namespace StudyBuddy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _uService;

        public UserController(IUserService userService)
        {
            _uService = userService;
        }

        // GET: api/user
       // [Authorize]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _uService.GetUsers();
        }

        // GET: api/user/5
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            return _uService.FindById(id);
        }

        // POST: api/user
       // [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return _uService.Create(user);
        }

        // PUT: api/user/5
       // [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<User> Put(long id, [FromBody] User user)
        {
            return _uService.Update(user);
        }

        // DELETE: api/ApiWithActions/5
      // [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(long id)
        {
            return _uService.Delete(id);
        }
    }
}
