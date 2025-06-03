# Project creation

This project takes the [Root-level separation (src/tests)](./project-layout.md#.net-project-layout) approach to project layout.

## Web API Project

This sub-dir contains all the code for the project.

```sh
# Start from the root of the solution
> cd NetWebApi

 

# Crete the Net solution

> dotnet new sln --name NetWebApi.API

# Initiate the NetWebApi.API project
# Create the Net Core API project root folder
> mkdir src
> cd src
# Initiate the src sub-dir with a new webapi project
> dotnet new webapi --name NetWebApi.API

# Create the sub-dir for Controllers 
> mkdir NetWebApi.API/Controllers
> touch NetWebApi.API/Controllers/ProductController.cs

# Create the sub-dir for Models
> mkdir NetWebApi.API/Models/
> touch NetWebApi.API/Models/Product.cs

# The project layout for NetWebApi.API should looks like this
❯ tree .
.
└── NetWebApi.API
    ├── appsettings.Development.json
    ├── appsettings.json
    ├── Controllers
    │   └── ProductController.cs
    ├── Models
    │   └── Product.cs
    ├── NetWebApi.API.csproj
    ├── NetWebApi.API.http
    ├── obj
    │   ├── NetWebApi.API.csproj.nuget.dgspec.json
    │   ├── NetWebApi.API.csproj.nuget.g.props
    │   ├── NetWebApi.API.csproj.nuget.g.targets
    │   ├── project.assets.json
    │   └── project.nuget.cache
    ├── Program.cs
    └── Properties
        └── launchSettings.json
```

## Tests for Web API Project

This sub-dir contains all the tests for the main Web API project.

```sh
# Start from the root of the solution
> cd NetWebApi

# Create the test root for the API project
> mkdir -p tests
> cd tests     

# Initialize the new sub-dir with a xunit project
> dotnet new xunit --name NetWebApi.Tests
> cd NetWebApi.Tests

# Add esssential NuGet packages for testing 
> dotnet add package AutoFixture
> dotnet add package Moq
> dotnet add package coverlet.msbuild
> dotnet add package Microsoft.AspNetCore.Mvc.Testing

# Add a reference to the Web API Project
> dotnet add reference ../../src/NetWebApi.API/NetWebApi.API.csproj
Reference `..\..\src\NetWebApi.API\NetWebApi.API.csproj` added to the project.
```

## Adding sub-projects to the main project


```sh
> # Start from the root of the solution
> cd NetWebApi

# Add all sub-projects
> dotnet sln add $(ls -r **/*.csproj)

Project `tests/NetWebApi.Tests/NetWebApi.Tests.csproj` added to the solution.
Project `src/NetWebApi.API/NetWebApi.API.csproj` added to the solution.
```
