using StackUnderFlow.Models;
using System;
using Xunit;

namespace StackUnderFlow.UITests.ModelTests
{
  public class ResponseModelTests
  {
    [Fact]
    public void ValidateIsValid()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Title = "TestTitle",
        Description = "Test Description",
        Votes = 0,
        QuestionId = 2,
        IsAnswer = false,
        Creator = new Profile()
      };
      bool expected = true;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCreatorId()
    {
      Response response = new Response
      {
        Title = "TestTitle",
        Description = "Test Description",
        Votes = 0,
        QuestionId = 2,
        IsAnswer = false,
        Creator = new Profile()
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingTitle()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Description = "Test Description",
        Votes = 0,
        QuestionId = 2,
        IsAnswer = false,
        Creator = new Profile()
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingDescription()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Title = "TestTitle",
        Votes = 0,
        QuestionId = 2,
        IsAnswer = false,
        Creator = new Profile()
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingVotes()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Title = "TestTitle",
        Description = "Test Description",
        QuestionId = 2,
        IsAnswer = false,
        Creator = new Profile()
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingQuestionId()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Title = "TestTitle",
        Description = "Test Description",
        Votes = 0,
        IsAnswer = false,
        Creator = new Profile()
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingIsAnswer()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Title = "TestTitle",
        Description = "Test Description",
        Votes = 0,
        QuestionId = 2,
        Creator = new Profile()
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCreator()
    {
      Response response = new Response
      {
        CreatorId = "adfadf",
        Title = "TestTitle",
        Description = "Test Description",
        Votes = 0,
        QuestionId = 2,
        IsAnswer = false
      };
      bool expected = false;

      bool actual = response.Validate();

      Assert.Equal(expected, actual);
    }
  }
}
