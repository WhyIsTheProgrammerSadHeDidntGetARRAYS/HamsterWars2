# HamsterWars2

School project, to learn about .NET Core Web API's.

In this project, the API is consumed by a Blazor Webassembly Client, and the the main idea is that you will be given 2 images of random hamsters, and you vote for the
cutest one.

The project is following a clean architecture, and also following the repository pattern. 

I am also using Identity for authentication and authorization, so make sure that you register as a user, to be able to perform all CRUD operations.

To try the project out, follow these steps:

1. Clone the project to your local machine
2. Navigate to the API project (HamsterWars2) in Package Manager Console, and create the database by using the command "update-database"
3. Set the Webassembly project (HamsterWars2.Client) AND the API project as startup projects, or run them both individually
