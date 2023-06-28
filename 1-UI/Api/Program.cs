using System.Net;
using IoC;


string MyCors = "MyCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var port = "5000";//Environment.GetEnvironmentVariable("PORT") ?? "3000";

builder.WebHost.UseKestrel().ConfigureKestrel((context, options) =>
{
    options.Listen(IPAddress.Any, Int32.Parse(port), listenOptions =>
    {

    });
});


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
builder.Services.AddMyServices(builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("Dev") : builder.Configuration.GetConnectionString("production"));

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
app.Run();
