# Xcorgis-Backend

This repository contain backend Asp .NET core based web api which will consume by separate frontend project(Jquery/Blazor) with use of CORS.

This Backend project devided in three subproject/.net class library projects/layers:
1.XCorgis.API  --> this is api/http controller layer for which will expose the data to front end client application using cors.
2.XCorgis.Domain --> this layer is domain/entities layer which contains entities related to business logic and interfaces for seperation of concern.
3.Xcorgis.DataAccess --> this layer contains logic for repository/unit of work design pattern and database migration schema.

# How to run project??

1. Download project/clone a repo in your local system.
2. Update the servername in appsetting.json, connectionstring name in both startup.cs and appsetting.json in order to connect backend sql server instance.
3. Delete the migration folder from Xcorgis.DataAccess project and run the new migration using entity framework core migration query(Add-Migration/Update Database)
4. After succesful migration, run the api layer project and test the apis in postman.

Currently working on improving backend and building front end of this project from scratch.
 
# More changes coming soon:)
