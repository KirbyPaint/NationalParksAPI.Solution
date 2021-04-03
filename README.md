------------------------------
### <u>Table of Contents</u>
* <a href="#about-the-project">About the Project</a>
* <a href="#end-readme">End Readme</a>
------------------------------

## About the Project
TEST README LINKING

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

Structure for posting to Parks:  
  Note: DO NOT add "missing" StateId or ParkId information in the request or it may affect the overall file structure
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

### States

#### Getting Info

GET ALL: http://localhost:5000/api/states
GET STATE BY ID: http://localhost:5000/api/states/`StateId`  
  Where `StateId` is that State's StateId value as integer (starting at 1, seeded data ends at 50)

Search Parameters & Examples  
http://localhost:5000/api/states?`statename`=`north`
  Note: In API version 1.0, this search is an *exact* search - when searching States, write the request URL like so:  
  http://localhost:5000/api/states?`statename`=`north`?api-version=2.0 to force the API to search with the upgraded version.  
  This upgraded version of the search will allow a partial search: I.E., running "north" on states with version 1.0 will not pull up any states in the database, but searching "north" with version 2.0 of the API will pull up both "North Dakota" and "North Carolina".

#### Sending Info

POST: http://localhost:5000/api/states/add
```
Example
{
    "statename": "Puerto Rico"
}

Example with custom StateId - recommended best practice is to allow the database to increment its own IDs, but this is technically possible.
{
    "stateId": 60,
    "stateName": "Cascadia"
}
```

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

## End Readme
TEST README LINKING