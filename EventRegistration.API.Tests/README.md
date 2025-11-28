# Event Registration API - End-to-End Tests

This test project contains comprehensive end-to-end tests for the Event Registration System API. These tests serve as both **acceptance criteria** and **validation** for your implementation.

## Overview

The test suite validates all features described in the `REQUIREMENTS.md` document. Your goal is to implement the API so that all these tests pass.

## Test Structure

```
EventRegistration.API.Tests/
├── Infrastructure/
│   ├── EventRegistrationApiFactory.cs  # Test server configuration
│   └── TestBase.cs                      # Base class with helper methods
├── Models/
│   └── DTOs.cs                          # Request/Response models
└── EndToEndTests/
    ├── EventManagementTests.cs          # Event CRUD operations
    ├── TicketTypeManagementTests.cs     # Ticket type management
    ├── RegistrationManagementTests.cs   # Registration operations
    ├── CapacityManagementTests.cs       # Capacity tracking
    ├── WaitlistManagementTests.cs       # Waitlist functionality
    ├── DiscountCodeTests.cs             # Discount codes
    ├── CancellationAndRefundTests.cs    # Cancellations & refunds
    ├── RegistrationDeadlineTests.cs     # Deadline enforcement
    └── ExportFunctionalityTests.cs      # Export features
```

## Running the Tests

### Run All Tests
```bash
dotnet test
```

### Run Specific Test Class
```bash
dotnet test --filter "FullyQualifiedName~EventManagementTests"
```

### Run Single Test
```bash
dotnet test --filter "FullyQualifiedName~EventManagementTests.CreateEvent_WithValidData_ShouldReturnCreatedEvent"
```

### Run with Verbose Output
```bash
dotnet test --logger "console;verbosity=detailed"
```

## Test Categories

### 1. Event Management Tests (13 tests)
Tests for creating, reading, updating, and deleting events with proper validation.

**Key scenarios:**
- Create event with valid data
- Validate date constraints (end date after start date)
- Validate registration deadline (before event start)
- Filter events by status
- Prevent deletion of events with registrations

### 2. Ticket Type Management Tests (14 tests)
Tests for managing multiple ticket types per event.

**Key scenarios:**
- Create ticket types with different prices and capacities
- Validate capacity constraints
- Ensure ticket type capacities don't exceed event capacity
- Validate available date ranges

### 3. Registration Management Tests (12 tests)
Tests for attendee registration process.

**Key scenarios:**
- Register with valid attendee details
- Validate email format and required fields
- Prevent duplicate email per event
- Only allow registration for published events
- Cancel registrations

### 4. Capacity Management Tests (8 tests)
Tests for tracking and enforcing capacity limits.

**Key scenarios:**
- Track overall event capacity
- Track per-ticket-type capacity
- Prevent registration when capacity is full
- Update capacity after cancellations

### 5. Waitlist Management Tests (11 tests)
Tests for automatic waitlist and promotion features.

**Key scenarios:**
- Add to waitlist when capacity is full
- Automatic promotion in FIFO order
- Waitlist confirmation with expiry
- Remove from waitlist

### 6. Discount Code Tests (18 tests)
Tests for discount code management and application.

**Key scenarios:**
- Create percentage and fixed-amount discounts
- Validate discount codes
- Apply discounts during registration
- Track usage and enforce limits
- Restrict codes to specific ticket types

### 7. Cancellation and Refund Tests (14 tests)
Tests for cancellation policies and refund calculations.

**Key scenarios:**
- Set cancellation policies
- Calculate full, partial, and no refunds based on timing
- Apply cancellation fees
- Handle discounted registrations
- Promote waitlist after cancellation

### 8. Registration Deadline Tests (11 tests)
Tests for enforcing registration deadlines.

**Key scenarios:**
- Allow registration before deadline
- Block registration after deadline
- Handle events without deadlines
- Validate deadline is before event start
- Allow waitlist promotions after deadline

### 9. Export Functionality Tests (13 tests)
Tests for exporting attendee lists in multiple formats.

**Key scenarios:**
- Export to JSON, CSV, and Excel formats
- Filter by status and ticket type
- Sort by name or registration date
- Include all required fields
- Handle special characters in CSV

## Understanding Test Results

### ✅ Green (Passing)
The feature is correctly implemented and meets the requirements.

### ❌ Red (Failing)
The feature is either:
- Not yet implemented
- Incorrectly implemented
- Missing validation rules

### Test Naming Convention
Tests follow the pattern: `MethodName_Scenario_ExpectedResult`

**Example:**
```csharp
CreateEvent_WithEndDateBeforeStartDate_ShouldReturnBadRequest()
```
- **Method:** CreateEvent
- **Scenario:** With end date before start date
- **Expected:** Should return HTTP 400 Bad Request

## Implementation Tips

### 1. Start with the DTOs
Create the request/response models that match those in `Models/DTOs.cs`.

### 2. Implement Features Incrementally
Follow this order:
1. Event Management
2. Ticket Type Management
3. Registration Management
4. Capacity Management
5. Discount Codes
6. Waitlist
7. Cancellation & Refunds
8. Registration Deadlines
9. Export Functionality

### 3. Use GitHub Copilot Effectively
- **Write a test name first**, then let Copilot suggest the implementation
- **Add XML comments** to your models and controllers for better suggestions
- **Use descriptive variable names** to help Copilot understand context
- **Write one method at a time** and verify it works before moving on

### 4. Common Validation Rules
Review the `Validation Rules` and `Business Rules` sections in `REQUIREMENTS.md` for each feature.

### 5. Test Infrastructure Setup
You'll need to configure:
- **In-memory database** (Entity Framework Core InMemory provider)
- **Test database seeding** (if needed)
- **Dependency injection** in `EventRegistrationApiFactory.cs`

Example:
```csharp
protected override void ConfigureWebHost(IWebHostBuilder builder)
{
    builder.ConfigureServices(services =>
    {
        // Remove existing DbContext
        var descriptor = services.SingleOrDefault(
            d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
        if (descriptor != null) services.Remove(descriptor);

        // Add in-memory database
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("TestDb");
        });
    });
}
```

## Debugging Failed Tests

### 1. Read the Error Message
```
Expected response.StatusCode to be HttpStatusCode.OK, but found HttpStatusCode.BadRequest.
```

### 2. Check What Was Sent
Look at the test's Arrange section to see the request data.

### 3. Verify Your Validation Logic
Ensure your API validates inputs according to the requirements.

### 4. Use Breakpoints
Set breakpoints in your API code and run tests in debug mode:
```bash
# In VS Code or Visual Studio
Debug > Debug All Tests
```

### 5. Check the Response Body
Modify tests temporarily to inspect error messages:
```csharp
var errorContent = await response.Content.ReadAsStringAsync();
Console.WriteLine(errorContent);
```

## Success Criteria

Your implementation is complete when:
- ✅ All 114+ tests pass
- ✅ Code follows SOLID principles
- ✅ Proper error handling is implemented
- ✅ API returns appropriate HTTP status codes
- ✅ Business rules are correctly enforced

## Additional Resources

- [ASP.NET Core Testing Documentation](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests)
- [xUnit Documentation](https://xunit.net/)
- [FluentAssertions Documentation](https://fluentassertions.com/)
- [Entity Framework Core InMemory Provider](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/)

## Getting Help

If tests are unclear or you suspect a bug in the tests themselves:
1. Review the `REQUIREMENTS.md` document
2. Check the test implementation for context
3. Ask your instructor for clarification

Good luck! 🚀
