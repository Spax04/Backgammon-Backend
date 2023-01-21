using Backgammon_Backend.Hubs;
using Microsoft.OpenApi.Models;
using Backgammon_Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


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
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Backgammon game - ASP.NET React app",Version="v1.0" });
});

builder.Services.AddDbContext<HrContext>(options =>
    options.UseSqlite("Data Source = C:\\Users\\danie\\source\\repos\\Backgammon-Backend\\Backgammon-DataBase\\DataBase.db"));


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var ctx = scope.ServiceProvider.GetRequiredService<HrContext>();
//    ctx.Database.EnsureDeleted();
//    ctx.Database.EnsureCreated();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( swaggerUIOptions =>
    {
        swaggerUIOptions.DocumentTitle = "Backgammon game - ASP.NET React app";
        swaggerUIOptions.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Web API serving Identity information");  // Need to change?
        swaggerUIOptions.RoutePrefix = String.Empty;
    });
}

app.UseCors("CORSPolicy");

//
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/hubs/chat");

app.Run();
