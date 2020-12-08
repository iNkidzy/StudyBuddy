using Core.Entity;
using FluentAssertions;
using StudyBuddy.Core;
using StudyBuddy.Core.ApplicationService.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudyBuddyTest.Validators
{
    public class TopicValidatorTest
    {
        [Fact]
        public void TopicValidator_ShouldBeOfTypeITopicValidator()
        {
            new TopicValidator().Should().BeAssignableTo<ITopicValidator>();
        }

        [Fact]
        public void DefaultValidation_TopicThatIsNull_ShouldThrowException()
        {
            ITopicValidator topicValidator = new TopicValidator();
            Action action = () => topicValidator.DefaultValidation(null as Topic);
            action.Should().Throw<NullReferenceException>().WithMessage("Topic can not be null");
        }
        [Fact]
        public void DefaultValidation_CourseThatIsNull_ShouldThrowException()
        {
            ITopicValidator topicValidator = new TopicValidator();
            Action action = () => topicValidator.DefaultValidation(new Topic() {Comments = new List<Comment>(), MainBody = "", Name = ""});
            action.Should().Throw<NullReferenceException>().WithMessage("Topic must have a Course");
        }
        [Fact]
        public void DefaultValidation_CommentListThatIsNull_ShouldThrowException()
        {
            ITopicValidator topicValidator = new TopicValidator();
            Action action = () => topicValidator.DefaultValidation(new Topic() { Course = new Course(), MainBody = "", Name = "" });
            action.Should().Throw<NullReferenceException>().WithMessage("Comment list must be initialized");
        }
        [Fact]
        public void DefaultValidation_MainBodyThatIsNull_ShouldThrowException()
        {
            ITopicValidator topicValidator = new TopicValidator();
            Action action = () => topicValidator.DefaultValidation(new Topic() { Comments = new List<Comment>(), Course = new Course(), Name = "" });
            action.Should().Throw<NullReferenceException>().WithMessage("Topic MainBody must be initialized");
        }
        [Fact]
        public void DefaultValidation_NameIsEmptyOrNull_ShouldThrowException()
        {
            ITopicValidator topicValidator = new TopicValidator();
            Action action = () => topicValidator.DefaultValidation(new Topic() { Comments = new List<Comment>(), Course = new Course(), MainBody = "" });
            action.Should().Throw<ArgumentException>().WithMessage("Topic Name must not be empty");
        }
    }
}
