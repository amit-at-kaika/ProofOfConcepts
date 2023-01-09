using Microsoft.AspNetCore.Mvc.Formatters; // IOutputFormatter, OutputFormatter
using ProofOfConcepts.WebApi.Repositories; // IActorRepository, ActorRepository
using ProofOfConcepts.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSakilaContext();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IActorRepository, ActorRepository>(); 
builder.Services.AddSwaggerGen();

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

app.Run();
