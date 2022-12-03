# Loans-GSC
Proyecto final para el curso de desarrollo Fullstack con Angular y .NET. Dictado por Grupo San Cristóbal y UTN.

## Web App
### [Angular + ASP.NET Core Web API](https://loans-web.azurewebsites.net)
### [MVC Things Controller](https://loans-api.azurewebsites.net/things)

## Descripción
El proyecto consiste en un sistema de préstamos de cosas/objetos, el cual permite registrar y administrar las cosas, su categoría, a quien y cuando las que prestamos.

El sistema puede ser utilizado por cualquier persona que posea un usuario con el rol de "Usuario" o "Admin".
El Usuario tiene permitidas tareas de visualización de la información.
El Admin esta autorizado a realizar tareas de gestión de personas, cosas, categorías, y prestamos.
El registro de usuarios esta solamente habilitado por el Administrador de la Base de datos.
El sistema de autenticación y autorización esta basado en JWT.

El proyecto esta implementado en Azure DevOps, con 2 pipelines para CI/CD, y despliegue en 2 Azure App Service. Uno para la aplicacion Angular y otro para la Web API.
Los datos están almacenados en una base de datos en Azure SQL Server. La aplicación también se puede utilizar usando una conexión local cambiando la variable de entorno ASPNETCORE_ENVIRONMENT a "Development".

## Tecnologías
Las tecnologías que se usaron para la realización de este proyecto son:
- Backend
  - .NET 6 
  - ASP.NET Core MVC
  - ASP.NET CORE Web Api
  - Microsoft SQL Server, Azure SQL Server, Azure SQL Database
  - Entity Framework Core
  - AutoMapper
  - JWT
  - gRPC
  - xUnit
  
- Frontend
  - Angular 14
  - Angular Material

- Herramientas Adicionales
  - Git y GitHub
  - Postman
  - Azure DevOps
  - Azure App Service
  - Azure KeyVault

## [Azure DevOps CI/CD](https://dev.azure.com/francofonzo1/Loans-GSC)

### Project Status

| Pipelines | Build | Release |
|:---------:|:-----:|:-------:|
| Web API | [![Build Status](https://dev.azure.com/francofonzo1/Loans-GSC/_apis/build/status/Loans-API-CI?branchName=main)](https://dev.azure.com/francofonzo1/Loans-GSC/_build/latest?definitionId=15&branchName=main) | [![Deployment](https://vsrm.dev.azure.com/francofonzo1/_apis/public/Release/badge/7f0a0f51-1287-46f1-8670-0144e3ee5d90/4/4)](https://dev.azure.com/francofonzo1/Loans-GSC/_release?_a=deployments&view=mine&definitionId=4) |
| Web UI | [![Build Status](https://dev.azure.com/francofonzo1/Loans-GSC/_apis/build/status/Loans-Angular-CI?branchName=main)](https://dev.azure.com/francofonzo1/Loans-GSC/_build/latest?definitionId=14&branchName=main) | [![Deployment](https://vsrm.dev.azure.com/francofonzo1/_apis/public/Release/badge/7f0a0f51-1287-46f1-8670-0144e3ee5d90/3/3)](https://dev.azure.com/francofonzo1/Loans-GSC/_release?_a=deployments&view=mine&latest=&definitionId=3) |