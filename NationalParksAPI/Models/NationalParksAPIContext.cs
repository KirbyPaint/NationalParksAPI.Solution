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

      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Crater Lake", Description = "Crater Lake inspires awe. Native Americans witnessed its formation 7,700 years ago, when a violent eruption triggered the collapse of a tall peak. Scientists marvel at its purity: fed by rain and snow, it’s the deepest lake in the USA and one of the most pristine on earth. Artists, photographers, and sightseers gaze in wonder at its blue water and stunning setting atop the Cascade Mountain Range. https://www.nps.gov/crla/index.htm", Longitude = 42.9446, Latitude = -122.109, StateId = 37, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Crater_Lake_winter_pano2.jpg/1920px-Crater_Lake_winter_pano2.jpg" },
          
          new Park { ParkId = 2, Name = "John Day Fossil Beds", Description = "Colorful rock formations at John Day Fossil Beds preserve a world class record of plant and animal evolution, changing climate, and past ecosystems that span over 40 million years.  Exhibits and a working lab at the Thomas Condon Paleontology and Visitor Center as well as scenic drives and hikes at all three units allow visitors to explore the prehistoric past of Oregon and see science in action. https://www.nps.gov/joda/index.htm", Longitude = 44.5446, Latitude = -119.632, StateId = 37, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Sheep_Rock_near_sunset.jpg/1920px-Sheep_Rock_near_sunset.jpg" },
          
          new Park { ParkId = 3, Name = "Marble Halls of Oregon", Description = "Deep within the Siskiyou Mountains are dark, twisting passages that await your discovery.  Eons of acidic water seeping into marble rock created and decorated the wondrous “Marble Halls of Oregon.” Join a tour, get a taste of what caving is all about, and explore a mountain from the inside and out! https://www.nps.gov/orca/index.htm", Longitude = 42.09555753320818, Latitude = -123.404417146034, StateId = 37, ImageUrl = "https://www.nationalparks.org/sites/default/files/Oregon%20Caves_NPS.jpg" },
          
          new Park { ParkId = 4, Name = "Dry Falls", Description = "At the end of the last Ice Age, about 18,000 to 15,000 years ago, an ice dam in northern Idaho created Glacial Lake Missoula in Montana. The ice dam burst and released flood waters across Washington and down the Columbia River back flooding into Oregon before eventually reaching the Pacific Ocean. Happening perhaps a 100 times. Forever changing the lives and landscape of the Pacific Northwest. https://www.nps.gov/iafl/index.htm", Longitude = 47.6046169023241, Latitude = -119.347401676649, StateId = 47, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/69/Dry_Falls_%28Washington%29.jpg" },
          
          new Park { ParkId = 5, Name = "Lake Roosevelt", Description = "The ancient geologic landscape of the upper Columbia River cradles Lake Roosevelt in walls of stone carved by massive ice age floods. Come explore the shorelines and learn the stories of American Indians, traders and trappers, settlers and dam builders who called this place home. Swim, boat, hike, camp, and fish at this hidden gem in Northeast Washington, created by the Grand Coulee Dam. https://www.nps.gov/laro/index.htm", Longitude = 48.1011, Latitude = -118.2466, StateId = 47, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Gifford_Ferry.JPG/1280px-Gifford_Ferry.JPG" },
          
          new Park { ParkId = 6, Name = "Minidoka National Historic Site", Description = "The Pearl Harbor attack intensified existing hostility towards Japanese Americans. As wartime hysteria mounted, President Roosevelt signed Executive Order 9066 forcing over 120,000 West Coast persons of Japanese ancestry (Nikkei) to leave their homes, jobs, and lives behind, forcing them into one of ten prison camps spread across the nation because of their ethnicity. This is Minidoka's story. https://www.nps.gov/miin/index.htm", Longitude = 42.67904535007292, Latitude = -114.243914786209, StateId = 12, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Minidoka_National_Historic_Site_%28Entrance%29.jpg/1920px-Minidoka_National_Historic_Site_%28Entrance%29.jpg" },
          
          new Park { ParkId = 7, Name = "Mount Rainier", Description = "Ascending to 14,410 feet above sea level, Mount Rainier stands as an icon in the Washington landscape. An active volcano, Mount Rainier is the most glaciated peak in the contiguous U.S.A., spawning five major rivers. Subalpine wildflower meadows ring the icy volcano while ancient forest cloaks Mount Rainier’s lower slopes. Wildlife abounds in the park’s ecosystems. A lifetime of discovery awaits. https://www.nps.gov/mora/index.htm", Longitude = 46.8800, Latitude = -121.7269, StateId = 47, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG/1280px-Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG" }
      );
    }

    public DbSet<Park> Parks { get; set; }
    public DbSet<State> States { get; set; }
  }
}