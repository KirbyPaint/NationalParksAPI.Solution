using Microsoft.EntityFrameworkCore;
using System;

namespace NationalParksAPI.Models
{
  public class NationalParksAPIContext : DbContext
  {
    public NationalParksAPIContext(DbContextOptions<NationalParksAPIContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<State>()
        .HasData(
          new State { StateId = 1, StateName = "Alabama" },
          new State { StateId = 2, StateName = "Alaska" },
          new State { StateId = 3, StateName = "Arizona" },
          new State { StateId = 4, StateName = "Arkansas" },
          new State { StateId = 5, StateName = "California" },
          new State { StateId = 6, StateName = "Colorado" },
          new State { StateId = 7, StateName = "Connecticut" },
          new State { StateId = 8, StateName = "Delaware" },
          new State { StateId = 9, StateName = "Florida" },
          new State { StateId = 10, StateName = "Georgia" },
          new State { StateId = 11, StateName = "Hawaii" },
          new State { StateId = 12, StateName = "Idaho" },
          new State { StateId = 13, StateName = "Illinois" },
          new State { StateId = 14, StateName = "Indiana" },
          new State { StateId = 15, StateName = "Iowa" },
          new State { StateId = 16, StateName = "Kansas" },
          new State { StateId = 17, StateName = "Kentucky" },
          new State { StateId = 18, StateName = "Louisiana" },
          new State { StateId = 19, StateName = "Maine" },
          new State { StateId = 20, StateName = "Maryland" },
          new State { StateId = 21, StateName = "Massachusetts" },
          new State { StateId = 22, StateName = "Michigan" },
          new State { StateId = 23, StateName = "Minnesota" },
          new State { StateId = 24, StateName = "Mississippi" },
          new State { StateId = 25, StateName = "Missouri" },
          new State { StateId = 26, StateName = "Montana" },
          new State { StateId = 27, StateName = "Nebraska" },
          new State { StateId = 28, StateName = "Nevada" },
          new State { StateId = 29, StateName = "New Hampshire" },
          new State { StateId = 30, StateName = "New Jersey" },
          new State { StateId = 31, StateName = "New Mexico" },
          new State { StateId = 32, StateName = "New York" },
          new State { StateId = 33, StateName = "North Carolina" },
          new State { StateId = 34, StateName = "North Dakota" },
          new State { StateId = 35, StateName = "Ohio" },
          new State { StateId = 36, StateName = "Oklahoma" },
          new State { StateId = 37, StateName = "Oregon" },
          new State { StateId = 38, StateName = "Pennsylvania" },
          new State { StateId = 39, StateName = "Rhode Island" },
          new State { StateId = 40, StateName = "South Carolina" },
          new State { StateId = 41, StateName = "South Dakota" },
          new State { StateId = 42, StateName = "Tennessee" },
          new State { StateId = 43, StateName = "Texas" },
          new State { StateId = 44, StateName = "Utah" },
          new State { StateId = 45, StateName = "Vermont" },
          new State { StateId = 46, StateName = "Virginia" },
          new State { StateId = 47, StateName = "Washington" },
          new State { StateId = 48, StateName = "West Virginia" },
          new State { StateId = 49, StateName = "Wisconsin" },
          new State { StateId = 50, StateName = "Wyoming" }
        );

      // The following is 30 seeded messages
      builder.Entity<Park>()
        .HasData(

      );
    }

    public DbSet<Park> Parks { get; set; }
    public DbSet<State> States { get; set; }
  }
}