# Verydeli

<!-- https://github.com/dwyl/repo-badges todo -->

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
Food delivery application using ASP .NET Core, and Vue.js
	
## Technologies
Project is created with:
* ASP .NET Core 3.1
* Vue.js
	
## Setup

To run VeryDeli server application:

### Requirements:
* .NET Core 3.1 installed on computer
* SQL Server

```
Set connection string to your local database in appsettings.Development.json
```

```
Use update-database command to create your local database instance with applying migrations:
https://docs.microsoft.com/pl-pl/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
```

```
Use seed endpoint to seed basic data for app
```

```
Run app:
https://docs.microsoft.com/pl-pl/dotnet/core/tools/dotnet-run
```

```
Swagger should be open in new instance of your browser
```

![Alt text](images/SwaggerView.jpg?raw=true "Swagger")

To run VeryDeli front: