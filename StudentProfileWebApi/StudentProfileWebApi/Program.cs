using Microsoft.EntityFrameworkCore;
using StudentProfileWebApi.Models;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:7120/swagger/index.html");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentProfileContext>(x => x.UseInMemoryDatabase("StudentProfiles"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddHttpClient(name: "StudentProfileWebApi",
    configureClient: options =>
    {
        options.BaseAddress = new Uri("https://localhost:7120/swagger/index.html");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json", 1.0));
    });

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
