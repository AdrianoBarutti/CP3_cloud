using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Data;

var builder = WebApplication.CreateBuilder(args);

// Conexão com Oracle ou SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// UseSqlServer → se estiver usando SQL Server
// UseOracle → se estiver usando Oracle
builder.Services.AddDbContext<AppDb>(options =>
    options.UseSqlServer(connectionString)); // ou UseOracle se for o caso

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
