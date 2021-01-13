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
  public class ResponsesController : ControllerBase
  {
    private readonly ResponsesService _rs;

    public ResponsesController(ResponsesService rs)
    {
      _rs = rs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Response>> Get()
    {
      try
      {
        return Ok(_rs.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Response> Get(int id)
    {
      try
      {
        return Ok(_rs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Response>> Post([FromBody] Response newResponse)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newResponse.CreatorId = userInfo.Id;
        Response created = _rs.Create(newResponse);
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
    public async Task<ActionResult<Response>> Edit(int id, [FromBody] Response editResponse)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editResponse.Id = id;
        editResponse.Creator = userInfo;
        return Ok(_rs.Edit(editResponse, userInfo.Id));
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
        return Ok(_rs.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
