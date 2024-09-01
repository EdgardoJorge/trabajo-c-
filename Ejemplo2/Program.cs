using ejemploData.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Base de datos

string con = "Data Source=DESKTOP-J34L8LH;Initial Catalog=MiDb6;Integrated Security=True; TrustServerCertificate=False";
builder.Services.AddDbContext<MiDbContext>(
    conf => conf.UseSqlServer(
        con, 
        b => b.MigrationsAssembly("Ejemplo2"))
    ) ;


/*
string con = "Data Source= MiMiniDB.db";
builder.Services.AddDbContext<MiDbContext>(
    conf => conf.UseSqlite(
        con,
        b => b.MigrationsAssembly("Ejemplo2")
        )
    );
*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
