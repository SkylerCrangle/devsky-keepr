using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }


    [HttpGet("myKeeps")]  // api/keeps/myKeeps
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetMyKeeps()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetMyKeeps(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<Keep> Get(int id)
    {
      try
      {
        // get the keep
        Keep keep = _ks.Get(id);
        if (keep.IsPrivate)
        {
          //if the user logged in
          //Check if user has a claim
          var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
          //if logged in user is author
          if (user != null && user.Value == keep.UserId)
          {
            // return keep
            return Ok(keep);
          }
          return Unauthorized("You do not have acces to this keep");
        }
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }












    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newKeep.UserId = userId;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Keep> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
        return Ok(_ks.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Keep> Edit(int id, [FromBody] Keep updatedKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
        updatedKeep.UserId = userId;
        updatedKeep.Id = id;
        return Ok(_ks.Edit(updatedKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }






  }
}