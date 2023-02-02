using DAM.Proyecto;
using DAM.Proyecto.DAL;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

/// <summary>
/// Punto de inicio del programa
/// Se crea una instancia del generador de host y se configuran los servicios mediante el registro de
/// 
/// Worker: servicio hospedado. El host contiene el proveedor de servicios de inserción de dependencias ( que en este caso esta en worker).
/// DamDbContext: definido como el contexto
/// <summary>
/// <returns></returns>
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        //string connString = "Server=(localdb)\\mssqllocaldb;Database=Test";
        //services.AddDbContext<DamDbContext>(options => options.UseSqlServer(connString));
        string connString = "Data Source=(localdb)\\MSSqllocaldb;Initial Catalog=InMemoryDemo;Integrated Security=True;MultipleActiveResultSets=True;";
        services.AddDbContext<DamDbContext>(options => options.UseInMemoryDatabase(connString));
    })
    .Build();            

await host.RunAsync();   
