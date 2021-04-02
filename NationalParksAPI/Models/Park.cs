using System;
using System.ComponentModel.DataAnnotations;

namespace NationalParksAPI.Models
{
  public class Park
  {
    [Required]
    public int ParkId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double Longitude { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public int StateId { get; set; }

    public string ImageUrl { get; set; }


    // Implement if time allows
    // public DateTime OpenDate { get; set; }
    // public DateTime ClosedDate { get; set; }
  }
}