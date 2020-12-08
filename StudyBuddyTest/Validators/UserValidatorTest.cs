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
    public class UserValidatorTest
    {
        [Fact]
        public void UserValidator_ShouldBeOfTypeIUserValidator()
        {
            new UserValidator().Should().BeAssignableTo<IUserValidator>();
            //checks on creation to see if IUserValidator is assigned to the UserValidator class
        }

        [Fact]
        public void DefaultValidation_UserThatIsNull_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(null as User);
            action.Should().Throw<NullReferenceException>().WithMessage("User can not be null");
            //checks if user is null
        }
    }
}
