using Chat_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


// Connecting DataBase
if (builder.Environment.IsProduction())
{

    builder.Services.AddDbContext<ChatDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection")));
}
else
{
    builder.Services.AddDbContext<ChatDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DevelopmentConnection")));
}

// SingnalR
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000")
        .AllowCredentials();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(swaggerUIOptions =>
//    {
//        swaggerUIOptions.DocumentTitle = "Backgammon game - ASP.NET React app";
//        swaggerUIOptions.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Web API serving Identity information");  // Need to change?
//        swaggerUIOptions.RoutePrefix = String.Empty;
//    });
//}

app.UseCors("CORSPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
