# **Microservices Architecture and Implementation with .NET 8**  

Welcome to the **Microservices Architecture and Implementation with .NET 8** repository! This project demonstrates how to build a robust microservices-based system using the latest tools, technologies, and best practices in .NET 8.  

## **Key Features**  

### **Technologies and Tools**  
- **Frameworks & Libraries:** *ASP.NET Web API, Minimal APIs, gRPC, YARP API Gateway, MediatR, FluentValidation, MassTransit, Mapster*.  
- **Data Management:** *PostgreSQL, Redis, SQLite, SQL Server, Marten Document DB*.  
- **Architecture Principles:** *Domain-Driven Design (DDD), CQRS, Vertical Slice Architecture, Clean Architecture*.  
- **Communication Patterns:** *RabbitMQ (Event-Driven Communication), gRPC (Sync Inter-Service Communication)*.  
- **Containerization:** *Docker, Docker Compose*.  
- **Design Patterns:** *Dependency Injection, Proxy, Decorator, Cache-aside, Rate Limiting*.  

### **Modules and Features**  

#### **1. Catalog Microservice**  
- Minimal APIs with the latest features of **.NET 8** and **C# 12**.  
- Implements **Vertical Slice Architecture** with feature folders.  
- Marten for PostgreSQL Document DB.  
- Includes validation pipeline using **MediatR** and **FluentValidation**.  
- Logging, global exception handling, and health checks.  
- Dockerized for multi-container support.  

#### **2. Basket Microservice**  
- ASP.NET 8 Web API following REST principles.  
- Redis as a distributed cache for basket data.  
- Implements Proxy, Decorator, and Cache-aside design patterns.  
- Communicates with the Discount service via **gRPC** for final price calculation.  
- Publishes `BasketCheckout` events to RabbitMQ.  

#### **3. Discount Microservice**  
- High-performance inter-service communication with **gRPC**.  
- SQLite database with **Entity Framework Core**.  
- RabbitMQ integration for async communication using **MassTransit**.  

#### **4. Ordering Microservice**  
- Implements **DDD, CQRS, and Clean Architecture**.  
- Domain events and integration events.  
- RabbitMQ and MassTransit for event-driven communication.  
- SQL Server database with auto migrations.  

#### **5. YARP API Gateway**  
- Gateway routing pattern using **YARP Reverse Proxy**.  
- Rate Limiting with FixedWindowLimiter.  
- Supports dynamic routing and transformations.  

#### **6. WebUI ShoppingApp**  
- Razor-based ASP.NET Core Web Application.  
- API consumption through **Refit-generated HttpClientFactory**.  
- Bootstrap 4 for UI components and responsiveness.  

### **Docker Compose**  
- Full orchestration of microservices and backing services.  
- Containerization of all services, including databases, caches, and message brokers.  
- Configurable environment variables for customization.  
