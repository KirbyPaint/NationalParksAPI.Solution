using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksAPI.Models;

namespace NationalParksAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  [ApiVersion("2.0")]
  public class ParksController : ControllerBase
  {
    private readonly NationalParksAPIContext _db;
    public ParksController(NationalParksAPIContext db)
    {
      _db = db;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Park>>> Get()
    {
      var query = _db.Parks.AsQueryable();
      return await query.ToListAsync();
    }

    [HttpGet("{parkId}")]
    public async Task<ActionResult<Park>> GetPark(int parkId)
    {
      var park = await _db.Parks.FindAsync(parkId);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string description, double longitude, double latitude)
    {
      var query = _db.Parks.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description.Contains(description));
      }
      if ((longitude != 0 && latitude != 0))
      {
        query = query.Where(entry => (entry.Longitude <= (longitude + 0.5) && entry.Longitude >= (longitude - 0.5)) && (entry.Latitude <= (latitude + 0.5) && entry.Latitude >= (latitude - 0.5)));
      }

      return await query.ToListAsync();
    }

    [HttpPost("{stateId}/add")]
    public async Task<ActionResult<Park>> Post(Park park, int stateId)
    {
      var state = _db.States.Include(entry => entry.Parks).FirstOrDefault(entry => entry.StateId == stateId);
      park.StateId = stateId;
      state.Parks.Add(park);
      _db.States.Update(state);
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut("edit/{parkId}")]
    public async Task<ActionResult> Put(int parkId, Park park)
    {
      if (parkId != park.ParkId)
      {
        return NotFound();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(parkId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("delete/{parkId}")]
    public async Task<ActionResult> DeletePark(int parkId)
    {
      var park = await _db.Parks.FindAsync(parkId);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool ParkExists(int parkId)
    {
      return _db.Parks.Any(e => e.ParkId == parkId);
    }

    // Version 2.0
    [HttpGet("all")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<IEnumerable<Park>>> GetV2_0()
    {
      var query = _db.Parks.AsQueryable();
      return await query.ToListAsync();
    }

    [HttpGet("{parkId}")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<Park>> GetParkV2_0(int parkId)
    {
      var park = await _db.Parks.FindAsync(parkId);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    [HttpGet("search")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<IEnumerable<Park>>> GetV2_0(string name, string description, double longitude, double latitude)
    {
      var query = _db.Parks.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description.Contains(description));
      }
      if ((longitude != 0 && latitude != 0))
      {
        query = query.Where(entry => (entry.Longitude <= (longitude + 0.5) && entry.Longitude >= (longitude - 0.5)) && (entry.Latitude <= (latitude + 0.5) && entry.Latitude >= (latitude - 0.5)));
      }

      return await query.ToListAsync();
    }

    [HttpPost("{stateId}/add")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<Park>> PostV2_0(Park park, int stateId)
    {
      var state = _db.States.Include(entry => entry.Parks).FirstOrDefault(entry => entry.StateId == stateId);
      park.StateId = stateId;
      state.Parks.Add(park);
      _db.States.Update(state);
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut("edit/{parkId}")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult> PutV2_0(int parkId, Park park)
    {
      if (parkId != park.ParkId)
      {
        return NotFound();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExistsV2_0(parkId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("delete/{parkId}")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult> DeleteParkV2_0(int parkId)
    {
      var park = await _db.Parks.FindAsync(parkId);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool ParkExistsV2_0(int parkId)
    {
      return _db.Parks.Any(e => e.ParkId == parkId);
    }
  }
}