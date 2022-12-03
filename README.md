# Loans-GSC
Proyecto final para el curso de desarrollo Fullstack con Angular y .NET. Dictado por Grupo San Cristóbal y UTN.

## Proyecto
El proyecto consiste en un sistema de préstamos de cosas/objetos, el cual permite registrar y administrar las cosas, su categoría, a quien y cuando las que prestamos.

El sistema puede ser utilizado por cualquier persona que posea un usuario con el rol de "Usuario" o "Admin". 

El Usuario tiene permitidas tareas de visualización de la información. El Admin esta autorizado a realizar tareas de gestión de personas, cosas, categorías, y prestamos.

El registro de usuarios esta solamente habilitado por el Administrador de la Base de datos.

Los datos están almacenados en una base de datos en Azure SQL Server. La aplicación también se puede utilizar usando una conexión local cambiando la variable de entorno a "Development".

## Tecnologias
Las tecnologías que se usaron para la realización de este proyecto son:
- Backend
  - .NET 6 
  - ASP.NET Core MVC
  - ASP.NET CORE Web Api
  - Microsoft SQL Server, Azure SQL Server, Azure SQL Database
  - Azure KeyVault
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
