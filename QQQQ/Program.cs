using Microsoft.EntityFrameworkCore;
using QQQQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy => // Назва політики "AllowAngularApp"
    {
        policy.WithOrigins("http://localhost:4200") // Дозволяємо Angular клієнт
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddDbContext<RestoranDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("RestoranDbContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowAngularApp");


app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
