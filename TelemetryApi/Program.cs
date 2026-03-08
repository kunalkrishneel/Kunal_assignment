using Microsoft.EntityFrameworkCore;
using TelemetryApi.Data;
using TelemetryApi.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VendingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TelemetryApiContext") ?? throw new InvalidOperationException("Connection string 'TelemetryApiContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TelemetryService>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHttpsRedirection();


app.MapControllers();


app.Run();
