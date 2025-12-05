# EventRegistration

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?style=flat-square&logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-9.0-512BD4?style=flat-square)](https://docs.microsoft.com/en-us/ef/)
[![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)](LICENSE)

⭐ If you like this project, star it on GitHub — it helps a lot!

[Overview](#overview) • [Features](#features) • [Getting Started](#getting-started) • [Architecture](#architecture) • [Project Structure](#project-structure) • [API Documentation](#api-documentation) • [Testing](#testing)

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

The EventRegistration system provides the following key features:

### Event Management
Create, update, and manage events with detailed information including venues, dates, and capacity.
- **Controller**: [`EventRegistration.API/Controllers/EventsController.cs`](EventRegistration.API/Controllers/EventsController.cs)
- **Entity Model**: [`EventRegistration.API/Models/Entities/Event.cs`](EventRegistration.API/Models/Entities/Event.cs)
- **UI Pages**: [`EventRegistration.UI/Components/Pages/Events/`](EventRegistration.UI/Components/Pages/Events/)

### Ticket Types
Configure multiple ticket types per event with individual pricing and capacity limits.
- **Controller**: [`EventRegistration.API/Controllers/TicketTypesController.cs`](EventRegistration.API/Controllers/TicketTypesController.cs)
- **Entity Model**: [`EventRegistration.API/Models/Entities/TicketType.cs`](EventRegistration.API/Models/Entities/TicketType.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/TicketTypesManager.razor`](EventRegistration.UI/Components/Pages/Events/TicketTypesManager.razor)

### Registration System
Handle attendee registrations with real-time capacity tracking.
- **Controller**: [`EventRegistration.API/Controllers/RegistrationsController.cs`](EventRegistration.API/Controllers/RegistrationsController.cs)
- **Entity Model**: [`EventRegistration.API/Models/Entities/Registration.cs`](EventRegistration.API/Models/Entities/Registration.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/RegistrationsManager.razor`](EventRegistration.UI/Components/Pages/Events/RegistrationsManager.razor)

### Waitlist Management
Automatically manage waitlists when events reach capacity.
- **Controller**: [`EventRegistration.API/Controllers/WaitlistController.cs`](EventRegistration.API/Controllers/WaitlistController.cs)
- **Entity Model**: [`EventRegistration.API/Models/Entities/WaitlistEntry.cs`](EventRegistration.API/Models/Entities/WaitlistEntry.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/WaitlistView.razor`](EventRegistration.UI/Components/Pages/Events/WaitlistView.razor)

### Discount Codes
Create and manage promotional discount codes with usage limits.
- **Controller**: [`EventRegistration.API/Controllers/DiscountCodesController.cs`](EventRegistration.API/Controllers/DiscountCodesController.cs)
- **Entity Model**: [`EventRegistration.API/Models/Entities/DiscountCode.cs`](EventRegistration.API/Models/Entities/DiscountCode.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/DiscountCodesManager.razor`](EventRegistration.UI/Components/Pages/Events/DiscountCodesManager.razor)

### Cancellation Policies
Flexible cancellation and refund policies per event.
- **Controller**: [`EventRegistration.API/Controllers/CancellationPolicyController.cs`](EventRegistration.API/Controllers/CancellationPolicyController.cs)
- **Entity Model**: [`EventRegistration.API/Models/Entities/CancellationPolicy.cs`](EventRegistration.API/Models/Entities/CancellationPolicy.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/CancellationPolicyManager.razor`](EventRegistration.UI/Components/Pages/Events/CancellationPolicyManager.razor)

### Capacity Tracking
Real-time capacity management for events and ticket types.
- **Controller**: [`EventRegistration.API/Controllers/CapacityController.cs`](EventRegistration.API/Controllers/CapacityController.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/CapacityView.razor`](EventRegistration.UI/Components/Pages/Events/CapacityView.razor)

### Data Export
Export registration data to multiple formats (JSON, CSV, Excel) for further analysis.
- **Controller**: [`EventRegistration.API/Controllers/ExportController.cs`](EventRegistration.API/Controllers/ExportController.cs)
- **UI Component**: [`EventRegistration.UI/Components/Pages/Events/ExportView.razor`](EventRegistration.UI/Components/Pages/Events/ExportView.razor)

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
├── EventRegistration.sln                    # Visual Studio solution file
├── EventRegistration.API/                   # Web API Backend
│   ├── Program.cs                           # Application entry point and service configuration
│   ├── appsettings.json                     # Application configuration
│   ├── Controllers/                         # API Controllers (REST endpoints)
│   │   ├── EventsController.cs              # Event CRUD operations
│   │   ├── TicketTypesController.cs         # Ticket type management
│   │   ├── RegistrationsController.cs       # Registration handling
│   │   ├── WaitlistController.cs            # Waitlist management
│   │   ├── DiscountCodesController.cs       # Discount code operations
│   │   ├── CancellationPolicyController.cs  # Cancellation policy setup
│   │   ├── CapacityController.cs            # Capacity tracking endpoints
│   │   └── ExportController.cs              # Data export functionality
│   ├── Data/                                # Entity Framework DbContext
│   │   └── AppDbContext.cs                  # Database context with entity configurations
│   ├── Models/
│   │   ├── Entities/                        # Domain Models
│   │   │   ├── Event.cs                     # Event entity with properties and navigation
│   │   │   ├── TicketType.cs                # Ticket type with pricing and capacity
│   │   │   ├── Registration.cs              # Attendee registration record
│   │   │   ├── WaitlistEntry.cs             # Waitlist entry tracking
│   │   │   ├── DiscountCode.cs              # Promotional discount codes
│   │   │   └── CancellationPolicy.cs        # Refund policy configuration
│   │   └── DTOs/                            # Data Transfer Objects
│   │       └── EventDtos.cs                 # Request/Response models for API
│   └── Migrations/                          # EF Core Database Migrations
├── EventRegistration.UI/                    # Blazor Server Frontend
│   ├── Program.cs                           # UI application entry point
│   ├── appsettings.json                     # UI configuration (API base URL)
│   ├── Components/
│   │   ├── App.razor                        # Root Blazor component
│   │   ├── Routes.razor                     # Routing configuration
│   │   └── Pages/                           # Razor Pages/Components
│   │       ├── Home.razor                   # Landing page
│   │       └── Events/                      # Event management pages
│   │           ├── Index.razor              # Event listing page
│   │           ├── Create.razor             # Create new event form
│   │           ├── Details.razor            # Event details view
│   │           ├── EventOverview.razor      # Event summary component
│   │           ├── TicketTypesManager.razor # Ticket type management
│   │           ├── RegistrationsManager.razor # Registration management
│   │           ├── WaitlistView.razor       # Waitlist display
│   │           ├── DiscountCodesManager.razor # Discount code management
│   │           ├── CancellationPolicyManager.razor # Policy configuration
│   │           ├── CapacityView.razor       # Capacity display
│   │           └── ExportView.razor         # Export options
│   ├── Services/                            # HTTP API Client
│   │   └── EventRegistrationApiClient.cs   # Typed HTTP client for API calls
│   ├── Models/                              # UI-specific models (mirrors API DTOs)
│   └── wwwroot/                             # Static files (CSS, JS, images)
└── EventRegistration.API.Tests/             # Integration Tests
    ├── EndToEndTests/                       # E2E Test Scenarios
    │   ├── EventManagementTests.cs          # Event CRUD tests
    │   ├── TicketTypeManagementTests.cs     # Ticket type tests
    │   ├── RegistrationManagementTests.cs   # Registration flow tests
    │   ├── CapacityManagementTests.cs       # Capacity tracking tests
    │   ├── WaitlistManagementTests.cs       # Waitlist functionality tests
    │   ├── DiscountCodeTests.cs             # Discount code tests
    │   ├── CancellationAndRefundTests.cs    # Cancellation policy tests
    │   ├── RegistrationDeadlineTests.cs     # Deadline enforcement tests
    │   └── ExportFunctionalityTests.cs      # Export feature tests
    ├── Infrastructure/                      # Test Infrastructure
    │   ├── EventRegistrationApiFactory.cs   # WebApplicationFactory setup
    │   └── TestBase.cs                      # Base class with helper methods
    └── Models/                              # Test-specific DTOs
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

## Project Structure

This section provides detailed information about key files and how they work together.

### API Backend (`EventRegistration.API/`)

The API backend is an ASP.NET Core Web API that handles all business logic and data persistence.

#### Entry Point
- [`Program.cs`](EventRegistration.API/Program.cs) - Configures services including:
  - Entity Framework Core with SQL Server (or InMemory for testing)
  - Swagger/OpenAPI documentation
  - Controller routing and authorization

#### Database Layer
- [`Data/AppDbContext.cs`](EventRegistration.API/Data/AppDbContext.cs) - Entity Framework DbContext containing:
  - `DbSet<Event>` - Events table
  - `DbSet<TicketType>` - Ticket types table
  - `DbSet<Registration>` - Registrations table
  - `DbSet<DiscountCode>` - Discount codes table
  - `DbSet<WaitlistEntry>` - Waitlist entries table
  - `DbSet<CancellationPolicy>` - Cancellation policies table
  - Entity configurations with relationships and constraints

#### Entity Models (`Models/Entities/`)
| File | Description |
|------|-------------|
| [`Event.cs`](EventRegistration.API/Models/Entities/Event.cs) | Core event entity with name, description, venue, dates, capacity, and status (Draft, Published, Cancelled, Completed) |
| [`TicketType.cs`](EventRegistration.API/Models/Entities/TicketType.cs) | Ticket type with name, price, capacity, and availability dates |
| [`Registration.cs`](EventRegistration.API/Models/Entities/Registration.cs) | Attendee registration with contact info, ticket type, status (Confirmed, Cancelled, Waitlisted, Refunded), and payment details |
| [`WaitlistEntry.cs`](EventRegistration.API/Models/Entities/WaitlistEntry.cs) | Waitlist entry tracking position, join date, and promotion expiry |
| [`DiscountCode.cs`](EventRegistration.API/Models/Entities/DiscountCode.cs) | Discount code with type (Percentage, FixedAmount), value, usage limits, and validity dates |
| [`CancellationPolicy.cs`](EventRegistration.API/Models/Entities/CancellationPolicy.cs) | Refund policy with full/partial refund deadlines and cancellation fees |

#### DTOs (`Models/DTOs/`)
- [`EventDtos.cs`](EventRegistration.API/Models/DTOs/EventDtos.cs) - Contains all request/response records:
  - `CreateEventRequest` / `UpdateEventRequest` / `EventResponse`
  - `CreateTicketTypeRequest` / `UpdateTicketTypeRequest` / `TicketTypeResponse`
  - `CreateRegistrationRequest` / `RegistrationResponse`
  - `CapacityResponse` / `TicketTypeCapacity`
  - `WaitlistEntryResponse`
  - `CreateDiscountCodeRequest` / `DiscountCodeResponse` / `ValidateDiscountCodeRequest`
  - `CreateCancellationPolicyRequest` / `CancellationPolicyResponse`
  - `CancelRegistrationResponse` / `AttendeeExportRecord`

### UI Frontend (`EventRegistration.UI/`)

The UI is a Blazor Server application that provides an interactive web interface.

#### Entry Point
- [`Program.cs`](EventRegistration.UI/Program.cs) - Configures:
  - Razor components with interactive server mode
  - `HttpClient` for API communication with base URL from configuration

#### API Client Service
- [`Services/EventRegistrationApiClient.cs`](EventRegistration.UI/Services/EventRegistrationApiClient.cs) - Typed HTTP client with methods for:
  - Events: `GetEventsAsync()`, `GetEventAsync()`, `CreateEventAsync()`, `DeleteEventAsync()`
  - Ticket Types: `GetTicketTypesAsync()`, `CreateTicketTypeAsync()`, `DeleteTicketTypeAsync()`
  - Registrations: `GetRegistrationsAsync()`, `CreateRegistrationAsync()`, `CancelRegistrationAsync()`
  - Capacity: `GetCapacityAsync()`
  - Waitlist: `GetWaitlistAsync()`, `RemoveFromWaitlistAsync()`
  - Discount Codes: `GetDiscountCodesAsync()`, `CreateDiscountCodeAsync()`, `DeleteDiscountCodeAsync()`
  - Cancellation Policy: `GetCancellationPolicyAsync()`, `CreateCancellationPolicyAsync()`, `UpdateCancellationPolicyAsync()`
  - Export: `ExportAttendeesAsync()`

#### UI Pages (`Components/Pages/Events/`)
| File | Description |
|------|-------------|
| [`Index.razor`](EventRegistration.UI/Components/Pages/Events/Index.razor) | Lists all events with cards showing name, status, dates, and capacity |
| [`Create.razor`](EventRegistration.UI/Components/Pages/Events/Create.razor) | Form for creating new events |
| [`Details.razor`](EventRegistration.UI/Components/Pages/Events/Details.razor) | Event details with tabs for different management views |
| [`EventOverview.razor`](EventRegistration.UI/Components/Pages/Events/EventOverview.razor) | Summary component showing event information |
| [`TicketTypesManager.razor`](EventRegistration.UI/Components/Pages/Events/TicketTypesManager.razor) | Create and manage ticket types |
| [`RegistrationsManager.razor`](EventRegistration.UI/Components/Pages/Events/RegistrationsManager.razor) | View and manage attendee registrations |
| [`WaitlistView.razor`](EventRegistration.UI/Components/Pages/Events/WaitlistView.razor) | Display and manage waitlist entries |
| [`DiscountCodesManager.razor`](EventRegistration.UI/Components/Pages/Events/DiscountCodesManager.razor) | Create and manage discount codes |
| [`CancellationPolicyManager.razor`](EventRegistration.UI/Components/Pages/Events/CancellationPolicyManager.razor) | Configure cancellation and refund policies |
| [`CapacityView.razor`](EventRegistration.UI/Components/Pages/Events/CapacityView.razor) | Real-time capacity tracking display |
| [`ExportView.razor`](EventRegistration.UI/Components/Pages/Events/ExportView.razor) | Export registrations in various formats |

### Test Project (`EventRegistration.API.Tests/`)

Comprehensive integration tests using xUnit and WebApplicationFactory.

#### Test Infrastructure
- [`Infrastructure/EventRegistrationApiFactory.cs`](EventRegistration.API.Tests/Infrastructure/EventRegistrationApiFactory.cs) - Custom WebApplicationFactory that:
  - Configures in-memory database for test isolation
  - Provides `HttpClient` for making API requests
- [`Infrastructure/TestBase.cs`](EventRegistration.API.Tests/Infrastructure/TestBase.cs) - Base class with:
  - Helper methods for creating test data
  - Common setup and teardown logic

#### Test Suites (`EndToEndTests/`)
| File | Tests |
|------|-------|
| [`EventManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/EventManagementTests.cs) | Event CRUD, validation, status filtering |
| [`TicketTypeManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/TicketTypeManagementTests.cs) | Ticket type CRUD, capacity constraints |
| [`RegistrationManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/RegistrationManagementTests.cs) | Registration flow, email validation, duplicates |
| [`CapacityManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/CapacityManagementTests.cs) | Capacity tracking, overflow prevention |
| [`WaitlistManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/WaitlistManagementTests.cs) | Waitlist add/remove, FIFO promotion |
| [`DiscountCodeTests.cs`](EventRegistration.API.Tests/EndToEndTests/DiscountCodeTests.cs) | Code validation, usage limits, expiration |
| [`CancellationAndRefundTests.cs`](EventRegistration.API.Tests/EndToEndTests/CancellationAndRefundTests.cs) | Refund calculations, deadline enforcement |
| [`RegistrationDeadlineTests.cs`](EventRegistration.API.Tests/EndToEndTests/RegistrationDeadlineTests.cs) | Deadline enforcement, exceptions |
| [`ExportFunctionalityTests.cs`](EventRegistration.API.Tests/EndToEndTests/ExportFunctionalityTests.cs) | JSON, CSV, Excel export validation |

## API Documentation

The API provides comprehensive endpoints for all event management operations. All endpoints are defined in the [`EventRegistration.API/Controllers/`](EventRegistration.API/Controllers/) directory.

### Events API ([`EventsController.cs`](EventRegistration.API/Controllers/EventsController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events` | List all events (optional `?status=` filter) |
| `POST` | `/api/events` | Create a new event |
| `GET` | `/api/events/{id}` | Get event details by ID |
| `PUT` | `/api/events/{id}` | Update event information |
| `DELETE` | `/api/events/{id}` | Delete an event (fails if registrations exist) |

### Ticket Types API ([`TicketTypesController.cs`](EventRegistration.API/Controllers/TicketTypesController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/ticket-types` | List ticket types for an event |
| `POST` | `/api/events/{eventId}/ticket-types` | Create a new ticket type |
| `GET` | `/api/events/{eventId}/ticket-types/{id}` | Get ticket type details |
| `PUT` | `/api/events/{eventId}/ticket-types/{id}` | Update ticket type |
| `DELETE` | `/api/events/{eventId}/ticket-types/{id}` | Delete ticket type |

### Registrations API ([`RegistrationsController.cs`](EventRegistration.API/Controllers/RegistrationsController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/registrations` | List registrations for an event |
| `POST` | `/api/events/{eventId}/registrations` | Register an attendee |
| `GET` | `/api/registrations/{id}` | Get registration details |
| `DELETE` | `/api/registrations/{id}` | Cancel a registration |

### Waitlist API ([`WaitlistController.cs`](EventRegistration.API/Controllers/WaitlistController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/waitlist` | List waitlist entries |
| `POST` | `/api/events/{eventId}/waitlist` | Add to waitlist |
| `DELETE` | `/api/waitlist/{id}` | Remove from waitlist |
| `POST` | `/api/waitlist/{id}/confirm` | Confirm waitlist promotion |

### Discount Codes API ([`DiscountCodesController.cs`](EventRegistration.API/Controllers/DiscountCodesController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/discount-codes` | List discount codes |
| `POST` | `/api/events/{eventId}/discount-codes` | Create a discount code |
| `GET` | `/api/discount-codes/{id}` | Get discount code details |
| `PUT` | `/api/discount-codes/{id}` | Update discount code |
| `DELETE` | `/api/discount-codes/{id}` | Delete discount code |
| `POST` | `/api/events/{eventId}/discount-codes/validate` | Validate a discount code |

### Cancellation Policy API ([`CancellationPolicyController.cs`](EventRegistration.API/Controllers/CancellationPolicyController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/cancellation-policy` | Get cancellation policy |
| `POST` | `/api/events/{eventId}/cancellation-policy` | Create cancellation policy |
| `PUT` | `/api/events/{eventId}/cancellation-policy` | Update cancellation policy |

### Capacity API ([`CapacityController.cs`](EventRegistration.API/Controllers/CapacityController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/capacity` | Get capacity information |

### Export API ([`ExportController.cs`](EventRegistration.API/Controllers/ExportController.cs))

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/events/{eventId}/export/json` | Export registrations as JSON |
| `GET` | `/api/events/{eventId}/export/csv` | Export registrations as CSV |
| `GET` | `/api/events/{eventId}/export/excel` | Export registrations as Excel |

Export endpoints support optional query parameters:
- `?status=` - Filter by registration status
- `?ticketTypeId=` - Filter by ticket type
- `?sortBy=` - Sort by `name` or `registrationDate`

Access the interactive API documentation at `https://localhost:7231/swagger` when running the API project.

## Testing

The project includes comprehensive integration tests in [`EventRegistration.API.Tests/`](EventRegistration.API.Tests/). For detailed test documentation, see [`EventRegistration.API.Tests/README.md`](EventRegistration.API.Tests/README.md).

### Running Tests

```bash
# Run all tests
dotnet test

# Run with verbose output
dotnet test --logger "console;verbosity=detailed"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test --filter "FullyQualifiedName~EventManagementTests"

# Run single test
dotnet test --filter "FullyQualifiedName~EventManagementTests.CreateEvent_WithValidData_ShouldReturnCreatedEvent"
```

### Test Categories

| Test File | Coverage |
|-----------|----------|
| [`EventManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/EventManagementTests.cs) | Event creation, updates, status transitions, deletion |
| [`TicketTypeManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/TicketTypeManagementTests.cs) | Ticket type CRUD, capacity validation |
| [`RegistrationManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/RegistrationManagementTests.cs) | Registration flow, email validation, duplicates |
| [`CapacityManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/CapacityManagementTests.cs) | Capacity tracking, overflow prevention |
| [`WaitlistManagementTests.cs`](EventRegistration.API.Tests/EndToEndTests/WaitlistManagementTests.cs) | Waitlist FIFO, promotion, confirmation |
| [`DiscountCodeTests.cs`](EventRegistration.API.Tests/EndToEndTests/DiscountCodeTests.cs) | Code validation, usage limits, expiration |
| [`CancellationAndRefundTests.cs`](EventRegistration.API.Tests/EndToEndTests/CancellationAndRefundTests.cs) | Refund calculations, deadline enforcement |
| [`RegistrationDeadlineTests.cs`](EventRegistration.API.Tests/EndToEndTests/RegistrationDeadlineTests.cs) | Deadline enforcement, exceptions |
| [`ExportFunctionalityTests.cs`](EventRegistration.API.Tests/EndToEndTests/ExportFunctionalityTests.cs) | JSON, CSV, Excel export validation |

### Test Infrastructure

The testing framework uses:
- **In-Memory Database**: Isolated test data using EF Core InMemory provider (configured in [`EventRegistrationApiFactory.cs`](EventRegistration.API.Tests/Infrastructure/EventRegistrationApiFactory.cs))
- **WebApplicationFactory**: Full application testing with test server
- **FluentAssertions**: Expressive assertion syntax
- **Bogus**: Test data generation for realistic scenarios
- **TestBase**: Common helper methods in [`TestBase.cs`](EventRegistration.API.Tests/Infrastructure/TestBase.cs)

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