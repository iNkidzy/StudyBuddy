using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class TopicService : ITopicService
    {
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

        public List<Topic> GetTopics()
        {
            throw new NotImplementedException();
        }

        public Topic Update(Topic topicUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
