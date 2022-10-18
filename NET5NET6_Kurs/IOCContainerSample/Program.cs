using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bei einer Programm Initialisierung

            //Wir befüllen unseren Container 
            IServiceCollection serviceCollection = new ServiceCollection();

            //Hinzufügen des TimeServices 
            serviceCollection.AddSingleton<ITimeService, TimeService>(); //Singleton bedeutet -> Einmal wird das Object instanziiert und ist immer verfügbar 


            //ASP.NET Core -> Pro Request, wird einmal das Objekt (TimeService) neu instanziiert
            //serviceCollection.AddScoped<ITimeService, TimeService>();


            //ASP.NET Core -> Pro Verwendung 
            //serviceCollection.AddTransient<ITimeService, TimeService>();

            //Initialisierungphase ist mit folgenden Befehl zueende -> Build
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();    



            //Zugriff auf den IOC Container 

            //Wenn IOC Eintrag nicht gefunden wird, liefert GetService NULL zurück
            ITimeService? timeService1 = serviceProvider.GetService<ITimeService>();

            //Wenn IOC Eintrag nicht gefunden wird -> wird eine Exception ausgeben 
            ITimeService timeService2 = serviceProvider.GetRequiredService<ITimeService>();
            
        }
    }

    public interface ITimeService
    {
        string GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        private DateTime dateTime; 
        public TimeService()
        { 
            dateTime = DateTime.Now;
        }
        public string GetCurrentTime()
        {
            return dateTime.ToShortTimeString();
        }
    }
}