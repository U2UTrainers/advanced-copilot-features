# GitHub Copilot Instructions for EventRegistration

## Overview

This file enables AI coding assistants to generate features aligned with the EventRegistration project's architecture and style conventions. All guidance is based on actual, observed patterns from the existing codebase - not invented practices.

The EventRegistration system is a C#/.NET 9.0 event management application with a clear separation between a Web API backend and Blazor Server frontend. The system handles event creation, ticket sales, registrations, waitlists, discount codes, and data export functionality.

---

## File Category Reference

### web-api-controllers
**Purpose**: RESTful API endpoints for business operations  
**Examples**: `EventsController.cs`, `RegistrationsController.cs`  
**Key Conventions**:
- Inherit from `ControllerBase` with `[ApiController]` attribute
- Route pattern: `[Route("api/{entity}")]`
- Constructor injection of `AppDbContext` only
- Private `MapToResponse()` methods for entity-to-DTO conversion
- Inline validation with early `BadRequest()` returns
- Async methods returning `Task<ActionResult<T>>`

### entity-models
**Purpose**: Database entity classes for Entity Framework Core  
**Examples**: `Event.cs`, `Registration.cs`, `TicketType.cs`  
**Key Conventions**:
- Simple classes with `public int Id { get; set; }` primary key
- String properties initialized with `= string.Empty`
- Collections initialized with `= new List<T>()`
- Navigation properties use `= null!;` for non-nullable references
- Status fields use string type with default values: `= "Draft"`

### dto-models
**Purpose**: Data Transfer Objects for API contracts  
**Examples**: `EventDtos.cs`, `EventModels.cs`  
**Key Conventions**:
- Use `record` types with positional parameters
- Naming: `Create{Entity}Request`, `Update{Entity}Request`, `{Entity}Response`
- Required properties before optional properties in parameter order
- No property setters or mutable state

### blazor-pages
**Purpose**: Interactive UI pages using Blazor Server  
**Examples**: `Index.razor`, `Create.razor`, `Details.razor`  
**Key Conventions**:
- Start with `@page`, `@using`, `@inject`, `@rendermode InteractiveServer`
- Bootstrap CSS classes throughout markup
- Loading states with `spinner-border`
- Empty states with `alert alert-info`
- Bootstrap Icons with `bi bi-{icon-name}` pattern
- Date format: `"MMM dd, yyyy HH:mm"`

### api-services
**Purpose**: HTTP client wrapper for API communication  
**Examples**: `EventRegistrationApiClient.cs`  
**Key Conventions**:
- Single class handling all API operations
- Methods named `Get{Entity}Async()`, `Create{Entity}Async()`
- RESTful URL patterns: `api/events/{eventId}/ticket-types`
- Empty collections return `?? new()` instead of null
- Error handling via `EnsureSuccessStatusCode()`

### data-layer
**Purpose**: Entity Framework Core database context  
**Examples**: `AppDbContext.cs`  
**Key Conventions**:
- Single `AppDbContext` with `DbSet<T>` properties
- All configuration in `OnModelCreating()` using Fluent API
- `OnDelete(DeleteBehavior.Cascade)` for owned data
- `OnDelete(DeleteBehavior.Restrict)` for referenced data
- Decimal properties: `HasColumnType("decimal(18,2)")`

### end-to-end-tests
**Purpose**: Integration tests using TestHost  
**Examples**: `EventManagementTests.cs`, `RegistrationManagementTests.cs`  
**Key Conventions**:
- Inherit from `TestBase` with factory pattern
- Method naming: `{Method}_{Scenario}_{ExpectedResult}`
- AAA pattern with explicit comments
- FluentAssertions syntax for all assertions
- In-memory database for test isolation

---

## Feature Scaffold Guide

### Creating a New Entity Feature

When adding a new entity (e.g., "Speaker"), create these files:

1. **Entity Model**: `EventRegistration.API/Models/Entities/Speaker.cs`
   ```csharp
   public class Speaker
   {
       public int Id { get; set; }
       public string Name { get; set; } = string.Empty;
       public string? Biography { get; set; }
       public int EventId { get; set; }
       public Event Event { get; set; } = null!;
   }
   ```

