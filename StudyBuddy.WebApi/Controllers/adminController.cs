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
    public class adminController : ControllerBase
    {
        private readonly IAdminService _adService;

        public adminController(IAdminService adminService)
        {
            _adService = adminService;
        }

        // GET: api/admin
        [HttpGet]
        public IEnumerable<Admin> Get()
        {
            return _adService.GetAdmin();
        }

        // GET: api/admin/5 
        [HttpGet("{id}", Name = "Get")] //<--Look here if something goes wrong!!!
        public ActionResult<Admin> Get(long id)
        {
            return _adService.FindById(id);
        }

        // POST: api/admin
        [HttpPost]
        public ActionResult<Admin> Post([FromBody] Admin admin)
        {
            return Ok(_adService.Create(admin));
        }

        // PUT: api/admin/5
        [HttpPut("{id}")]
        public ActionResult<Admin> Put(long id, [FromBody] Admin admin)
        {
            return _adService.Update(admin);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Admin> Delete(long id)
        {
            return _adService.Delete(id);
        }
    }
}
