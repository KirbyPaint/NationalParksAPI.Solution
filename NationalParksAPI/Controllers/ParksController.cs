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

    [HttpGet("{parkid}")]
    public async Task<ActionResult<Park>> GetPark(int parkid)
    {
      var park = await _db.Parks.FindAsync(parkid);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string description, double longitude, double latitude)
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
      if (latitude >= -90 && latitude <= 90 && longitude >= -180 && longitude <= 180)
      {
        query = query.Where(entry => entry.Longitude <= (longitude + 0.5) && entry.Longitude >= (longitude - 0.5) && entry.Latitude <= (latitude + 0.5) && entry.Latitude >= (latitude - 0.5));
      }

      return await query.ToListAsync();
    }

    [HttpPost("{stateid}/add")]
    public async Task<ActionResult<Park>> Post(Park park, int stateid)
    {
      var state = _db.States.Include(entry => entry.Parks).FirstOrDefault(entry => entry.StateId == stateid);
      park.StateId = stateid;
      state.Parks.Add(park);
      _db.States.Update(state);
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpPut("edit/{parkid}")]
    public async Task<ActionResult> Put(int parkid, Park park)
    {
      if (parkid != park.ParkId)
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
        if (!ParkExists(parkid))
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

    [HttpDelete("delete/{parkid}")]
    public async Task<ActionResult> DeletePark(int parkid)
    {
      var park = await _db.Parks.FindAsync(parkid);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool ParkExists(int parkid)
    {
      return _db.Parks.Any(e => e.ParkId == parkid);
    }
  }
}