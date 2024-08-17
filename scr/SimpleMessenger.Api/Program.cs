using Infrastucture.Persistence;
using SimpleMessenger.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Configuration;

builder.Services.UpdateDatabase(configuration);

builder.Services.ConfigureServices();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.ConfigureHub(builder.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => {
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://127.0.0.1:5500");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
