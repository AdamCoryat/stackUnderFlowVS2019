using System;
using System.Collections.Generic;
using StackUnderFlow.Models;
using StackUnderFlow.Repositories;

namespace StackUnderFlow.Services
{
  public class ResponsesService
  {
    private readonly ResponsesRepository _repo;

    public ResponsesService(ResponsesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Response> GetAll()
    {
      return _repo.GetAll();
    }

    internal Response GetById(int id)
    {
      Response data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal IEnumerable<Response> GetRepsonsesByQuestionId(int id)
    {
      IEnumerable<Response> data = _repo.GetResponsesByQuestionId(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Response Create(Response newResponse)
    {
      newResponse.Id = _repo.Create(newResponse);
      return newResponse;
    }

    internal Response Edit(Response editResponse, string creatorId)
    {
      Response data = _repo.GetById(editResponse.Id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invaild Permissions");
      }
      if (data.IsAnswer == true)
      {
        throw new Exception("Response has been Marked Answer");
      }
      editResponse.CreatorId = creatorId;
      editResponse.Title = editResponse.Title == null ? data.Title : editResponse.Title;
      editResponse.Description = editResponse.Description == null ? data.Description : editResponse.Description;
      return _repo.Edit(editResponse);
    }



    internal string Delete(int id, string creatorId)
    {
      Response data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      if (data.IsAnswer == true)
      {
        throw new Exception("Response has Been Marked Answer");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}