using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
   public interface ITopicService
    {
        Topic Createtopic(string name, string mainBody, Course course, List<Comment> comments);

        Topic Create(Topic topic);

        Topic FindById(long id);

        Topic Update(Topic topicUpdate);

        Topic Delete(long id);

        public List<Topic> GetTopics();
        
        
    }
}
