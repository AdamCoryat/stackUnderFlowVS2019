using StackUnderFlow.Models;
using System;
using Xunit;

namespace StackUnderFlow.UITests.ModelTests
{
  public class QuestionModelTests
  {
    [Fact]
    public void ValidateIsValid()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        IsSolved = false,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = true;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCreatorId()
    {
      //Arrange
      Question question = new Question
      {
        Title = "TestTitle",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        IsSolved = false,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingTitle()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        IsSolved = false,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingDescription()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        IsSolved = false,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingDateCreated()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        Description = "Test Description",
        Responses = 0,
        IsSolved = false,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingResponses()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        IsSolved = false,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingIsSolved()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        CatagoryID = 4,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCatagoryId()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        IsSolved = false,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCreator()
    {
      //Arrange
      Question question = new Question
      {
        CreatorId = "adfaasdf",
        Title = "TestTitle",
        Description = "Test Description",
        DateCreated = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0)),
        Responses = 0,
        IsSolved = false,
        CatagoryID = 4
      };
      bool expected = false;

      //Act
      bool actual = question.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }
  }
}
