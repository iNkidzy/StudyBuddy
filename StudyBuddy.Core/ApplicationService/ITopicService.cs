using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
   public interface ITopicService
    {
        Topic Createtopic(string name, string mainBody, long id, Course course);

        Topic Create(Topic topic);

        Topic FindById(int id);

        Topic Update(Topic topicUpdate);
        Topic Delete(int id);


        public List<Topic> GetTopics();
        Topic 
        
    }
}
