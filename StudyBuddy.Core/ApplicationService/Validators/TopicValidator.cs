using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Validators
{
    public class TopicValidator : ITopicValidator
    {
        public void DefaultValidation(Topic topic)
        {
            if(topic == null)
            {
                throw new NullReferenceException("Topic can not be null");
            }
            if(topic.MainBody == null)
            {
                throw new NullReferenceException("Topic MainBody must be initialized");
            }
            if (string.IsNullOrEmpty(topic.Name))
            {
                throw new ArgumentException("Topic Name must not be empty");
            }
        }
    }
}
