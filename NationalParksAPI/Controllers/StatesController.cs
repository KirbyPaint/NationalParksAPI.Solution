using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksAPI.Models;

namespace NationalParksAPI.Controllers
{
  [Route("api/states")]
  [ApiController]
  [ApiVersion("1.0")]
  [ApiVersion("2.0")]
  public class StatesV1Controller : ControllerBase
  {

    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "Value1 from Version 1", "value2 from Version 1" };
    }

    // GET api/values
    [HttpGet]
    [MapToApiVersion("2.0")]
    public IEnumerable<string> GetV2_0()
    {
      return new string[] { "Value1 from Version 2", "value2 from Version 2" };
    }
  }

  [ApiVersion("2.0")]
  [Route("api/states")]
  public class StatesV2Controller : Controller
  {
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1 from Version 2", "value2 from Version 2" };
    }

    // private readonly NationalParksAPIContext _db;
    // public StatesController(NationalParksAPIContext db)
    // {
    //   _db = db;
    // }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<IEnumerable<State>>> GetState(int id)
    // {
    //   var query = _db.States.Include(entry => entry.Parks).AsQueryable();

    //   if (query == null)
    //   {
    //     return NotFound();
    //   }
    //   query = query.Where(entry => entry.StateId == id);

    //   return await query.ToListAsync();
    // }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<State>>> Get(string statename)
    // {
    //   var query = _db.States.Include(entry => entry.Parks).AsQueryable();

    //   if (statename != null)
    //   {
    //     query = query.Where(e => e.StateName.Contains(statename));
    //   }

    //   return await query.ToListAsync();
    // }

    // [HttpPost("add")]
    // public async Task<ActionResult<State>> Post(State state)
    // {
    //   _db.States.Add(state);
    //   await _db.SaveChangesAsync();

    //   return CreatedAtAction("Post", new { id = state.StateId }, state);
    // }


  }
}