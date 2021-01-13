using StackUnderFlow.Models;
using System;
using Xunit;


namespace StackUnderFlow.UITests.ModelTests
{
  public class ProfileModelTests
  {
    [Fact]
    public void ValidateIsValid()
    {
      //Arrange
      Profile profile = new Profile
      {
        Name = "TestName",
        Email = "Test@Email.Com"
      };
      bool expected = true;

      //Act
      bool actual = profile.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingName()
    {
      //Arrange
      Profile profile = new Profile
      {
        Email = "Test@Email.Com"
      };
      bool expected = false;

      //Act
      bool actual = profile.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingEmail()
    {
      //Arrange
      Profile profile = new Profile
      {
        Name = "TestName"
      };
      bool expected = false;

      //Act
      bool actual = profile.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }
  }
}
