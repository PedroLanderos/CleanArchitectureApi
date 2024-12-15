This project is a User Management API built with .NET 8, following the principles of Clean Architecture. The architecture promotes separation of concerns by dividing the project into distinct layers: Domain, Application, Infrastructure, and Presentation. This structure ensures scalability, maintainability, and testability of the application.

Layers Overview
Domain
The core of the application. It contains:

Entities: Define the core business objects and their behavior.

Interfaces: Abstractions for business logic services and repositories.

This layer is completely independent of external dependencies.

Application
Contains the business logic and application use cases. This layer orchestrates the application flow.

DTOs: Data Transfer Objects used for transferring data between layers.
Mappers: Utilities to map between entities and DTOs.
Responses: Standardized response objects for API endpoints.
Interfaces: Contracts defining dependencies such as repositories.
Infrastructure
Implements the contracts defined in the Domain and Application layers.

Data: Manages database configurations and migrations.
Repositories: Implements repository patterns for data access.
DependencyInjection: Configures DI containers for the application.
Presentation
The entry point for users via the API. Exposes endpoints for interaction.

Controllers: Define API endpoints and handle HTTP requests/responses.
Configuration: Handles app settings, middlewares, and Swagger documentation.