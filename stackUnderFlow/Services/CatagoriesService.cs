using System;
using System.Collections.Generic;
using StackUnderFlow.Models;
using StackUnderFlow.Repositories;

namespace StackUnderFlow.Services
{
  public class CatagoriesService
  {
    private readonly CatagoriesRepository _repo;

    public CatagoriesService(CatagoriesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Catagory> GetAll()
    {
      return _repo.GetAll();
    }

    internal Catagory GetById(int id)
    {
      Catagory data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Catagory Create(Catagory newCatagory)
    {
      newCatagory.Id = _repo.Create(newCatagory);
      return newCatagory;
    }

    internal Catagory Edit(Catagory editCatagory, string creatorId)
    {
      Catagory data = _repo.GetById(editCatagory.Id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      if (data.Questions != 0)
      {
        throw new Exception("Can Not Delete With Active Questions");
      }
      editCatagory.Title = editCatagory.Title == null ? data.Title : editCatagory.Title;
      editCatagory.CreatorId = creatorId;
      return _repo.Edit(editCatagory);
    }

    internal string Delete(int id, string creatorId)
    {
      Catagory data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      if (data.CreatorId != creatorId)
      {
        throw new Exception("Denied Invalid Permissions");
      }
      if (data.Questions != 0)
      {
        throw new Exception("Can not Delete With active Questions");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}