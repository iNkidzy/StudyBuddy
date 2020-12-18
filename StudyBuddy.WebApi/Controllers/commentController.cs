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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _comService;

        public CommentController(ICommentService commentService)
        {
            _comService = commentService;
        }
        // GET: api/comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _comService.GetComment();
        }

        // GET: api/comment/5
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(long id)
        {
            return _comService.FindById(id);
        }

        // POST: api/comment
        [HttpPost]
        public ActionResult<Comment> Post([FromBody] Comment comment)
        {
            return _comService.Create(comment);
        }

        // PUT: api/comment/5
        [HttpPut("{id}")]
        public ActionResult<Comment> Put(long id, [FromBody] Comment comment)
        {
            return _comService.Update(comment);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Comment> Delete(long id)
        {
            return _comService.Delete(id);
        }
    }
}
