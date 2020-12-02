using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.DomainService
{
    public interface ITopicRepository
    {

        Topic Create(Topic topic);

        Topic FindById(long id);

        Topic Update(Topic topicUpdate);

        Topic Delete(long id);

        public IEnumerable<Topic> GetTopics();

    }
}
