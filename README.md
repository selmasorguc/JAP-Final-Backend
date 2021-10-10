# JAP Final Task
## Movie Application Back End

Technologies used:
 - ASP .NET Core API

# What is this project about?

This is a .Net Core Web Api application created with three main functionalities: 
1. Getting, creating and updating media that can be of Movie or Tv Show type. Also, searching and filtering media based on ratings so that top rated display can be provided on the front end.
2. Screening creation and buying tickets
3. User log in and registration, as well as impementation of two main user roles (regular user and admin)

The solution is structured in 3 parts:

### CORE
 Consists of:
  - Entities
  - DTOs
  - Services
  - Interfaces
  
### INFRASTRUCTURE
 Consists of:
  - Everything related to the database - Migration and Dataseed
  - Automapper
  - Repositories
  
### WEB
Is the main startup project that consists of
  - Controllers
  - Configuration and Startup
  


# How to run the project?
 - Install Microsoft SQL Server Management Studio and make sure you have the right connection string.
 Change the connection string in the appsettings.Development.json
 
 ![Screenshot_6](https://user-images.githubusercontent.com/89447689/134517032-5b65e267-5ed7-4efd-82c9-a8acf7f28f4a.png)
 
 Data will be seeded when you run the solution. In case you're in VS Code use dotnet watch run or dotnet run CLI command. For Visual Studio, simply run the solution with IIS Express.
 
 # How to make API calls when authentication is needed?
 To use API buying tickets features ​/api​/tickets​/buy, login or registration is necessary to obtain the token.
 Two users are initially seeded
 ADMIN
 username: Selma
 password: Selma1
 
 REGULAR USER - member
 username: Dummy
 password: Dummy1
 
 ![image](https://user-images.githubusercontent.com/89447689/135115965-cac041c4-acad-44a9-aad1-5bd93318daf6.png)

After you make the login API call, copy the token and click on the Authorize button. Type bearer and paste the token. ![image](https://user-images.githubusercontent.com/89447689/135116272-0a166743-9072-4c6d-bafc-eed8ccd3b2d8.png)

![image](https://user-images.githubusercontent.com/89447689/135116200-a651e5cd-0f19-48ef-90c7-bbf7ac0ff736.png)


![image](https://user-images.githubusercontent.com/89447689/135116392-aed98203-367b-4f9e-b323-e063bd1f713c.png)


## API calls

Media (which can be a movie or a tv show)
 - GET /api/media 
 - POST /api/media
 - PUT /api/media
 - GET /api/media/{id}

Ratings
GET /api/ratings/average/{mediaId}
POST /api/ratings/add

Tickets
 - POST ​/api​/tickets​/buy
 - GET /api/tickets/user/{username}

Screening
- GET /api/screening/addresses
- GET /api/screening
- POST /api/screening

Authentication
 - POST /api/users/register
 - POST /api/users/login

## Postman collection to test OK, Bad Request and Unauthorized request

Postman collection with 3 requests testing the Api is in the root folder under the name: Movie App Final Task.postman_collection
