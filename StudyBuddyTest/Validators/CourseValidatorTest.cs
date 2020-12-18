using System;
using Core.Entity;
using FluentAssertions;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.Validators;
using Xunit;

namespace StudyBuddyTest.Validators
{
    public class CourseValidatorTest
    {
       [Fact]
       public void CourseValidator_ShouldBeOfTypeICourseValidator()
        {
            new CourseValidator().Should().BeAssignableTo<ICourseValidator>();
        }
        [Fact]
        public void DefaultValidation_CourseIsNull_ShouldThrowException()
        {
            ICourseValidator courseValidator = new CourseValidator();
            Action action = () => courseValidator.DefaultValidation(null as Course);
            action.Should().Throw<NullReferenceException>().WithMessage("Course can not be null");
        }
        [Fact]
        public void DefaultValidation_CourseNameIsEmpty_ShouldThrowException()
        {
            ICourseValidator courseValidator = new CourseValidator();
            Action action = () => courseValidator.DefaultValidation(new Course() { });
            action.Should().Throw<ArgumentException>().WithMessage("Course Name can not be empty");
        }
    }
}
