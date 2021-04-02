## (POSTMAN) ROUTES

### Parks

GET ALL: http://localhost:5000/api/parks
GET BY ID: http://localhost:5000/api/parks/`id`
  Where `id` is the numerical `ParkId` value (starting at 1)

Search Parameters & Examples
  http://localhost:5000/api/parks?`name`=`john`
  http://localhost:5000/api/parks?`description`=`john`
  http://localhost:5000/api/parks?`longitude`=`42.9`&`latitude`=`-122.1`
    Note: on lat/lon, it is a ranged search with some wiggle room, since the data can get incredibly specific (LOTS OF DECIMAL POINTS and no way to tell how many significant figures will be included) ensure that the latitude and longitude are within 1 degree (0.5 +/-) for accurate results