using LostAndFound.API.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MongoDB Service
builder.Services.AddSingleton<MongoDBService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Test MongoDB Connection on Startup
try
{
    using (var scope = app.Services.CreateScope())
    {
        var mongoService = scope.ServiceProvider.GetRequiredService<MongoDBService>();
        await mongoService.TestConnection();
    }

    Console.WriteLine("🎉 Application started successfully with MongoDB connection!");
}
catch (Exception ex)
{
    Console.WriteLine($"💥 Application failed to start: {ex.Message}");
    throw;
}

app.Run();