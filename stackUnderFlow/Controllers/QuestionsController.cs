using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackUnderFlow.Models;
using StackUnderFlow.Services;

namespace StackUnderFlow.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class QuestionsController : ControllerBase
  {
    private readonly QuestionsService _qs;
    private readonly ResponsesService _rs;

    public QuestionsController(QuestionsService qs, ResponsesService rs)
    {
      _qs = qs;
      _rs = rs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Question>> Get()
    {
      try
      {
        return Ok(_qs.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Question> Get(int id)
    {
      try
      {
        return Ok(_qs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/responses")]
    public async Task<ActionResult<IEnumerable<Response>>> GetResponsesByQuestionId(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        IEnumerable<Response> responses = _rs.GetRepsonsesByQuestionId(id);
        foreach (Response r in responses)
        {
          r.Creator = userInfo;
        }
        return Ok(responses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Question>> Post([FromBody] Question newQuestion)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newQuestion.CreatorId = userInfo.Id;
        Question created = _qs.Create(newQuestion);
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
    public async Task<ActionResult<Question>> Edit(int id, [FromBody] Question editQuestion)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editQuestion.Id = id;
        editQuestion.Creator = userInfo;
        return Ok(_qs.Edit(editQuestion, userInfo.Id));
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
        return Ok(_qs.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}