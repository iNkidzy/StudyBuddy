using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class TopicRepo : ITopicRepository
    {
        private static List<Topic> _topicList = new List<Topic>();
        public ITopicService _topService;

        public TopicRepo(ITopicService topicService)
        {
            _topService = topicService;
        }

        public Topic Create(Topic topic)
        {
            _topicList.Add(topic);
            return topic;
            /* Topic t = _ctx.Topics.Add(topic).Entity;
             _ctx.SaveChanges();
             return t;*/
            
        }

       

        public Topic Delete(long id)
        {
            /*  Topic t = GetTopic().ToList().Find(x => x.Id == id);
          GetTopic).ToList().Remove(t);
          if (t != null) 
          {
              return t;
          }
          return null;*/
            throw new NotImplementedException();
           
        }

        public Topic FindById(long id)
        {
            var topic = _topicList.Find(x => x.Id == id);
            return topic;
            /*return _ctx.Topics
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);*/
           
        }

        public IEnumerable<Topic> GetTopics()
        {
            return _topicList.ToList();
            /*
            return _ctx.Topics.Include(c => c.Course).ToList();*/

        }

        public Topic Update(Topic topicUpdate)
        {
            var topicDB = FindById(topicUpdate.Id);
            if (topicDB != null)
            {
                topicDB.Name = topicUpdate.Name;
                return topicDB;
            }
            return null;
;
        }
    }
}