2. **DTOs**: Add to `EventRegistration.API/Models/DTOs/EventDtos.cs`
   ```csharp
   public record CreateSpeakerRequest(
       string Name,
       string? Biography,
       int EventId
   );
   
   public record SpeakerResponse(
       int Id,
       string Name,
       string? Biography,
       int EventId
   );
   ```

3. **Controller**: `EventRegistration.API/Controllers/SpeakersController.cs`
   ```csharp
   [ApiController]
   [Route("api/events/{eventId}/speakers")]
   public class SpeakersController : ControllerBase
   {
       private readonly AppDbContext _context;
       // ... standard controller pattern
   }
   ```

4. **DbContext Integration**: Add to `AppDbContext.cs`
   ```csharp
   public DbSet<Speaker> Speakers { get; set; }
   
   // In OnModelCreating:
   modelBuilder.Entity<Speaker>(entity =>
   {
       entity.HasKey(s => s.Id);
       entity.Property(s => s.Name).IsRequired().HasMaxLength(200);
   });
   ```

5. **API Client Methods**: Add to `EventRegistrationApiClient.cs`
   ```csharp
   public async Task<List<SpeakerResponse>> GetSpeakersAsync(int eventId)
   {
       return await _httpClient.GetFromJsonAsync<List<SpeakerResponse>>($"api/events/{eventId}/speakers") ?? new();
   }
   ```

6. **Blazor Pages**: `EventRegistration.UI/Components/Pages/Events/SpeakersManager.razor`
   ```razor
   @page "/events/{EventId:int}/speakers"
   @using EventRegistration.UI.Services
   @inject EventRegistrationApiClient ApiClient
   @rendermode InteractiveServer
   ```

7. **Tests**: `EventRegistration.API.Tests/EndToEndTests/SpeakerManagementTests.cs`
   ```csharp
   public class SpeakerManagementTests : TestBase
   {
       public SpeakerManagementTests(EventRegistrationApiFactory factory) : base(factory) { }
       
       [Fact]
       public async Task CreateSpeaker_WithValidData_ShouldReturnCreatedSpeaker()
       {
           // AAA pattern with FluentAssertions
       }
   }
   ```

### File Placement Conventions
- **API Controllers**: `EventRegistration.API/Controllers/`
- **Entities**: `EventRegistration.API/Models/Entities/`
- **DTOs**: `EventRegistration.API/Models/DTOs/`
- **Blazor Pages**: `EventRegistration.UI/Components/Pages/Events/`
- **Services**: `EventRegistration.UI/Services/`
- **Tests**: `EventRegistration.API.Tests/EndToEndTests/`

---

## Integration Rules

### Required Patterns
- **Entity Framework**: All data access must go through `AppDbContext`
- **API Client**: UI components must use `EventRegistrationApiClient` for all API calls
- **Bootstrap UI**: All UI components must use Bootstrap CSS classes and Bootstrap Icons
- **Server-Side Rendering**: Blazor pages must use `@rendermode InteractiveServer`

### Architectural Constraints
- **No Direct Database Access**: UI components never access database directly
- **Single DbContext**: Only one `AppDbContext` class for entire application
- **Record DTOs**: All API contracts must use `record` types, not classes
- **Async Operations**: All database and HTTP operations must be async
- **Error Boundaries**: Controllers handle validation, UI handles display errors

### Data Flow Requirements
1. **UI → API Client → Controller → DbContext → Database**
2. **Database → DbContext → Entity → DTO → API Client → UI**

---

## Example Prompt Usage

**User Request**: "Create a searchable speaker list that lets users filter by expertise"

**Expected AI Response**: Generate these files following project conventions:
- `EventRegistration.API/Models/Entities/Speaker.cs` - Entity with navigation properties
- Add Speaker DTOs to `EventRegistration.API/Models/DTOs/EventDtos.cs` 
- `EventRegistration.API/Controllers/SpeakersController.cs` - RESTful controller with filtering
- Update `AppDbContext.cs` - Add DbSet and Fluent API configuration
- Add methods to `EventRegistrationApiClient.cs` - HTTP client wrapper
- `EventRegistration.UI/Components/Pages/Events/SpeakersManager.razor` - Bootstrap UI with search
- `EventRegistration.API.Tests/EndToEndTests/SpeakerManagementTests.cs` - Integration tests

The AI should follow all naming conventions, architectural patterns, and styling guidelines documented above to ensure consistency with the existing codebase.