using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TopicRepo : ITopicRepository
    {
        private StudyBuddyContext _ctx;

        public TopicRepo(StudyBuddyContext ctx)
        {
            _ctx = ctx;
        }

        public Topic Create(Topic topic)
        {
            Topic t = _ctx.Topics.Add(topic).Entity;
             _ctx.SaveChanges();
             return t;
        }

       

        public Topic Delete(long id)
        {
           Topic t = GetTopics().ToList().Find(x => x.Id == id);
          GetTopics().ToList().Remove(t);
          if (t != null) 
          {
              return t;
          }
          return null;
        }

        public Topic FindById(long id)
        {
            return _ctx.Topics
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Topic> GetTopics()
        {
            
            return _ctx.Topics.Include(c => c.Comments).ToList();
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
