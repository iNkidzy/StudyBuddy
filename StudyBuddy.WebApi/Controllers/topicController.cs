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
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topService;

        public TopicController(ITopicService topService)
        {
            _topService = topService;
        }

        // GET: api/topic
        [HttpGet]
        public IEnumerable<Topic> Get()
        {
            return _topService.GetTopics();
        }

        // GET: api/topic/5
        [HttpGet("{id}")]
        public ActionResult<Topic> Get(long id)
        {
            return _topService.FindById(id);
        }

        // POST: api/topic
        [HttpPost]
        public ActionResult<Topic> Post([FromBody] Topic topic)
        {
            return _topService.Create(topic);

        }

        // PUT: api/topic/5
        [HttpPut("{id}")]
        public ActionResult<Topic> Put(int id, [FromBody] Topic topic)
        {
            return _topService.Update(topic);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Topic> Delete(int id)
        {
            return _topService.Delete(id);
        }
    }
}
