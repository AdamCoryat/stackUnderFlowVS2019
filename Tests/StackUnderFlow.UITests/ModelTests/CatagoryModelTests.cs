using StackUnderFlow.Models;
using System;
using Xunit;

namespace StackUnderFlow.UITests
{
  public class CatagoryModelTests
  {
    [Fact]
    public void ValidateIsValid()
    {
      //Arrange
      Catagory catagory = new Catagory
      {
        CreatorId = "alkjadsf",
        Title = "Test Title",
        Questions = 0,
        Creator = new Profile()
      };
      bool expected = true;

      //Act
      bool actual = catagory.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingTitle()
    {
      //Arrange
      Catagory catagory = new Catagory
      {
        CreatorId = "alkjadsf",
        Questions = 0,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = catagory.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingQuestions()
    {
      //Arrange
      Catagory catagory = new Catagory
      {
        CreatorId = "alkjadsf",
        Title = "Test Title",
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = catagory.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCreator()
    {
      //Arrange
      Catagory catagory = new Catagory
      {
        CreatorId = "alkjadsf",
        Title = "Test Title",
        Questions = 0
      };
      bool expected = false;

      //Act
      bool actual = catagory.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateMissingCreatorId()
    {
      //Arrange
      Catagory catagory = new Catagory
      {
        Title = "Test Title",
        Questions = 0,
        Creator = new Profile()
      };
      bool expected = false;

      //Act
      bool actual = catagory.Validate();

      //Assert
      Assert.Equal(expected, actual);
    }
  }
}
