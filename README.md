# EventRegistration

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?style=flat-square&logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-9.0-512BD4?style=flat-square)](https://docs.microsoft.com/en-us/ef/)
[![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)](LICENSE)

⭐ If you like this project, star it on GitHub — it helps a lot!

[Overview](#overview) • [Features](#features) • [Getting Started](#getting-started) • [Architecture](#architecture) • [API Documentation](#api-documentation) • [Testing](#testing)

A comprehensive event management system built with .NET 9.0, featuring a Web API backend and Blazor Server frontend. The application handles event creation, ticket sales, registrations, waitlists, discount codes, and data export functionality.

## Overview

EventRegistration is a modern event management platform that provides a complete solution for organizing events, managing registrations, and handling ticket sales. The system is built with a clean architecture approach, separating concerns between the API layer and the user interface.

The application demonstrates best practices in:
- **Clean Architecture**: Clear separation between API, UI, and data layers
- **Entity Framework Core**: Code-first database approach with migrations
- **RESTful API Design**: Well-structured HTTP endpoints following REST conventions
- **Blazor Server**: Interactive server-side rendering for rich web experiences
- **Comprehensive Testing**: End-to-end integration tests with in-memory database

## Features

- **Event Management**: Create, update, and manage events with detailed information including venues, dates, and capacity
- **Ticket Types**: Configure multiple ticket types per event with individual pricing and capacity limits
- **Registration System**: Handle attendee registrations with real-time capacity tracking
- **Waitlist Management**: Automatically manage waitlists when events reach capacity
- **Discount Codes**: Create and manage promotional discount codes with usage limits
- **Cancellation Policies**: Flexible cancellation and refund policies per event
- **Data Export**: Export registration data to Excel format for further analysis
- **Real-time UI**: Interactive Blazor Server interface with real-time updates
- **Comprehensive API**: RESTful API with OpenAPI/Swagger documentation

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) or SQL Server instance
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd EventRegistration
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection (optional)**
   
   The application uses SQL Server LocalDB by default. To use a different connection string, update `appsettings.json` in the API project:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "your-connection-string-here"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   cd EventRegistration.API
   dotnet ef database update
   ```

### Running the Application

You can run both the API and UI projects simultaneously:

**Option 1: Using Visual Studio**
- Set multiple startup projects (EventRegistration.API and EventRegistration.UI)
- Press F5 to start debugging

**Option 2: Using Command Line**

Terminal 1 (API):
```bash
cd EventRegistration.API
dotnet run
```

Terminal 2 (UI):
```bash
cd EventRegistration.UI
dotnet run
```

The API will be available at `https://localhost:7231` and the UI at `https://localhost:7232`.

## Architecture

The solution follows a clean architecture pattern with clear separation of concerns:

```
EventRegistration/
├── EventRegistration.API/              # Web API Backend
│   ├── Controllers/                    # API Controllers
│   ├── Data/                          # Entity Framework DbContext
│   ├── Models/
│   │   ├── Entities/                  # Domain Models
│   │   └── DTOs/                      # Data Transfer Objects
│   └── Migrations/                    # EF Core Migrations
├── EventRegistration.UI/               # Blazor Server Frontend
│   ├── Components/
│   │   └── Pages/                     # Razor Pages/Components
│   └── Services/                      # HTTP API Client
└── EventRegistration.API.Tests/        # Integration Tests
    ├── EndToEndTests/                 # E2E Test Scenarios
    └── Infrastructure/                # Test Infrastructure
```

### Technology Stack

- **Backend**: ASP.NET Core 9.0 Web API
- **Frontend**: Blazor Server 9.0
- **Database**: Entity Framework Core 9.0 with SQL Server
- **Testing**: xUnit, FluentAssertions, ASP.NET Core TestHost
- **Documentation**: Swagger/OpenAPI with Scalar UI
- **Data Export**: ClosedXML for Excel generation

### Key Design Patterns

- **Repository Pattern**: Implemented through Entity Framework DbContext
- **DTO Pattern**: Separate models for API contracts and internal entities
- **Factory Pattern**: Test infrastructure using WebApplicationFactory
- **Clean Architecture**: Clear boundaries between layers

## API Documentation

The API provides comprehensive endpoints for all event management operations:

### Core Endpoints

- `GET /api/events` - List all events with optional status filtering
- `POST /api/events` - Create a new event
- `GET /api/events/{id}` - Get event details
- `PUT /api/events/{id}` - Update event information
- `DELETE /api/events/{id}` - Delete an event

### Registration Management

- `GET /api/events/{eventId}/registrations` - List registrations for an event
- `POST /api/events/{eventId}/registrations` - Register for an event
- `DELETE /api/registrations/{id}` - Cancel a registration

### Additional Features

- **Ticket Types**: `/api/events/{eventId}/ticket-types`
- **Waitlist**: `/api/events/{eventId}/waitlist`
- **Discount Codes**: `/api/events/{eventId}/discount-codes`
- **Capacity Management**: `/api/events/{eventId}/capacity`
- **Data Export**: `/api/events/{eventId}/export`

Access the interactive API documentation at `https://localhost:7231/swagger` when running the API project.

## Testing

The project includes comprehensive integration tests covering all major functionality:

### Running Tests

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test --filter "EventManagementTests"
```

### Test Categories

- **Event Management**: Creation, updates, status transitions
- **Registration Flow**: Normal registration, capacity limits, waitlists
- **Ticket Types**: Multiple ticket types, individual capacity management
- **Discount Codes**: Code validation, usage limits, expiration
- **Cancellation**: Refund policies, deadline enforcement
- **Data Export**: Excel generation and content validation

### Test Infrastructure

The testing framework uses:
- **In-Memory Database**: Isolated test data using EF Core InMemory provider
- **WebApplicationFactory**: Full application testing with test server
- **FluentAssertions**: Expressive assertion syntax
- **Bogus**: Test data generation for realistic scenarios

## Contributing

We welcome contributions! Please see our contributing guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines

- Follow C# coding conventions and use consistent formatting
- Add unit/integration tests for new functionality
- Update documentation for API changes
- Ensure all existing tests pass

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Troubleshooting

### Common Issues

**Database Connection Issues**
```bash
# Reset and recreate the database
dotnet ef database drop --force
dotnet ef database update
```

**Port Conflicts**
- Check `launchSettings.json` in both projects for port configurations
- Default ports: API (7231), UI (7232)

**Missing Dependencies**
```bash
# Clean and restore all projects
dotnet clean
dotnet restore
```

For more detailed troubleshooting, check the application logs and ensure all prerequisites are properly installed.