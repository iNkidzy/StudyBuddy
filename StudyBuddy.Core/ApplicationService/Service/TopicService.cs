using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class TopicService : ITopicService
    {
        readonly ITopicRepository _topRepo;
        public TopicService(ITopicRepository topicRepository) 
        {
            _topRepo = topicRepository;
        }

        public Topic Create(Topic topic)
        {
            return _topRepo.Create(topic);
        }

        public Topic Createtopic(string name, string mainBody, Course course, List<Comment> comments)
        {
            var topic = new Topic()
            {
                Name = name,
                MainBody = mainBody,
                Course = course,
                Comments = comments
            };
            return topic;
        }

        public Topic Delete(long id)
        {
            return _topRepo.Delete(id);
        }

        public Topic FindById(long id)
        {
            return _topRepo.FindById(id);
        }

        public List<Topic> GetTopics()
        {
            return _topRepo.GetTopics().ToList();
        }

        public Topic Update(Topic topicUpdate)
        {
            if (topicUpdate.MainBody.Length < 1)
            {
                throw new InvalidDataException("topic must be atleast 1 character");
            }
            else
            {
                var topic = FindById(topicUpdate.Id);
                topic.MainBody = topicUpdate.MainBody;
                topic.Course = topicUpdate.Course;
                topic.Comments = topicUpdate.Comments;
                topic.Name = topicUpdate.Name;
                return topic;
            }
        }
    }
}
