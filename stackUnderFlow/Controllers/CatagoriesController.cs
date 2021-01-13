using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stack.Models;
using Stack.Services;

namespace Stack.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CatagoriesController : ControllerBase
  {
    private readonly CatagoriesService _cs;
    private readonly QuestionsService _qs;

    public CatagoriesController(CatagoriesService cs, QuestionsService qs)
    {
      _cs = cs;
      _qs = qs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Catagory>> Get()
    {
      try
      {
        return Ok(_cs.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Catagory> Get(int id)
    {
      try
      {
        return Ok(_cs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/questions")]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByCatagoryId(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        IEnumerable<Question> questions = _qs.GetQuestionsByCatagoryId(id);
        foreach (Question q in questions)
        {
          q.Creator = userInfo;
        }
        return Ok(questions);
      }

      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Catagory>> Post([FromBody] Catagory newCatagory)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newCatagory.CreatorId = userInfo.Id;
        Catagory created = _cs.Create(newCatagory);
        created.Creator = userInfo;
        return Ok(created);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Catagory>> Edit(int id, [FromBody] Catagory editCatagory)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editCatagory.Id = id;
        editCatagory.Creator = userInfo;
        return Ok(_cs.Edit(editCatagory, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_cs.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}