# EducationHub  ![status](https://img.shields.io/static/v1?label=status&message=in%20progress&color=yellow)
API Rest with C# .NET 7 and Data Persistence in MongoDB. 

## Structure
```
└── Solution
    ├── EducationHub.API      // Presentation layer
    ├── EducationHub.Business // Business layer
    │   ├── Builders          // Logic for building complex objects step by step
    │   ├── Entities          // MongoDB Entities with their respective business logic
    │   ├── Enums             // Enumerations related to entities
    │   ├── Helpers           // Utility classes to business layer
    │   ├── Interfaces        // Service and repository interfaces
    │   ├── Messages          // Application message enumerations
    │   ├── Models            // Simple classes to use in services 
    │   ├── Services          // Service implementations
    │   └── Validators        // Fluent validations
    │    
    ├── EducationHub.Infrastructure      // Infrastructure layer
    │    ├── Helpers                     // Utility classes to infrastructure layer
    │    ├── Repositories                // Repository implementations
    │    └── EducationHubContextDb.cs    // Class to connect to MongoDb context and database configurations
    │
    └── EducationHub.Shared
         ├── Dtos          // Data transfer objects to API response 
         ├── Environment   // Environment variables settings
         └── Helpers       // Utility classes to share with another layers

```

## API

#### /user
* `POST` /login : User login
* `POST` /signup : Create a new account (user)
* `PUT` /confirmaccount : Confirm account with a token

## Swagger
TODO

## To Do

- [x] Login.
- [x] SinUp
- [x] JWT Token
- [x] Basic Swagger.
- [ ] Courses controller.
- [ ] Certificate controller.
- [ ] Deploy at jenkins 
