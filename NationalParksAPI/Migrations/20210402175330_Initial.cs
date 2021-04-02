using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NationalParksAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(type: "varchar(40) CHARACTER SET utf8mb4", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                    table.ForeignKey(
                        name: "FK_Parks_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "StateName" },
                values: new object[,]
                {
                    { 1, "Alabama" },
                    { 28, "Nevada" },
                    { 29, "New Hampshire" },
                    { 30, "New Jersey" },
                    { 31, "New Mexico" },
                    { 32, "New York" },
                    { 33, "North Carolina" },
                    { 34, "North Dakota" },
                    { 35, "Ohio" },
                    { 36, "Oklahoma" },
                    { 37, "Oregon" },
                    { 38, "Pennsylvania" },
                    { 39, "Rhode Island" },
                    { 40, "South Carolina" },
                    { 41, "South Dakota" },
                    { 42, "Tennessee" },
                    { 43, "Texas" },
                    { 44, "Utah" },
                    { 45, "Vermont" },
                    { 46, "Virginia" },
                    { 47, "Washington" },
                    { 48, "West Virginia" },
                    { 27, "Nebraska" },
                    { 26, "Montana" },
                    { 25, "Missouri" },
                    { 24, "Mississippi" },
                    { 2, "Alaska" },
                    { 3, "Arizona" },
                    { 4, "Arkansas" },
                    { 5, "California" },
                    { 6, "Colorado" },
                    { 7, "Connecticut" },
                    { 8, "Delaware" },
                    { 9, "Florida" },
                    { 10, "Georgia" },
                    { 11, "Hawaii" },
                    { 49, "Wisconsin" },
                    { 12, "Idaho" },
                    { 14, "Indiana" },
                    { 15, "Iowa" },
                    { 16, "Kansas" },
                    { 17, "Kentucky" },
                    { 18, "Louisiana" },
                    { 19, "Maine" },
                    { 20, "Maryland" },
                    { 21, "Massachusetts" },
                    { 22, "Michigan" },
                    { 23, "Minnesota" },
                    { 13, "Illinois" },
                    { 50, "Wyoming" }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "ImageUrl", "Latitude", "Longitude", "Name", "StateId" },
                values: new object[,]
                {
                    { 6, "The Pearl Harbor attack intensified existing hostility towards Japanese Americans. As wartime hysteria mounted, President Roosevelt signed Executive Order 9066 forcing over 120,000 West Coast persons of Japanese ancestry (Nikkei) to leave their homes, jobs, and lives behind, forcing them into one of ten prison camps spread across the nation because of their ethnicity. This is Minidoka's story. https://www.nps.gov/miin/index.htm", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Minidoka_National_Historic_Site_%28Entrance%29.jpg/1920px-Minidoka_National_Historic_Site_%28Entrance%29.jpg", -114.243914786209, 42.679045350072919, "Minidoka National Historic Site", 12 },
                    { 1, "Crater Lake inspires awe. Native Americans witnessed its formation 7,700 years ago, when a violent eruption triggered the collapse of a tall peak. Scientists marvel at its purity: fed by rain and snow, it’s the deepest lake in the USA and one of the most pristine on earth. Artists, photographers, and sightseers gaze in wonder at its blue water and stunning setting atop the Cascade Mountain Range. https://www.nps.gov/crla/index.htm", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Crater_Lake_winter_pano2.jpg/1920px-Crater_Lake_winter_pano2.jpg", -122.10899999999999, 42.944600000000001, "Crater Lake", 37 },
                    { 2, "Colorful rock formations at John Day Fossil Beds preserve a world class record of plant and animal evolution, changing climate, and past ecosystems that span over 40 million years.  Exhibits and a working lab at the Thomas Condon Paleontology and Visitor Center as well as scenic drives and hikes at all three units allow visitors to explore the prehistoric past of Oregon and see science in action. https://www.nps.gov/joda/index.htm", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Sheep_Rock_near_sunset.jpg/1920px-Sheep_Rock_near_sunset.jpg", -119.63200000000001, 44.544600000000003, "John Day Fossil Beds", 37 },
                    { 3, "Deep within the Siskiyou Mountains are dark, twisting passages that await your discovery.  Eons of acidic water seeping into marble rock created and decorated the wondrous “Marble Halls of Oregon.” Join a tour, get a taste of what caving is all about, and explore a mountain from the inside and out! https://www.nps.gov/orca/index.htm", "https://www.nationalparks.org/sites/default/files/Oregon%20Caves_NPS.jpg", -123.40441714603401, 42.095557533208179, "Marble Halls of Oregon", 37 },
                    { 4, "At the end of the last Ice Age, about 18,000 to 15,000 years ago, an ice dam in northern Idaho created Glacial Lake Missoula in Montana. The ice dam burst and released flood waters across Washington and down the Columbia River back flooding into Oregon before eventually reaching the Pacific Ocean. Happening perhaps a 100 times. Forever changing the lives and landscape of the Pacific Northwest. https://www.nps.gov/iafl/index.htm", "https://upload.wikimedia.org/wikipedia/commons/6/69/Dry_Falls_%28Washington%29.jpg", -119.347401676649, 47.604616902324103, "Dry Falls", 47 },
                    { 5, "The ancient geologic landscape of the upper Columbia River cradles Lake Roosevelt in walls of stone carved by massive ice age floods. Come explore the shorelines and learn the stories of American Indians, traders and trappers, settlers and dam builders who called this place home. Swim, boat, hike, camp, and fish at this hidden gem in Northeast Washington, created by the Grand Coulee Dam. https://www.nps.gov/laro/index.htm", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Gifford_Ferry.JPG/1280px-Gifford_Ferry.JPG", -118.2466, 48.101100000000002, "Lake Roosevelt", 47 },
                    { 7, "Ascending to 14,410 feet above sea level, Mount Rainier stands as an icon in the Washington landscape. An active volcano, Mount Rainier is the most glaciated peak in the contiguous U.S.A., spawning five major rivers. Subalpine wildflower meadows ring the icy volcano while ancient forest cloaks Mount Rainier’s lower slopes. Wildlife abounds in the park’s ecosystems. A lifetime of discovery awaits. https://www.nps.gov/mora/index.htm", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG/1280px-Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG", -121.7269, 46.880000000000003, "Mount Rainier", 47 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parks_StateId",
                table: "Parks",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
