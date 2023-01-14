using Microsoft.AspNetCore.Mvc.Formatters; // IOutputFormatter, OutputFormatter
using ProofOfConcepts.WebApi.Repositories; // IActorRepository, ActorRepository
using Microsoft.AspNetCore.HttpLogging; // HttpLoggingFields
using ProofOfConcepts.Shared;
using Microsoft.EntityFrameworkCore; //UseMySql method

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SakilaContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Database"), new MySqlServerVersion(new Version(8, 0, 29)));
    options.LogTo(Console.WriteLine, new[]
    {
        Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting
    });
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096; // default is 32k
    options.ResponseBodyLogLimit = 4096; // default is 32k
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
