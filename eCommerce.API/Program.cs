using eCommerce.API.Middleware;
using eCommerce.core;
using eCommerce.Core.Mapper;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();


builder.Services.AddControllers().AddJsonOptions(options=> {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Program.cs / Startup.cs
builder.Services.AddAutoMapper(cfg => {
    // optional configuration here
}, typeof(ApplicationUserMappingProfile).Assembly
 ,typeof(RegisterRequestMappingProfile).Assembly 
 /* or other assemblies that contain Profiles */
 );
//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
