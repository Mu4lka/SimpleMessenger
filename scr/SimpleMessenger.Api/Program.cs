using Infrastucture.Persistence;
using SimpleMessenger.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .ConfigureMigrations(builder.Configuration)
    .UpdateDatabase();

builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
builder.Services.AddSignalR();

builder.Services.AddSwaggerGen();
var app = builder.Build();

app.ConfigureHub(builder.Environment);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
