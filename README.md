# _National Parks API_

#### _Custom API built to emulate a real-world application API._

#### By _**Ash Porter (KirbyPaint)**_

## Description

_The purpose of this API is to demonstrate knowledge of building an API, customizing routes for the API, and storing the user's data in the database._  
_Additionally, as part of further exploration, this API showcases versioning._  
_There is a version 1.0 and a version 2.0_

------------------------------

### <u>Table of Contents</u>
* <a href="#setup-and-installation-requirements">Setup/Installation Requirements</a>
  * <a href="#cloning-with-git">Cloning with Git</a>
  * <a href="#configuration-file-setup">Configuration File Setup</a>
  * <a href="#after-everything-is-set-up">After everything is set up</a>
* <a href="#how-to-use-the-program">How To Use The Program</a>
  * <a href="#parks---getting-info">Parks - Getting Info</a>
  * <a href="#sending-info">Sending Info</a>
  * <a href="#editing-existing-info">Editing Existing Info</a>
  * <a href="#removing-info">Removing Info</a>
* <a href="#states---how-to-use">States - How to Use</a>
* <a href="#known-bugs-and-issues">Known Bugs and Issues</a>
* <a href="#support-and-contact-details">Support and Contact Details</a>
* <a href="#technologies-used">Technologies Used</a>

------------------------------

## Setup and Installation Requirements

### Cloning with Git:
* Open Git Bash, or your preferred terminal
* Navigate to your directory for Git projects (not within an existing project)
* Type the following: `git clone https://github.com/KirbyPaint/NationalParksAPI.Solution.git`

This program was built with and requires .NET version 5.0.102. You may install the 64-bit version for Windows [using this link](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer)  

Once the installation of .NET 5 is complete, you may check that the proper version was installed by opening up Git Bash and typing:  

`dotnet --version`  

Then, open your Git Bash terminal and navigate to:

`C:<filepath the files are installed at>\NationalParksAPI.Solution`

where "filepath the files are installed at" will be the location you saved your copy of the project at, or alternatively:  

You may navigate to the folder in the project labeled "NationalParksAPI.Solution".  
Right-click inside the File Explorer window, and in the right-click menu, choose "Open Git Bash Here," or Shift+Right-click and choose "Open Powershell Window Here."  
This will open a Powershell/Git Bash window that is already inside the proper directory.

[Click here for tips on navigating the terminal](https://docs.microsoft.com/en-us/powershell/scripting/samples/managing-current-location?view=powershell-7.1)

### Configuration File Setup

First, you will need to ensure you navigate into the `\NationalParksAPI.Solution\NationalParksAPI` directory. Create a file named `appsettings.json` and paste the following code into the newly created `appsettings.json` file:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=root;pwd=[YOUR PASSWORD];"
  }
}
```

You will then need to make at least TWO changes to the appsettings.json file:  
Where the text says `database=[DATABASE_NAME]`, enter your own database's name, and remove the brackets. If your database was named `my_database` this code will look like `database=my_database`  
Where the text says `pwd=[YOUR PASSWORD]`, enter your own secure password, and remove the brackets. If your password is `SafePassword123` this code will look like `pwd=SafePassword123`  
This ensures that the program will be able to read and write to your own local database.

### After everything is set up

Once you have properly navigated to the project directory (`<your directory>\NationalParksAPI.Solution\NationalParksAPI`), your appsettings.json file has been created, and your local server has been set up, type:

`dotnet restore`

The program should automatically restore all necessary packages.  

Note: This program does come with a "Migrations" folder, but if that folder is missing, please run the following command:

`dotnet ef migrations add Initial`

If the Migrations folder already exists in the project structure, skip this step and enter this next command:

`dotnet ef database update`

to fully apply the database structure.

Once all of the previous steps are applied, enter the following:

`dotnet run`

This will run the web application on a local server. Look for terminal output containing these lines:  

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
```

Once you see this in the terminal, you will be able to use the API on your local network, just as if calling on a real API. The `http://localhost:5000/api/` URL will be constant.  

## How To Use The Program

### Parks - Getting Info
GET ALL: http://localhost:5000/api/parks/all  
GET BY ID: http://localhost:5000/api/parks/parkId  
*  Where `parkId` is that Park's parkId value as integer (starting at 1)

Search Parameters & Examples
SEARCH URL: http://localhost:5000/api/parks/search?name=john

