using Educonnect.Identity.Service.API.Models.Context;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost
      .ConfigureKestrel(options =>
      {
          options.Listen(IPAddress.Any, 80, listenOptions =>
          {
              listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
          });
          options.Listen(IPAddress.Any, 81, listenOptions =>
          {
              listenOptions.Protocols = HttpProtocols.Http2;
          });

      });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
