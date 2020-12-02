using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Repositories
{
    public class TopicRepo : ITopicRepository
    {
        public TopicRepo()
        {
        }

        public Topic Create(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Topic Createtopic(string name, string mainBody, long id, Course course, List<Comment> comments)
        {
            throw new NotImplementedException();
        }

        public Topic Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Topic FindById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetTopics()
        {
            throw new NotImplementedException();
        }

        public Topic Update(Topic topicUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
