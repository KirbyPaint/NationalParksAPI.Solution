using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

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
      if (longitude != null && latitude != null)
      {
        query = query.Where(entry => entry.Longitude <= (longitude + 0.5) && entry.Longitude >= (longitude - 0.5) && entry.Latitude <= (latitude + 0.5) && entry.Latitude >= (latitude - 0.5));
      }

      return await query.ToListAsync();
    }
  }
}