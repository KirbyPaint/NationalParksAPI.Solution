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
  public class StatesController : ControllerBase
  {
    private readonly NationalParksAPIContext _db;
    public StatesController(NationalParksAPIContext db)
    {
      _db = db;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<State>>> GetState(int id)
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();

      if (query == null)
      {
        return NotFound();
      }
      query = query.Where(entry => entry.StateId == id);

      return await query.ToListAsync();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<State>>> Get(string stateName)
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();

      if (stateName != null)
      {
        query = query.Where(e => e.StateName == stateName);
      }

      return await query.ToListAsync();
    }

    [HttpPost("add")]
    public async Task<ActionResult<State>> Post(State state)
    {
      _db.States.Add(state);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = state.StateId }, state);
    }

    // Version 2 API
    [HttpGet("{id}")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<IEnumerable<State>>> GetStateV2_0(int id)
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();

      if (query == null)
      {
        return NotFound();
      }
      query = query.Where(entry => entry.StateId == id);

      return await query.ToListAsync();
    }

    [HttpGet]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<IEnumerable<State>>> GetV2_0(string stateName)
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();

      if (stateName != null)
      {
        query = query.Where(e => e.StateName.Contains(stateName));
      }

      return await query.ToListAsync();
    }

    [HttpPost("add")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<State>> PostV2_0(State state)
    {
      _db.States.Add(state);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = state.StateId }, state);
    }
  }
}