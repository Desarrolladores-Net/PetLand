using System.Net;
using IoC;


string MyCors = "MyCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCors, cor =>
    {
        cor.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var connection = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("dev") : builder.Configuration.GetConnectionString("production");
Console.WriteLine("CADENA DE CONEXION --> "+connection);
builder.Services.AddMyServices(connection);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(MyCors);
app.MapFallbackToFile("index.html");
app.Run();
