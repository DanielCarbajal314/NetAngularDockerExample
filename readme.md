# Net-Angular-Docker - Example App
## _Fully containerized Net6 App with Angular Frontend_
[My LinkedIn Profile]

Full-stack developement approach to building a containerized using Net6 and Angular Stack. This app consist in a web page
that allows you to upload images. Once uploaded the images are send to S3 for public URLS, and an asyncronous event is send
to a dispacher to created thumbnails of diferent sizes.

- Backend using Hexagonal Architecture, Net6, EntityFramework, SQL Server, RabbitMq, AWS
- Docker-Compose file for all services (Sql Server, Aws Localstack, RabbitMq)
- Frontend Using Angular 13 with Angular Material
- Containerized Backend and Frontend
- Light Unit test

## TO RUN IT

- It requires Docker Desktop
- Just Run command ```docker-compose up```

## Backend
-   Hexagonal Aquitecure using 
    - Mediator, UnitOfWork, Repository, facade, CQRS
-   WepApi on Net6
-   Unit Testing with Xunit
-   Event Dispacher listening to RabbitMq
-   Local Stack Service with initial Setup
-   Using EFCore as ORM for SQL Server
-   SignalR for messaging Asyncronuous Events

## Frontend
-   Angular 13
-   Angular Material
-   Rxjs Shared Services to handled State Management
-   SignalR integration with Angular

## Missing
-   Integration Testing with Karate
-   E2E testing with TestCafe
-   Unit Testing Angular Components
-   Configure Network Docker Compose Network for running everything Locally, only runs databases, queues and S3
-   Better Observability and exception handling
-   CI/CD with Git Actions

## License

MIT

**Free Software, Hell Yeah!**

   [My LinkedIn Profile]: <https://www.linkedin.com/in/danielcarbajalpucp/>
