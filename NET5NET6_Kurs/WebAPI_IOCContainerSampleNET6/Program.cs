using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI_IOCContainerSampleNET6.Data;
using WebAPI_IOCContainerSampleNET6.Services;
using WebApiContrib.Core.Formatter.Csv;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


#region IServiceCollection initialisierung
// Add services to the container.

builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddCsvSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options=>
{
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

builder.Services.AddScoped<ITimeService, TimeService>();

builder.Services.AddDbContext<MovieDbContext>(opt =>
{
    //Einstellungen für AddDbContext
    opt.UseInMemoryDatabase("MovieDB");
}); //AddScoped -> Jede Anfrage bekommt eine neue MovieDbContext-Instanz
#endregion


//WebApplicationBuilder ist auch zu frühere ASP.NET Core Versionen 'Abwärtskompatibel'

//ASP.NET Core 3.1 und NET 5 
//IHostBuilder zum erstellen eines Dienstes
//builder.Host -> IHostBuilder


//ASP.NET Core 2.1 IWebHostBuilder 
//builder.WebHost -> IWebHostBuilder 


WebApplication app = builder.Build(); //Initialisierungphase fertig 

#region Seeden von MockDaten






#region ASP.NET Core 2.1/2.0 -> Zugriff auf IOC-Container
using (IServiceScope serviceScope = app.Services.CreateScope())
{
    ITimeService? timeService1 = serviceScope.ServiceProvider.GetService<ITimeService>();
    MovieDbContext? movieDbContext = serviceScope.ServiceProvider.GetService<MovieDbContext>();

    DataSeeder.Initialize(movieDbContext);
}
#endregion

//#region direktere Variante -> Fehlerfrei? 
//ITimeService? timeService2 = app.Services.GetService<ITimeService>();
//MovieDbContext? movieDbContext2 = app.Services.GetService<MovieDbContext>();
//#endregion



#endregion 

#region Konfiguration von Services
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
#endregion

//WebApplication wird gestartet
app.Run();


//Typdefinitionen erst danach! 