using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
   dbContext.Database.EnsureCreated();
   return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.Run();

/*
Te voy a poner una prueba. Cuando termines me mandas el repo de git 

Tienes 2 dias para entregarme una Api en .net 6 o superior, donde: se registre una empresa y se registren impresoras, cada empresa tendra una lista de impresoras que hayan rentado. 

Necesito que apliques: 
Librerias como: 
* EntityFramework (Los id deben ser guid y no int)

Patrones de diseño como :
* Inyeccion de dependencias
* MVC
*/

