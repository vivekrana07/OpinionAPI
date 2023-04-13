using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using OpinionAPI.Interface;
using OpinionAPI.DL;
using OpinionAPI.Model;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OpinionDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUser, Login>();
builder.Services.AddScoped<IMovies, MoviesLayer>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseRouting();
    app.UseCors("CorsPolicy");
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}


app.UseHttpsRedirection();



app.MapControllers();

app.Run();
