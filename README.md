## (POSTMAN) ROUTES

### Parks

#### Getting Info
GET ALL: http://localhost:5000/api/parks/all
GET BY ID: http://localhost:5000/api/parks/`ParkId`
  Where `ParkId` is that Park's ParkId value as integer (starting at 1)

Search Parameters & Examples
  http://localhost:5000/api/parks?`name`=`john`
  http://localhost:5000/api/parks?`description`=`john`
  http://localhost:5000/api/parks?`longitude`=`42.9`&`latitude`=`-122.1`
    Note: on lat/lon, it is a ranged search with some wiggle room, since the data can get incredibly specific (LOTS OF DECIMAL POINTS and no way to tell how many significant figures will be included) ensure that the latitude and longitude are within 1 degree (0.5 +/-) for accurate results

#### Sending Info
POST: http://localhost:5000/api/parks/`StateId`/add
  Where `StateId` is the numerical value for the State this Park belongs in (starting at 1, default max of 50, one per state)

Empty Structure for posting to state:
  Note: StateId parameter is omitted due to the value being inserted through the route. DO NOT add this back in or it may affect the overall file structure
```
Example:
{
    "name": "text in quotes",
    "description": "text in quotes",
    "longitude": longitude to as many decimal points as possible, NO SYMBOLS EXCEPT POSSIBLE MINUS SIGN FOR VALUES WEST OF MERIDIAN,
    "latitude": latitude to as many decimal points as possible, NO SYMBOLS EXCEPT POSSIBLE MINUS SIGN FOR VALUES SOUTH OF EQUATOR,
    "imageUrl": "text string of url ending in an image filetype (for displaying, not required)"
}

Empty Example:
{
    "name": "",
    "description": "",
    "longitude": ,
    "latitude": ,
    "imageUrl": ""
}
```

PUT: http://localhost:5000/api/parks/edit/`ParkId`
  Where `ParkId` is that Park's ParkId value as integer (starting at 1)
```
Empty Example:
{
    "parkid": ,
    "name": "",
    "description": "",
    "longitude": ,
    "latitude": ,
    "stateid": ,
    "imageUrl": ""
}
```
#### Removing Info
DELETE: http://localhost:5000/api/parks/delete/`ParkId`
  Where `ParkId` is that Park's ParkId value as integer (starting at 1)

### STATE IDs AND CORRESPONDING STATES

```
1: Alabama
2: Alaska
3: Arizona
4: Arkansas
5: California
6: Colorado
7: Connecticut
8: Delaware
9: Florida
10: Georgia
11: Hawaii
12: Idaho
13: Illinois
14: Indiana
15: Iowa
16: Kansas
17: Kentucky
18: Louisiana
19: Maine
20: Maryland
21: Massachusetts
22: Michigan
23: Minnesota
24: Mississippi
25: Missouri
26: Montana
27: Nebraska
28: Nevada
29: New Hampshire
30: New Jersey
31: New Mexico
32: New York
33: North Carolina
34: North Dakota
35: Ohio
36: Oklahoma
37: Oregon
38: Pennsylvania
39: Rhode Island
40: South Carolina
41: South Dakota
42: Tennessee
43: Texas
44: Utah
45: Vermont
46: Virginia
47: Washington
48: West Virginia
49: Wisconsin
50: Wyoming
```