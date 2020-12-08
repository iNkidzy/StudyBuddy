using Core.Entity;
using FluentAssertions;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.ApplicationService.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudyBuddyTest.Validators
{
    public class CommentValidatorTest
    {
        [Fact]
        public void CommentValidator_ShouldBeOfTypeICommentValidator()
        {
            new CommentValidator().Should().BeAssignableTo<ICommentValidator>();
        }

        [Fact]
        public void DefaultValidation_CommentThatIsNull_ShouldThrowException()
        {
            ICommentValidator commentValidator = new CommentValidator();
            Action action = () => commentValidator.DefaultValidation(null as Comment);
            action.Should().Throw<NullReferenceException>().WithMessage("Comment can not be null");
        }
        [Fact]
        public void DefaultValidation_UserThatIsNull_ShouldThrowException()
        {
            ICommentValidator commentValidator = new CommentValidator();
            Action action = () => commentValidator.DefaultValidation(new Comment() {DatePosted = DateTime.Now.AddDays(-5), MainBody = "yadayada", Topic = new Topic() });
            action.Should().Throw<NullReferenceException>().WithMessage("Comment must have a User");
        }
        [Fact]
        public void DefaultValidation_TopicThatIsNull_ShouldThrowException()
        {
            ICommentValidator commentValidator = new CommentValidator();
            Action action = () => commentValidator.DefaultValidation(new Comment() { DatePosted = DateTime.Now.AddDays(-5), MainBody = "yadayada", User = new User() });
            action.Should().Throw<NullReferenceException>().WithMessage("Comment must have a Topic");
        }
        [Fact]
        public void DefaultValidation_CommentCanNotBeEmptyOrNull_ShouldThrowException()
        {
            ICommentValidator commentValidator = new CommentValidator();
            Action action = () => commentValidator.DefaultValidation(new Comment() { DatePosted = DateTime.Now.AddDays(-5), Topic = new Topic(), User = new User() });
            action.Should().Throw<ArgumentException>().WithMessage("Comment must not be empty");
        }
        [Fact]
        public void DefaultValidation_DatePostedCanNotBeInFuture_ShouldThrowException()
        {
            ICommentValidator commentValidator = new CommentValidator();
            Action action = () => commentValidator.DefaultValidation(new Comment() { DatePosted = DateTime.Now.AddDays(5), MainBody = "yadayada", Topic = new Topic(), User = new User() });
            action.Should().Throw<ArgumentException>().WithMessage("DatePosted can not be in the future");
        }
    }
}
