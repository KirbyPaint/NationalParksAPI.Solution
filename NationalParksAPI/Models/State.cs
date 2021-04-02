using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NationalParksAPI.Models
{
  public class State
  {
    public State()
    {
      Parks = new HashSet<Park>();
    }
    public int StateId {get; set;}
    [Required]
    [StringLength(40)]
    public string StateName {get; set; }
    public virtual ICollection<Park> Parks{get; set;}
  }
}