using System;
using System.ComponentModel.DataAnnotations;

namespace NationalParksAPI.Models
{
  public class Park
  {
    public int ParkId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public int StateId { get; set; }
    
    [Required]
    public int Zip { get; set; }

    // Implement if time allows
    // public DateTime OpenDate { get; set; }
    // public DateTime ClosedDate { get; set; }

    public string ImageUrl { get; set; }
  }
}