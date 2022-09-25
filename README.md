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

# Api endpoints
## Hamster endpoints
  - [Create Hamster](#create-hamster)
    - [Create Hamster Request](#create-hamster-request)
    - [Create Hamster Response](#create-hamster-response)
  - [Get Hamster](#get-hamsters)
    - [Get Hamsters Request](#get-hamsters-request)
    - [Get Hamsters Response](#get-hamsters-response)
  - [Update Hamster](#update-hamster)
    - [Update Hamster Request](#update-hamster-request)
    - [Update Hamster Response](#update-hamster-response)
  - [Delete Hamster](#delete-hamster)
    - [Delete Hamster Request](#delete-hamster-request)
    - [Delete Hamster Response](#delete-hamster-response)
    
## Auth endpoints
  - [Register](#register)
    - [Register Request](#register-request)
    - [Register Response](#register-response)
  - [Login](#login)
    - [Login Request](#login-request)
    - [Login Response](#login-response)


## Create Hamster

### Create Hamster Request

```js
POST /api/hamsters
```

```json
{
  "name": "john snow",
  "imageUrl": "https://exampleimage.test",
  "age": 2,
  "loves": "football",
  "favoriteFood": "pizza"
}
```

### Create Hamster Response

```js
201 Created
```

## Get Hamsters

### Get Hamsters Request

```js
GET /api/hamsters
```

### Get Hamsters Response

```js
200 Ok
```

```json
[
  {
     "id": 1,
     "name": "john snow",
     "imageUrl": "https://exampleimage.test",
     "age": 3,
     "loves": "football",
     "favoriteFood": "pizza",
     "totalGames": 1337,
     "wins": 1337,
     "defeats": 1337
  },
  {
    "id": 2,
    "name": "ned stark",
    "imageUrl": "https://exampleimage.test",
    "age": 5,
    "loves": "football",
    "favoriteFood": "pizza",
    "totalGames": 1,
    "wins": 0,
    "defeats": 1
  },
]
```

## Update Hamster

### Update Hamster Request

```js
PUT /api/hamsters/{{id}}
```

```json
{
    "name": "jack sparrow",
    "imageUrl": "yourimage.com",
    "age": 2,
    "loves": "rugby",
    "favoriteFood": "tacos",
    "totalGames": 12,
    "wins": 11,
    "defeats": 1
}
```

### Update Hamster Response

```js
204 No Content
```

## Delete Hamster

### Delete Hamster Request
```js
DELETE /api/hamsters/{{id}}
```
### Delete Hamster Response
```js
204 No Content
```

## Register

### Register Request

```js
POST /api/authentication/register
```

```json
{
  "firstName": "john",
  "lastName": "snow",
  "username": "j.snow",
  "password": "password",
  "confirmPassword": "password",
  "email": "example@gmail.com"
}
```

### Register Response

```json
{
  "isSuccessfulRegistration": true,
  "errors": [],
}
```

## Login

### Login Request

```js
POST /api/authentication/login
```
```json
{
  "username": "j.snow",
  "password": "password"
}
```

### Login Response

```json
{
  "token": "your-jwt"
}
```