| Parameter   | Type        | Description | Example Query |
| ----------- | ----------- | ----------- | ----------- |
| title       | String      | Title of the park. | http://localhost:5000/api/parks/search?name=john |
| description | String      | Description of the park | http://localhost:5000/api/parks/search?description=john |
| longitude   | Double      | The angular distance of a place east or west of the meridian at Greenwich, England. Enter as many significant digits known as possible - must be within +/-0.5 degrees of accuracy. | http://localhost:5000/api/parks?longitude=44.5&latitude=-119.6 |
| latitude    | Double      | The angular distance of a place north or south of the earth's equator. Enter as many significant digits known as possible - must be within +/-0.5 degrees of accuracy. | See above for example |
| imageUrl    | String      | A URL leading to an image of the park. Optional. | https://exampleurl.jpg |

### Sending Info
POST: http://localhost:5000/api/parks/stateId/add  
*  Where stateId is the numerical value for the State this Park belongs in (starting at 1, default max of 50, one per state)

Structure for posting to Parks:  
*  Note: DO NOT add "missing" stateId or parkId information in the request or it may affect the overall file structure
```JSON
Example:
{
    "name": "text in quotes",
    "description": "text in quotes",
    "longitude": -50.00,
    "latitude": -50.00,
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

### Editing Existing Info
PUT: http://localhost:5000/api/parks/edit/parkId  
  Where `parkId` is that Park's parkId value as integer (starting at 1)
```JSON
Empty Example:
{
    "parkId": ,
    "name": "",
    "description": "",
    "longitude": ,
    "latitude": ,
    "stateId": ,
    "imageUrl": ""
}
```
### Removing Info
DELETE: http://localhost:5000/api/parks/delete/parkId  
*  Where `parkId` is that Park's parkId value as integer (starting at 1)

### States - How to Use

GET ALL: http://localhost:5000/api/states  
GET STATE BY ID: http://localhost:5000/api/states/stateId 
*  Where `stateId` is that State's stateId value as integer (starting at 1, seeded data ends at 50)

Search Parameters & Examples  
http://localhost:5000/api/states?stateName=north  
*  Note: In API version 1.0, this search is an *exact* search - when searching States, write the request URL like so:  
    *  http://localhost:5000/api/states?stateName=north?api-version=2.0 to force the API to search with the upgraded version.  
*  This upgraded version of the search will allow a partial search: I.E., running "north" on states with version 1.0 will not pull up any states in the database, but searching "north" with version 2.0 of the API will pull up both "North Dakota" and "North Carolina".

POST: http://localhost:5000/api/states/add
```JSON
Example
{
    "stateName": "Puerto Rico"
}

Example with custom stateId - recommended best practice is to allow the database to increment its own IDs, but this is technically possible.
{
    "stateId": 60,
    "stateName": "Cascadia"
}
```

<details>
<summary>State IDs and Corresponding States</summary>
<br>
<ol>
  <li>Alabama</li>
  <li>Alaska</li>
  <li>Arizona</li>
  <li>Arkansas</li>
  <li>California</li>
  <li>Colorado</li>
  <li>Connecticut</li>
  <li>Delaware</li>
  <li>Florida</li>
  <li>Georgia</li>
  <li>Hawaii</li>
  <li>Idaho</li>
  <li>Illinois</li>
  <li>Indiana</li>
  <li>Iowa</li>
  <li>Kansas</li>
  <li>Kentucky</li>
  <li>Louisiana</li>
  <li>Maine</li>
  <li>Maryland</li>
  <li>Massachusetts</li>
  <li>Michigan</li>
  <li>Minnesota</li>
  <li>Mississippi</li>
  <li>Missouri</li>
  <li>Montana</li>
  <li>Nebraska</li>
  <li>Nevada</li>
  <li>New Hampshire</li>
  <li>New Jersey</li>
  <li>New Mexico</li>
  <li>New York</li>
  <li>North Carolina</li>
  <li>North Dakota</li>
  <li>Ohio</li>
  <li>Oklahoma</li>
  <li>Oregon</li>
  <li>Pennsylvania</li>
  <li>Rhode Island</li>
  <li>South Carolina</li>
  <li>South Dakota</li>
  <li>Tennessee</li>
  <li>Texas</li>
  <li>Utah</li>
  <li>Vermont</li>
  <li>Virginia</li>
  <li>Washington</li>
  <li>West Virginia</li>
  <li>Wisconsin</li>
  <li>Wyoming</li>
</ol>
</details>

## Known Bugs and Issues

Adding versioning appears to have broken all of the best functions of this API, including:
*  Searching parks within a longitude&latitude range
*  Searching by name and description together (now it is an either/or deal)

## Support and contact details

_Discord: @KirbyPaint#0751_

## Technologies Used

*  C#
*  .NET 5
*  ASP.NET MVC
*  ASP.NET Versioning
*  MySQL and MySQL Workbench
*  Entity Framework Core

### License Information

_GNU Public License_

Copyright (c) 2021 **_KirbyPaint_**