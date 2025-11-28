using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EventRegistration.API.Tests.Infrastructure;

public class EventRegistrationApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Configure in-memory database or test-specific services here
            // This will be implemented by students
        });

        builder.UseEnvironment("Testing");
    }
}
