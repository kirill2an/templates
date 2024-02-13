using backend.infrastructure;
using backend.app;
using backend.infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

string? connString = builder.Configuration.GetConnectionString("Default Connection")
    ?? throw new ArgumentNullException("Connection string is null");
string? tokenKey = builder.Configuration.GetValue<string>("TokenKey")
    ?? throw new ArgumentNullException("Token key is null");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(connString);
builder.Services.AddApplication(tokenKey);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationContext>();
    await context.Database.EnsureCreatedAsync();

    await Seed.SeedUsers(context);
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("_myAllowSpecificOrigins");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapFallbackToController("Index", "Fallback");
app.MapControllers();

app.Run();
