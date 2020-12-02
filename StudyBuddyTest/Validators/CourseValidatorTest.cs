using System;
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
    }
}
