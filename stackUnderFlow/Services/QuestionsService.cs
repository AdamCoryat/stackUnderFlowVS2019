using System;
using System.Collections.Generic;
using Stack.Models;
using Stack.Repositories;

namespace Stack.Services
{
  public class QuestionsService
  {
    private readonly QuestionsRepository _repo;

    public QuestionsService(QuestionsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Question> GetAll()
    {
      return _repo.GetAll();
    }

    internal Question GetById(int id)
    {
      Question data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal IEnumerable<Question> GetQuestionsByCatagoryId(int id)
    {
      IEnumerable<Question> data = _repo.GetQuestionsByCatagoryId(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Question Create(Question newQuestion)
    {
      newQuestion.Id = _repo.Create(newQuestion);
      return newQuestion;
    }

    internal Question Edit(Question editQuestion, string creatorId)
    {
      Question data = _repo.GetById(editQuestion.Id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      if (data.IsSolved == true)
      {
        throw new Exception("Question has Been Solved");
      }
      editQuestion.CreatorId = creatorId;
      editQuestion.Title = editQuestion.Title == null ? data.Title : editQuestion.Title;
      editQuestion.Description = editQuestion.Description == null ? data.Description : editQuestion.Description;
      editQuestion.DateCreated = data.DateCreated;
      editQuestion.DateClosed = editQuestion.DateClosed == null ? data.DateClosed : editQuestion.DateClosed;
      editQuestion.DateUpdated = editQuestion.DateUpdated == null ? data.DateUpdated : editQuestion.DateUpdated;
      return _repo.Edit(editQuestion);
    }



    internal string Delete(int id, string creatorId)
    {
      Question data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      if (data.IsSolved == true)
      {
        throw new Exception("Question has Been Solved");
      }
      _repo.Delete(id);
      return "Successfully Deleted!";
    }
  }
}